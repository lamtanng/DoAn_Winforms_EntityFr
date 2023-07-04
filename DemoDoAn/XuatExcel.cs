using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using Microsoft.Office.Core;
using OfficeOpenXml;
namespace DemoDoAn
{
    public class XuatExcel
    {
        private void ToExcel(DataGridView dataGridView1, string fileName)
        {
            //khai báo thư viện hỗ trợ Microsoft.Office.Interop.Excel
            Microsoft.Office.Interop.Excel.Application excel;
            Microsoft.Office.Interop.Excel.Workbook workbook;
            Microsoft.Office.Interop.Excel.Worksheet worksheet;
            try
            {
                //Tạo đối tượng COM.
                excel = new Microsoft.Office.Interop.Excel.Application();
                excel.Visible = false;
                excel.DisplayAlerts = false;
                //tạo mới một Workbooks bằng phương thức add()
                workbook = excel.Workbooks.Add(Type.Missing);
                worksheet = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Sheets["Sheet1"];
                //đặt tên cho sheet
                worksheet.Name = "Quản lý học sinh";

                // export header trong DataGridView
                for (int i = 0; i < dataGridView1.ColumnCount; i++)
                {
                    worksheet.Cells[1, i + 1] = dataGridView1.Columns[i].HeaderText;
                }
                // export nội dung trong DataGridView
                for (int i = 0; i < dataGridView1.RowCount - 1; i++)
                {
                    for (int j = 0; j < dataGridView1.ColumnCount; j++)
                    {
                        DateTime dateValue;
                        if (dataGridView1.Columns[j].HeaderText == "NgayThangNamSinh")
                        {
                            DateTime.TryParse(dataGridView1.Rows[i].Cells[j].Value.ToString(), out dateValue);
                            worksheet.Cells[i + 2, j + 1].Value = dateValue.ToString("dd/MM/yyyy");
                        }
                        else
                            worksheet.Cells[i + 2, j + 1] = dataGridView1.Rows[i].Cells[j].Value.ToString();
                    }
                }
                // sử dụng phương thức SaveAs() để lưu workbook với filename
                workbook.SaveAs(fileName);
                //đóng workbook
                workbook.Close();
                excel.Quit();
                MessageBox.Show("Xuất dữ liệu ra Excel thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                workbook = null;
                worksheet = null;
            }
        }

        public void FoderExcel(DataGridView v)
        {
            SaveFileDialog mySaveDialog = new SaveFileDialog(); // Tạo một đối tượng SaveFileDialog mới với tên là mySaveDialog

            mySaveDialog.Filter = "Text files (*.txt)|*.txt|Excel files (*.xlsx, *.xls)|*.xlsx;*.xls|All files (*.*)|*.*";
            // Thiết lập bộ lọc cho loại tệp cần lưu
            mySaveDialog.Title = "Xuất Excel"; // Thiết lập tiêu đề cho hộp thoại

            if (mySaveDialog.ShowDialog() == DialogResult.OK)
            {
                //gọi hàm ToExcel() với tham số là dtgDSHS và filename từ SaveFileDialog
                ToExcel(v, mySaveDialog.FileName);
            }
        }
    }
    
}
