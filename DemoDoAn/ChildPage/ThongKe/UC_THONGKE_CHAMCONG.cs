using DemoDoAn.HOCVIEN.Class;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace DemoDoAn.ChildPage.ThongKe
{
    public partial class UC_THONGKE_CHAMCONG : UserControl
    {
        BangLuongDao luongDao = new BangLuongDao();
        DataTable dtLuong_12thang = new DataTable();
        //DataTable dtLuong_1thang = new DataTable();
        bieuDoChart bd_chart = new bieuDoChart();

        enum nameCol_Luong
        {
            STT, ID, HOTEN, Luong, LuongDay, PhuCap, TienThuong, TienBaoHiem, TongLuong
        }

        #region DOHOA
        bool isEmpty_Search = true;
        private void an_SearchText(TextBox txt_Search, ref bool isEmpty_Search)
        {
            if (isEmpty_Search == true)
            {
                txt_Search.Text = String.Empty;
                txt_Search.Font = new Font(txt_Search.Font, FontStyle.Regular);
                txt_Search.ForeColor = Color.DimGray;
                isEmpty_Search = false;
            }
        }
        private void hien_SearchText(TextBox txt_Search, ref bool isEmpty_Search)
        {
            txt_Search.Text = "Search...";
            txt_Search.Font = new Font("SFU Futura", 10F, FontStyle.Italic);
            txt_Search.ForeColor = Color.Silver;
            isEmpty_Search = true;
        }
        private void txt_Search_Click(object sender, EventArgs e)
        {
            an_SearchText(txt_Search, ref isEmpty_Search);
        }
        #endregion

        public UC_THONGKE_CHAMCONG()
        {
            InitializeComponent();
        }

        private void UC_THONGKE_CHAMCONG_Load(object sender, EventArgs e)
        {
            cbb_thangnam.SelectedItem = DateTime.Now.Month.ToString();
            taiBangLuong(dataGrView_BangLuong,ref dtLuong_12thang);
            chart_thong_ke_luong_theo_thang(DateTime.Now.Month);
        }

        //tai bang luong
        // Tải bảng lương đầu tiên khi vừa chạy thống kê ( 1 tháng )
        private void taiBangLuong(DataGridView dtg,ref DataTable dt)
        {
            dt.Rows.Clear();
            dt = luongDao.LayThongTinLuong();
            //loadForm(dtg, dt);
            //ẩn full các cột     
            for (int i = 0; i < dtg.Columns.Count; i++)
            {
                DataGridViewColumn colDtg = dtg.Columns[i];
                colDtg.Visible = false;
            }
            //hiện những cột cần, name của các cột được lưu trong Enum
            foreach (nameCol_Luong day in Enum.GetValues(typeof(nameCol_Luong)))
            {
                for (int i = 0; i < dtg.Columns.Count; i++)
                {
                    DataGridViewColumn colDtg = dtg.Columns[i];
                    if (colDtg.Name.ToString() == day.ToString())
                    {
                        colDtg.Visible = true;
                        break;
                    }
                }
            }
            dtg.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            // hàm tải bảng lương lên datagridview
            loadForm(dataGrView_BangLuong, luongThangHienTai(dt)) ;
        }
        //load dtg
        private void LoadForm(DataGridView dtg, DataTable dt)
        {
            dtg.DataSource = dt;
        }
        

        private void dataGrView_BangHocPhi_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //this.dataGrView_BangHocPhi.DataSource = luongDao.LayThongTinLuong("5");
            //dataGrView_DSGV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        //cap nhat
        private void btn_Reset_Click(object sender, EventArgs e)
        {

        }

        private void dataGrView_BangLuong_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void cbb_thangnam_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            dtLuong_12thang = luongDao.LayThongTinLuong();
            
            loadForm(dataGrView_BangLuong, luongThangHienTai(dtLuong_12thang));
        }

        //load dt
        private void loadForm(DataGridView dtg, DataTable dt)
        {
            dtg.DataSource = dt;
        }
        // Hàm tìm lương của tất cả nhân viên trong tháng
        private DataTable luongThangHienTai(DataTable tb_12thang)
        {
            DataTable tb_1thang = tb_12thang.Clone();
            for (int r = 0; r < tb_12thang.Rows.Count; r++)
            {
                //tìm những dòng có MãKH đã được chọn
                if (tb_12thang.Rows[r]["THANG"].ToString() == cbb_thangnam.SelectedItem.ToString().Trim())
                {
                    //tạo dataRow lưu hàng đó lại
                    DataRow newRow = tb_1thang.NewRow();
                    newRow.ItemArray = tb_12thang.Rows[r].ItemArray; // sao chép dữ liệu từ dòng r của dt vào newRow
                    tb_1thang.Rows.Add(newRow);
                }
            }
            return tb_1thang;
        }

        //////////////////////////////////////
        // load biểu đồ

        public string tong_luong_trong_thang(DataTable tb_12thang, string s)
        {
            int tong_luong = 0;
            for (int r = 0; r < tb_12thang.Rows.Count; r++)
            {
                //tìm những dòng có MãKH đã được chọn
                if (tb_12thang.Rows[r]["THANG"].ToString().Trim() == s)
                {
                    tong_luong = tong_luong + Convert.ToInt32(tb_12thang.Rows[r]["Tongluong"].ToString().Trim());
                }
            }
            return tong_luong.ToString();
        }

        // Hàm thống kê lương theo từng tháng để vẽ lên biểu đồ chart
        public void chart_thong_ke_luong_theo_thang(int thang)
        {
            salary_chart.Series["Salary"].Points.Clear();


            Random random = new Random();
            // Tạo một danh sách chứa các màu ngẫu nhiên
            List<Color> randomColors = new List<Color>();
            // Tạo màu ngẫu nhiên và thêm vào danh sách
           
            List<string> myList = new List<string>();
            //dtLuong_12thang = luongDao.LayThongTinLuong()
            DataTable dt = new DataTable();
            dt = luongThangHienTai(dtLuong_12thang);
            for (int i = 1; i <= thang; i++)
            {
                Color randomColor = Color.FromArgb(random.Next(256), random.Next(256), random.Next(256));
                randomColors.Add(randomColor);
                myList.Add(tong_luong_trong_thang(dtLuong_12thang, i.ToString()));
            }
            for (int i = 1; i <= thang; i++)
            {
                bd_chart.Chart_Salary(salary_chart, "Salary",  i.ToString(), Convert.ToInt32(myList[i - 1]));
                //salary_chart.Series["Salary"].Points.AddY(random.Next(100));
                salary_chart.Series["Salary"].Points[i-1].Color = randomColors[i-1];
            }

            
            

            
        }

        //
        private void txt_Search_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                thucHienTimKiem(dataGrView_BangLuong, txt_Search.Text.ToString(), typeof(nameCol_Luong));
            }
            else if (e.KeyCode == Keys.Escape)
            {
                thucHienReset(dataGrView_BangLuong, txt_Search, ref isEmpty_Search);
            }
        }
        //thuc hien tim kiem
        private void thucHienTimKiem(DataGridView dtg, string duLieu, Type enumType)
        {
            locDuLieuTimKiem(dtg, duLieu, enumType);
        }
        //lọc dữ liệu để tìm kiếm trong DataGridView
        private void locDuLieuTimKiem(DataGridView dtg, string searchText, Type enumType)
        {
            if (string.IsNullOrEmpty(searchText))
            {
                // Nếu không có dữ liệu nhập vào, hiển thị tất cả các dòng
                dtg.Rows.Cast<DataGridViewRow>().ToList().ForEach(r => r.Visible = true);
            }
            else
            {
                for (int r = 0; r < dtg.Rows.Count; r++)
                {
                    DataGridViewRow row = dtg.Rows[r];

                    //4 dòng fix lỗi : 'Row associated with the currency manager's position cannot be made invisible.'
                    CurrencyManager currencyManager1 = (CurrencyManager)BindingContext[dtg.DataSource];
                    currencyManager1.SuspendBinding();
                    row.Visible = false;
                    currencyManager1.ResumeBinding();

                    //tim kiem dữ liệu có chứa trong các ô của row không
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        //hiện những cột cần, name của các cột được lưu trong Enum
                        foreach (var day in Enum.GetValues(enumType))
                        {
                            //chỉ tìm trên các ô thuộc cột có trong enum:
                            if (dtg.Columns[cell.ColumnIndex].Name == day.ToString())
                            {
                                if (cell.Value != null && cell.Value.ToString().Contains(searchText))
                                {
                                    row.Visible = true;
                                    break;
                                }
                            }
                        }
                    }
                }


            }
        }
        //thuc hien reset
        private void thucHienReset(DataGridView dtg, TextBox txt_Search, ref bool isEmptyText)
        {
            // hiển thị tất cả các dòng
            dtg.Rows.Cast<DataGridViewRow>().ToList().ForEach(r => r.Visible = true);
            hien_SearchText(txt_Search, ref isEmptyText);
        }


        ////////////////////////////////////////////
        private void LoadForm(DataTable dt)
        {
            this.dataGrView_BangLuong.DataSource = dt;
        }

        private void salary_chart_Click(object sender, EventArgs e)
        {

        }

        private void pBox_CapNhatDiem_Click(object sender, EventArgs e)
        {
            for(int i = 0; i < dataGrView_BangLuong.Rows.Count; i++)
            {
                DataGridViewRow row = dataGrView_BangLuong.Rows[i];
                BangLuong luong = new BangLuong(row.Cells["ID"].Value.ToString().Trim(), row.Cells["HOTEN"].Value.ToString().Trim(),
                                                Convert.ToDouble( row.Cells["Luong"].Value.ToString()), Convert.ToDouble(row.Cells["PhuCap"].Value.ToString()),
                                                Convert.ToDouble(row.Cells["TienThuong"].Value.ToString()), Convert.ToDouble(row.Cells["TienBaoHiem"].Value.ToString()),
                                                Convert.ToDouble(row.Cells["THANG"].Value.ToString()));
                luongDao.LUULUONG(luong);
            }
            taiBangLuong(dataGrView_BangLuong, ref dtLuong_12thang);
            chart_thong_ke_luong_theo_thang(DateTime.Now.Month);
        }
    }
}
