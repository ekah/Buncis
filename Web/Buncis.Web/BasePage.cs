using System.Web.UI;
using WebFormsMvp.Web;
using System;

namespace Buncis.Web
{
    public class BasePage<TModel> : MvpPage<TModel> where TModel : class, new()
    {
        
    }
}