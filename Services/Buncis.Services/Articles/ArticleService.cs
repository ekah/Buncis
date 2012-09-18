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

		public ArticleService(IArticleItemRepository articleItemRepository)
		{
			_articleItemRepository = articleItemRepository;
		}

		public IEnumerable<ViewModelBuncisArticleItem> GetAvailableArticleItems(int clientId)
		{
			var raw = _articleItemRepository.FilterBy(o => !o.IsDeleted && o.ClientId == clientId).ToList();

			var converted = raw.Select(item =>
			{
				var ViewModelArticleItem = new ViewModelBuncisArticleItem();
				ViewModelArticleItem.InjectFrom(item);
				return ViewModelArticleItem;
			}).ToList();

			return converted;
		}

		public ViewModelBuncisArticleItem GetArticleItem(int articleId)
		{
			var raw = _articleItemRepository.FindBy(o => !o.IsDeleted && o.ArticleId == articleId);

			var ViewModelArticleItem = new ViewModelBuncisArticleItem();
			ViewModelArticleItem.InjectFrom(raw);

			return ViewModelArticleItem;
		}

		public ValidationDictionary<ViewModelBuncisArticleItem> DeleteArticleItem(int articleId)
		{
			var raw = _articleItemRepository.FindBy(o => o.ArticleId == articleId);

			var validator = new ValidationDictionary<ViewModelBuncisArticleItem>();

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

		public ValidationDictionary<ViewModelBuncisArticleItem> SaveArticleItem(int clientId, ViewModelBuncisArticleItem article)
		{
			var validator = new ValidationDictionary<ViewModelBuncisArticleItem>();
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
	}
}
