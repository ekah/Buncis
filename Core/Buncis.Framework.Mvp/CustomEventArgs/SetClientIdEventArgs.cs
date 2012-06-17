using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Buncis.Framework.Mvp.CustomEventArgs
{
    public class SetClientIdEventArgs : EventArgs
    {
        public int ClientId { get; set; }
    }
}
