﻿using System.Collections.Generic;
using System.Linq;
using Buncis.Framework.Core.Infrastructure.IoC;
using Buncis.Framework.Core.SupportClasses;
using Buncis.Framework.Core.Services.News;
using Buncis.Web.Common.DataTransferObject;
using Buncis.Web.WebServices.Contracts;
using Omu.ValueInjecter;
using Buncis.Framework.Core.ViewModel;
using Buncis.Framework.Core.SupportClasses.Injector;

namespace Buncis.Web.WebServices
{
	// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "News" in code, svc and config file together.
	public class News : BaseWebService, INews
	{
		public Response<IEnumerable<DtoBuncisNews>> BPGetNewsList(int clientId)
		{
			var newsService = IoC.Resolve<INewsService>();
			var raw = newsService.GetAvailableNewsItems(clientId);
			var converted = raw.Select(o =>
			{
				var dto = new DtoBuncisNews();
				dto.InjectFrom<CloneInjection>(o);
				return dto;
			}).ToList();

			var response = new Response<IEnumerable<DtoBuncisNews>>();
			response.IsSuccess = true;
			response.Message = string.Empty;
			response.ResponseObject = converted;
			return response;
		}

		public Response<DtoBuncisNews> BPUpdateNews(int clientId, DtoBuncisNews news)
		{
			var service = IoC.Resolve<INewsService>();
			var viewModel = new ViewModelNewsItem().InjectFrom<CloneInjection>(news) as ViewModelNewsItem;
			var result = service.SaveNewsItem(clientId, viewModel);

			var response = new Response<DtoBuncisNews>();
			response.IsSuccess = result.IsValid;
			response.Message = result.ValidationSummaryToString();
			if (response.IsSuccess)
			{
				var responseObject = new DtoBuncisNews().InjectFrom<CloneInjection>(result.RelatedObject) as DtoBuncisNews;
				response.ResponseObject = responseObject;
			}
			return response;
		}

		public Response<DtoBuncisNews> BPInsertNews(int clientId, DtoBuncisNews news)
		{
			var service = IoC.Resolve<INewsService>();
			var viewModel = new ViewModelNewsItem().InjectFrom<CloneInjection>(news) as ViewModelNewsItem;
			var result = service.SaveNewsItem(clientId, viewModel);

			var response = new Response<DtoBuncisNews>();
			response.IsSuccess = result.IsValid;
			response.Message = result.ValidationSummaryToString();
			if (response.IsSuccess)
			{
				var responseObject = new DtoBuncisNews().InjectFrom<CloneInjection>(result.RelatedObject) as DtoBuncisNews;
				response.ResponseObject = responseObject;
			}
			return response;
		}

		public Response BPDeleteNews(int clientId, int newsId)
		{
			var service = IoC.Resolve<INewsService>();
			var result = service.DeleteNewsItem(clientId, newsId);

			return new Response(result.IsValid, string.Empty);
		}

		public Response<IEnumerable<DtoBuncisNews>> GetPublishedNewsList(int clientId)
		{
			var newsService = IoC.Resolve<INewsService>();
			var raw = newsService.GetPublishedNewsItem(clientId);
			var converted = raw.Select(o =>
			{
				var dto = new DtoBuncisNews();
				dto.InjectFrom<CloneInjection>(o);
				return dto;
			}).ToList();

			var response = new Response<IEnumerable<DtoBuncisNews>>();
			response.IsSuccess = true;
			response.Message = string.Empty;
			response.ResponseObject = converted;
			return response;
		}

		public Response<IEnumerable<DtoBuncisNewsCategory>> BPGetNewsCategories(int clientId)
		{
			var service = IoC.Resolve<INewsService>();
			var data = service.GetNewsCategories(clientId)
				.OrderBy(p => p.NewsCategoryName)
				.ToList();
			var dto = data.Select(o => new DtoBuncisNewsCategory().InjectFrom<CloneInjection>(o) as DtoBuncisNewsCategory).ToList();

			var response = new Response<IEnumerable<DtoBuncisNewsCategory>>();
			response.ResponseObject = dto;
			response.IsSuccess = true;
			response.Message = string.Empty;
			return response;
		}

		public Response<DtoBuncisNewsCategory> BPInsertNewsCategory(int clientId, DtoBuncisNewsCategory newsCategory)
		{
			var service = IoC.Resolve<INewsService>();
			var viewModel = new ViewModelNewsCategory().InjectFrom<CloneInjection>(newsCategory) as ViewModelNewsCategory;
			var result = service.InsertNewsCategory(clientId, viewModel);

			var response = new Response<DtoBuncisNewsCategory>();
			response.IsSuccess = result.IsValid;
			response.Message = result.ValidationSummaryToString();
			if (response.IsSuccess)
			{
				var responseObject = new DtoBuncisNewsCategory().InjectFrom<CloneInjection>(result.RelatedObject) as DtoBuncisNewsCategory;
				response.ResponseObject = responseObject;
			}

			return response;
		}

		public Response<DtoBuncisNewsCategory> BPUpdateNewsCategory(int clientId, DtoBuncisNewsCategory newsCategory)
		{
			var service = IoC.Resolve<INewsService>();
			var viewModel = new ViewModelNewsCategory().InjectFrom<CloneInjection>(newsCategory) as ViewModelNewsCategory;
			var result = service.UpdateNewsCategory(clientId, viewModel);

			var response = new Response<DtoBuncisNewsCategory>();
			response.IsSuccess = result.IsValid;
			response.Message = result.ValidationSummaryToString();
			if (response.IsSuccess)
			{
				var responseObject = new DtoBuncisNewsCategory().InjectFrom<CloneInjection>(result.RelatedObject) as DtoBuncisNewsCategory;
				response.ResponseObject = responseObject;
			}

			return response;
		}

		public string GetNewsUrl(int newsId, string newsTitle)
		{
			var service = IoC.Resolve<INewsService>();
			return service.GetNewsUrl(newsId, newsTitle);
		}
	}
}
