using System;

namespace Buncis.Framework.Core.Membership
{
    public interface IUserProfile
    {
        int UserId { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        string FullName { get; }
        string Email { get; set; }
        bool IsLocked { get; set; }
        bool IsApproved { get; set; }
        DateTime? LastLoginDate { get; set; }
    }
}