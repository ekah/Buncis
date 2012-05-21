using WebFormsMvp.Web;

namespace Buncis.Framework.Mvp.Controls
{
    public class BaseMvpUserControl<TModel> : MvpUserControl<TModel> where TModel : class, new()
    {
    }
}