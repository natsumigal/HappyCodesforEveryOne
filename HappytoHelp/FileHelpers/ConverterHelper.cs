using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace HappytoHelp.FileHelpers
{
    public class ConverterHelper
    {

        public string ConvertCsvToXml(string filePath)
        {
            DataTable dt = new DataTable();
            string[] lines = File.ReadAllLines(filePath);

            if (lines.Length == 0)
            {
                throw new Exception("Empty file.");
            }

            // Create columns based on header row
            string[] headers = lines[0].Split(',');
            foreach (string header in headers)
            {
                dt.Columns.Add(header);
            }

            // Add rows to DataTable
            for (int i = 1; i < lines.Length; i++)
            {
                string[] data = lines[i].Split(',');
                if (data.Length != dt.Columns.Count)
                {
                    throw new Exception("Invalid file format. Missing data in line: " + i);
                }
                dt.Rows.Add(data);
            }
            DataTableHelper dtHelp = new();

            if (!dtHelp.CheckAllRowsValid(dt))
            {
                return "rows is invalid";
            }
            else
            {
                ConvertDataTableToXML(dt, filePath);
                return "";
            }



        }

        public DataTable ConvertCsvToDatatable(string filePath)
        {
            DataTable dt = new();
            string[] lines = File.ReadAllLines(filePath);

            // Create columns based on header row
            string[] headers = lines[0].Split(',');
            foreach (string header in headers)
            {
                dt.Columns.Add(header);
            }

            // Add rows to DataTable
            for (int i = 1; i < lines.Length; i++)
            {
                string[] data = lines[i].Split(',');
                dt.Rows.Add(data);
            }
            return dt;
        }

        public void ConvertDataTableToXML(DataTable dt, string filePath)
        {
            // Convert DataTable to XML
            DataSet dataSet = new DataSet();
            dataSet.Tables.Add(dt);

            // Save XML to file
            string xmlFilePath = Path.Combine(Path.GetDirectoryName(filePath), Path.GetFileNameWithoutExtension(filePath) + ".xml");
            dataSet.WriteXml(xmlFilePath);
        }

        public DataTable ConvertXmlToDataTable(string xmlFilePath)
        {
            // Create a new DataSet
            DataSet dataSet = new DataSet();

            // Read the XML data into the DataSet
            dataSet.ReadXml(xmlFilePath);

            // Assuming the XML contains only one DataTable
            if (dataSet.Tables.Count > 0)
            {
                // Return the first DataTable from the DataSet
                return dataSet.Tables[0];
            }
            else
            {
                // No DataTable found in the XML
                return null;
            }
        }
    }
}

