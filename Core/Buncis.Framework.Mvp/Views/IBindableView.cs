
namespace Buncis.Framework.Mvp.Views
{
    public interface IBindableView<TModel> : IBaseView<TModel> where TModel : class, new()
    {
        void BindViewData();
    }
}
