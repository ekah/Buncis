using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Buncis.Framework.Core.Infrastructure.IoC;
using Buncis.Framework.Core.SupportClasses;
using Buncis.Logic.DataTransferObject;
using Buncis.Framework.Core.Services.News;
using Omu.ValueInjecter;

namespace Buncis.Web.WebServices
{
	// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "News" in code, svc and config file together.
	public class News : BaseWebService, INews
	{
		public Response<IEnumerable<oBuncisNews>> bPanelGetNewsList(int clientId)
		{
			var newsService = IoC.Resolve<INewsService>();
			var raw = newsService.GetNewsNotDeleted(clientId);
			var converted = raw.Select(o =>
			{
				var dto = new oBuncisNews();
				dto.InjectFrom(o);
				return dto;
			}).ToList();

			var response = new Response<IEnumerable<oBuncisNews>>();
			response.IsSuccess = true;
			response.Message = string.Empty;
			response.ResponseObject = converted;
			return response;
		}

		public Response<oBuncisNews> bPanelGetNews(int clientId, int newsId)
		{
			var newsService = IoC.Resolve<INewsService>();
			var raw = newsService.GetNews(newsId);
			var response = new Response<oBuncisNews>();
			response.IsSuccess = true;
			response.Message = string.Empty;
			response.ResponseObject = (oBuncisNews)new oBuncisNews().InjectFrom(raw);
			return response;
		}

		public Response<IEnumerable<oBuncisNews>> GetPublishedNewsList(int clientId)
		{
			var newsService = IoC.Resolve<INewsService>();
			var raw = newsService.GetPublishedNews(clientId);
			var converted = raw.Select(o =>
			{
				var dto = new oBuncisNews();
				dto.InjectFrom(o);
				return dto;
			}).ToList();

			var response = new Response<IEnumerable<oBuncisNews>>();
			response.IsSuccess = true;
			response.Message = string.Empty;
			response.ResponseObject = converted;
			return response;
		}
	}
}
