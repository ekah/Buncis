using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Buncis.Logic.ViewModel;
using Omu.ValueInjecter;
using Buncis.Framework.Services.Pages;
using Buncis.Framework.Core.SupportClasses;

namespace Buncis.Logic.BusinessObject
{
    public class BuncisPages : BaseBusinessObject<BuncisPageViewModel>
    {
        private readonly IDynamicPageService _dynamicPageService;

        public int ClientId { get; set; }

        public BuncisPages(IDynamicPageService dynamicPageService)
        {
            _dynamicPageService = dynamicPageService;
        }

        public override Response<BuncisPageViewModel> Insert()
        {
            throw new NotImplementedException();
        }

        public override Response<BuncisPageViewModel> Update()
        {
            throw new NotImplementedException();
        }

        public override Response Delete()
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        public override void SetupNewObjectToInsert()
        {
            throw new NotImplementedException();
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
