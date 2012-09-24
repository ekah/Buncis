using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Buncis.Framework.Core.SupportClasses.Injector;
using Omu.ValueInjecter;
using Buncis.Framework.Core.SupportClasses;
using Buncis.Framework.Core.Services;
using Buncis.Framework.Core.Services.News;
using Buncis.Framework.Core.ViewModel;
using Buncis.Framework.Core.Repository.News;
using Buncis.Data.Domain.News;
using Buncis.Framework.Core.Infrastructure.Extensions;

namespace Buncis.Services.News
{
	public class NewsService : BaseService, INewsService
	{
		private readonly INewsItemRepository _newsRepository;
		private readonly INewsCategoryRepository _newsCategoryRepository;

		public NewsService(INewsItemRepository newsRepository, INewsCategoryRepository newsCategoryRepository)
		{
			_newsRepository = newsRepository;
			_newsCategoryRepository = newsCategoryRepository;
		}

		public IEnumerable<ViewModelNewsItem> GetAvailableNewsItems(int clientId)
		{
			var raw = _newsRepository.FilterBy(o => !o.IsDeleted && o.ClientId == clientId).ToList();

			var converted = raw.Select(item =>
			{
				var viewModelNewsItem = new ViewModelNewsItem();
				viewModelNewsItem.InjectFrom<CloneInjection>(item);
				return viewModelNewsItem;
			}).ToList();

			return converted;
		}

		public ViewModelNewsItem GetNewsItem(int newsId)
		{
			var raw = _newsRepository.FindBy(o => !o.IsDeleted && o.NewsId == newsId);

			var viewModelNewsItem = new ViewModelNewsItem();
			viewModelNewsItem.InjectFrom<CloneInjection>(raw);

			return viewModelNewsItem;
		}

		public ValidationDictionary<ViewModelNewsItem> DeleteNewsItem(int newsId)
		{
			var raw = _newsRepository.FindBy(o => o.NewsId == newsId);

			var validator = new ValidationDictionary<ViewModelNewsItem>();

			if (raw != null)
			{
				raw.IsDeleted = true;

				_newsRepository.Update(raw);

				validator.IsValid = true;
			}
			else
			{
				validator.IsValid = false;
				validator.AddError("", "The News is not available in the database");
			}

			return validator;
		}

		public ValidationDictionary<ViewModelNewsItem> SaveNewsItem(int clientId, ViewModelNewsItem viewModelNews)
		{
			var validator = new ValidationDictionary<ViewModelNewsItem>();
			if (viewModelNews == null)
			{
				validator.IsValid = false;
				validator.AddError("", "The News you're trying to save is null");
				return validator;
			}

			// rule based here
			viewModelNews.DateExpired = viewModelNews.DateExpired.DatePart();
			viewModelNews.DatePublished = viewModelNews.DatePublished.DatePart();

			NewsItem newsItem;
			if (viewModelNews.NewsId <= 0)
			{
				newsItem = new NewsItem();
				newsItem.InjectFrom<CloneInjection>(viewModelNews);
				newsItem.DateCreated = DateTime.UtcNow;
				newsItem.DateLastUpdated = DateTime.UtcNow;
				newsItem.ClientId = clientId;

				_newsRepository.Add(newsItem);
			}
			else
			{
				newsItem = _newsRepository.FindBy(o => !o.IsDeleted && o.NewsId == viewModelNews.NewsId);
				if (newsItem != null)
				{
					var createdDate = newsItem.DateCreated;
					newsItem.InjectFrom<CloneInjection>(viewModelNews);
					newsItem.DateLastUpdated = DateTime.UtcNow;
					newsItem.DateCreated = createdDate;
					newsItem.IsDeleted = false;

					_newsRepository.Update(newsItem);
				}
			}

			ViewModelNewsItem pingedNews = GetNewsItem(newsItem.NewsId);
			validator.IsValid = true;
			validator.RelatedObject = pingedNews;
			return validator;
		}

		public IEnumerable<ViewModelNewsItem> GetPublishedNewsItem(int clientId)
		{
			var raw = _newsRepository.FilterBy(o => !o.IsDeleted && DateTime.UtcNow >= o.DatePublished && DateTime.UtcNow <= o.DateExpired).ToList();

			var converted = raw.Select(item =>
			{
				var viewModelNewsItem = new ViewModelNewsItem();
				viewModelNewsItem.InjectFrom<CloneInjection>(item);
				return viewModelNewsItem;
			}).ToList();

			return converted;
		}


		public IEnumerable<ViewModelNewsCategory> GetNewsCategories(int clientId)
		{
			var raw = _newsCategoryRepository.FilterBy(o => !o.IsDeleted && o.ClientId == clientId).ToList();

			var converted = raw.Select(item =>
			{
				var viewModelNewsCategory = new ViewModelNewsCategory();
				viewModelNewsCategory.InjectFrom(item);
				return viewModelNewsCategory;
			}).ToList();

			return converted;
		}

		public ValidationDictionary<ViewModelNewsCategory> InsertNewsCategory(int clientId, ViewModelNewsCategory viewModelNewsCategory)
		{
			var validator = new ValidationDictionary<ViewModelNewsCategory>();
			if (viewModelNewsCategory == null)
			{
				validator.IsValid = false;
				validator.AddError("", "The XX you're trying to save is null");
				return validator;
			}

			// rule based here
			var existingWithSameName = _newsCategoryRepository
				.FilterBy(o => o.NewsCategoryName.ToLower() == viewModelNewsCategory.NewsCategoryName.ToLower() && o.ClientId == clientId);
			if (existingWithSameName.Any())
			{
				validator.IsValid = false;
				validator.AddError("", "News Category with same name is already existed");
				return validator;
			}

			var newsCategory = new NewsCategory();
			newsCategory.InjectFrom(viewModelNewsCategory);
			newsCategory.DateCreated = DateTime.UtcNow;
			newsCategory.DateLastUpdated = DateTime.UtcNow;
			newsCategory.ClientId = clientId;

			_newsCategoryRepository.Add(newsCategory);

			var rawPinged = _newsCategoryRepository.FindBy(o => o.NewsCategoryId == newsCategory.NewsCategoryId);
			var pinged = new ViewModelNewsCategory().InjectFrom(rawPinged) as ViewModelNewsCategory;
			validator.IsValid = true;
			validator.RelatedObject = pinged;
			return validator;
		}
	}
}
