using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Buncis.Framework.Core.ViewModel
{
    public class ViewModelArticleItem
    {
        public int ArticleId { get; set; }
        public string ArticleTitle { get; set; }
        public string ArticleTeaser { get; set; }
        public string ArticleContent { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateLastUpdated { get; set; }
        public int ClientId { get; set; }
    }
}
