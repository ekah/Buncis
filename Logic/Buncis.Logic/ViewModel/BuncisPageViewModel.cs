using System;
using System.Linq;

namespace Buncis.Logic.ViewModel
{
    public class BuncisPageViewModel
    {
        public int PageId { get; set; }
        public string PageName { get; set; }
        public string PageDescription { get; set; }
        public string PageContent { get; set; }
        public string MetaTitle { get; set; }
        public string MetaDescription { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateLastUpdated { get; set; }
        public string FriendlyUrl { get; set; }
        public bool IsHomePage
        {
            get
            {
                return FriendlyUrl.Equals("/", StringComparison.OrdinalIgnoreCase);
            }
        }
    }
}
