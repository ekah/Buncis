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
            Map(x => x.PageName).Column("PageName").Not.Nullable().Length(255);
            Map(x => x.PageMenuName).Column("PageMenuName").Not.Nullable().Length(50);
            Map(x => x.PageDescription).Column("PageDescription").Nullable().Length(500);
            Map(x => x.PageContent).Column("PageContent").Not.Nullable();
            Map(x => x.FriendlyUrl).Column("FriendlyUrl").Not.Nullable().Length(1000);
            Map(x => x.ParentPageId).Column("ParentPageId").Nullable();
            Map(x => x.MetaTitle).Column("MetaTitle").Nullable().Length(255);
            Map(x => x.MetaDescription).Column("MetaDescription").Nullable().Length(500);
            Map(x => x.DateCreated).Column("DateCreated").Not.Nullable();
            Map(x => x.IsDeleted).Column("IsDeleted").Not.Nullable();
        }
    }
}