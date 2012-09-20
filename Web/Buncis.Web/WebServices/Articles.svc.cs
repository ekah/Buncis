using System.Collections.Generic;
using System.Linq;
using Buncis.Framework.Core.Services.Articles;
using Buncis.Framework.Core.SupportClasses;
using Buncis.Framework.Core.Infrastructure.IoC;
using Buncis.Web.Common.DataTransferObject;
using Buncis.Web.WebServices.Contracts;
using Omu.ValueInjecter;
using Buncis.Framework.Core.ViewModel;
using Buncis.Framework.Core.SupportClasses.Injector;

namespace Buncis.Web.WebServices
{
	public class Articles : BaseWebService, IArticles
	{
		public Response<IEnumerable<DtoBuncisArticle>> BPGetArticles(int clientId)
		{
			var service = IoC.Resolve<IArticleService>();
			var data = service.GetAvailableArticleItems(clientId)
				.OrderBy(p => p.ArticleTitle)
				.ToList();
			var dto = data.Select(o => new DtoBuncisArticle().InjectFrom<CloneInjection>(o) as DtoBuncisArticle).ToList();

			var response = new Response<IEnumerable<DtoBuncisArticle>>();
			response.ResponseObject = dto;
			response.IsSuccess = true;
			response.Message = string.Empty;
			return response;
		}

		public Response<DtoBuncisArticle> BPGetArticle(int clientId, int articleId)
		{
			var service = IoC.Resolve<IArticleService>();
			var data = service.GetArticleItem(articleId);

			var response = new Response<DtoBuncisArticle>();
			response.IsSuccess = true;
			response.Message = string.Empty;
			response.ResponseObject = new DtoBuncisArticle().InjectFrom<CloneInjection>(data) as DtoBuncisArticle;
			return response;
		}

		public Response<DtoBuncisArticle> BPUpdateArticle(int clientId, DtoBuncisArticle article)
		{
			var service = IoC.Resolve<IArticleService>();
			var viewModel = new ViewModelArticleItem().InjectFrom<CloneInjection>(article) as ViewModelArticleItem;
			var result = service.SaveArticleItem(clientId, viewModel);

			var response = new Response<DtoBuncisArticle>();
			response.IsSuccess = result.IsValid;
			response.Message = result.ValidationSummaryToString();

			var responseObject = new DtoBuncisArticle().InjectFrom<CloneInjection>(result.RelatedObject) as DtoBuncisArticle;
			response.ResponseObject = responseObject;
			return response;
		}

		public Response<DtoBuncisArticle> BPInsertArticle(int clientId, DtoBuncisArticle article)
		{
			var service = IoC.Resolve<IArticleService>();
			var viewModel = new ViewModelArticleItem().InjectFrom<CloneInjection>(article) as ViewModelArticleItem;
			var result = service.SaveArticleItem(clientId, viewModel);

			var response = new Response<DtoBuncisArticle>();
			response.IsSuccess = result.IsValid;
			response.Message = result.ValidationSummaryToString();

			var responseObject = new DtoBuncisArticle().InjectFrom<CloneInjection>(result.RelatedObject) as DtoBuncisArticle;
			response.ResponseObject = responseObject;

			return response;
		}

		public Response BPDeleteArticle(int clientId, int articleId)
		{
			// do use clientId ?
			var service = IoC.Resolve<IArticleService>();
			var result = service.DeleteArticleItem(articleId);
			return new Response(result.IsValid, string.Empty);
		}

		public Response<IEnumerable<DtoBuncisArticleCategory>> BPGetArticleCategories(int clientId)
		{
			var service = IoC.Resolve<IArticleService>();
			var data = service.GetArticleCategories(clientId)
				.OrderBy(p => p.ArticleCategoryName)
				.ToList();
			var dto = data.Select(o => new DtoBuncisArticleCategory().InjectFrom<CloneInjection>(o) as DtoBuncisArticleCategory).ToList();

			var response = new Response<IEnumerable<DtoBuncisArticleCategory>>();
			response.ResponseObject = dto;
			response.IsSuccess = true;
			response.Message = string.Empty;
			return response;
		}

		public Response<DtoBuncisArticleCategory> BPInsertArticleCategory(int clientId, DtoBuncisArticleCategory articleCategory)
		{
			var service = IoC.Resolve<IArticleService>();
			var viewModel = new ViewModelArticleCategory().InjectFrom<CloneInjection>(articleCategory) as ViewModelArticleCategory;
			var result = service.InsertArticleCategory(clientId, viewModel);

			var response = new Response<DtoBuncisArticleCategory>();
			response.IsSuccess = result.IsValid;
			response.Message = result.ValidationSummaryToString();

			var responseObject = new DtoBuncisArticleCategory().InjectFrom<CloneInjection>(result.RelatedObject) as DtoBuncisArticleCategory;
			response.ResponseObject = responseObject;

			return response;
		}
	}
}

