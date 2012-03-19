using Buncis.Framework.Core.Membership;
using StructureMap;

namespace Buncis.Web.Common.Membership
{
    public static class WebMembership
    {
        private static IMembership _membership;

        public static IMembership Entity
        {
            get
            {
                if (_membership == null)
                    _membership = ObjectFactory.GetInstance<IMembership>();
                return _membership;
            }
        }
    }
}