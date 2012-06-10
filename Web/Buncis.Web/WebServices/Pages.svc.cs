using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Buncis.Web.WebServices
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Pages" in code, svc and config file together.
    public class Pages : IPages
    {
        public string DoWork()
        {
            return "a";
        }
    }
}
