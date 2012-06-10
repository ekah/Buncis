using System;

namespace Buncis.Data.Domain.Membership
{
    public class MembershipUser
    {
        public virtual int UserId { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public virtual string Email { get; set; }
        public virtual Guid ProfileUserId { get; set; }
        public virtual int ClientId { get; set; }
        public virtual bool IsDeleted { get; set; }
    }
}
