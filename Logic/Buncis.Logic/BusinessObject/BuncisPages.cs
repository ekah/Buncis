using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Buncis.Logic.ViewModel;
using Omu.ValueInjecter;
using Buncis.Framework.Services.Pages;
using Buncis.Framework.Core.SupportClasses;
using Buncis.Data.Domain.Pages;

namespace Buncis.Logic.BusinessObject
{
    public class BuncisPages : BaseClientBusinessObject<BuncisPageViewModel>
    {
        private readonly IDynamicPageService _dynamicPageService;

        public BuncisPages(IDynamicPageService dynamicPageService, int clientId)
        {
            _dynamicPageService = dynamicPageService;
            ClientId = clientId;
        }

        public override Response<BuncisPageViewModel> Insert()
        {
            var response = new Response<BuncisPageViewModel>();
            try
            {
                var page = new DynamicPage();
                page.InjectFrom(ToInsert);
                page.ClientId = ClientId;
                page.DateCreated = DateTime.UtcNow;
                _dynamicPageService.SavePage(page);

                GetEditableByKey();

                response.IsSuccess = true;
                response.ResponseObject = Editable;
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public override Response<BuncisPageViewModel> Update()
        {
            var response = new Response<BuncisPageViewModel>();
            try
            {
                var page = new DynamicPage();
                page.InjectFrom(Editable);
                page.ClientId = ClientId;
                page.DateLastUpdated = DateTime.UtcNow;
                _dynamicPageService.SavePage(page);

                GetEditableByKey();

                response.IsSuccess = true;
                response.ResponseObject = Editable;
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public override Response Delete()
        {
            try
            {
                var page = _dynamicPageService.GetPage(KeyToDelete);
                page.IsDeleted = true;
                _dynamicPageService.SavePage(page);
                return new Response(true, string.Empty);
            }
            catch (Exception ex)
            {
                return new Response(false, ex.Message);
            }
        }

        public override Response GetList()
        {
            var response = new Response();
            try
            {
                var rawPages = _dynamicPageService.GetPagesNotDeleted(ClientId);
                var convertedPages = rawPages.Select(o =>
                {
                    var viewModel = new BuncisPageViewModel();
                    viewModel.InjectFrom(o);
                    return viewModel;
                }).ToList();

                convertedPages = convertedPages.OrderByDescending(o => o.IsHomePage).ThenBy(o => o.PageName).ToList();

                List = convertedPages;

                response.IsSuccess = true;
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }

            return response;
        }

        public override Response GetEditableByKey()
        {
            var response = new Response();
            try
            {
                var page = _dynamicPageService.GetPage(Key);
                var viewModel = new BuncisPageViewModel();
                viewModel.InjectFrom(page);
                Editable = viewModel;
                response.IsSuccess = true;
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public override void SetupNewObjectToInsert()
        {
            ToInsert = new BuncisPageViewModel();
        }

        public override bool ValidateBeforeInsert()
        {
            throw new NotImplementedException();
        }

        public override bool ValidateBeforeUpdate()
        {
            throw new NotImplementedException();
        }
    }
}
