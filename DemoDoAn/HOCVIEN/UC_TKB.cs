using DemoDoAn.ChildPage.HocTap;
using DemoDoAn.GIANGVIEN;
using DemoDoAn.HOCVIEN.Class;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
//using System.Runtime.InteropServices;
//using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DemoDoAn.HOCVIEN
{
    public partial class UC_TKB : UserControl
    {
        int chucVu; // 0 la admin;  1 la hocvien;  2 la giao vien
        int chucnang; //1:tkb   2:dkl

        public UC_TKB(int chucVu, int chucnang)
        {
            InitializeComponent();
            this.chucVu = chucVu;
            this.chucnang = chucnang;
        }

        private void UC_TKB_Load(object sender, EventArgs e)
        {
            layID();//lấy mssv // msgv
            creTKB();
            if (chucnang == 1)
            {
                pnl_QLTitleDKL.Visible = false;
                fLPnl_DSL.Visible = false;
                pnl_BangDiem.Visible = false;
                pnl_QLChiTietLH.Visible = false;
                pnl_QLKQDKL.Visible = false;
                pnl_PhanCach_DKL.Location = new Point(pnl_PHANCACH.Location.X, pnl_PHANCACH.Location.Y - 800 - pnl_QLDSL.Height - fLPnl_XacNhanLop.Height);
                pnl_PhanCach_DKL.SendToBack();
                pnl_PHANCACH.Location = new Point(pnl_PHANCACH.Location.X, pnl_PHANCACH.Location.Y - 800 - pnl_QLDSL.Height - fLPnl_XacNhanLop.Height);
                pnl_PHANCACH.SendToBack();
                if (chucVu == 1)//hocvien
                {
                    taiBangHocPhi(dataGrView_DSLop, dtHocPhi, ID);
                    taiBangDiemHV(ID);
                    pnl_QLCapNhatDiem.Visible = false;
                    fLPnl_XacNhanLop.Visible = false;
                    pnl_QLDSL.Visible = false;
                    fLPnl_QLTable.Height -= 359;
                    pnl_PHANCACH.Location = new Point(pnl_PHANCACH.Location.X, pnl_PHANCACH.Location.Y - 659 - pnl_QLDSL.Height - fLPnl_XacNhanLop.Height);
                }
                else if (chucVu == 2)//giang vien
                {
                    taiDSLFull();
                    taiDSLChuaDay();
                    taiDSLDangDay();
                    taiBangDiemGV(dataGrView_CapNhatDiem, maLop);
                    hienLopXacNhan();
                    pnl_QLThanhToan.Visible = false;
                    pnl_QLDiemHV.Visible = false;
                    fLPnl_QLTable.Height -= (pnl_QLThanhToan.Height + pnl_QLDiemHV.Height);
                    pnl_PHANCACH.Location = new Point(pnl_PHANCACH.Location.X, pnl_PHANCACH.Location.Y - pnl_QLThanhToan.Height - pnl_QLDiemHV.Height);
                }
            }
            else if (chucnang == 2)
            {
                pnl_QLTitleTKB.Visible = false;
                pnl_QLTKB.Visible = false;
                fLPnl_QLTable.Visible = false;
                pnl_QLTitleDKL.Location = new Point(pnl_QLTitleDKL.Location.X, pnl_QLTitleDKL.Location.Y - 2735);
                fLPnl_DSL.Location = new Point(fLPnl_DSL.Location.X, fLPnl_DSL.Location.Y - 2735);
                pnl_BangDiem.Location = new Point(pnl_BangDiem.Location.X, pnl_BangDiem.Location.Y - 2735);
                pnl_QLChiTietLH.Location = new Point(pnl_QLChiTietLH.Location.X, pnl_QLChiTietLH.Location.Y - 2735);
                pnl_QLKQDKL.Location = new Point(pnl_QLKQDKL.Location.X, pnl_QLKQDKL.Location.Y - 2735);
                pnl_PhanCach_DKL.Location = new Point(pnl_PHANCACH.Location.X, pnl_PHANCACH.Location.Y - 800 - pnl_QLDSL.Height - fLPnl_XacNhanLop.Height);
                pnl_PhanCach_DKL.SendToBack();
                if (chucVu == 1)//hocvien
                {
                    taiDSL_DaDangKy1();
                }
                else if (chucVu == 2)//giang vien
                {
                    taiDSLFull1();
                    taiDSLDangDay1();
                }

                taiDSLDangKy1();
                hienThongTinLopDaDangKy1();
                taiDSLNoiBat1();
            }
        }

        #region TKB
        TKBDao tkbDao = new TKBDao();
        HocSinhDao hsDao = new HocSinhDao();
        BangDiemDAO bangDiemDao = new BangDiemDAO();
        LopHocDao lopDao = new LopHocDao();
        GiaoVienDao gvDao = new GiaoVienDao();
        DangKiLopDao dklDao = new DangKiLopDao();

        DataTable dt = new DataTable("TKB");
        DataTable dtBangDiemGV = new DataTable();
        DataTable dtKhoaHoc = new DataTable();
        DataTable dsLop = new DataTable();
        DataTable dtLopDaDay = new DataTable();
        DataTable dtLopChuaDay = new DataTable();
        DataTable dtHocPhi = new DataTable();

        string ID;
        //bang diem HV
        enum nameCol_BangDiem
        {
            STT_BD,
            MaLop_BD,
            TenMon_BD,
            DiemGiuaKy_BD,
            DiemCuoiKy_BD,
            DiemTB_BD
        }
        //bang nhap diem GV
        enum nameCol_BD
        {
            STT,
            HVID,
            HOTEN,
            DiemGiuaKy,
            DiemCuoiKy,
            DiemTB,
            ThuHang
        }
        //các cột bảng DSL
        enum name_CotDSL
        {
            STT_DSL,
            MaLop_DSL,
            TenMon_DSL,
            TenKH_DSL,
            SoHocVien_DSL,
            //HocPhi_DSL,
            TrangThai_DSL
        }
        //
        enum nameCol_HP
        {
            MaLop, TenMon, NgayBatDau, NgayKetThuc, HocPhi, DaDong, ConNo, TrangThai, ThanhToan
        }


        //list luu img màu nền 
        List<string> linkBG = new List<string>
            {
                "01_tkb@3x",
                "02_tkb@3x",
                "03_tkb@3x",
                "04_tkb@3x",
                "05_tkb@3x",
                "06_tkb@3x"
            };
        //luu bảng màu tương ứng
        List<Color> colorBG = new List<Color>
            {
                Color.FromArgb(1, 118, 225),
                Color.FromArgb(152, 86, 250),
                Color.FromArgb(253, 82, 97),
                Color.FromArgb(14, 216, 75),
                Color.FromArgb(254, 188, 67),
                Color.FromArgb(58, 54, 96)
            };

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

        

        #region GiangVien
        string maLop;
        //show lop can xac nhan
        public void hienLopXacNhan()
        {
            UC_XACNHANLOP_CHILD[] ucXacNhanDay = new UC_XACNHANLOP_CHILD[dtLopChuaDay.Rows.Count];

            fLPnl_XacNhanLop.Controls.Clear();

            for (int i = 0; i < dtLopChuaDay.Rows.Count; i++)
            {
                DataRow row = dtLopChuaDay.Rows[i];
                string malop = row["MaLop"].ToString().Trim();
                string tenlop = row["TenMon"].ToString().Trim();

                DataTable dtLopXacNhan = new DataTable();
                dtLopXacNhan = dklDao.LayThongTinLop(malop);
                //gán thứ
                string thu = "";
                for (int r = 0; r < dtLopXacNhan.Rows.Count; r++)
                {
                    thu += "Thứ " + dtLopXacNhan.Rows[r]["Thu"].ToString() + "    ";
                }

                //phong
                string phong = dtLopXacNhan.Rows[0]["Phong"].ToString().Trim();

                //giờ BD: TIME -> TimeSpan
                TimeSpan gioBD = (TimeSpan)dtLopXacNhan.Rows[0]["GioBatDau"];
                string giobd = gioBD.ToString(@"hh\:mm");

                //Giờ KT
                TimeSpan gioKT = (TimeSpan)dtLopXacNhan.Rows[0]["GioKetThuc"];
                string giokt = gioKT.ToString(@"hh\:mm");

                //Ngày BD: DATE -> DateTime
                DateTime ngayBD = (DateTime)dtLopXacNhan.Rows[0]["NgayBatDau"];
                string ngaybd = ngayBD.ToString("dd/MM/yyyy");

                //NgàyKT
                DateTime ngayKT = (DateTime)dtLopXacNhan.Rows[0]["NgayKetThuc"];
                string ngaykt = ngayKT.ToString("dd/MM/yyyy");

                ucXacNhanDay[i] = new UC_XACNHANLOP_CHILD(malop, tenlop, phong, thu, giobd, giokt, ngaybd, ngaykt);
                fLPnl_XacNhanLop.Controls.Add(ucXacNhanDay[i]);
            }

            //bat su kien
            for (int i = 0; i < dtLopChuaDay.Rows.Count; i++)
            {
                ucXacNhanDay[i].DeleteClicked += UC_TKB_DeleteClicked;
            }
        }

        private void UC_TKB_DeleteClicked(object sender, EventArgs e)
        {
            UC_XACNHANLOP_CHILD uc = sender as UC_XACNHANLOP_CHILD;
            string maLop = uc.MALH.ToString();
            uc.Visible = false;
        }

        //lay tong ds lop
        private void taiDSLFull()
        {
            dsLop = dklDao.LayDanhSachLop();
            for(int i = dsLop.Rows.Count - 1; i >= 0; i--)
            {
                DataRow row = dsLop.Rows[i];
                if (row["GiangVien"].ToString().Trim() != ID)
                    dsLop.Rows.Remove(row);
            }
        }

        //load dsl chua xac nhan
        private void taiDSLChuaDay()
        {
            // tạo DT mới có số cột = số cột cũ qua.Clone()
            dtLopChuaDay.Rows.Clear();
            dtLopChuaDay = dsLop.Clone();
            dtLopChuaDay.Rows.Clear();
            for (int i = 0; i < dsLop.Rows.Count; i++)
            {
                DataRow row = dsLop.Rows[i];
                if (Convert.ToInt32(row["XacNhan"].ToString()) == 0 && Convert.ToInt32(row["TTMoLop"].ToString()) == 1)//chua xac nhan day
                {
                    //tạo dataRow lưu hàng đó lại
                    DataRow newRow = copyRowToDataTble(dsLop, dtLopChuaDay, i);
                    dtLopChuaDay.Rows.Add(newRow);
                }
            }
        }

        //copy row cho dataTable
        private DataRow copyRowToDataTble(DataTable dtGoc, DataTable dtMoi, int rowIdx)
        {
            //tạo dataRow lưu hàng đó lại
            DataRow newRow = dtMoi.NewRow();
            newRow.ItemArray = dtGoc.Rows[rowIdx].ItemArray; // sao chép dữ liệu từ dòng r của dt vào newRow
            return newRow;
        }

        //load dsl dang day
        private void taiDSLDangDay()
        {
            //lọc bỏ khá học trùng
            //    DataTable distinctMaKH = dtKhoaHoc.DefaultView.ToTable(true, new string[] { "MaKH", "TenKH" });
            //    loadCombobox(cbb_KhoaHoc, distinctMaKH, "TenKH", "MaKH");
            dtLopDaDay.Rows.Clear();
            dtLopDaDay = dsLop.Clone();
            dtLopDaDay.Rows.Clear();
            for (int i = 0; i < dsLop.Rows.Count; i++)
            {
                DataRow row = dsLop.Rows[i];
                //da xac nhan day && lop còn hoạt động
                if (Convert.ToInt32(row["XacNhan"].ToString()) == 1 && Convert.ToInt32(row["TTMoLop"].ToString()) == 1)
                {
                    //tạo dataRow lưu hàng đó lại
                    DataRow newRow = copyRowToDataTble(dsLop, dtLopDaDay, i);
                    dtLopDaDay.Rows.Add(newRow);
                }
            }
            LoadForm(dataGrView_CacLopDay, dtLopDaDay);

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

        //xu li load bang diem
        private void dataGrView_CacLopDay_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow row = dataGrView_CacLopDay.Rows[e.RowIndex];
                maLop = row.Cells["MaLop_DSL"].Value.ToString().Trim();
                taiBangDiemGV(dataGrView_CapNhatDiem,maLop );
            }
            catch

            { }
            
        }

        //tai bang cap nhat diem
        private void taiBangDiemGV(DataGridView dtg, string maLop)
        {

            dtBangDiemGV.Rows.Clear();
            dtBangDiemGV = bangDiemDao.taiBangDiem(maLop);
            LoadForm(dtg, dtBangDiemGV);

            //ẩn full các cột     
            for (int i = 0; i < dtg.Columns.Count; i++)
            {
                DataGridViewColumn colDtg = dtg.Columns[i];
                colDtg.Visible = false;
            }
            //hiện những cột cần, name của các cột được lưu trong Enum
            foreach (nameCol_BD day in Enum.GetValues(typeof(nameCol_BD)))
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

            //xem hang
            dataGrView_CapNhatDiem.Sort(dataGrView_CapNhatDiem.Columns["XepHang"], ListSortDirection.Descending);
            xepThuHang();
            dtg.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        //xep thu hang
        private void xepThuHang()
        {
            double diem = 11;
            int idxRank = 0;
            for (int r = 0; r < dataGrView_CapNhatDiem.Rows.Count; r++)
            {
                DataGridViewRow row = dataGrView_CapNhatDiem.Rows[r];

                if (Convert.ToDouble(row.Cells["DiemTB"].Value) < diem)
                {
                    row.Cells["ThuHang"].Value = (++idxRank).ToString();
                    diem = Convert.ToDouble(row.Cells["DiemTB"].Value);
                }
                else row.Cells["ThuHang"].Value = (idxRank).ToString();
            }
            //dataGrView_CapNhatDiem.Refresh();
        }

        ////load combobox
        //private void loadCombobox(ComboBox cbb, DataTable dt, string displayMember, string valueMember)
        //{
        //    cbb.DataSource = dt;
        //    cbb.DisplayMember = displayMember;
        //    cbb.ValueMember = displayMember;
        //}
        ////load cbb khoa hoc
        //private void loadCbb_KhoaHoc()
        //{
        //    dtKhoaHoc.Rows.Clear();
        //    dtKhoaHoc = lopDao.LayDanhSachLop();

        //    //duyet lui chứ mỗi lần xóa bị lỗi
        //    int rows = dtKhoaHoc.Rows.Count;
        //    for (int r = rows - 1; r >= 0; r--)
        //    {
        //        DataRow row = dtKhoaHoc.Rows[r];
        //        //loai bỏ những hàng không hoạt động và không phải do giáo viên đó dạy:
        //        if (Convert.ToInt32(row["TrangThaiKH"]) == 0 || row["GiangVien"].ToString().Trim() != ID)
        //            dtKhoaHoc.Rows.Remove(row);
        //    }
        //    //lọc bỏ khá học trùng
        //    DataTable distinctMaKH = dtKhoaHoc.DefaultView.ToTable(true, new string[] { "MaKH", "TenKH" });
        //    loadCombobox(cbb_KhoaHoc, distinctMaKH, "TenKH", "MaKH");
        //}
        ////load cbb lop hoc
        //private void loadCbb_LopHoc(string maKH)
        //{
        //    //tạo DT mới có số cột = số cột cũ qua .Clone()
        //    DataTable dtLopHoc = dtKhoaHoc.Clone();

        //    for (int r = 0; r < dtKhoaHoc.Rows.Count; r++)
        //    {
        //        //tìm những dòng có MãKH đã được chọn
        //        if (dtKhoaHoc.Rows[r]["MaKH"].ToString() == maKH)
        //        {
        //            //tạo dataRow lưu hàng đó lại
        //            DataRow newRow = dtLopHoc.NewRow();
        //            newRow.ItemArray = dtKhoaHoc.Rows[r].ItemArray; // sao chép dữ liệu từ dòng r của dt vào newRow
        //            dtLopHoc.Rows.Add(newRow);
        //        }
        //    }
        //    //load những lớp thuộc MãKH đó lên thôi
        //    loadCombobox(cbb_LopHoc, dtLopHoc, "TenMon", "MaLop");
        //}
        ////xuli chon khoa hoc
        //private void cbb_KhoaHoc_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    ComboBox cbb = sender as ComboBox;
        //    if (cbb.SelectedIndex >= 0)
        //    {
        //        //string khoaHoc = ((DataRowView)cbb.SelectedItem)["MaKH"].ToString();
        //        //loadCbb_LopHoc(khoaHoc);
        //    }
        //    //lblKhoaHoc.Visible = false;
        //}
        ////xu li tim kiem chon lop hoc
        //private void cbb_LopHoc_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    ComboBox cbb = sender as ComboBox;
        //    if (cbb.SelectedIndex >= 0)
        //    {
        //        //string maLop = ((DataRowView)cbb_LopHoc.SelectedItem)["maLop"].ToString();
        //        //taiBangDiemGV(dataGrView_CapNhatDiem, maLop);
        //    }
        //}

        //load diem bi thay doi
        private void dataGrView_CapNhatDiem_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewCell cell = sender as DataGridViewCell;
            cell = dataGrView_CapNhatDiem.Rows[e.RowIndex].Cells[e.ColumnIndex];
            if (String.IsNullOrEmpty(cell.Value.ToString()))
                cell.Value = 0.0;
        }

        //cap nhat diem
        private void btn_CapNhatDiem_Click(object sender, EventArgs e)
        {
            //string maLop = ((DataRowView)cbb_LopHoc.SelectedItem)["MaLop"].ToString();
            for (int r = 0; r < dataGrView_CapNhatDiem.Rows.Count; r++)
            {
                DataGridViewRow row = dataGrView_CapNhatDiem.Rows[r];
                string HvID = row.Cells["HvID"].Value.ToString();
                double diemGK = Convert.ToDouble(row.Cells["DiemGiuaKy"].Value.ToString());
                double diemCK = Convert.ToDouble(row.Cells["DiemCuoiKy"].Value.ToString());
                bangDiemDao.capNhatDiem(maLop, HvID, diemGK, diemCK);
            }

            //taiDSLFull();
            //taiDSLChuaDay();
            //taiDSLDangDay();
            taiBangDiemGV(dataGrView_CapNhatDiem, maLop);
        }

        private void dataGrView_CacLopDay_SelectionChanged(object sender, EventArgs e)
        {
            DataGridView dtg = sender as DataGridView;
            if (dtg.SelectedRows.Count > 0)
            {
                int rowInx = dtg.Rows[0].Index;
                maLop = dtg.Rows[rowInx].Cells["MaLop_DSL"].Value.ToString().Trim();
                taiBangDiemGV(dataGrView_CapNhatDiem, maLop);
            }
        }

        //danh STT
        private void dataGrView_CapNhatDiem_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            DataGridViewRow row = dataGrView_CapNhatDiem.Rows[e.RowIndex];
            row.Cells[0].Value = (e.RowIndex + 1).ToString();
        }

        #endregion


        #region HocVien
        //load bang thanh toan
        private void taiBangHocPhi( DataGridView dtg, DataTable dt,string hvID)
        {
            dtHocPhi.Rows.Clear();
            dtHocPhi = tkbDao.loadDSL(hvID);
            LoadForm(dtg, dtHocPhi);
            for (int i = 0; i < dtg.Columns.Count; i++)
            {
                DataGridViewColumn colDtg = dtg.Columns[i];
                colDtg.Visible = false;
            }
            //hiện những cột cần, name của các cột được lưu trong Enum
            foreach (nameCol_HP day in Enum.GetValues(typeof(nameCol_HP)))
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

        //load bang diem
        private void taiBangDiemHV(string hvID)
        {
            LoadForm(dataGrView_BangDiem, hsDao.taiBangDiem(hvID));
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

        //thanh toan hoc phi
        private void btn_ThanhToan_Click(object sender, EventArgs e)
        {
            F_TKB_THANHTOAN thanhtoan = new F_TKB_THANHTOAN();
            thanhtoan.ShowDialog();
            DataTable dtINFO = new DataTable();
            dtINFO = hsDao.Lay_MSSV(Login.userName);
            string hvID = dtINFO.Rows[0]["ID"].ToString().Trim();
            LoadForm(dataGrView_DSLop, tkbDao.loadDSL(hvID));
        }

        private void dataGrView_BangDiem_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            DataGridViewRow row = dataGrView_BangDiem.Rows[e.RowIndex];
            row.Cells[0].Value = (e.RowIndex + 1).ToString();
        }

        private void dataGrView_DSLop_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dtg = sender as DataGridView;
            DataGridViewColumn col = dataGrView_DSLop.Columns[e.ColumnIndex];
            DataGridViewRow row = dataGrView_DSLop.Rows[e.RowIndex];
            if (col.Name == "ThanhToan")
            {
                string maKH = row.Cells["MaKH"].Value.ToString().Trim();
                string tenKH = row.Cells["TenKH"].Value.ToString().Trim();
                string maLH = row.Cells["MaLop"].Value.ToString().Trim();
                string tenLH = row.Cells["TenMon"].Value.ToString().Trim();
                string hocPhi = row.Cells["HocPhi"].Value.ToString().Trim();
                string conNo = row.Cells["ConNo"].Value.ToString().Trim();
                F_TKB_THANHTOAN thanhtoan = new F_TKB_THANHTOAN(maKH, tenKH, maLH, tenLH, ID, hocPhi, conNo);
                thanhtoan.ShowDialog();
                taiBangHocPhi(dataGrView_DSLop, dtHocPhi, ID);
            }
        }

        #endregion


        //lay ID user
        private void layID()
        {
            DataTable dtID = new DataTable();
            dtID = hsDao.Lay_MSSV(Login.userName);
            ID = dtID.Rows[0]["ID"].ToString().Trim();
        }

        //xu li TKB
        private void creTKB()
        {
            //lưu lịch học 
            //
            if (chucVu == 1)//hoc vien
            {
                dt = tkbDao.LayTKB(ID);
            }
            else if (chucVu == 2)
            {
                dt = tkbDao.loadDSLopDay(ID);
            }


            //tạo List lưu tên các môn của học sinh đó đã đăng kí
            List<string> MonHocList = new List<string>();
            string temp = "";
            for (int row = 0; row < dt.Rows.Count; row++)
            {
                if (dt.Rows[row]["TenMon"].ToString() != temp)
                {
                    MonHocList.Add(dt.Rows[row]["TenMon"].ToString());
                    temp = dt.Rows[row]["TenMon"].ToString();
                }
            }

            //in môn + phòng vào TKB
            for (int i = 0; i < MonHocList.Count; i++)
            {
                for (int r = 0; r < dt.Rows.Count; r++)
                {
                    string pnlQlThu = "pnl_QLThu";//lưu pnl quản lí các thứ
                    string pnlName = "pnl";//lưu pnl trong mỗi pnl thứ
                    string pBoxName = "pBox";
                    if (dt.Rows[r]["TenMon"].ToString() == MonHocList[i])
                    {
                        pBoxName += "_T" + dt.Rows[r]["Thu"].ToString() + "_" + dt.Rows[r]["Ca"].ToString();//pBox_T2_1
                        pnlName += "_T" + dt.Rows[r]["Thu"].ToString() + "_" + dt.Rows[r]["Ca"].ToString();//pnl_T2_1
                        pnlQlThu += dt.Rows[r]["Thu"].ToString();//pnlQLThu_2
                        //duyệt từng lớp Panel
                        foreach (Panel pnlQLThu in pnl_QLTKB.Controls.OfType<Panel>())
                        {
                            if (pnlQLThu.Name == pnlQlThu)
                                foreach (Panel pnl in pnlQLThu.Controls.OfType<Panel>())
                                    if (pnl.Name == pnlName)
                                        foreach (PictureBox pBox in pnl.Controls.OfType<PictureBox>())
                                            if (pBox.Name == pBoxName)
                                            {
                                                insertMH(dt.Rows[r]["TenMonGon"].ToString(), dt.Rows[r]["Phong"].ToString(), pBox, linkBG[i], pnl, i);
                                                break;
                                            }

                        }
                    }
                }

            }
        }

        //insert to TKB
        private void insertMH(string tenMonGon, string phongHoc, PictureBox pBox, string imgBG, Panel pnlGioHoc, int idxColor)
        {
            //in tên môn học
            Label lbl_tenMH = new Label();
            cusLable(lbl_tenMH, tenMonGon, pBox, imgBG, pnlGioHoc, 20, 21, idxColor);
            //in tên phòng học
            Label lbl_phong = new Label();
            cusLable(lbl_phong, phongHoc, pBox, imgBG, pnlGioHoc, 20, 52, idxColor);
        }

        //custom Lable
        private void cusLable(Label lbl, string lblText, PictureBox pBox, string imgName, Panel pnlGioHoc, int x, int y, int idxColor)
        {
            pnlGioHoc.Controls.Add(lbl);
            lbl.Text = lblText;
            lbl.Location = new Point(x, y);//
            lbl.Name = "lbl_tenMH";
            lbl.ForeColor = Color.White;
            lbl.BackColor = colorBG[idxColor];
            lbl.Font = new Font("Lato", 10, FontStyle.Bold);
            lbl.BringToFront();
            pBox.Image = new Bitmap(Application.StartupPath + "\\Resources\\" + imgName + ".png");
            pBox.SendToBack();

        }
        //
        private DataTable creaDataTable(DataTable dt)
        {
            DataTable dtINFO = new DataTable();
            dtINFO = hsDao.Lay_MSSV(Login.userName);
            string hvID = dtINFO.Rows[0]["ID"].ToString().Trim();
            dt.Columns.Add("TenMon");
            dt.Columns.Add("Thu");
            dt.Columns.Add("Ca");
            dt.Columns.Add("GioBD", typeof(DateTime));
            dt.Columns.Add("GioKT", typeof(DateTime));
            dt.Columns.Add("Phong");
            dt.Columns.Add("MaLop");

            dt = tkbDao.LayTKB(hvID);
            return dt;
        }

        //load datagrview
        private void LoadForm(DataGridView dtg, DataTable dt)
        {
            dtg.DataSource = dt;
        }

        #endregion

        #region DKL
        DangKiLopDao dklDao1 = new DangKiLopDao();
        DanhSachLopDao dslDao1 = new DanhSachLopDao();
        HocSinhDao hsDao1 = new HocSinhDao();
        GiaoVienDao gvDao1 = new GiaoVienDao();
        LopHocDao lhDao1 = new LopHocDao();

        DataTable dtDSLFull1 = new DataTable();
        //DataTable dtLopDaDay = new DataTable();
        DataTable dtKQ1 = new DataTable("DS_KQ");
        DataTable dtDSL1 = new DataTable();//full danh sach(bao gồm còn hoạt động và hết hd)
        List<string> dslTrungLich1 = new List<string>();//dslop trung lich voi dsl hiện tại

        string trangThai1;
        //string ID;
        //string gvID;//check trùng giáng viên

        enum nameCol_DSL1
        {
            STT1,
            MaLop1,
            TenMon1,
            TenKH1,
            HocPhi1,
            HOTEN1,
            TrangThai_1
        }

        #region DOHOA
        bool isEmpty_Search1 = true;
        private void an_SearchText1(TextBox txt_Search, ref bool isEmpty_Search)
        {
            if (isEmpty_Search == true)
            {
                txt_Search.Text = String.Empty;
                txt_Search.Font = new Font(txt_Search.Font, FontStyle.Regular);
                txt_Search.ForeColor = Color.DimGray;
                isEmpty_Search = false;
            }
        }
        private void hien_SearchText1(TextBox txt_Search, ref bool isEmpty_Search)
        {
            txt_Search.Text = "Search...";
            txt_Search.Font = new Font("SFU Futura", 10F, FontStyle.Italic);
            txt_Search.ForeColor = Color.Silver;
            isEmpty_Search = true;
        }
        private void txt_Search_Click1(object sender, EventArgs e)
        {
            an_SearchText1(txt_Search, ref isEmpty_Search1);
        }
        #endregion

        //public UC_DANGKILOP(int chucVu)
        //{
        //    InitializeComponent();
        //    this.chucVu = chucVu;
        //    layID();
        //}

        //private void UC_DANGKILOP_Load(object sender, EventArgs e)
        //{
        //    if (chucVu == 1)//hocvien
        //    {
        //        taiDSL_DaDangKy();
        //    }
        //    else if (chucVu == 2)//giang vien
        //    {
        //        taiDSLFull();
        //        taiDSLDangDay();
        //    }

        //    taiDSLDangKy();
        //    hienThongTinLopDaDangKy();
        //    taiDSLNoiBat();
        //}

        #region GiangVien
        //lay tong ds lop
        private void taiDSLFull1()
        {
            dtDSLFull1 = dklDao1.LayDanhSachLop();
            for (int i = dtDSLFull1.Rows.Count - 1; i >= 0; i--)
            {
                DataRow row = dtDSLFull1.Rows[i];
                if (row["GiangVien"].ToString().Trim() != ID)
                    dtDSLFull1.Rows.Remove(row);
            }
        }

        //load dsl dang day
        private void taiDSLDangDay1()

        {
            dtKQ1.Rows.Clear();
            dtKQ1 = dtDSLFull1.Clone();
            dtKQ1.Rows.Clear();
            for (int i = 0; i < dtDSLFull1.Rows.Count; i++)
            {
                DataRow row = dtDSLFull1.Rows[i];
                //da xac nhan day
                if (Convert.ToInt32(row["XacNhan"].ToString()) == 1)
                {
                    //tạo dataRow lưu hàng đó lại
                    DataRow newRow = copyRowToDataTble1(dtDSLFull1, dtKQ1, i);
                    dtKQ1.Rows.Add(newRow);
                }
            }
        }

        //copy row cho dataTable
        private DataRow copyRowToDataTble1(DataTable dtGoc, DataTable dtMoi, int rowIdx)
        {
            //tạo dataRow lưu hàng đó lại
            DataRow newRow = dtMoi.NewRow();
            newRow.ItemArray = dtGoc.Rows[rowIdx].ItemArray; // sao chép dữ liệu từ dòng r của dt vào newRow
            return newRow;
        }

        //check lop da co gv
        private bool isNullGV(string malop)
        {
            for (int r = 0; r < dtDSL1.Rows.Count; r++)
            {
                if (dtDSL1.Rows[r]["MaLop"].ToString().Trim() == malop)
                {
                    if (string.IsNullOrEmpty(dtDSL1.Rows[r]["GiangVien"].ToString()))
                    {
                        return true;
                    }
                    break;
                }

            }
            return false;
        }
        #endregion

        #region HOCVIEN
        //tai DSLdaDangKy
        private void taiDSL_DaDangKy1()
        {
            dtKQ1.Rows.Clear();
            dtKQ1 = dklDao1.LayDanhSachLopDaDangKi(ID);
        }
        //check lop da dang ky
        private bool kiemTraLop1(string value, string colValue, DataTable dt)
        {
            for (int r = 0; r < dt.Rows.Count; r++)
            {
                if (dt.Rows[r][colValue].ToString() == value)
                {
                    return false;
                }
            }
            return true;
        }
        #endregion

        //tai dsl noi bat
        private void taiDSLNoiBat1()
        {
            LopHoc lopHoc = new LopHoc();
            for (int r = 0; r < dataGrViewDSL1.Rows.Count; r++)
            {
                lopHoc.TENLOP = dataGrViewDSL1.Rows[r].Cells["TenMon1"].Value.ToString().Trim();
                lopHoc.KHOAHOC = dataGrViewDSL1.Rows[r].Cells["TenKH1"].Value.ToString().Trim();
                lopHoc.HOCPHI = dataGrViewDSL1.Rows[r].Cells["HocPhi1"].Value.ToString().Trim();
                lopHoc.GIANGVIEN = dataGrViewDSL1.Rows[r].Cells["HOTEN1"].Value.ToString().Trim();
                fLPnl_DSL.Controls.Add(new UC_DANHSACHLOP_CHILD(lopHoc.KHOAHOC.ToString(), lopHoc.TENLOP.ToString(), lopHoc.HOCPHI.ToString(), lopHoc.GIANGVIEN.ToString()));
            }
        }

        ////lay ID user
        //private void layID()
        //{
        //    DataTable dtID = new DataTable();
        //    dtID = hsDao1.Lay_MSSV(Login.userName);
        //    ID = dtID.Rows[0]["ID"].ToString().Trim();
        //}

        //tai DSL DKy
        private void taiDSLDangKy1()
        {
            dtDSL1 = dklDao1.LayDanhSachLop();
            //loại bỏ những lớp không còn hoạt động:
            for (int i = dtDSL1.Rows.Count - 1; i >= 0; i--)
            {
                DataRow row = dtDSL1.Rows[i];
                if (Convert.ToInt32(row["TTMoLop"].ToString()) == 0)
                    dtDSL1.Rows.Remove(row);
            }

            loadForm(dataGrViewDSL1, dtDSL1);
            //ẩn full các cột     
            for (int i = 0; i < dataGrViewDSL1.Columns.Count; i++)
            {
                DataGridViewColumn colDtg = dataGrViewDSL1.Columns[i];
                colDtg.Visible = false;
            }

            //hiện những cột cần, name của các cột được lưu trong Enum
            foreach (nameCol_DSL1 day in Enum.GetValues(typeof(nameCol_DSL1)))
            {
                for (int i = 0; i < dataGrViewDSL1.Columns.Count; i++)
                {
                    DataGridViewColumn colDtg = dataGrViewDSL1.Columns[i];
                    if (colDtg.Name.ToString() == day.ToString())
                    {
                        colDtg.Visible = true;
                        break;
                    }
                }
            }
            dataGrViewDSL1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

        }

        //dang ki
        private void btn_DangKi_Click(object sender, EventArgs e)
        {
            string maLop = lbl_MaLop.Text.Trim();
            string lopTrungLich = "";

            //check lop da dang ky
            if (chucVu == 1)//hocvien
            {
                if (kiemTraLop1(maLop, "MaLop", dtKQ1) == true)
                {
                    if (kiemTraTrungLich(maLop, ref lopTrungLich) == true)
                    {
                        if (trangThai1 == "Hoạt động")
                        {
                            //thêm học viên vào lớp + cập nhật sĩ số lớp đó
                            dslDao1.themHocVienVaoLop(lbl_MaLop.Text.ToString(), ID);
                            dklDao1.CapNhatSiSoLop();
                            taiDSL_DaDangKy1();
                        }
                        else
                        {
                            MessageBox.Show("Lớp học đã đầy!");
                        }

                    }
                    else
                    {
                        MessageBox.Show("Trùng lịch với lớp " + lopTrungLich);
                    }
                }
                else
                {
                    MessageBox.Show("Lớp học đã được đăng ký trước đó!");
                }
            }
            else if (chucVu == 2)//giangvien
            {
                if (isNullGV(maLop) == true)
                {
                    if (kiemTraTrungLich(maLop, ref lopTrungLich) == true)
                    {
                        //cap nhat giang vien day + cap nhat trang thai XacNhan day = 1
                        lhDao1.capNhatGiangVienChoLop(maLop, ID);
                        gvDao1.xacNhanDay(maLop, 1);
                        taiDSLFull1();
                        taiDSLDangDay1();
                    }
                    else
                    {
                        MessageBox.Show("Trùng lịch với lớp " + lopTrungLich);
                    }
                }
                else
                {
                    MessageBox.Show("Lớp học đã được đăng ký trước đó!");
                }
            }
            hienThongTinLopDaDangKy1();
            taiDSLDangKy1();
        }
        ////load danh sach lop hoc da duoc dang ki
        private void hienThongTinLopDaDangKy1()
        {
            fLPnl_KQ.Controls.Clear();

            UC_DANGKILOP_CHILD[] ucDangKiLop = new UC_DANGKILOP_CHILD[dtKQ1.Rows.Count];
            //MaLop, TenMon, TenKH, HocPhi, GiangVien, HOTEN, TrangThai
            string maLop_Temp = "";
            int stt = 0;
            for (int i = 0; i < dtKQ1.Rows.Count; i++)
            {
                if (dtKQ1.Rows[i]["MaLop"].ToString() != maLop_Temp)
                {
                    ucDangKiLop[stt] = new UC_DANGKILOP_CHILD((++stt).ToString(), dtKQ1.Rows[i]["MaLop"].ToString(),
                                        dtKQ1.Rows[i]["TenMon"].ToString(), Convert.ToDateTime(dtKQ1.Rows[i]["NgayBatDau"]),
                                        Convert.ToDateTime(dtKQ1.Rows[i]["NgayKetThuc"]), dtKQ1.Rows[i]["HOTEN"].ToString(),
                                        dtKQ1.Rows[i]["TrangThai"].ToString(), chucVu);
                    fLPnl_KQ.Controls.Add(ucDangKiLop[stt - 1]);
                    maLop_Temp = dtKQ1.Rows[i]["MaLop"].ToString();
                }

            }
            //event
            for (int i = 0; i < stt; i++)
            {
                ucDangKiLop[i].DeleteClicked += UC_DANGKILOP_DeleteClicked;
            }
        }
        //event
        private void UC_DANGKILOP_DeleteClicked(object sender, EventArgs e)
        {
            UC_DANGKILOP_CHILD uc = sender as UC_DANGKILOP_CHILD;
            if (Convert.ToUInt32(uc.CHUCVU.ToString()) == 1)//hv
            {
                taiDSL_DaDangKy1();
            }
            else if (Convert.ToUInt32(uc.CHUCVU.ToString()) == 2)//gv
            {
                taiDSLFull1();
                taiDSLDangDay1();
            }

            hienThongTinLopDaDangKy1();
            taiDSLDangKy1();
        }

        //check trung lich
        private bool kiemTraTrungLich(string maLop, ref string loptrunglich)
        {
            //lay thong tin lich hoc cua lop
            DataTable dtTTCT = new DataTable("TTChiTiet");
            dtDSL1 = dklDao1.LayThongTinLop(maLop);

            for (int i = 0; i < dtTTCT.Rows.Count; i++)
            {
                DataRow rowDK = dtTTCT.Rows[i];

                //duyệt từng lớp đã đki
                for (int j = 0; j < dtKQ1.Rows.Count; j++)
                {
                    //DataRow rowKQ = dtKQ.Rows[j];
                    //xét trùng thứ
                    //lay thong tin lich hoc cua lop ket qua
                    DataTable dtTTCT_KQ = new DataTable("TTChiTiet");
                    dtTTCT_KQ = dklDao1.LayThongTinLop(dtKQ1.Rows[j]["MaLop"].ToString());

                    for (int r = 0; r < dtTTCT_KQ.Rows.Count; r++)
                    {
                        DataRow rowKQ = dtTTCT_KQ.Rows[r];
                        if (Convert.ToInt32(rowKQ["Thu"].ToString()) == Convert.ToInt32(rowDK["Thu"].ToString()))
                        {   //xét trùng ca học
                            if (Convert.ToInt32(rowKQ["Ca"].ToString()) == Convert.ToInt32(rowDK["Ca"].ToString()))
                            {
                                //MessageBox.Show(rowKQ["MaLop"].ToString().Trim());
                                loptrunglich = dtKQ1.Rows[j]["TenMon"].ToString();
                                return false;//trung lich
                            }
                        }
                    }

                }

            }
            return true;

        }

        //xu li truyen thong tin
        private void dataGrView_DSLop1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = new DataGridViewRow();
            row = dataGrViewDSL1.Rows[e.RowIndex];

            lbl_MaLop.Text = row.Cells["MaLop1"].Value.ToString();
            lbl_TT_TenKhoaHoc.Text = row.Cells["TenKH1"].Value.ToString();
            lbl_TT_TenLopHoc.Text = row.Cells["TenMon1"].Value.ToString();
            trangThai1 = row.Cells["TrangThai_1"].Value.ToString();

            //lay thong tin lich hoc cua lop
            DataTable dtTTCT = new DataTable("TTChiTiet");
            dtTTCT = dklDao1.LayThongTinLop(row.Cells["MaLop1"].Value.ToString());
            //gán thứ
            lbl_ThuHoc.Text = String.Empty;
            for (int r = 0; r < dtTTCT.Rows.Count; r++)
            {
                lbl_ThuHoc.Text += "Thứ " + dtTTCT.Rows[r]["Thu"].ToString() + "\n";
            }
            //phòng
            lbl_SoPhongHoc.Text = dtTTCT.Rows[0]["Phong"].ToString();

            //giờ BD: TIME -> TimeSpan
            TimeSpan gioBD = (TimeSpan)dtTTCT.Rows[0]["GioBatDau"];
            lbl_GioBatDau.Text = gioBD.ToString(@"hh\:mm");

            //Giờ KT
            TimeSpan gioKT = (TimeSpan)dtTTCT.Rows[0]["GioKetThuc"];
            lbl_GioKetThuc.Text = gioKT.ToString(@"hh\:mm");

            //Ngày BD: DATE -> DateTime
            DateTime ngayBD = (DateTime)dtTTCT.Rows[0]["NgayBatDau"];
            lbl_NgayBatDau.Text = ngayBD.ToString("dd/MM/yyyy");

            //NgàyKT
            DateTime ngayKT = (DateTime)dtTTCT.Rows[0]["NgayKetThuc"];
            lbl_NgayKetThuc.Text = ngayKT.ToString("dd/MM/yyyy");
        }

        //load dtg
        private void loadForm(DataGridView dtg, DataTable dt)
        {
            dtg.DataSource = dt;
        }

        //danh STT
        private void dataGrView_DSLop1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            DataGridViewRow row = dataGrViewDSL1.Rows[e.RowIndex];
            row.Cells[0].Value = (e.RowIndex + 1).ToString();
        }

        //to mau
        private void dataGrView_DSLop_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {


        }

        //
        private void txt_Search_KeyDown1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                thucHienTimKiem(dataGrView_DSLop, txt_Search.Text.ToString(), typeof(nameCol_DSL1));
            }
            else if (e.KeyCode == Keys.Escape)
            {
                thucHienReset(dataGrView_DSLop, txt_Search, ref isEmpty_Search1);
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

        #endregion
    }
}
