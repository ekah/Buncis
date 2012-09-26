using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Buncis.Framework.Mvp.Views;
using Buncis.Logic.Models.News;

namespace Buncis.Logic.Views.News
{
	public interface INewsListView : IBindableView<NewsListModel>
	{
		event EventHandler GetNewsList;
		void BindNewsList();
	}
}
