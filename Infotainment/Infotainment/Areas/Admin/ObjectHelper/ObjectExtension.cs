using Infotainment.Data.Controls;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Infotainment.Helper
{
    public static class ObjectExtension
    {
        private static DataTable GetDataTable(this ITopNews news)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("TopNewsID", typeof(String)));
            dt.Columns.Add(new DataColumn("EditorID", typeof(String)));
            dt.Columns.Add(new DataColumn("DisplayOrder", typeof(Int32)));
            dt.Columns.Add(new DataColumn("Heading", typeof(String)));
            dt.Columns.Add(new DataColumn("ShortDescription", typeof(String)));
            dt.Columns.Add(new DataColumn("TopNewsID", typeof(String)));
            dt.Columns.Add(new DataColumn("TopNewsID", typeof(String)));
            dt.Columns.Add(new DataColumn("TopNewsID", typeof(String)));
            dt.Columns.Add(new DataColumn("TopNewsID", typeof(String)));
            dt.Columns.Add(new DataColumn("TopNewsID", typeof(String)));
            dt.Columns.Add(new DataColumn("TopNewsID", typeof(String)));
            dt.Columns.Add(new DataColumn("TopNewsID", typeof(String)));
            dt.Columns.Add(new DataColumn("TopNewsID", typeof(String)));
            dt.Columns.Add(new DataColumn("TopNewsID", typeof(String)));
            dt.Columns.Add(new DataColumn("TopNewsID", typeof(String)));
            dt.Columns.Add(new DataColumn("TopNewsID", typeof(String)));
            if (news != null)
            {

            }
            return null;
        }
    }
}