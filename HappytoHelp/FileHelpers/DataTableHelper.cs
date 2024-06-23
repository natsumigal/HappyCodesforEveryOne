using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace HappytoHelp.FileHelpers
{

    public class DataTableHelper
    {
        public DataTable XElementToDataTable(XElement xElement)
        {
            DataTable dataTable = new DataTable();

            // Assuming the first element has all columns needed
            var firstElement = xElement.Elements().First();
            foreach (var element in firstElement.Elements())
            {
                dataTable.Columns.Add(element.Name.LocalName);
            }

            foreach (var row in xElement.Elements())
            {
                var dataRow = dataTable.NewRow();
                foreach (var column in row.Elements())
                {
                    dataRow[column.Name.LocalName] = column.Value;
                }
                dataTable.Rows.Add(dataRow);
            }

            return dataTable;
        }
        public  bool CheckAllRowsValid(DataTable dataTable)
        {
            foreach (DataRow row in dataTable.Rows)
            {
                foreach (var item in row.ItemArray)
                {
                    if (item == null || string.IsNullOrWhiteSpace(item.ToString()))
                    {
                        return false; // One or more values are missing
                    }
                }
            }
            return true; // All rows are valid
        }
    }
}
