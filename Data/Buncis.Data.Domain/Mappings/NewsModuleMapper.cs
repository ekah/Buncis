using Buncis.Data.Domain.News;
using FluentNHibernate.Mapping;

namespace Buncis.Data.Domain.Mappings
{
    public sealed class ArticleMap : ClassMap<Article>
    {
        public ArticleMap()
        {
            Table("News_Articles");
            LazyLoad();
            Id(x => x.ArticleId).GeneratedBy.Identity().Column("ArticleId");
            Map(x => x.ArticleTitle).Column("ArticleTitle").Not.Nullable().Length(250);
            Map(x => x.ArticleTeaser).Column("ArticleTeaser").Not.Nullable().Length(500);
            Map(x => x.ArticleContent).Column("ArticleContent").Not.Nullable();
            Map(x => x.DateCreated).Column("DateCreated").Not.Nullable();
            Map(x => x.DatePublished).Column("DatePublished");
            Map(x => x.DateExpired).Column("DateExpired");
            Map(x => x.IsDeleted).Column("IsDeleted").Not.Nullable();
        }
    }
}
