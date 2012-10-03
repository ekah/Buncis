using System;
using System.Collections.Generic;
using System.Linq;
using Buncis.Data.Domain.Articles;
using Buncis.Framework.Core.Infrastructure;
using Buncis.Framework.Core.Repository.Articles;
using Buncis.Framework.Core.Services.Articles;
using Buncis.Framework.Core.SupportClasses.Injector;
using Omu.ValueInjecter;
using Buncis.Framework.Core.SupportClasses;
using Buncis.Framework.Core.Services;
using Buncis.Framework.Core.ViewModel;

namespace Buncis.Services.Articles
{
	public class ArticleService : BaseService, IArticleService
	{
		private readonly IArticleItemRepository _articleItemRepository;
		private readonly IArticleCategoryRepository _articleCategoryRepository;
		private readonly IUrlEngine<ArticleItem> _urlEngine;

		public ArticleService(IArticleItemRepository articleItemRepository,
			IArticleCategoryRepository articleCategoryRepository,
			IUrlEngine<ArticleItem> urlEngine)
		{
			_articleItemRepository = articleItemRepository;
			_articleCategoryRepository = articleCategoryRepository;
			_urlEngine = urlEngine;
		}

		public IEnumerable<ViewModelArticleItem> GetAvailableArticleItems(int clientId)
		{
			var raw = _articleItemRepository.FilterBy(o => !o.IsDeleted && o.ClientId == clientId).ToList();

			var converted = raw.Select(item =>
			{
				var viewModelArticleItem = new ViewModelArticleItem();
				viewModelArticleItem.InjectFrom<CloneInjection>(item);
				return viewModelArticleItem;
			}).ToList();

			return converted;
		}

		public IEnumerable<ViewModelArticleItem> GetAvailableArticleItems(int clientId, int categoryId)
		{
			var raw = _articleItemRepository
				.FilterBy(o => !o.IsDeleted
					&& o.ClientId == clientId
					&& o.ArticleCategory.ArticleCategoryId == categoryId)
				.ToList();

			var converted = raw.Select(item =>
			{
				var viewModelArticleItem = new ViewModelArticleItem();
				viewModelArticleItem.InjectFrom<CloneInjection>(item);
				return viewModelArticleItem;
			}).ToList();

			return converted;
		}

		public ViewModelArticleItem GetArticleItem(int clientId, int articleId)
		{
			var raw = _articleItemRepository.FindBy(o => !o.IsDeleted && o.ArticleId == articleId && o.ClientId == clientId);

			var viewModelArticleItem = new ViewModelArticleItem();
			viewModelArticleItem.InjectFrom<CloneInjection>(raw);

			return viewModelArticleItem;
		}

		public ValidationDictionary<ViewModelArticleItem> DeleteArticleItem(int clientId, int articleId)
		{
			var raw = _articleItemRepository.FindBy(o => o.ArticleId == articleId && o.ClientId == clientId);

			var validator = new ValidationDictionary<ViewModelArticleItem>();

			if (raw != null)
			{
				raw.IsDeleted = true;

				_articleItemRepository.Update(raw);

				validator.IsValid = true;
			}
			else
			{
				validator.IsValid = false;
				validator.AddError("", "The XX is not available in the database");
			}

			return validator;
		}

		public ValidationDictionary<ViewModelArticleItem> SaveArticleItem(int clientId, ViewModelArticleItem viewModelArticle)
		{
			var validator = new ValidationDictionary<ViewModelArticleItem>();
			if (viewModelArticle == null)
			{
				validator.IsValid = false;
				validator.AddError("", "The XX you're trying to save is null");
				return validator;
			}

			// rule based here


			ArticleItem articleItem;

			if (viewModelArticle.ArticleId <= 0)
			{
				articleItem = new ArticleItem();
				articleItem.InjectFrom<CloneInjection>(viewModelArticle);
				articleItem.DateCreated = DateTime.UtcNow;
				articleItem.DateLastUpdated = DateTime.UtcNow;
				articleItem.ClientId = clientId;

				_articleItemRepository.Add(articleItem);
			}
			else
			{
				articleItem = _articleItemRepository.FindBy(o => !o.IsDeleted && o.ArticleId == viewModelArticle.ArticleId && o.ClientId == clientId);
				if (articleItem != null)
				{
					var createdDate = articleItem.DateCreated;
					articleItem.InjectFrom<CloneInjection>(viewModelArticle);
					articleItem.DateLastUpdated = DateTime.UtcNow;
					articleItem.DateCreated = createdDate;
					articleItem.IsDeleted = false;

					_articleItemRepository.Update(articleItem);
				}
			}

			UpdateArticleUrl(articleItem.ArticleId);

			var pinged = GetArticleItem(clientId, articleItem.ArticleId);
			validator.IsValid = true;
			validator.RelatedObject = pinged;
			return validator;
		}

		private void UpdateArticleUrl(int articleId)
		{
			var articleItem = _articleItemRepository.FindBy(o => o.ArticleId == articleId && !o.IsDeleted);
			articleItem.ArticleUrl = _urlEngine.GenerateUrl(articleItem.ArticleId,
				articleItem.ArticleTitle,
				articleItem.DateCreated);
			_articleItemRepository.Update(articleItem);
		}

		public IEnumerable<ViewModelArticleCategory> GetArticleCategories(int clientId)
		{
			var raw = _articleCategoryRepository.FilterBy(o => !o.IsDeleted && o.ClientId == clientId).ToList();

			var converted = raw.Select(item =>
			{
				var viewModelArticleCategory = new ViewModelArticleCategory();
				viewModelArticleCategory.InjectFrom(item);
				return viewModelArticleCategory;
			}).ToList();

			return converted;
		}

		public ValidationDictionary<ViewModelArticleCategory> InsertArticleCategory(int clientId,
			ViewModelArticleCategory viewModelArticleCategory)
		{
			return SaveArticleCategory(clientId, viewModelArticleCategory);
		}

		public ValidationDictionary<ViewModelArticleCategory> UpdateArticleCategory(int clientId,
			ViewModelArticleCategory viewModelArticleCategory)
		{
			return SaveArticleCategory(clientId, viewModelArticleCategory);
		}

		private ValidationDictionary<ViewModelArticleCategory> SaveArticleCategory(int clientId,
			ViewModelArticleCategory viewModelArticleCategory)
		{
			var validator = new ValidationDictionary<ViewModelArticleCategory>();
			if (viewModelArticleCategory == null)
			{
				validator.IsValid = false;
				validator.AddError("", "The XX you're trying to save is null");
				return validator;
			}

			// rule based here
			var existingWithSameName = _articleCategoryRepository
				.FilterBy(o => o.ArticleCategoryName.ToLower() == viewModelArticleCategory.ArticleCategoryName.ToLower()
					&& o.ClientId == clientId
					&& !o.IsDeleted)
				.ToList();

			if (existingWithSameName.Any())
			{
				var haveSameId = viewModelArticleCategory.ArticleCategoryId <= 0
					|| (viewModelArticleCategory.ArticleCategoryId > 0
						&& existingWithSameName.Any(o => o.ArticleCategoryId != viewModelArticleCategory.ArticleCategoryId));
				if (haveSameId)
				{
					validator.IsValid = false;
					validator.AddError("", "Article Category with same name is already existed");
					return validator;
				}
			}

			ArticleCategory articleCategory;
			if (viewModelArticleCategory.ArticleCategoryId > 0)
			{
				articleCategory = _articleCategoryRepository
					.FindBy(o => o.ArticleCategoryId == viewModelArticleCategory.ArticleCategoryId && o.ClientId == clientId);
				var dateCreated = articleCategory.DateCreated;
				articleCategory.InjectFrom(viewModelArticleCategory);
				articleCategory.ClientId = clientId;
				articleCategory.DateLastUpdated = DateTime.UtcNow;
				articleCategory.DateCreated = dateCreated;
				_articleCategoryRepository.Update(articleCategory);
			}
			else
			{
				articleCategory = new ArticleCategory();
				articleCategory.InjectFrom(viewModelArticleCategory);
				articleCategory.ClientId = clientId;
				articleCategory.DateCreated = DateTime.UtcNow;
				articleCategory.DateLastUpdated = DateTime.UtcNow;
				_articleCategoryRepository.Add(articleCategory);
			}

			var rawPinged = _articleCategoryRepository
				.FindBy(o => o.ArticleCategoryId == articleCategory.ArticleCategoryId && o.ClientId == clientId);
			var pinged = new ViewModelArticleCategory().InjectFrom(rawPinged) as ViewModelArticleCategory;
			validator.IsValid = true;
			validator.RelatedObject = pinged;
			return validator;
		}

		public string GetArticleUrl(int articleId, string articleTitle)
		{
			return _urlEngine.GenerateUrl(articleId, articleTitle, DateTime.UtcNow);
		}

		public IEnumerable<ViewModelArticleItem> GetRecentArticles(int clientId)
		{
			var raw = GetAvailableArticleItems(clientId);
			raw = raw.OrderByDescending(o => o.DateCreated).Take(5).ToList();

			var converted = raw.Select(item =>
			{
				var viewModelArticleItem = new ViewModelArticleItem();
				viewModelArticleItem.InjectFrom<CloneInjection>(item);
				return viewModelArticleItem;
			}).ToList();

			return converted;
		}

		public ValidationDictionary<ViewModelArticleCategory> DeleteArticleCategory(int clientId, int articleCategoryId)
		{
			var validator = new ValidationDictionary<ViewModelArticleCategory>();
			var raw = _articleCategoryRepository.FindBy(o => o.ArticleCategoryId == articleCategoryId && o.ClientId == clientId);
			if (raw != null)
			{
				raw.IsDeleted = true;
				_articleCategoryRepository.Update(raw);

				var articles = _articleItemRepository.FilterBy(a => a.ArticleCategory.ArticleCategoryId == articleCategoryId).ToList();
				foreach (var item in articles)
				{
					//item.IsDeleted = true;
					item.ArticleCategory = null;
					_articleItemRepository.Update(item);
				}

				validator.IsValid = true;
			}
			else
			{
				validator.IsValid = false;
				validator.AddError("", "The XX is not available in the database");
			}
			return validator;
		}
	}
}
