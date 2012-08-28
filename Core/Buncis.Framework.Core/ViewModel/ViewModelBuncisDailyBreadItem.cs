using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Buncis.Framework.Core.ViewModel
{
    public class ViewModelBuncisDailyBreadItem
    {
        public int DailyBreadId { get; set; }
        public string DailyBreadTitle { get; set; }
        public string DailyBreadSummary { get; set; }
        public string DailyBreadContent { get; set; }
        public string FriendlyUrl { get; set; }
        public int ClientId { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateLastUpdated { get; set; }
        public string DailyBreadBook { get; set; }
        public int DailyBreadBookChapter { get; set; }
        public int DailyBreadBookVerse1 { get; set; }
        public int DailyBreadBookVerse2 { get; set; }
        public string DailyBreadBookContent { get; set; }
    }
}
