using Buncis.Data.Domain.Pages;
using FluentNHibernate.Mapping;

namespace Buncis.Data.Domain.Mappings
{
    public sealed class PageMap : ClassMap<DynamicPage>
    {
        public PageMap()
        {
            Table("Page_Pages");
            LazyLoad();
            Id(x => x.PageId).GeneratedBy.Identity().Column("PageId");
            Map(x => x.PageName).Column("PageName").Not.Nullable();
            Map(x => x.PageMenuName).Column("PageMenuName").Not.Nullable();
            Map(x => x.PageDescription).Column("PageDescription");
            Map(x => x.PageContent).Column("PageContent").Not.Nullable().CustomType("StringClob");
            Map(x => x.FriendlyUrl).Column("FriendlyUrl").Not.Nullable();
            Map(x => x.ParentPageId).Column("ParentPageId");
            Map(x => x.MetaTitle).Column("MetaTitle").Not.Nullable();
            Map(x => x.MetaDescription).Column("MetaDescription").Not.Nullable();
            Map(x => x.DateCreated).Column("DateCreated").Not.Nullable();
            Map(x => x.DateLastUpdated).Column("DateLastUpdated").Not.Nullable();
            Map(x => x.ClientId).Column("ClientId").Not.Nullable();
            Map(x => x.IsDeleted).Column("IsDeleted").Not.Nullable();
        }
    }
}