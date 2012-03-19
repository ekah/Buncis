namespace Buncis.Core.Infrastructures
{
    public class SystemSettings : ISystemSettings
    {
        #region ISystemSettings Members

        public decimal PpnTax { get; set; }

        public string DeveloperEmail { get; set; }

        public int GlobalItemPerPage { get; set; }

        #endregion
    }
}