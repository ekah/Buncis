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
            var bo = IoC.Resolve<BuncisPages>("clientId", clientId);
            var boResponse = bo.GetList();
            bo.List = bo.List.OrderByDescending(p => p.IsHomePage).ThenBy(o => o.DateLastUpdated).ToList();

            var response = new Response<List<BuncisPageViewModel>>();
            response.ResponseObject = bo.List;
            response.IsSuccess = boResponse.IsSuccess;
            response.Message = boResponse.Message;

            return response;
        }

        public Response<BuncisPageViewModel> GetPage(int clientId, int pageId)
        {
            var bo = IoC.Resolve<BuncisPages>("clientId", clientId);
            bo.Key = pageId;

            var boResponse = bo.GetEditableByKey();
            var response = new Response<BuncisPageViewModel>();
            response.IsSuccess = boResponse.IsSuccess;
            response.Message = boResponse.Message;
            response.ResponseObject = bo.Editable;

            return response;
        }

        public Response UpdatePage(int clientId, BuncisPageViewModel viewModel)
        {
            var bo = IoC.Resolve<BuncisPages>("clientId", clientId);
            bo.Editable = viewModel;
            var boResponse = bo.Update();
            return new Response(boResponse.IsSuccess, boResponse.Message);
        }

        public Response DeletePage(int clientId, int pageId)
        {
            var bo = IoC.Resolve<BuncisPages>("clientId", clientId);
            bo.KeyToDelete = pageId;
            var boResponse = bo.Delete();
            return new Response(boResponse.IsSuccess, boResponse.Message);
        }

        public Response InsertPage(int clientId, BuncisPageViewModel viewModel)
        {
            var bo = IoC.Resolve<BuncisPages>("clientId", clientId);
            bo.ToInsert = viewModel;
            var boResponse = bo.Insert();
            return new Response(boResponse.IsSuccess, boResponse.Message);
        }
    }
}
