using HappytoHelp.FileHelpers;
using Microsoft.VisualBasic.ApplicationServices;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
using System.IO;
using System.Xml.Linq;
using System.Xml.Serialization;
using xml_curd_form.Model;


namespace xml_curd_form.Services
{
    public  class XmlHelper
    {

        public void SaveRecordsToXml(string filePath, List<Route> records)
        {

            XElement xml = new XElement("Routes",
                from record in records
                select new XElement("Route",
                    new XElement("Title", record.Title),
                    new XElement("Start", record.Start),
                    new XElement("End", record.End),
                    new XElement("Distance", record.Distance),
                    new XElement("Status", record.Status),
                    new XElement("CreatedDatetime", record.CreatedDateTime)
                )
            );
            xml.Save(filePath);
        }

        public  List<Route> LoadRecords(string filePath)
        {
            List<Route> records = new List<Route>();
            XElement xml = XElement.Load(filePath);

            foreach (var recordElem in xml.Elements("Route"))
            {

                Route record = new Route
                {
                    Title = recordElem.Element("Title").Value,
                    Start = recordElem.Element("Start").Value,
                    End = recordElem.Element("End").Value,
                    Distance = Convert.ToDecimal(recordElem.Element("Distance").Value),
                    Status = recordElem.Element("Status").Value,
                    CreatedDateTime = DateTime.Parse(recordElem.Element("CreatedDatetime").Value),
                };

                records.Add(record);
               
            }
            return records;
        }

        public DataTable LoadDynamicRecords(string filePath)
        {
            List<Route> records = new List<Route>();
            XElement xml = XElement.Load(filePath);
            DataTableHelper dthelp = new();
           DataTable dt= dthelp.XElementToDataTable(xml);
            return dt;
        }
    }
}
