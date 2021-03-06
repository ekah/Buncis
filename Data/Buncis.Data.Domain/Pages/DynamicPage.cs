﻿using System;

namespace Buncis.Data.Domain.Pages
{
    public class DynamicPage
    {
        public virtual int PageId { get; set; }
        public virtual string PageName { get; set; }
        public virtual string PageMenuName { get; set; }
        public virtual string PageDescription { get; set; }
        public virtual string PageContent { get; set; }
        public virtual string PageUrl { get; set; }
        public virtual int? ParentPageId { get; set; }
        public virtual string MetaTitle { get; set; }
        public virtual string MetaDescription { get; set; }
        public virtual DateTime DateCreated { get; set; }
        public virtual DateTime DateLastUpdated { get; set; }
        public virtual int ClientId { get; set; }
        public virtual bool IsDeleted { get; set; }
    }
}