using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Buncis.Data.Domain.DailyBread
{
    public class DailyBreadItem
    {
        public virtual int DailyBreadId { get; set; }
        public virtual string DailyBreadTitle { get; set; }
        public virtual string DailyBreadSummary { get; set; }
        public virtual string DailyBreadContent { get; set; }
        public virtual string DailyBreadUrl { get; set; }
        public virtual int ClientId { get; set; }
        public virtual bool IsDeleted { get; set; }
        public virtual DateTime DateCreated { get; set; }
        public virtual DateTime DateLastUpdated { get; set; }
        public virtual string DailyBreadBook { get; set; }
        public virtual int DailyBreadBookChapter { get; set; }
        public virtual int DailyBreadBookVerse1 { get; set; }
        public virtual int DailyBreadBookVerse2 { get; set; }
        public virtual string DailyBreadBookContent { get; set; }
    }
}
