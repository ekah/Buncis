using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Buncis.Logic.ViewModel
{
    public class BuncisPageViewModel
    {
        public int PageId { get; set; }
        public string PageName { get; set; }
        public string PageContent { get; set; }
        public string MetaTitle { get; set; }
        public string MetaDescription { get; set; }
    }
}
