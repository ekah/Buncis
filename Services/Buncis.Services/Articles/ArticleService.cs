using System;
using System.Collections.Generic;
using System.Linq;
using Buncis.Data.Domain.Articles;
using Buncis.Framework.Core.Repository.Articles;
using Buncis.Framework.Core.Services.Articles;
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

		public ArticleService(IArticleItemRepository articleItemRepository,
			IArticleCategoryRepository articleCategoryRepository)
		{
			_articleItemRepository = articleItemRepository;
			_articleCategoryRepository = articleCategoryRepository;
		}

		public IEnumerable<ViewModelArticleItem> GetAvailableArticleItems(int clientId)
		{
			var raw = _articleItemRepository.FilterBy(o => !o.IsDeleted && o.ClientId == clientId).ToList();

			var converted = raw.Select(item =>
			{
				var viewModelArticleItem = new ViewModelArticleItem();
				viewModelArticleItem.InjectFrom(item);
				return viewModelArticleItem;
			}).ToList();

			return converted;
		}

		public ViewModelArticleItem GetArticleItem(int articleId)
		{
			var raw = _articleItemRepository.FindBy(o => !o.IsDeleted && o.ArticleId == articleId);

			var viewModelArticleItem = new ViewModelArticleItem();
			viewModelArticleItem.InjectFrom(raw);

			return viewModelArticleItem;
		}

		public ValidationDictionary<ViewModelArticleItem> DeleteArticleItem(int articleId)
		{
			var raw = _articleItemRepository.FindBy(o => o.ArticleId == articleId);

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

		public ValidationDictionary<ViewModelArticleItem> SaveArticleItem(int clientId, ViewModelArticleItem article)
		{
			var validator = new ValidationDictionary<ViewModelArticleItem>();
			if (article == null)
			{
				validator.IsValid = false;
				validator.AddError("", "The XX you're trying to save is null");
				return validator;
			}

			// rule based here


			ArticleItem articleItem;

			if (article.ArticleId <= 0)
			{
				articleItem = new ArticleItem();
				articleItem.InjectFrom(article);
				articleItem.DateCreated = DateTime.UtcNow;
				articleItem.DateLastUpdated = DateTime.UtcNow;
				articleItem.ClientId = clientId;

				_articleItemRepository.Add(articleItem);
			}
			else
			{
				articleItem = _articleItemRepository.FindBy(o => !o.IsDeleted && o.ArticleId == article.ArticleId);
				if (articleItem != null)
				{
					var createdDate = articleItem.DateCreated;
					articleItem.InjectFrom(article);
					articleItem.DateLastUpdated = DateTime.UtcNow;
					articleItem.DateCreated = createdDate;
					articleItem.IsDeleted = false;

					_articleItemRepository.Update(articleItem);
				}
			}

			var pinged = GetArticleItem(articleItem.ArticleId);
			validator.IsValid = true;
			validator.RelatedObject = pinged;
			return validator;
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
	}
}
