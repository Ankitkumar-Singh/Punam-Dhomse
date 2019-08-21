using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.HtmlControls;
using Assignment6.Models;
using System.Text;
using System.Web.UI.WebControls;
using System.Reflection;
using System.IO;
using System.Web.UI;

namespace Assignment6.CustomeHtmlHelper
{
    public static class CustomTableHelper
    {
        #region "Table"
        /// <summary>Tables the specified guest.</summary>
        /// <param name="helper">The helper.</param>
        /// <param name="guest">The guest.</param>
        /// <returns>HtmlString.</returns>
        /// <exception cref="T:System.ArgumentNullException">helper</exception>
        public static HtmlString Table(this HtmlHelper helper, List<GuestDetail> guest)
        {
            if (helper is null)
            {
                throw new ArgumentNullException(nameof(helper));
            }

            HtmlTable ht = new HtmlTable();

            HtmlTableRow htColumnsRow = new HtmlTableRow();

            typeof(GuestDetail).GetProperties().Select(prop =>
            {
                HtmlTableCell htCell = new HtmlTableCell();
                htCell.InnerText = prop.Name;
                return htCell;
            }).ToList().ForEach(cell => htColumnsRow.Cells.Add(cell));
            ht.Rows.Add(htColumnsRow);

            guest.ForEach(delegate (GuestDetail obj)
            {
                HtmlTableRow htRow = new HtmlTableRow();
                obj.GetType().GetProperties().ToList().ForEach(delegate (PropertyInfo prop)
                {
                    HtmlTableCell htCell = new HtmlTableCell();
                    htCell.InnerText = prop.GetValue(obj, null).ToString();
                    htRow.Cells.Add(htCell);
                });
                ht.Rows.Add(htRow);
            });

            StringBuilder sb = new StringBuilder();
            StringWriter tw = new StringWriter(sb);
            HtmlTextWriter hw = new HtmlTextWriter(tw);

            ht.RenderControl(hw);

            string HTMLContent = sb.ToString();

            return new MvcHtmlString(sb.ToString());
        }
        #endregion

        #region "Table with two  parameter"
        /// <summary>Tables the specified data.</summary>
        /// <param name="helper">The helper.</param>
        /// <param name="Data">The data.</param>
        /// <param name="class">The class.</param>
        /// <returns>IHtmlString.</returns>
        /// <exception cref="T:System.ArgumentNullException">helper</exception>
        public static IHtmlString Table(this HtmlHelper helper, List<GuestDetail> Data, string @class)
        {
            if (helper is null)
            {
                throw new ArgumentNullException(nameof(helper));
            }
            HtmlTable ht = new HtmlTable();
            ht.Attributes.Add("class", @class);
            //Get the columns
            HtmlTableRow htColumnsRow = new HtmlTableRow();

            typeof(GuestDetail).GetProperties().Select(prop =>
            {
                HtmlTableCell htCell = new HtmlTableCell();
                htCell.InnerText = prop.Name;
                return htCell;
            }).ToList().ForEach(cell => htColumnsRow.Cells.Add(cell));
            ht.Rows.Add(htColumnsRow);
            //Get the remaining rows
            Data.ForEach(delegate (GuestDetail obj)
            {
                HtmlTableRow htRow = new HtmlTableRow();
                obj.GetType().GetProperties().ToList().ForEach(delegate (PropertyInfo prop)
                {
                    HtmlTableCell htCell = new HtmlTableCell();
                    htCell.InnerText = prop.GetValue(obj, null).ToString();
                    htRow.Cells.Add(htCell);
                });
                ht.Rows.Add(htRow);
            });

            StringBuilder sb = new StringBuilder();
            StringWriter tw = new StringWriter(sb);
            HtmlTextWriter hw = new HtmlTextWriter(tw);

            ht.RenderControl(hw);

            string HTMLContent = sb.ToString();

            return new MvcHtmlString(sb.ToString());

        }
        #endregion
    }
}