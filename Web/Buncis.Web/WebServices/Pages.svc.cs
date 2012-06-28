using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Text;
using Buncis.Framework.Core.SupportClasses;
using Buncis.Framework.Core.Infrastructure.IoC;
using Omu.ValueInjecter;
using Buncis.Logic.Presenters.Pages;
using uNhAddIns.WCF;
using Buncis.Logic.DataTransferObject;
using Buncis.Framework.Core.Services.Pages;
using Buncis.Framework.Core.ViewModel;

namespace Buncis.Web.WebServices
{
    public class Pages : BaseWebService, IPages
    {
        public Response<IEnumerable<oBuncisPage>> GetPages(int clientId)
        {
            var service = IoC.Resolve<IDynamicPageService>();
            var pages = service.GetPagesNotDeleted(clientId)
                .OrderByDescending(p => p.IsHomePage)
                .ThenByDescending(o => o.DateLastUpdated)
                .ToList();
            var dto = pages.Select(o => (oBuncisPage)new oBuncisPage().InjectFrom(o)).ToList();
            var response = new Response<IEnumerable<oBuncisPage>>();
            response.ResponseObject = dto;
            response.IsSuccess = true;
            response.Message = string.Empty;
            return response;
        }

        public Response<oBuncisPage> GetPage(int clientId, int pageId)
        {
            var service = IoC.Resolve<IDynamicPageService>();
            var page = service.GetPage(pageId);
            var response = new Response<oBuncisPage>();
            response.IsSuccess = true;
            response.Message = string.Empty;
            response.ResponseObject = (oBuncisPage)new oBuncisPage().InjectFrom(page);
            return response;
        }

        public Response UpdatePage(int clientId, oBuncisPage page)
        {
            var service = IoC.Resolve<IDynamicPageService>();
            var viewModel = (vBuncisPage)new vBuncisPage().InjectFrom(page);
            var result = service.SavePage(clientId, viewModel);
            var response = new Response(result.IsValid, string.Empty);
            return response;
        }

        public Response DeletePage(int clientId, int pageId)
        {
            // do use clientId ?
            var service = IoC.Resolve<IDynamicPageService>();
            var result = service.DeletePage(pageId);
            return new Response(result.IsValid, string.Empty);
        }

        public Response InsertPage(int clientId, oBuncisPage page)
        {
            var service = IoC.Resolve<IDynamicPageService>();
            var viewModel = (vBuncisPage)new vBuncisPage().InjectFrom(page);
            var result = service.SavePage(clientId, viewModel);
            var response = new Response(result.IsValid, string.Empty);
            return response;
        }
    }
}
