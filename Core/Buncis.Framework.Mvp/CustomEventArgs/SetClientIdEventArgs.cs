using System;

namespace Buncis.Framework.Mvp.CustomEventArgs
{
    public class SetClientIdEventArgs : EventArgs
    {
        public int ClientId { get; set; }
    }
}
