using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        public NewsService(INewsItemRepository newsRepository)
        {
            _newsRepository = newsRepository;
        }

        public IEnumerable<ViewModelBuncisNewsItem> GetAvailableNewsItems(int clientId)
        {
            var raw = _newsRepository.FilterBy(o => !o.IsDeleted).ToList();

            var converted = raw.Select(item =>
            {
                var vBuncisNews = new ViewModelBuncisNewsItem();
                vBuncisNews.InjectFrom(item);
                return vBuncisNews;
            }).ToList();

            return converted;
        }

        public ViewModelBuncisNewsItem GetNewsItem(int newsId)
        {
            var raw = _newsRepository.FindBy(o => !o.IsDeleted && o.NewsId == newsId);

            var vBuncisNews = new ViewModelBuncisNewsItem();
            vBuncisNews.InjectFrom(raw);

            return vBuncisNews;
        }

        public ValidationDictionary<ViewModelBuncisNewsItem> DeleteNewsItem(int newsId)
        {
            var raw = _newsRepository.FindBy(o => o.NewsId == newsId);

            var validator = new ValidationDictionary<ViewModelBuncisNewsItem>();

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

        public ValidationDictionary<ViewModelBuncisNewsItem> SaveNewsItem(int clientId, ViewModelBuncisNewsItem news)
        {
            var validator = new ValidationDictionary<ViewModelBuncisNewsItem>();
            if (news == null)
            {
                validator.IsValid = false;
                validator.AddError("", "The News you're trying to save is null");
                return validator;
            }

            // rule based here
            news.DateExpired = news.DateExpired.DatePart();
            news.DatePublished = news.DatePublished.DatePart();

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
                    newsItem.IsDeleted = false;

                    _newsRepository.Update(newsItem);
                }
            }

			ViewModelBuncisNewsItem pingedNews = GetNewsItem(newsItem.NewsId);
            validator.IsValid = true;
            validator.RelatedObject = pingedNews;
            return validator;
        }

        public IEnumerable<ViewModelBuncisNewsItem> GetPublishedNewsItem(int clientId)
        {
            var raw = _newsRepository.FilterBy(o => !o.IsDeleted && DateTime.UtcNow >= o.DatePublished && DateTime.UtcNow <= o.DateExpired).ToList();

            var converted = raw.Select(item =>
            {
                var vBuncisNews = new ViewModelBuncisNewsItem();
                vBuncisNews.InjectFrom(item);
                return vBuncisNews;
            }).ToList();

            return converted;
        }
    }
}
