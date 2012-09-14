using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using Buncis.Data.Domain.DailyBread;

namespace Buncis.Data.Domain.Mappings
{
	public class DailyBreadModuleMapper : ClassMap<DailyBreadItem>
	{
		public DailyBreadModuleMapper()
		{
			Table("DailyBread_DailyBreadItem");
			LazyLoad();
			Id(x => x.DailyBreadId).GeneratedBy.Identity().Column("DailyBreadId");
			Map(x => x.DailyBreadTitle).Column("DailyBreadTitle").Not.Nullable().Length(250);
			Map(x => x.DailyBreadSummary).Column("DailyBreadSummary").Not.Nullable().Length(500);
			Map(x => x.DailyBreadContent).Column("DailyBreadContent").Not.Nullable().CustomType("StringClob");
			Map(x => x.DailyBreadUrl).Column("FriendlyUrl").Not.Nullable().Length(250);
			Map(x => x.ClientId).Column("ClientId").Not.Nullable();
			Map(x => x.IsDeleted).Column("IsDeleted").Not.Nullable();
			Map(x => x.DateCreated).Column("DateCreated").Not.Nullable();
			Map(x => x.DateLastUpdated).Column("DateLastUpdated").Not.Nullable();
			Map(x => x.DatePublished).Column("DatePublished").Not.Nullable();
			Map(x => x.DailyBreadBook).Column("DailyBreadBook").Not.Nullable().Length(50);
			Map(x => x.DailyBreadBookChapter).Column("DailyBreadBookChapter").Not.Nullable();
			Map(x => x.DailyBreadBookVerse1).Column("DailyBreadBookVerse1").Not.Nullable();
			Map(x => x.DailyBreadBookVerse2).Column("DailyBreadBookVerse2").Not.Nullable();
			Map(x => x.DailyBreadBookContent).Column("DailyBreadBookContent").Not.Nullable();
		}
	}
}
