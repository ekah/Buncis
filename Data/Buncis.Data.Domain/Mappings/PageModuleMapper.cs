using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;

namespace Buncis.Data.Domain.Mappings
{
    public class PageMap : ClassMap<DynamicPage>
    {
        public PageMap()
        {
            Table("Page_Pages");
            LazyLoad();
            Id(x => x.PageId).GeneratedBy.Identity().Column("PageId");
            Map(x => x.PageName).Column("PageName").Length(255);
            Map(x => x.PageMenuName).Column("PageMenuName").Length(50);
            Map(x => x.PageDescription).Column("PageDescription").Not.Nullable().Length(500);
            Map(x => x.PageContent).Column("PageContent");
            Map(x => x.FriendlyUrl).Column("FriendlyUrl").Length(1000);
            Map(x => x.ParentPageId).Column("ParentPageId");
            Map(x => x.MetaTitle).Column("MetaTitle").Length(255);
            Map(x => x.MetaDescription).Column("MetaDescription").Not.Nullable().Length(500);
            Map(x => x.DateCreated).Column("DateCreated");
            Map(x => x.IsDeleted).Column("IsDeleted");
        }
    }
}
