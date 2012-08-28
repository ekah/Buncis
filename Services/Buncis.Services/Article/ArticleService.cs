using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Omu.ValueInjecter;
using Buncis.Framework.Core.SupportClasses;
using Buncis.Framework.Core.Services;
using Buncis.Framework.Core.Services.Article;
using Buncis.Framework.Core.ViewModel;
using Buncis.Framework.Core.Repository.Article;
using Buncis.Data.Domain.Article;
using Buncis.Framework.Core.Infrastructure.Extensions;

namespace Buncis.Services.Article
{
    public class ArticleService : BaseService, IArticleService
    {
        private readonly IArticleItemRepository _articleItemRepository;

        public ArticleService(IArticleItemRepository articleItemRepository)
        {
            _articleItemRepository = articleItemRepository;
        }

        public IEnumerable<ViewModelArticleItem> GetArticleItemsNotDeleted(int clientId)
        {
            var raw = _articleItemRepository.FilterBy(o => !o.IsDeleted).ToList();

            var converted = raw.Select(item =>
            {
                var ViewModelArticleItem = new ViewModelArticleItem();
                ViewModelArticleItem.InjectFrom(item);
                return ViewModelArticleItem;
            }).ToList();

            return converted;
        }

        public ViewModelArticleItem GetArticleItem(int articleId)
        {
            var raw = _articleItemRepository.FindBy(o => !o.IsDeleted && o.ArticleId == articleId);

            var ViewModelArticleItem = new ViewModelArticleItem();
            ViewModelArticleItem.InjectFrom(raw);

            return ViewModelArticleItem;
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
    }
}
