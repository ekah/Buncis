﻿using System;
using System.Linq;
using WebFormsMvp.Web;
using Buncis.Framework.Mvp.Views;

namespace Buncis.Web.Base
{
    public class BaseUserControl<TModel> : MvpUserControl<TModel>, ICustomEventView where TModel : class, new()
    {
        public event EventHandler Initialize;

        protected void InitializeView(object sender, EventArgs e)
        {
            Initialize(sender, e);
        }
    }
}