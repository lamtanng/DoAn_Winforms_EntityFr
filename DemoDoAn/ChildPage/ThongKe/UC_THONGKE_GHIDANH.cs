using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DemoDoAn.ChildPage.ThongKe
{
    public partial class UC_THONGKE_GHIDANH : UserControl
    {
        ThongKeDao tkDao = new ThongKeDao();
        XuatExcel xuatExel = new XuatExcel();
        DataTable dtGhiDanh = new DataTable();
        bieuDoChart pie_chart = new bieuDoChart();

        enum nameCol_GhiDanh
        {
            STT,
            HVID,
            HOTEN,
            GIOITINH,
            //NGAYSINH,
            NgayDK
        }

        public UC_THONGKE_GHIDANH()
        {
            InitializeComponent();
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

        private void UC_THONGKE_GHIDANH_Load(object sender, EventArgs e)
        {
            taiBangGhiDanh();
            taiThongTin();
            taiThongTin();
        }


        //tai bang ghi danh
        private void taiBangGhiDanh()
        {
            dtGhiDanh.Rows.Clear();
            dtGhiDanh = tkDao.layBangGhiDanh();
            loadForm(dataGrView_GhiDanh, dtGhiDanh);
            //ẩn full các cột     
            for (int i = 0; i < dataGrView_GhiDanh.Columns.Count; i++)
            {
                DataGridViewColumn colDtg = dataGrView_GhiDanh.Columns[i];
                colDtg.Visible = false;
            }
            //hiện những cột cần, name của các cột được lưu trong Enum
            foreach (nameCol_GhiDanh day in Enum.GetValues(typeof(nameCol_GhiDanh)))
            {
                for (int i = 0; i < dataGrView_GhiDanh.Columns.Count; i++)
                {
                    DataGridViewColumn colDtg = dataGrView_GhiDanh.Columns[i];
                    if (colDtg.Name.ToString() == day.ToString())
                    {
                        colDtg.Visible = true;
                        break;
                    }
                }
            }
            dataGrView_GhiDanh.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

        }
        //load dtg
        private void loadForm(DataGridView dtg, DataTable dt)
        {
            dtg.DataSource = dt;
        }

        //tai thong tin
        private void taiThongTin()
        {
            lbl_SLTongHocVien.Text = dtGhiDanh.Rows.Count.ToString();
            int s = 0;
            for (int r = 0; r < dtGhiDanh.Rows.Count - 1; r++)
            {
                DataRow row = dtGhiDanh.Rows[r];
                string thang = Convert.ToDateTime( row["NgayDK"]).Month.ToString();
                string nam = Convert.ToDateTime(row["NgayDK"]).Year.ToString();

                if (thang == DateTime.Now.Month.ToString())
                {
                    ++s;
                }
            }
            lbl_SoHVDaHoanThanh.Text = s.ToString();

            double rate = (Convert.ToDouble(lbl_SoHVDaHoanThanh.Text) / Convert.ToDouble(lbl_MucTieu.Text)) *100;
            lbl_SoTiLe.Text = rate.ToString("F2");
            lbl_TiLeOverw.Text = lbl_SoTiLe.Text;
            cirPBar_TongQuan.Value =  (int)rate;
        }

        //danh STT
        private void dataGrView_GhiDanh_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            DataGridViewRow row = dataGrView_GhiDanh.Rows[e.RowIndex];
            if (row != dataGrView_GhiDanh.Rows[dataGrView_GhiDanh.Rows.Count - 1])
            {
                row.Cells[0].Value = (e.RowIndex + 1).ToString();
            }
        }

        //click tim kiem
        private void btn_Search_Click(object sender, EventArgs e)
        {
            string duLieu = txt_Search.Text.ToString();
            thucHienTimKiem(dataGrView_GhiDanh, duLieu);
        }
        //thuc hien tim kiem
        private void thucHienTimKiem(DataGridView dtg, string duLieu)
        {
            locDuLieuTimKiem(dtg, duLieu);
        }
        //lọc dữ liệu để tìm kiếm trong DataGridView
        private void locDuLieuTimKiem(DataGridView dtg, string searchText)
        {
            if (string.IsNullOrEmpty(searchText))
            {
                // Nếu không có dữ liệu nhập vào, hiển thị tất cả các dòng
                dtg.Rows.Cast<DataGridViewRow>().ToList().ForEach(r => r.Visible = true);
            }
            else
            {
                for (int r = 0; r < dtg.Rows.Count - 1; r++)
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
                        foreach (nameCol_GhiDanh day in Enum.GetValues(typeof(nameCol_GhiDanh)))
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


        //reset
        private void btn_Reset_Click(object sender, EventArgs e)
        {
            thucHienReset(dataGrView_GhiDanh, txt_Search);
        }
        //thuc hien reset
        private void thucHienReset(DataGridView dtg, TextBox txt_Search)
        {
            // hiển thị tất cả các dòng
            dtg.Rows.Cast<DataGridViewRow>().ToList().ForEach(r => r.Visible = true);
            hien_SearchText(txt_Search, ref isEmpty_Search);
        }

        private void btn_In_Click(object sender, EventArgs e)
        {
            xuatExel.FoderExcel(dataGrView_GhiDanh);
        }

        private void btn_BangHocPhi_Click(object sender, EventArgs e)
        {

        }
    }
}
