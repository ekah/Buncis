using Buncis.Data.Domain.News;
using FluentNHibernate.Mapping;

namespace Buncis.Data.Domain.Mappings
{
    public sealed class ArticleMap : ClassMap<NewsItem>
    {
        public ArticleMap()
        {
            Table("News_NewsItem");
            LazyLoad();
            Id(x => x.NewsId).GeneratedBy.Identity().Column("NewsId");
            Map(x => x.NewsTitle).Column("NewsTitle").Not.Nullable().Length(250);
            Map(x => x.NewsTeaser).Column("NewsTeaser").Not.Nullable().Length(500);
            Map(x => x.NewsContent).Column("NewsContent").Not.Nullable();
			Map(x => x.DatePublished).Column("DatePublished").Not.Nullable();
			Map(x => x.DateExpired).Column("DateExpired").Not.Nullable();
            Map(x => x.ClientId).Column("ClientId").Not.Nullable();
            Map(x => x.IsDeleted).Column("IsDeleted").Not.Nullable();
			Map(x => x.FriendlyUrl).Column("FriendlyUrl").Not.Nullable();
			Map(x => x.DateCreated).Column("DateCreated").Not.Nullable();
			Map(x => x.DateLastUpdated).Column("DateLastUpdated").Not.Nullable();
        }
    }
}
