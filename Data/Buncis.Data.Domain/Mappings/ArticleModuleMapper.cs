using Buncis.Data.Domain.Articles;
using FluentNHibernate.Mapping;

namespace Buncis.Data.Domain.Mappings
{
	public sealed class ArticleItemMap : ClassMap<ArticleItem>
	{
		public ArticleItemMap()
		{
			Table("Article_ArticleItem");
			LazyLoad();
			Id(x => x.ArticleId).GeneratedBy.Identity().Column("ArticleId");
			Map(x => x.ArticleTitle).Column("ArticleTitle").Not.Nullable().Length(250);
			Map(x => x.ArticleTeaser).Column("ArticleTeaser").Not.Nullable().Length(500);
			Map(x => x.ArticleUrl).Column("FriendlyUrl").Not.Nullable().Length(250);
			Map(x => x.ArticleContent).Column("ArticleContent").Not.Nullable().CustomType("StringClob");
			Map(x => x.DateCreated).Column("DateCreated").Not.Nullable();
			Map(x => x.DateLastUpdated).Column("DateLastUpdated").Not.Nullable();
			Map(x => x.IsDeleted).Column("IsDeleted").Not.Nullable();
			Map(x => x.ClientId).Column("ClientId").Not.Nullable();
			References(o => o.ArticleCategory, "ArticleCategoryId").Cascade.None();
		}

		public sealed class ArticleCategoryMap : ClassMap<ArticleCategory>
		{
			public ArticleCategoryMap()
			{
				Table("Article_ArticleCategory");
				LazyLoad();
				Id(x => x.ArticleCategoryId).GeneratedBy.Identity().Column("ArticleCategoryId");
				Map(x => x.ArticleCategoryName).Column("ArticleCategoryName").Not.Nullable().Length(250);
				Map(x => x.ArticleCategoryDescription).Column("ArticleCategoryDescription").Not.Nullable().Length(1000);
				Map(x => x.DateCreated).Column("DateCreated").Not.Nullable();
				Map(x => x.DateLastUpdated).Column("DateLastUpdated").Not.Nullable();
				Map(x => x.IsDeleted).Column("IsDeleted").Not.Nullable();
				Map(x => x.ClientId).Column("ClientId").Not.Nullable();
			}
		}
	}
}

