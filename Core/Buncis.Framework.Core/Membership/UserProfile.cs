using System;

namespace Buncis.Framework.Core.Membership
{
    public class UserProfile
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName
        {
            get
            {
                return string.Format("{0} {1}", FirstName, LastName).TrimEnd();
            }
        }
        public string Email { get; set; }
        public bool IsLocked { get; set; }
        public bool IsApproved { get; set; }
        public DateTime? LastLoginDate { get; set; }

    }
}
