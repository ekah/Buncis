using System;
using System.Linq;
using Buncis.Framework.Infrastructure.Extensions;
using System.Collections.Generic;

namespace Buncis.Logic.ViewModel
{
    public class BuncisPageViewModel
    {
        public int PageId { get; set; }
        public string PageName { get; set; }
        public string PageDescription { get; set; }
        public string PageTeaser
        {
            get
            {
                var words = (PageDescription ?? string.Empty).Split(' ');
                IEnumerable<string> taken;
                if (words.Length > 8)
                {
                    taken = words.Take(8);
                }
                else
                {
                    taken = words.Take(words.Length);
                }
                var spaced = taken.Select(o => o + " ");
                return string.Concat(spaced) + "..";
            }
            set { }
        }
        public string PageContent { get; set; }
        public string MetaTitle { get; set; }
        public string MetaDescription { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateLastUpdated { get; set; }
        public string DisplayDateCreated
        {
            get
            {
                return DateCreated.ToLongFormatString();
            }
            set { }
        }
        public string DisplayDateLastUpdated
        {
            get
            {
                return DateLastUpdated.ToLongFormatString();
            }
            set { }
        }
        public string FriendlyUrl { get; set; }
        public bool IsHomePage
        {
            get
            {
                return FriendlyUrl.Equals("/", StringComparison.OrdinalIgnoreCase);
            }
            set { }
        }
    }
}
