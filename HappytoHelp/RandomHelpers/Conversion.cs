using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.ComponentModel;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace HappytoHelp.RandomHelpers
{
	public static class Conversion
	{

        //https://stackoverflow.com/questions/11981282/convert-json-to-datatable
        // Call Method Example:
        // List<User> UserList = JsonConvert.DeserializeObject<List<User>>(jsonString);
        // UserList.DynamicDataToDataTable<User>();
        //DataTable dt = (DataTable)JsonConvert.DeserializeObject(json, (typeof(DataTable)));
        public static DataTable DynamicDataToDataTable<T>(this IList<T> data)
		{
			PropertyDescriptorCollection props =
			TypeDescriptor.GetProperties(typeof(T));
			DataTable table = new DataTable();
			for (int i = 0; i < props.Count; i++)
			{
				PropertyDescriptor prop = props[i];
				table.Columns.Add(prop.Name, prop.PropertyType);
			}
			object[] values = new object[props.Count];
			foreach (T item in data)
			{
				for (int i = 0; i < values.Length; i++)
				{
					values[i] = props[i].GetValue(item);
				}
				table.Rows.Add(values);
			}
			return table;
		}



        public static byte[] ConvertStreamtoByteArray(IFormFile path)
        {
            var stream = path.OpenReadStream();


            byte[] by;


            using (BinaryReader br = new BinaryReader(stream))
            {
                by = br.ReadBytes((int)stream.Length);
            }



            return by;
        }
    }
}
