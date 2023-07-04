using DemoDoAn.ChildForm;
using DemoDoAn.ChildPage.General_Management.UC_GM_CLASS;
using DemoDoAn.ChildPage.HocTap;
using DemoDoAn.HOCVIEN.Class;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DemoDoAn.ChildPage.Student
{
    public partial class UC_STUDENT_DSHocVien : UserControl
    {
        HocSinhDao hocsinhDao = new HocSinhDao();
        DangKiLopDao dklDao = new DangKiLopDao();
        BangDiemDAO BangDiemDAO = new BangDiemDAO();
        TKBDao tkbDao = new TKBDao();
        DataTable dtSinhVien = null;

        HocSinh hv = new HocSinh();

        enum nameCol_DSHV
        {
            STT,
            HVID,
            HOTEN,
            GIOITINH,
            NGAYSINH,
            XoaIcon
        }
        enum nameCol_DSLDaHoc
        {
            STT_DSL,
            MaLop_DSL,
            TenMon_DSL,
            NgayBatDau_DSL,
            NgayKetThuc_DSL,
            TrangThai_DSL
        }
        enum nameCol_BangDiem
        {
            STT_BD,
            MaLop_BD,
            TenMon_BD,
            DiemGiuaKy_BD,
            DiemCuoiKy_BD,
            DiemTB_BD
        }
        enum nameCol_HocPhi
        {
            STT_HP,
            MaLop_HP,
            TenMon_HP,
            HocPhi_HP,
            TrangThai_HP
        }

        bool Them = false;
        bool Sua = false;
        public UC_STUDENT_DSHocVien()
        {
            InitializeComponent();
        }

        #region DOHOA
        private void ChooseTable(DataGridView dtg, ref bool table)
        {
            if (table == false)
            {
                dtg.Visible = true;
                table = true;
            }
            else
            {
                dtg.Visible = false;
                table = false;
            }
        }
        bool isDSLopDaHoc = false;
        private void btn_DSLopDaHoc_Click(object sender, EventArgs e)
        {
            ChooseTable(dataGrView_DSLopDaHoc, ref isDSLopDaHoc);
        }
        bool isBangDiem = false;
        private void btn_BangDiem_Click(object sender, EventArgs e)
        {
            ChooseTable(dataGrView_BangDiem, ref isBangDiem);
        }
        bool isBangHocPhi = false;
        private void btn_BangHocPhi_Click(object sender, EventArgs e)
        {
            ChooseTable(dataGrView_BangHocPhi, ref isBangHocPhi);
        }
        bool isEmpty_Search = true;
        private void txt_Search_Click(object sender, EventArgs e)
        {
            an_SearchText(txt_Search, ref isEmpty_Search);
        }
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
        #endregion

        private void UC_STUDENT_DSHocVien_Load(object sender, EventArgs e)
        {
            taiDSHV();
        }

        #region LOADFORM
        //load form DSHV
        private void taiDSHV()
        {
            LoadForm(this.dataGrView_DSHocVien, hocsinhDao.LayDanhSachSinhVien());
            for (int i = 0; i < dataGrView_DSHocVien.Columns.Count; i++)
            {
                DataGridViewColumn colDtg = dataGrView_DSHocVien.Columns[i];
                colDtg.Visible = false;
            }
            //hiện những cột cần, name của các cột được lưu trong Enum
            foreach (nameCol_DSHV day in Enum.GetValues(typeof(nameCol_DSHV)))
            {
                for (int i = 0; i < dataGrView_DSHocVien.Columns.Count; i++)
                {
                    DataGridViewColumn colDtg = dataGrView_DSHocVien.Columns[i];
                    if (colDtg.Name.ToString() == day.ToString())
                    {
                        colDtg.Visible = true;
                        break;
                    }
                }
            }
            dataGrView_DSHocVien.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        //load lớp đã đk
        private void taiDSLDangKy(string hvID)
        {
            LoadForm(this.dataGrView_DSLopDaHoc, dklDao.LayDanhSachLopDaDangKi(hvID));
            for (int i = 0; i < dataGrView_DSLopDaHoc.Columns.Count; i++)
            {
                DataGridViewColumn colDtg = dataGrView_DSLopDaHoc.Columns[i];
                colDtg.Visible = false;
            }
            //hiện những cột cần, name của các cột được lưu trong Enum
            foreach (nameCol_DSLDaHoc day in Enum.GetValues(typeof(nameCol_DSLDaHoc)))
            {
                for (int i = 0; i < dataGrView_DSLopDaHoc.Columns.Count; i++)
                {
                    DataGridViewColumn colDtg = dataGrView_DSLopDaHoc.Columns[i];
                    if (colDtg.Name.ToString() == day.ToString())
                    {
                        colDtg.Visible = true;
                        break;
                    }
                }
            }
            dataGrView_DSLopDaHoc.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        //load bang diem
        private void taiBangDiem(string hvID)
        {
            LoadForm(dataGrView_BangDiem, hocsinhDao.taiBangDiem(hvID));
            for (int i = 0; i < dataGrView_BangDiem.Columns.Count; i++)
            {
                DataGridViewColumn colDtg = dataGrView_BangDiem.Columns[i];
                colDtg.Visible = false;
            }
            //hiện những cột cần, name của các cột được lưu trong Enum
            foreach (nameCol_BangDiem day in Enum.GetValues(typeof(nameCol_BangDiem)))
            {
                for (int i = 0; i < dataGrView_BangDiem.Columns.Count; i++)
                {
                    DataGridViewColumn colDtg = dataGrView_BangDiem.Columns[i];
                    if (colDtg.Name.ToString() == day.ToString())
                    {
                        colDtg.Visible = true;
                        break;
                    }
                }
            }
            dataGrView_BangDiem.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        //load bang hoc phi
        private void taiBangHocPhi(DataGridView dtg,string hvID)
        {
            LoadForm(dataGrView_BangHocPhi, tkbDao.loadDSL(hvID));
            for (int i = 0; i < dtg.Columns.Count; i++)
            {
                DataGridViewColumn colDtg = dtg.Columns[i];
                colDtg.Visible = false;
            }
            //hiện những cột cần, name của các cột được lưu trong Enum
            foreach (nameCol_HocPhi day in Enum.GetValues(typeof(nameCol_HocPhi)))
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
        }
        //load datagrview
        private void LoadForm(DataGridView dtg, DataTable dt)
        {
            dtg.DataSource = dt;
        }
        #endregion

        //them hoc vien
        private void btn_ThemHocVien_Click(object sender, EventArgs e)
        {
            F_STUDENT_THEMHOCVIEN themHV = new F_STUDENT_THEMHOCVIEN();
            themHV.ShowDialog();
            taiDSHV();
        }

        //cap nhat thong tin
        private void btn_CapNhat_Click(object sender, EventArgs e)
        {
            try
            {
                F_STUDENT_CAPNHAT capNhatHV = new F_STUDENT_CAPNHAT(hv);
                capNhatHV.ShowDialog();
                taiDSHV();
            }
            catch 
            {
                MessageBox.Show("Học viên không xác định!");

            }
        }
        //cap nhat HV dc chon trong datagrview
        private HocSinh capNhatHV(ref HocSinh hv, string gvid, string hoten, string cmnd, DateTime ngaysinh, string gioitinh, string sdt, string diachi, string email, string accid, string username, string password)
        {
            hv.HSID = gvid;
            hv.HOTEN = hoten;
            hv.CMND = cmnd;
            hv.NGAYSINH = ngaysinh;
            hv.GIOITINH = gioitinh;
            hv.SDT = sdt;
            hv.DIACHI = diachi;
            hv.EMAIL = email;
            hv.ACCID = accid;
            hv.USERNAME = username;
            hv.PASSWORD = password;
            return hv;
        }

        //button RESET
        private void btnReset_Click(object sender, EventArgs e)
        {
            thucHienReset(dataGrView_DSHocVien, txt_Search);
            dataGrView_DSHocVien.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        //thuc hien reset
        private void thucHienReset(DataGridView dtg, TextBox txt_Search)
        {
            // hiển thị tất cả các dòng
            dtg.Rows.Cast<DataGridViewRow>().ToList().ForEach(r => r.Visible = true);
            hien_SearchText(txt_Search, ref isEmpty_Search);
        }

        //button TIMKIEM
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string duLieu = txt_Search.Text.ToString().Trim();
            thucHienTimKiem(dataGrView_DSHocVien, duLieu);
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
                        foreach (nameCol_DSHV day in Enum.GetValues(typeof(nameCol_DSHV)))
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

        //KeyPrees thay cho 'Click'
        private void txt_Search_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                thucHienTimKiem(dataGrView_DSHocVien, txt_Search.Text.ToString().Trim());
            }
            else if (e.KeyCode == Keys.Escape)
            {
                thucHienReset(dataGrView_DSHocVien, txt_Search);
            }
        }

        //xu li datagrview + Xoa hoc vien
        private void dataGrView_DSHocVien_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridView dtg = sender as DataGridView;
                //cập nhật hoc viên đang được chọn
                string hvID = dataGrView_DSHocVien.Rows[e.RowIndex].Cells["HVID"].Value.ToString().Trim();
                string ten = dataGrView_DSHocVien.Rows[e.RowIndex].Cells["HOTEN"].Value.ToString().Trim();
                string cmnd = dataGrView_DSHocVien.Rows[e.RowIndex].Cells["CMND"].Value.ToString().Trim();
                DateTime ngaySinh = Convert.ToDateTime(dataGrView_DSHocVien.Rows[e.RowIndex].Cells["NGAYSINH"].Value.ToString().Trim());
                string gioiTinh = dataGrView_DSHocVien.Rows[e.RowIndex].Cells["GIOITINH"].Value.ToString().Trim();
                string SDT = dataGrView_DSHocVien.Rows[e.RowIndex].Cells["SDT"].Value.ToString().Trim();
                string diaChi = dataGrView_DSHocVien.Rows[e.RowIndex].Cells["DIACHI"].Value.ToString().Trim();
                string email = dataGrView_DSHocVien.Rows[e.RowIndex].Cells["EMAIL"].Value.ToString().Trim();
                string accID = dataGrView_DSHocVien.Rows[e.RowIndex].Cells["AccID_Stu"].Value.ToString().Trim();
                string username = dataGrView_DSHocVien.Rows[e.RowIndex].Cells["username"].Value.ToString().Trim();
                string password = dataGrView_DSHocVien.Rows[e.RowIndex].Cells["pass"].Value.ToString().Trim();
                hv = capNhatHV(ref hv, hvID, ten, cmnd, ngaySinh, gioiTinh, SDT, diaChi, email, accID, username, password);

                taiDSLDangKy(hv.HSID);
                taiBangDiem(hv.HSID);
                taiBangHocPhi(dataGrView_BangHocPhi, hv.HSID);

                DataGridViewRow row = dataGrView_DSHocVien.Rows[e.RowIndex];
                if (dtg.Columns[e.ColumnIndex].HeaderText == "Xóa")
                {
                    //xóa tài khoản -> tự động xóa thông tin
                    hocsinhDao.xoaTaiKhoan(hv.ACCID);
                    taiDSHV();
                }
            }
            catch
            {
                //
            }
        }

        //tu động chọn HV khi không click
        private void dataGrView_DSHocVien_SelectionChanged(object sender, EventArgs e)
        {
            DataGridView dtg = sender as DataGridView;
            // Kiểm tra xem có dòng nào được chọn hay không
            if (dtg.SelectedRows.Count > 0)
            {
                // Lấy chỉ số (index) dòng đầu tiên được chọn
                int rowIndex = dtg.SelectedRows[0].Index;

                //cập nhật hoc viên đang được chọn
                string hvID = dataGrView_DSHocVien.Rows[rowIndex].Cells["HVID"].Value.ToString().Trim();
                string ten = dataGrView_DSHocVien.Rows[rowIndex].Cells["HOTEN"].Value.ToString().Trim();
                string cmnd = dataGrView_DSHocVien.Rows[rowIndex].Cells["CMND"].Value.ToString().Trim();
                DateTime ngaySinh = Convert.ToDateTime(dataGrView_DSHocVien.Rows[rowIndex].Cells["NGAYSINH"].Value.ToString().Trim());
                string gioiTinh = dataGrView_DSHocVien.Rows[rowIndex].Cells["GIOITINH"].Value.ToString().Trim();
                string SDT = dataGrView_DSHocVien.Rows[rowIndex].Cells["SDT"].Value.ToString().Trim();
                string diaChi = dataGrView_DSHocVien.Rows[rowIndex].Cells["DIACHI"].Value.ToString().Trim();
                string email = dataGrView_DSHocVien.Rows[rowIndex].Cells["EMAIL"].Value.ToString().Trim();
                string accID = dataGrView_DSHocVien.Rows[rowIndex].Cells["AccID_Stu"].Value.ToString().Trim();
                string username = dataGrView_DSHocVien.Rows[rowIndex].Cells["username"].Value.ToString().Trim();
                string password = dataGrView_DSHocVien.Rows[rowIndex].Cells["pass"].Value.ToString().Trim();
                hv = capNhatHV(ref hv, hvID, ten, cmnd, ngaySinh, gioiTinh, SDT, diaChi, email, accID, username, password);
                taiDSLDangKy(hv.HSID);
                taiBangDiem(hv.HSID);
                taiBangHocPhi(dataGrView_BangHocPhi, hv.HSID);
            }

        }

        //danh STT
        private void dataGrView_DSHocVien_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            DataGridViewRow row = dataGrView_DSHocVien.Rows[e.RowIndex];
            row.Cells[0].Value = (e.RowIndex + 1).ToString();

        }
        private void dataGrView_DSLopDaHoc_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            DataGridViewRow row = dataGrView_DSLopDaHoc.Rows[e.RowIndex];
            row.Cells[0].Value = (e.RowIndex + 1).ToString();
        }
        private void dataGrView_BangDiem_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            DataGridViewRow row = dataGrView_BangDiem.Rows[e.RowIndex];
            row.Cells[0].Value = (e.RowIndex + 1).ToString();
        }
        private void dataGrView_BangHocPhi_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            DataGridViewRow row = dataGrView_BangHocPhi.Rows[e.RowIndex];
            row.Cells[0].Value = (e.RowIndex + 1).ToString();
        }
    }
}
