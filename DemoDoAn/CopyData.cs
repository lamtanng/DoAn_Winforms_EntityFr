using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DemoDoAn
{
    internal class CopyData
    {
        public DataTable ConvertToDataTable<T>(List<T> list)
        {
            DataTable dt = new DataTable();

            if (list.Count > 0)
            {
                // Lấy tên các thuộc tính của đối tượng đầu tiên trong danh sách
                PropertyInfo[] properties = list[0].GetType().GetProperties();

                // Tạo các cột trong DataTable dựa trên tên thuộc tính
                foreach (PropertyInfo property in properties)
                {
                    dt.Columns.Add(property.Name, Nullable.GetUnderlyingType(property.PropertyType) ?? property.PropertyType);
                }

                // Thêm dữ liệu vào DataTable
                foreach (T item in list)
                {
                    DataRow row = dt.NewRow();

                    // Gán giá trị từ các thuộc tính của đối tượng vào các cột tương ứng trong DataRow
                    foreach (PropertyInfo property in properties)
                    {
                        row[property.Name] = property.GetValue(item) ?? DBNull.Value;
                    }

                    dt.Rows.Add(row);
                }
            }

            return dt;
        }
    }
}
