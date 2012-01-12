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

namespace Buncis.Web
{
    public partial class _Default : System.Web.UI.Page
    {
        ICategoryRepository cr = null;
        IProductRepository pr = null;
        ISupplierRepository sr = null;
        IUnitOfWork uow = null;

        private Category Category { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ltrTest.Text = Category == null ? "" : Category.CategoryName;
            }
        }

        protected override void OnInit(EventArgs e)
        {
            cr = IoC.Resolve<ICategoryRepository>();
            pr = IoC.Resolve<IProductRepository>();
            sr = IoC.Resolve<ISupplierRepository>();

            randomize1.Click += new EventHandler(randomize1_Click);
            randomize2.Click += new EventHandler(randomize1_Click);
            randomize3.Click += new EventHandler(randomize1_Click);
            randomize4.Click += new EventHandler(randomize1_Click);
            btnCancel.Click += new EventHandler(btnCancel_Click);
            btnComplete.Click += new EventHandler(btnComplete_Click);

            base.OnInit(e);
        }

        void btnComplete_Click(object sender, EventArgs e)
        {

        }

        void btnCancel_Click(object sender, EventArgs e)
        {

        }

        void randomize1_Click(object sender, EventArgs e)
        {
            uow = IoC.Resolve<IUnitOfWork>();

            using (uow)
            {
                Category = cr.FindBy(o => o.CategoryId == 9);

                Category.CategoryName = new Random(DateTime.Now.Millisecond).Next().ToString();
                ltrTest.Text = Category == null ? "" : Category.CategoryName;

                cr.Update(Category);

                uow.Commit();
            }
        }

    }
}
