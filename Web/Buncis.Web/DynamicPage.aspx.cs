﻿using System;
using System.Linq;
using Buncis.Framework.Core.Infrastructure.IoC;
using Buncis.Web.Base;
using WebFormsMvp;
using Buncis.Web.Common.DynamicControls;
using Buncis.Logic.Models.Pages;
using Buncis.Logic.Views.Pages;
using Buncis.Logic.Presenters.Pages;

namespace Buncis.Web
{
    [PresenterBinding(typeof(DynamicPagePresenter), ViewType = typeof(IDynamicPageView))]
    public partial class DynamicPage : BasePage<DynamicPageModel>, IDynamicPageView
    {
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            InitializeView(this, e);
        }

        #region IBindableView<DynamicPageModel> Members

        public void BindViewData()
        {
            Page.Title = Model.MetaTitle;
            Page.MetaDescription = Model.MetaDescription;

            var controlResolver = IoC.Resolve<IDynamicControlsResolver>();
            controlResolver.ResolveDynamicControls(plcBodyContent, Model.PageContent);
        }

        #endregion

    }
}
