﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Buncis.Framework.Core.ViewModel;

namespace Buncis.Logic.Models.Articles
{
	public class ArticleListModel
	{
		public IEnumerable<ViewModelArticleItem> ArticleItems { get; set; } 
	}
}
