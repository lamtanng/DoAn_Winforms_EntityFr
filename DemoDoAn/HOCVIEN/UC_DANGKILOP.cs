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

namespace DemoDoAn.HOCVIEN
{
    public partial class UC_DANGKILOP : UserControl
    {
        int chucVu; // 0 la admin;  1 la hocvien;  2 la giao vien

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
        string ID;
        //string gvID;//check trùng giáng viên

        enum nameCol_DSL1
        {
            STT_DSL,
            MaLop_DSL,
            TenMon_DSL,
            TenKH_DSL,
            HocPhi_DSL,
            HOTEN_DSL,
            TrangThai_DSL
        }

        #region DOHOA
        bool isEmpty_Search1 = true;
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
        private void txt_Search_Click1(object sender, EventArgs e)
        {
            an_SearchText(txt_Search, ref isEmpty_Search1);
        }
        #endregion

        public UC_DANGKILOP(int chucVu)
        {
            InitializeComponent();
            this.chucVu = chucVu;
            layID();
            
        }

        private void UC_DANGKILOP_Load(object sender, EventArgs e)
        {
            if (chucVu == 1)//hocvien
            {
                taiDSL_DaDangKy();
            }
            else if (chucVu == 2)//giang vien
            {
                taiDSLFull();
                taiDSLDangDay();
            }

            taiDSLDangKy();
            hienThongTinLopDaDangKy();
            taiDSLNoiBat();
        }

        #region GiangVien
        //lay tong ds lop
        private void taiDSLFull()
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
        private void taiDSLDangDay()

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
                    DataRow newRow = copyRowToDataTble(dtDSLFull1, dtKQ1, i);
                    dtKQ1.Rows.Add(newRow);
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
        private void taiDSL_DaDangKy()
        {
            dtKQ1.Rows.Clear();
            dtKQ1 = dklDao1.LayDanhSachLopDaDangKi(ID);
        }
        //check lop da dang ky
        private bool kiemTraLop(string value, string colValue, DataTable dt)
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
        private void taiDSLNoiBat()
        {
            LopHoc lopHoc = new LopHoc();
            for (int r = 0; r < dataGrView_DSLop.Rows.Count; r++)
            {
                lopHoc.TENLOP = dataGrView_DSLop.Rows[r].Cells["TenMon_DSL"].Value.ToString().Trim();
                lopHoc.KHOAHOC = dataGrView_DSLop.Rows[r].Cells["TenKH_DSL"].Value.ToString().Trim();
                lopHoc.HOCPHI = dataGrView_DSLop.Rows[r].Cells["HocPhi_DSL"].Value.ToString().Trim();
                lopHoc.GIANGVIEN = dataGrView_DSLop.Rows[r].Cells["HOTEN_DSL"].Value.ToString().Trim();
                fLPnl_DSL.Controls.Add(new UC_DANHSACHLOP_CHILD(lopHoc.KHOAHOC.ToString(), lopHoc.TENLOP.ToString(), lopHoc.HOCPHI.ToString(), lopHoc.GIANGVIEN.ToString()));
            }
        }

        //lay ID user
        private void layID()
        {
            DataTable dtID = new DataTable();
            dtID = hsDao1.Lay_MSSV(Login.userName);
            ID = dtID.Rows[0]["ID"].ToString().Trim();
        }
        
        //tai DSL DKy
        private void taiDSLDangKy()
        {
            dtDSL1 = dklDao1.LayDanhSachLop();
            //loại bỏ những lớp không còn hoạt động:
            for (int i = dtDSL1.Rows.Count - 1; i >= 0; i--)
            {
                DataRow row = dtDSL1.Rows[i];
                if (Convert.ToInt32(row["TTMoLop"].ToString()) == 0)
                    dtDSL1.Rows.Remove(row);
            }

            loadForm(dataGrView_DSLop, dtDSL1);
            //ẩn full các cột     
            for (int i = 0; i < dataGrView_DSLop.Columns.Count; i++)
            {
                DataGridViewColumn colDtg = dataGrView_DSLop.Columns[i];
                colDtg.Visible = false;
            }

            //hiện những cột cần, name của các cột được lưu trong Enum
            foreach (nameCol_DSL1 day in Enum.GetValues(typeof(nameCol_DSL1)))
            {
                for (int i = 0; i < dataGrView_DSLop.Columns.Count; i++)
                {
                    DataGridViewColumn colDtg = dataGrView_DSLop.Columns[i];
                    if (colDtg.Name.ToString() == day.ToString())
                    {
                        colDtg.Visible = true;
                        break;
                    }
                }
            }
            dataGrView_DSLop.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

        }

        //dang ki
        private void btn_DangKi_Click(object sender, EventArgs e)
        {
            string maLop = lbl_MaLop.Text.Trim();
            string lopTrungLich = "";

            //check lop da dang ky
            if (chucVu == 1)//hocvien
            {
                if (kiemTraLop(maLop, "MaLop", dtKQ1) == true)
                {
                    if (kiemTraTrungLich(maLop, ref lopTrungLich) == true)
                    {
                        if (trangThai1 == "Hoạt động")
                        {
                            //thêm học viên vào lớp + cập nhật sĩ số lớp đó
                            dslDao1.themHocVienVaoLop(lbl_MaLop.Text.ToString(), ID);
                            dklDao1.CapNhatSiSoLop();
                            taiDSL_DaDangKy();
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
                        taiDSLFull();
                        taiDSLDangDay();
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
            hienThongTinLopDaDangKy();
            taiDSLDangKy();
        }
        ////load danh sach lop hoc da duoc dang ki
        private void hienThongTinLopDaDangKy()
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
            if(Convert.ToUInt32(uc.CHUCVU.ToString()) == 1)//hv
            {
                taiDSL_DaDangKy();
            }
            else if(Convert.ToUInt32(uc.CHUCVU.ToString()) == 2)//gv
            {
                taiDSLFull();
                taiDSLDangDay();
            }
            
            hienThongTinLopDaDangKy();
            taiDSLDangKy();
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
        private void dataGrView_DSLop_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = new DataGridViewRow();
            row = dataGrView_DSLop.Rows[e.RowIndex];

            lbl_MaLop.Text = row.Cells["MaLop_DSL"].Value.ToString();
            lbl_TT_TenKhoaHoc.Text = row.Cells["TenKH_DSL"].Value.ToString();
            lbl_TT_TenLopHoc.Text = row.Cells["TenMon_DSL"].Value.ToString();
            trangThai1 = row.Cells["TrangThai_DSL"].Value.ToString();

            //lay thong tin lich hoc cua lop
            DataTable dtTTCT = new DataTable("TTChiTiet");
            dtTTCT = dklDao1.LayThongTinLop(row.Cells["MaLop_DSL"].Value.ToString());
            //gán thứ
            lbl_Thu.Text = String.Empty;
            for (int r = 0; r < dtTTCT.Rows.Count; r++)
            {
                lbl_Thu.Text += "Thứ " + dtTTCT.Rows[r]["Thu"].ToString() + "\n\n";
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
        private void dataGrView_DSLop_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            DataGridViewRow row = dataGrView_DSLop.Rows[e.RowIndex];
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

        private void btn_DangKi_Click_1(object sender, EventArgs e)
        {

        }
    }
}
