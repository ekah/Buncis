using System;

namespace Buncis.Data.Domain
{
    public class MembershipUser
    {
        public virtual int UserId { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public virtual string Email { get; set; }
        public virtual string LoweredEmail { get; set; }
        public virtual string Password { get; set; }
        public virtual bool IsLocked { get; set; }
        public virtual bool IsApproved { get; set; }
        public virtual DateTime? LastLoginDate { get; set; }
        public virtual DateTime CreatedDate { get; set; }
        public virtual DateTime? LastLockedDate { get; set; }
    }
}
