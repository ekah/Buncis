using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Buncis.Web.Common.Exceptions
{
    public class PageNotFoundException : Exception
    {
        public string Url { get; set; }
        public int PageId { get; set; }

        public PageNotFoundException(string message, string url)
            : base(message)
        {
            this.Url = url;
        }

        public PageNotFoundException(string message, int pageId)
            : base(message)
        {
            this.PageId = pageId;
        }
    }
}
