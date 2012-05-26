using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using Buncis.Data.Domain.News;

namespace Buncis.Data.Domain.Mappings
{
    public sealed class ArticleMap : ClassMap<Article>
    {
        public ArticleMap()
        {
            Table("News_Article");
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
