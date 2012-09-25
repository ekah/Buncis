using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Buncis.Framework.Mvp.Views;
using Buncis.Logic.Models.Articles;

namespace Buncis.Logic.Views.Articles
{
	public interface IRecentArticlesView : IBindableView<RecentArticlesModel>
	{
		event EventHandler GetRecentArticles;
		void BindRecentArticles();
	}
}
