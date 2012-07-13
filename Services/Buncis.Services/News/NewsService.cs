using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Buncis.Services.Validator.News;
using Omu.ValueInjecter;
using Buncis.Framework.Core.Services;
using Buncis.Framework.Core.Services.News;
using Buncis.Framework.Core.ViewModel;
using Buncis.Framework.Core.Repository.News;
using Buncis.Data.Domain.News;

namespace Buncis.Services.News
{
	public class NewsService : BaseService, INewsService
	{
		private readonly INewsRepository _newsRepository;

		public NewsService(INewsRepository newsRepository)
		{
			_newsRepository = newsRepository;
		}

		public IEnumerable<vBuncisNews> GetNewsNotDeleted(int clientId)
		{
			var raw = _newsRepository.FilterBy(o => !o.IsDeleted).ToList();
			var converted = raw.Select(item =>
			{
				var vBuncisNews = new vBuncisNews();
				vBuncisNews.InjectFrom(item);
				return vBuncisNews;
			}).ToList();

			return converted;
		}

		public vBuncisNews GetNews(int newsId)
		{
			var raw = _newsRepository.FindBy(o => !o.IsDeleted && o.NewsId == newsId);
			var vBuncisNews = new vBuncisNews();
			vBuncisNews.InjectFrom(raw);
			return vBuncisNews;
		}

		public ValidationDictionary<vBuncisNews> DeleteNews(int newsId)
		{
			vBuncisNews vBuncisNews = null;
			var raw = _newsRepository.FindBy(o => o.NewsId == newsId);

			if (raw != null)
			{
				vBuncisNews = new vBuncisNews();
				vBuncisNews.InjectFrom(raw);
			}

			var validator = new OnDeleteNewsValidator(vBuncisNews);
			validator.Validate();
			if (!validator.IsValid)
			{
				return validator;
			}

			if (raw != null)
			{
				raw.IsDeleted = true;
				_newsRepository.Update(raw);
			}

			return validator;
		}

		public ValidationDictionary<vBuncisNews> SaveNews(int clientId, vBuncisNews news)
		{
			var validator = new OnSaveNewsValidator(news);
			validator.Validate();
			if (!validator.IsValid)
			{
				return validator;
			}

			NewsItem newsItem;
			if (news.NewsId <= 0)
			{
				newsItem = new NewsItem();
				newsItem.InjectFrom(news);
				newsItem.DateCreated = DateTime.UtcNow;
				newsItem.DateLastUpdated = DateTime.UtcNow;
				newsItem.ClientId = clientId;
				_newsRepository.Add(newsItem);
			}
			else
			{
				newsItem = _newsRepository.FindBy(o => !o.IsDeleted && o.NewsId == news.NewsId);
				if (newsItem != null)
				{
					var createdDate = newsItem.DateCreated;
					newsItem.InjectFrom(news);
					newsItem.DateLastUpdated = DateTime.UtcNow;
					newsItem.DateCreated = createdDate;
					_newsRepository.Update(newsItem);
				}
			}

			// refetch
			var raw = _newsRepository.FindBy(o => !o.IsDeleted && o.NewsId == news.NewsId);
			validator.ValidatedObject.InjectFrom(raw);
			return validator;
		}

		public IEnumerable<vBuncisNews> GetPublishedNews(int clientId)
		{
			var raw = _newsRepository.FilterBy(o => !o.IsDeleted && DateTime.UtcNow >= o.DatePublished && DateTime.UtcNow <= o.DateExpired).ToList();
			var converted = raw.Select(item =>
			{
				var vBuncisNews = new vBuncisNews();
				vBuncisNews.InjectFrom(item);
				return vBuncisNews;
			}).ToList();

			return converted;
		}
	}
}
