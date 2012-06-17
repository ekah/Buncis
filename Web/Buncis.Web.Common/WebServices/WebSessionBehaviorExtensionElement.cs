using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel.Configuration;

namespace Buncis.Web.Common.WebServices
{
    public class WebSessionBehaviorExtensionElement : BehaviorExtensionElement
    {
        protected override object CreateBehavior()
        {
            return new WebSessionEndpointBehavior();
        }

        public override Type BehaviorType
        {
            get
            {
                return typeof(WebSessionEndpointBehavior);
            }
        }
    }
}
