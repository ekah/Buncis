using Buncis.Framework.Core.Infrastructure.IoC;
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
                    _membership = IoC.Resolve<IMembership>();
                return _membership;
            }
        }
    }
}