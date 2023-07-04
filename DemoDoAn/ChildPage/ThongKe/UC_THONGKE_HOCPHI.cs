using DemoDoAn.HOCVIEN.Class;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.Windows.Controls;
using System.Windows.Forms;

namespace DemoDoAn.ChildPage.ThongKe
{
    public partial class UC_THONGKE_HOCPHI : UserControl
    {
        ThongKeDao tkDao = new ThongKeDao();   
        DataTable dtHP = new DataTable();
        bieuDoChart bdc = new bieuDoChart();
        enum nameCol_HP
        {
            STT,
            HVID,
            HOTEN,
            TenMon,
            HocPhi,
            TrangThai,
            DaDong,
            ConNo
        }

        public UC_THONGKE_HOCPHI()
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

        private void UC_THONGKE_HOCPHI_Load(object sender, EventArgs e)
        {
            taiBangHP();
            thongKe();
        }

        //load dtg
        private void loadForm(DataGridView dtg, DataTable dt)
        {
            dtg.DataSource = dt;
        }
        //tai bang hoc phi
        private void taiBangHP()
        {
            dtHP.Rows.Clear();
            dtHP = tkDao.layBangHocPhi();
            loadForm(dataGrView_BangHocPhi, dtHP);
            //ẩn full các cột     
            for (int i = 0; i < dataGrView_BangHocPhi.Columns.Count; i++)
            {
                DataGridViewColumn colDtg = dataGrView_BangHocPhi.Columns[i];
                colDtg.Visible = false;
            }
            //hiện những cột cần, name của các cột được lưu trong Enum
            foreach (nameCol_HP day in Enum.GetValues(typeof(nameCol_HP)))
            {
                for (int i = 0; i < dataGrView_BangHocPhi.Columns.Count; i++)
                {
                    DataGridViewColumn colDtg = dataGrView_BangHocPhi.Columns[i];
                    if (colDtg.Name.ToString() == day.ToString())
                    {
                        colDtg.Visible = true;
                        break;
                    }
                }
            }
            dataGrView_BangHocPhi.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }


        //
        private void txt_Search_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                thucHienTimKiem(dataGrView_BangHocPhi, txt_Search.Text.ToString(), typeof(nameCol_HP));
            }
            else if (e.KeyCode == Keys.Escape)
            {
                thucHienReset(dataGrView_BangHocPhi, txt_Search, ref isEmpty_Search);
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

        //load thong ke
        private void thongKe()
        {
            double tongHocPhi = 0;
            double tongThu = 0;
            dtHP = tkDao.layBangHocPhi();
            lbl_TongSoLuong.Text = dataGrView_BangHocPhi.Rows.Count.ToString();
            double dadongHocPhi = 0;
            for (int r = 0; r < dtHP.Rows.Count; r++)
            {
                //tìm những dòng có HocPhi đã được chọn
                tongHocPhi = Convert.ToInt32(dtHP.Rows[r]["HocPhi"].ToString()) + tongHocPhi;
                tongThu = Convert.ToInt32(dtHP.Rows[r]["DaDong"].ToString()) + tongThu;
                if (dtHP.Rows[r]["ConNo"].ToString() == "0")
                    dadongHocPhi++;
            }
            lbl_HoanThanh.Text = dadongHocPhi.ToString();
            double chua_hoang_thanh = Convert.ToDouble(dataGrView_BangHocPhi.Rows.Count.ToString()) - dadongHocPhi;
            lbl_ChuaHoanThanh.Text = Convert.ToString(chua_hoang_thanh);
            lbl_TiLeHoanThanh.Text = ((dadongHocPhi / Convert.ToDouble(lbl_TongSoLuong.Text)) * 100).ToString("F2");

            lbl_TongTienHP.Text = tongHocPhi.ToString("#,##0", CultureInfo.GetCultureInfo("vi-VN")).Replace(",", "."); ;
            lbl_TongHPDaThu.Text = tongThu.ToString("#,##0", CultureInfo.GetCultureInfo("vi-VN")).Replace(",", "."); ;
            double da_dong = (tongThu / tongHocPhi);
            bdc.Chart_Salary(chart_hoc_phi, "chart_thong_ke_hoc_phi", "Còn nợ", 1- da_dong);
            bdc.Chart_Salary(chart_hoc_phi, "chart_thong_ke_hoc_phi", "Đã đóng", da_dong);
            chart_hoc_phi.Series["chart_thong_ke_hoc_phi"].IsValueShownAsLabel = true;
            chart_hoc_phi.Series["chart_thong_ke_hoc_phi"].LabelFormat = ".%";




        }

        //danh STT
        private void dataGrView_BangHocPhi_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            DataGridViewRow row = dataGrView_BangHocPhi.Rows[e.RowIndex];
                row.Cells[0].Value = (e.RowIndex + 1).ToString();
        }

        private void dataGrView_BangHocPhi_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
