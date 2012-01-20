using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebFormsMvp.Web;

namespace Buncis.Framework.Mvp.Controls
{
    public class BuncisMvpUserControl<TModel> : MvpUserControl<TModel> where TModel : class, new()
    {
    }
}
