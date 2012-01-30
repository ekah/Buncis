using System.Web.UI.WebControls;

namespace Buncis.Web.Common.Extensions
{
    public static class DropDownListExtension
    {
        /// <summary>
        /// Inserts the list item_ all.
        /// </summary>
        /// <param name="ddl">The DDL.</param>
        public static void InsertListItem_All(this DropDownList ddl)
        {
            ddl.Items.Insert(0, new ListItem("All", string.Empty));
        }
    }
}