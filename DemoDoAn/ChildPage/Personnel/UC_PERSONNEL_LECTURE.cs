using DemoDoAn.ChildPage.General_Management.UC_GM_CLASS;
using DemoDoAn.ChildPage.Personnel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Xml.Linq;

namespace DemoDoAn.ChildPage
{
    public partial class UC_PERSONNEL_LECTURE : UserControl
    {

        GiaoVienDao giaoVienDao = new GiaoVienDao();
        GiaoVien gv = new GiaoVien();
        //DataTable dsGV = new DataTable();

        //các cột của bảng DSGV
        enum name_CotDSGV
        {
            STT,
            GvID,
            HOTEN,
            GIOITINH,
            Xoa
        }
        //các cột bảng DSL
        enum name_CotDSL
        {
            STT_DSL,
            MaLop_DSL,
            TenMon_DSL,
            TenKH_DSL,
            SoHocVien_DSL,
            HocPhi_DSL,
            TrangThai_DSL
        }

        public UC_PERSONNEL_LECTURE()
        {

            InitializeComponent();
        }

        #region DoHoa
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
        private void txt_TimKiem_Click(object sender, EventArgs e)
        {
            an_SearchText(txt_Search, ref isEmpty_Search);
        }
        #endregion

        private void UC_PERSONNEL_LECTURE_Load(object sender, EventArgs e)
        {
            taiDSGV();
        }

        //load datagrview
        private void LoadForm(DataGridView dtg, DataTable dt)
        {
            dtg.DataSource = dt;
        }

        //them giang vien moi
        private void pBox_Them_Click(object sender, EventArgs e)
        {
            F_LECTURE_THEMGIANGVIEN themGV = new F_LECTURE_THEMGIANGVIEN();
            themGV.ShowDialog();
            taiDSGV();
        }

        //cap nhat thông tin GV
        private void pBox_CapNhat_Click(object sender, EventArgs e)
        {

            //DateTime ngaysinh = Convert.ToDateTime(lbl_NgaySinh.Text.ToString().Trim());
            //GiaoVien gv = new GiaoVien(lbl_MaGV.Text.ToString(), lbl_TenGV.Text.ToString(), lblcccd.Text.ToString(),ngaysinh , lbl_GioiTinh.Text.ToString(), btn_SDT.Text.ToString(), lbl_DiaChi.Text.ToString(), btn_Email.Text.ToString(), "", "", "");
            F_LECTURE_CAPNHAT capNhatGV = new F_LECTURE_CAPNHAT(gv);
            capNhatGV.ShowDialog();
            taiDSGV();
        }

        //xử lí dataGrview / XOA GV
        private void dataGrView_DSGV_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dtg = sender as DataGridView;


            try
            {
                //cập nhật giáo viên đang được chọn
                string gvID = dataGrView_DSGV.Rows[e.RowIndex].Cells["GvID"].Value.ToString().Trim();
                string ten = dataGrView_DSGV.Rows[e.RowIndex].Cells["HOTEN"].Value.ToString().Trim();
                string cmnd = dataGrView_DSGV.Rows[e.RowIndex].Cells["CMND"].Value.ToString().Trim();
                DateTime ngaySinh = Convert.ToDateTime(dataGrView_DSGV.Rows[e.RowIndex].Cells["NGAYSINH"].Value.ToString().Trim());
                string gioiTinh = dataGrView_DSGV.Rows[e.RowIndex].Cells["GIOITINH"].Value.ToString().Trim();
                string SDT = dataGrView_DSGV.Rows[e.RowIndex].Cells["SDT"].Value.ToString().Trim();
                string diaChi = dataGrView_DSGV.Rows[e.RowIndex].Cells["DIACHI"].Value.ToString().Trim();
                string email = dataGrView_DSGV.Rows[e.RowIndex].Cells["EMAIL"].Value.ToString().Trim();
                string accID = dataGrView_DSGV.Rows[e.RowIndex].Cells["AccID_Tea"].Value.ToString().Trim();
                string username = dataGrView_DSGV.Rows[e.RowIndex].Cells["username"].Value.ToString().Trim();
                string password = dataGrView_DSGV.Rows[e.RowIndex].Cells["pass"].Value.ToString().Trim();
                gv = capNhatGV(ref gv, gvID, ten, cmnd, ngaySinh, gioiTinh, SDT, diaChi, email, accID, username, password);

                //hiển thông tin + dsl dạy của GV đó
                hienThongTinGV(gioiTinh, gvID, ten, diaChi, ngaySinh, SDT, email, cmnd);
                taiDSLDangDay(gv);

                //xóa GV
                if (dtg.Columns[e.ColumnIndex].HeaderText == "Xóa")
                {
                    //xoa acc -> tự động xóa thông tin -> set ON DELETE CASCADE
                    giaoVienDao.xoaTaiKhoan(gv.ACCID);
                    LoadForm(dataGrView_DSGV, giaoVienDao.LayDanhSachGiaoVien());
                }
            }
            catch
            {
                //MessageBox.Show("sss");
            }

        }

        //cap nhat GV dc chon trong datagrview
        private GiaoVien capNhatGV(ref GiaoVien gv, string gvid, string hoten, string cmnd, DateTime ngaysinh, string gioitinh, string sdt, string diachi, string email, string accid, string username, string password)
        {
            gv.GVID = gvid;
            gv.HOTEN = hoten;
            gv.CMND = cmnd;
            gv.NGAYSINH = ngaysinh;
            gv.GIOITINH = gioitinh;
            gv.SDT = sdt;
            gv.DIACHI = diachi;
            gv.EMAIL = email;
            gv.ACCID = accid;
            gv.USERNAME = username;
            gv.PASSWORD = password;
            return gv;
        }

        //hien thong tin GV
        private void hienThongTinGV(string gioitinh, string magv, string tengv, string diachi, DateTime ngaysinh, string sdt, string email, string cmnd)
        {

            lbl_GioiTinh.Text = gioitinh.ToString().Trim();
            lbl_MaGV.Text = magv.ToString().Trim();
            lbl_TenGV.Text = tengv.ToString().Trim();
            lbl_DiaChi.Text = diachi.ToString().Trim();
            lbl_NgaySinh.Text = ngaysinh.ToString("dd/MM/yyyy").Trim();
            btn_SDT.Text = sdt.ToString().Trim();
            btn_Email.Text = email.ToString().Trim();
            lblcccd.Text = cmnd.ToString().Trim();
        }

        //load dsl dang day
        private void taiDSLDangDay(GiaoVien gv)
        {
            DataTable dsLop = new DataTable();
            dsLop = giaoVienDao.LayThongTinGiaoVienVaLop(gv.GVID);
            LoadForm(dataGrView_CacLopDay, dsLop);
            //ẩn full các cột
            for (int i = 0; i < dataGrView_CacLopDay.Columns.Count; i++)
            {
                DataGridViewColumn colDtg = dataGrView_CacLopDay.Columns[i];
                colDtg.Visible = false;
            }
            //hiện những cột cần, name của các cột được lưu trong Enum
            foreach (name_CotDSL day in Enum.GetValues(typeof(name_CotDSL)))
            {
                for (int i = 0; i < dataGrView_CacLopDay.Columns.Count; i++)
                {
                    DataGridViewColumn colDtg = dataGrView_CacLopDay.Columns[i];
                    if (colDtg.Name.ToString() == day.ToString())
                    {
                        colDtg.Visible = true;
                        break;
                    }
                }
            }
            dataGrView_CacLopDay.Sort(dataGrView_CacLopDay.Columns["MaLop_DSL"], ListSortDirection.Ascending);

        }

        //load form dsGV
        private void taiDSGV()
        {
            LoadForm(dataGrView_DSGV, giaoVienDao.LayDanhSachGiaoVien());
            //ẩn full các cột     
            for (int i = 0; i < dataGrView_DSGV.Columns.Count; i++)
            {
                DataGridViewColumn colDtg = dataGrView_DSGV.Columns[i];
                colDtg.Visible = false;
            }
            //hiện những cột cần, name của các cột được lưu trong Enum
            foreach (name_CotDSGV day in Enum.GetValues(typeof(name_CotDSGV)))
            {
                for (int i = 0; i < dataGrView_DSGV.Columns.Count; i++)
                {
                    DataGridViewColumn colDtg = dataGrView_DSGV.Columns[i];
                    if (colDtg.Name.ToString() == day.ToString())
                    {
                        colDtg.Visible = true;
                        break;
                    }
                }
            }
        }


        //Key thay cho "Click"
        private void txt_TimKiem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                thucHienTimKiem(dataGrView_DSGV, txt_Search.Text.ToString(), typeof(name_CotDSGV));
            }
            else if (e.KeyCode == Keys.Escape)
            {
                thucHienReset(dataGrView_DSGV, txt_Search, ref isEmpty_Search);
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



        //danh STT
        private void dataGrView_DSGV_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            DataGridViewRow row = dataGrView_DSGV.Rows[e.RowIndex];
            row.Cells[0].Value = (e.RowIndex + 1).ToString();
        }
        private void dataGrView_CacLopDay_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            DataGridViewRow row = dataGrView_CacLopDay.Rows[e.RowIndex];
            row.Cells[0].Value = (e.RowIndex + 1).ToString();
        }

        //tự động hiện thông tin GV theo dòng được chọn khi không Click
        private void dataGrView_DSGV_SelectionChanged(object sender, EventArgs e)
        {

            DataGridView dtg = sender as DataGridView;
            if(dtg.SelectedRows.Count > 0)
            {
                // Lấy chỉ số (index) dòng đầu tiên được chọn
                int rowIndex = dtg.SelectedRows[0].Index;
                //cập nhật giáo viên đang được chọn
                string gvID = dataGrView_DSGV.Rows[rowIndex].Cells["GvID"].Value.ToString().Trim();
                string ten = dataGrView_DSGV.Rows[rowIndex].Cells["HOTEN"].Value.ToString().Trim();
                string cmnd = dataGrView_DSGV.Rows[rowIndex].Cells["CMND"].Value.ToString().Trim();
                DateTime ngaySinh = Convert.ToDateTime(dataGrView_DSGV.Rows[rowIndex].Cells["NGAYSINH"].Value.ToString().Trim());
                string gioiTinh = dataGrView_DSGV.Rows[rowIndex].Cells["GIOITINH"].Value.ToString().Trim();
                string SDT = dataGrView_DSGV.Rows[rowIndex].Cells["SDT"].Value.ToString().Trim();
                string diaChi = dataGrView_DSGV.Rows[rowIndex].Cells["DIACHI"].Value.ToString().Trim();
                string email = dataGrView_DSGV.Rows[rowIndex].Cells["EMAIL"].Value.ToString().Trim();
                string accID = dataGrView_DSGV.Rows[rowIndex].Cells["AccID_Tea"].Value.ToString().Trim();
                string username = dataGrView_DSGV.Rows[rowIndex].Cells["username"].Value.ToString().Trim();
                string password = dataGrView_DSGV.Rows[rowIndex].Cells["pass"].Value.ToString().Trim();
                gv = capNhatGV(ref gv, gvID, ten, cmnd, ngaySinh, gioiTinh, SDT, diaChi, email, accID, username, password);
                //hiển thông tin + dsl dạy của GV đó
                hienThongTinGV(gioiTinh, gvID, ten, diaChi, ngaySinh, SDT, email, cmnd);
                taiDSLDangDay(gv);
            }
            
        }


    }
}
