using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Buncis.Core.Repositories;
using Buncis.Framework.Core.Infrastructure.IoC;
using NHibernate;
using Buncis.Data.Models;
using Buncis.Framework.Core.Infrastructure;
using Buncis.Core.Services;

namespace Buncis.Web
{
    public partial class _Default : System.Web.UI.Page
    {
        IProductRepository pr = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            pr = IoC.Resolve<IProductRepository>();

            if (!IsPostBack)
            {
                IProductService ps = IoC.Resolve<IProductService>();
                var res = ps.GetProducts(3, 8);
            }
        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
        }

    }
}
