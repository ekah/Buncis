using Buncis.Framework.Core.SupportClasses;

namespace Buncis.Framework.Core.Membership
{
	public interface IMembership
	{
		//int? LoggedInUserId { get; }
		//IUserProfile LoggedInUserProfile { get; }
		bool UserHasAccessToModule(ApplicationModule module);
		Response DoLogin(string username, string password);
		Response DoLogout(int userId);
	}
}