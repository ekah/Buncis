using System;
using Buncis.Framework.Core.Infrastructure.Extensions;

namespace Buncis.Framework.Core.ViewModel
{
    public class vBuncisNewsItem
    {
        public int NewsId { get; set; }
        public string NewsTitle { get; set; }
        public string NewsTeaser { get; set; }
        public string NewsContent { get; set; }
        public DateTime DatePublished { get; set; }
        public string DisplayDatePublished
        {
            get
            {
                return DatePublished.DatePart().ToBuncisShortFormatString();
            }
        }
        public DateTime DateExpired { get; set; }
        public string DisplayDateExpired
        {
            get
            {
				return DateExpired.DatePart().ToBuncisShortFormatString();
            }
        }
        public string FriendlyUrl { get; set; }
        public DateTime DateCreated { get; set; }
        public string DisplayDateCreated
        {
            get
            {
                return DateCreated.ToBuncisLongFormatString();
            }
        }
        public DateTime DateLastUpdated { get; set; }
        public string DisplayDateLastUpdated
        {
            get
            {
                return DateLastUpdated.ToBuncisLongFormatString();
            }
        }
    }
}
