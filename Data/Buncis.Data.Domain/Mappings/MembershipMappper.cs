using Buncis.Data.Domain.Membership;
using FluentNHibernate.Mapping;

namespace Buncis.Data.Domain.Mappings
{
    public sealed class MembershipUserMap : ClassMap<MembershipUser>
    {
        public MembershipUserMap()
        {
            Table("Membership_Users");
            LazyLoad();
            Id(x => x.UserId).GeneratedBy.Identity().Column("UserId");
            Map(x => x.FirstName).Column("FirstName").Not.Nullable();
            Map(x => x.LastName).Column("LastName").Not.Nullable();
            Map(x => x.Email).Column("Email").Not.Nullable();
            Map(x => x.ProfileUserId).Column("ProfileUserId").Not.Nullable();
            Map(x => x.ClientId).Column("ClientId").Not.Nullable();
            Map(x => x.IsDeleted).Column("IsDeleted").Not.Nullable();
        }
    }

    public sealed class MembershipRoleMap : ClassMap<MembershipRole>
    {
        public MembershipRoleMap()
        {

            Table("Membership_Roles");
            LazyLoad();
            Id(x => x.RoleId).GeneratedBy.Identity().Column("RoleId");
            Map(x => x.RoleName).Column("RoleName").Not.Nullable();

        }
    }
}
