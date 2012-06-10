using WebFormsMvp;

namespace Buncis.Framework.Mvp.Views
{
	public interface IBaseView<TModel> : ICustomEventView, IView<TModel> where TModel : class, new()
	{
		
	}
}