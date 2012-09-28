using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Buncis.Framework.Core.Infrastructure;
using Buncis.Framework.Core.SupportClasses.Injector;
using Buncis.Services.Url;
using Omu.ValueInjecter;
using Buncis.Framework.Core.SupportClasses;
using Buncis.Framework.Core.Services;
using Buncis.Framework.Core.Services.News;
using Buncis.Framework.Core.ViewModel;
using Buncis.Framework.Core.Repository.News;
using Buncis.Data.Domain.News;
using Buncis.Framework.Core.Infrastructure.Extensions;
using Buncis.Framework.Core.Infrastructure.IoC;

namespace Buncis.Services.News
{
	public class NewsService : BaseService, INewsService
	{
		private readonly INewsItemRepository _newsRepository;
		private readonly INewsCategoryRepository _newsCategoryRepository;
		private readonly IUrlEngine<NewsItem> _urlEngine;

		public NewsService(INewsItemRepository newsRepository,
			INewsCategoryRepository newsCategoryRepository,
			IUrlEngine<NewsItem> urlEngine)
		{
			_newsRepository = newsRepository;
			_newsCategoryRepository = newsCategoryRepository;
			_urlEngine = urlEngine;
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

		public IEnumerable<ViewModelNewsItem> GetAvailableNewsItems(int clientId, int categoryId)
		{
			var raw = _newsRepository
				.FilterBy(o => !o.IsDeleted
					&& o.ClientId == clientId
					&& o.NewsCategory.NewsCategoryId == categoryId)
				.ToList();

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

			// update news url
			UpdateNewsUrl(newsItem.NewsId);

			var pingedNews = GetNewsItem(newsItem.NewsId);
			validator.IsValid = true;
			validator.RelatedObject = pingedNews;
			return validator;
		}

		private void UpdateNewsUrl(int newsId)
		{
			var newsItem = _newsRepository.FindBy(o => o.NewsId == newsId && !o.IsDeleted);
			newsItem.NewsUrl = _urlEngine.GenerateUrl(newsItem.NewsId, newsItem.NewsTitle, newsItem.DatePublished);
			_newsRepository.Update(newsItem);
		}

		public IEnumerable<ViewModelNewsItem> GetPublishedNewsItem(int clientId)
		{
			var raw = _newsRepository.FilterBy(o => !o.IsDeleted
				&& DateTime.UtcNow >= o.DatePublished
				&& DateTime.UtcNow <= o.DateExpired
				&& o.ClientId == clientId).ToList();

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
			return SaveNewsCategory(clientId, viewModelNewsCategory);
		}

		public ValidationDictionary<ViewModelNewsCategory> UpdateNewsCategory(int clientId, ViewModelNewsCategory viewModelNewsCategory)
		{
			return SaveNewsCategory(clientId, viewModelNewsCategory);
		}

		private ValidationDictionary<ViewModelNewsCategory> SaveNewsCategory(int clientId, ViewModelNewsCategory viewModelNewsCategory)
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
				.FilterBy(o => o.NewsCategoryName.ToLower() == viewModelNewsCategory.NewsCategoryName.ToLower()
					&& o.ClientId == clientId
					&& !o.IsDeleted);

			if (existingWithSameName.Any())
			{
				var haveSameId = viewModelNewsCategory.NewsCategoryId <= 0
					|| (viewModelNewsCategory.NewsCategoryId > 0
						&& existingWithSameName.Any(o => o.NewsCategoryId != viewModelNewsCategory.NewsCategoryId));
				if (haveSameId)
				{
					validator.IsValid = false;
					validator.AddError("", "News Category with same name is already existed");
					return validator;
				}
			}

			NewsCategory newsCategory;
			if (viewModelNewsCategory.NewsCategoryId >= 0)
			{
				newsCategory = _newsCategoryRepository.FindBy(o => o.NewsCategoryId == viewModelNewsCategory.NewsCategoryId);
				var dateCreated = newsCategory.DateCreated;
				newsCategory.InjectFrom(viewModelNewsCategory);
				newsCategory.ClientId = clientId;
				newsCategory.DateLastUpdated = DateTime.UtcNow;
				newsCategory.DateCreated = dateCreated;
				_newsCategoryRepository.Update(newsCategory);
			}
			else
			{
				newsCategory = new NewsCategory();
				newsCategory.InjectFrom(viewModelNewsCategory);
				newsCategory.DateCreated = DateTime.UtcNow;
				newsCategory.DateLastUpdated = DateTime.UtcNow;
				newsCategory.ClientId = clientId;
				_newsCategoryRepository.Add(newsCategory);
			}

			var rawPinged = _newsCategoryRepository.FindBy(o => o.NewsCategoryId == newsCategory.NewsCategoryId);
			var pinged = new ViewModelNewsCategory().InjectFrom(rawPinged) as ViewModelNewsCategory;
			validator.IsValid = true;
			validator.RelatedObject = pinged;
			return validator;
		}

		public string GetNewsUrl(int newsId, string newsTitle)
		{
			return _urlEngine.GenerateUrl(newsId, newsTitle, DateTime.UtcNow);
		}

		public IEnumerable<ViewModelNewsItem> GetRecentNews(int clientId)
		{
			var raw = GetPublishedNewsItem(clientId);
			raw = raw.OrderByDescending(o => o.DateCreated).Take(5).ToList();

			var converted = raw.Select(item =>
			{
				var viewModelNewsItem = new ViewModelNewsItem();
				viewModelNewsItem.InjectFrom<CloneInjection>(item);
				return viewModelNewsItem;
			}).ToList();

			return converted;
		}
	}
}
