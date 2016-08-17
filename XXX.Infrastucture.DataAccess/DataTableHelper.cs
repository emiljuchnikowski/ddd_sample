using System.Collections.Generic;
using System.Data;

namespace XXX.Infrastructure.DataAccess
{
    public class DataTableHelper
    {
        public static DataTable GetForExternalIds(IEnumerable<string> ids)
        {
            var table = new DataTable();
            table.Columns.Add("ExternalId");

            foreach (var id in ids)
            {
                var row = table.NewRow();
                row["ExternalId"] = id;
                table.Rows.Add(row);
            }

            return table;
        }
    }
}