using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Text;
using Buncis.Framework.Core.SupportClasses;
using Buncis.Logic.ViewModel;
using Buncis.Framework.Services.Pages;
using Buncis.Framework.Core.Infrastructure.IoC;
using Omu.ValueInjecter;
using Buncis.Logic.Presenters.Pages;
using Buncis.Logic.BusinessObject;
using uNhAddIns.WCF;

namespace Buncis.Web.WebServices
{
    public class Pages : BaseWebService, IPages
    {
        public Response<List<BuncisPageViewModel>> GetPages(int clientId)
        {
            try
            {
                var bo = IoC.Resolve<BuncisPages>();
                bo.ClientId = clientId;
                var boResponse = bo.GetList();
                bo.List = bo.List.OrderByDescending(p => p.IsHomePage).ThenBy(o => o.DateLastUpdated).ToList();

                var response = new Response<List<BuncisPageViewModel>>();
                response.IsSuccess = boResponse.IsSuccess;
                response.Message = boResponse.Message;
                response.ResponseObject = bo.List;

                return response;
            }
            catch
            {
                CurrentResponse.StatusCode = 500;
                return null;
            }
        }
    }
}
