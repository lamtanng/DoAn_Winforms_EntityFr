using DemoDoAn.ChildPage.HocTap;
using DemoDoAn.HOCVIEN.Class;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.Windows.Controls;
//using System.Windows.Controls;
using System.Windows.Forms;

namespace DemoDoAn.ChildPage
{
    public partial class UC_STUDENT_XEPLOP : UserControl
    {
        LopHocDao LopHocDao = new LopHocDao();
        BangDiemDAO bangDiemDao = new BangDiemDAO();
        HocSinhDao hvDao = new HocSinhDao();
        DanhSachLopDao dslDao = new DanhSachLopDao();
        DangKiLopDao dklDao = new DangKiLopDao();
        PhieuThuDao ptDao = new PhieuThuDao();

        DataTable dtKhoaHoc = new DataTable();
        DataTable dsHV = new DataTable();
        DataTable dsLop = new DataTable();
        DataTable dtKQ = new DataTable();

        enum nameCol_DSHV
        {
            STT_DSHV, HVID_DSHV, HOTEN_DSHV, Them
        }
        enum nameCol_DSL
        {
            STT_DSL, HVID_DSL, HOTEN_DSL, Xoa_DSL
        }

        //trang thai si so lop: hoat dong || da day
        string trangThai;

        public UC_STUDENT_XEPLOP()
        {
            InitializeComponent();
        }

        #region DoHoa
        //ẩn text Search
        bool isEmpty_Search_DSHV = true;
        bool isEmpty_Search_DSL = true;
        private void txt_SearchHVChuaCoLop_Click(object sender, EventArgs e)
        {
            an_SearchText(txt_SearchHVChuaCoLop, ref isEmpty_Search_DSHV);
        }
        private void txt_SearchDSLopHoc_Click(object sender, EventArgs e)
        {
            an_SearchText(txt_SearchDSLopHoc, ref isEmpty_Search_DSL);
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

        private void UC_STUDENT_XEPLOP_Load(object sender, EventArgs e)
        {
            loadCbb_KhoaHoc();
            
        }

        //load form
        private void loadForm(DataGridView dtg, DataTable dt)
        {
            dtg.DataSource = dt;
        }

        //load ds hoc vien chua co lop
        private void taiDSHV_KhongLop(DataGridView dtg)
        {
            dsHV = hvDao.LayDanhSachSinhVien();
            //loại bỏ những hv đã có trong lớp
            for (int i = dsLop.Rows.Count - 1; i >= 0; i--)
            {
                DataRow row = dsLop.Rows[i];
                for (int r = 0; r < dsHV.Rows.Count; r++)
                {
                    if (row["HVID"].ToString() == dsHV.Rows[r]["HVID"].ToString())
                    {
                        dsHV.Rows.Remove(dsHV.Rows[r]);
                        break;
                    }

                }
            }
            loadForm(dtg, dsHV);
            //ẩn full các cột     
            for (int i = 0; i < dtg.Columns.Count; i++)
            {
                DataGridViewColumn colDtg = dtg.Columns[i];
                colDtg.Visible = false;
            }
            //hiện những cột cần, name của các cột được lưu trong Enum
            foreach (nameCol_DSHV day in Enum.GetValues(typeof(nameCol_DSHV)))
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
            dtg.Sort(dtg.Columns["HVID_DSHV"], ListSortDirection.Ascending);
        }

        //load ds lop
        private void taiDSLop(DataGridView dtg ,string maLop)
        {
            dsLop = bangDiemDao.taiBangDiem(maLop);
            loadForm(dtg, dsLop);
            //ẩn full các cột     
            for (int i = 0; i < dtg.Columns.Count; i++)
            {
                DataGridViewColumn colDtg = dtg.Columns[i];
                colDtg.Visible = false;
            }
            //hiện những cột cần, name của các cột được lưu trong Enum
            foreach (nameCol_DSL day in Enum.GetValues(typeof(nameCol_DSL)))
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
            dtg.Sort(dtg.Columns["HVID_DSL"], ListSortDirection.Ascending);
        }

        //load combobox
        private void loadCombobox(ComboBox cbb, DataTable dt, string displayMember, string valueMember)
        {
            cbb.DataSource = dt;
            cbb.DisplayMember = displayMember;
            cbb.ValueMember = displayMember;
        }

        //load cbb khoa hoc
        private void loadCbb_KhoaHoc()
        {
            dtKhoaHoc.Rows.Clear();
            dtKhoaHoc = LopHocDao.LayDanhSachLop();
            //duyet lui chứ mỗi lần xóa bị lỗi
            int rows = dtKhoaHoc.Rows.Count;
            for (int r = rows - 1; r >= 0; r--)
            {
                DataRow row = dtKhoaHoc.Rows[r];
                //loại bỏ các dòng có khóa học và lớp học đã ngưng hoạt động
                if (Convert.ToInt32(row["TrangThaiKH"]) == 0 || Convert.ToInt32(row["TTMoLop"]) == 0)
                    dtKhoaHoc.Rows.Remove(row);
            }
            DataTable distinctMaKH = dtKhoaHoc.DefaultView.ToTable(true, new string[] { "MaKH", "TenKH" });
            loadCombobox(cbb_ChonKhoaHoc, distinctMaKH, "TenKH", "MaKH");
        }

        //load cbb lop hoc
        private void loadCbb_LopHoc(string maKH)
        {
            //tạo DT mới có số cột = số cột cũ qua .Clone()
            DataTable dtLopHoc = dtKhoaHoc.Clone();

            for (int r = 0; r < dtKhoaHoc.Rows.Count; r++)
            {
                //tìm những dòng có MãKH đã được chọn
                if (dtKhoaHoc.Rows[r]["MaKH"].ToString() == maKH)
                {
                    //tạo dataRow lưu hàng đó lại
                    DataRow newRow = dtLopHoc.NewRow();
                    newRow.ItemArray = dtKhoaHoc.Rows[r].ItemArray; // sao chép dữ liệu từ dòng r của dt vào newRow
                    dtLopHoc.Rows.Add(newRow);
                }
            }
            //load những lớp thuộc MãKH đó lên thôi
            loadCombobox(cbb_ChonLopHoc, dtLopHoc, "TenMon", "MaLop");
        }

        //xu li chon khoa hoc
        private void cbb_ChonKhoaHoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cbb = sender as ComboBox;
            if (cbb.SelectedIndex >= 0)
            {
                string khoaHoc = ((DataRowView)cbb.SelectedItem)["MaKH"].ToString();
                loadCbb_LopHoc(khoaHoc);
            }
        }
        //load thong tin 
        private void cbb_ChonLopHoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cbb = sender as ComboBox;
            if (cbb.SelectedIndex >= 0)
            {
                string maLop = ((DataRowView)cbb_ChonLopHoc.SelectedItem)["maLop"].ToString();
                taiDSLop(dataGrView_DSLop, maLop);
                taiDSHV_KhongLop(dataGrView_DSHocVien);

                string soHVHienTai = (dataGrView_DSLop.Rows.Count).ToString();
                hienThongTinLop(maLop, soHVHienTai);
            }
        }

        //hien thong tin lop
        private void hienThongTinLop(string maLop, string soHVHienTai)
        {
            //lấy thông tin lớp
            DataTable dtTTLop = new DataTable();
            dtTTLop = bangDiemDao.layThongTinLop(maLop);

            DataRow row = dtTTLop.Rows[0];
            lbl_TT_TenKhoaHoc.Text = row["TenKH"].ToString();
            lbl_TT_TenLopHoc.Text = row["TenMon"].ToString();
            string ngayBD = ((DateTime)row["NgayBatDau"]).ToString("dd/MM/yyyy");
            lbl_TT_NgayBatDau.Text = ngayBD;
            string ngayKT = ((DateTime)row["NgayKetThuc"]).ToString("dd/MM/yyyy");
            lbl_TT_NgayKetThuc.Text = ngayKT;
            lbl_TT_TongSoHV.Text = row["SoHocVien"].ToString();
            lbl_TT_HocVienHienTai.Text = soHVHienTai;
            lbl_TT_TenGiangVien.Text = row["HOTEN"].ToString();
            lbl_TT_SoTienHocPhi.Text = row["HocPhi"].ToString();

            trangThai = row["TrangThai"].ToString().Trim();
        }

        //them hoc vien vao lop
        private void dataGrView_DSHocVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = new DataGridViewRow();
            try
            {
                row = dataGrView_DSHocVien.Rows[e.RowIndex];
                if (dataGrView_DSHocVien.Columns[e.ColumnIndex].Name == "Them")
                {

                    string maLop = ((DataRowView)cbb_ChonLopHoc.SelectedItem)["MaLop"].ToString();
                    string hvID = row.Cells["HVID_DSHV"].Value.ToString();
                    string loptrunglich = "";
                    //kiem tra si so
                    if (trangThai == "Hoạt động")
                    {
                        //check trung lich
                        if(kiemTraTrungLich(maLop, ref loptrunglich, hvID))
                        {
                            //them hv
                            dslDao.themHocVienVaoLop(maLop, hvID);
                            dklDao.CapNhatSiSoLop();
                        }
                        else
                        {
                            MessageBox.Show("Trùng lịch học lớp " + loptrunglich);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Không thành công!");
                    }
                    taiDSLop(dataGrView_DSLop,maLop);
                    taiDSHV_KhongLop(dataGrView_DSHocVien);
                    hienThongTinLop(maLop, (dataGrView_DSLop.Rows.Count).ToString());
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }

        }


        //check trung lich
        private bool kiemTraTrungLich(string maLop, ref string loptrunglich, string hvid)
        {
            taiDSL_DaDangKy(hvid);
            //lay thong tin lich hoc cua lop
            DataTable dtTTCT = new DataTable("TTChiTiet");
            dtTTCT = dklDao.LayThongTinLop(maLop);

            for (int i = 0; i < dtTTCT.Rows.Count; i++)
            {
                DataRow rowDK = dtTTCT.Rows[i];

                //duyệt từng lớp đã đki
                for (int j = 0; j < dtKQ.Rows.Count; j++)
                {
                    //lay thong tin lich hoc cua lop ket qua
                    DataTable dtTTCT_KQ = new DataTable("TTChiTiet");
                    dtTTCT_KQ = dklDao.LayThongTinLop(dtKQ.Rows[j]["MaLop"].ToString());
                    for (int r = 0; r < dtTTCT_KQ.Rows.Count; r++)
                    {
                        //xét trùng thứ
                        DataRow rowKQ = dtTTCT_KQ.Rows[r];
                        if (Convert.ToInt32(rowKQ["Thu"].ToString()) == Convert.ToInt32(rowDK["Thu"].ToString()))
                        {   //xét trùng ca học
                            if (Convert.ToInt32(rowKQ["Ca"].ToString()) == Convert.ToInt32(rowDK["Ca"].ToString()))
                            {
                                //MessageBox.Show(rowKQ["MaLop"].ToString().Trim());
                                loptrunglich = dtKQ.Rows[j]["TenMon"].ToString();
                                return false;//trung lich
                            }
                        }
                    }

                }

            }
            return true;

        }
        //tai DSLdaDangKy
        private void taiDSL_DaDangKy(string hvid)
        {
            dtKQ.Rows.Clear();
            dtKQ = dklDao.LayDanhSachLopDaDangKi(hvid);
        }

        //xoa hoc vien khoi lop
        private void dataGrView_DSLop_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dtg = sender as DataGridView;
            //MessageBox.Show(dtg.SelectedRows.Count.ToString() + "eeee" + dtg.SelectedRows[e.RowIndex].Index.ToString());

            try
            {
                DataGridViewRow row = new DataGridViewRow();
                row = dtg.Rows[e.RowIndex];
                if (dtg.Columns[e.ColumnIndex].Name == "Xoa_DSL")
                {
                    if (MessageBox.Show("Bạn muốn xóa học viên?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        string maLop = ((DataRowView)cbb_ChonLopHoc.SelectedItem)["MaLop"].ToString();
                        string hvID = row.Cells["HVID_DSL"].Value.ToString();

                        dslDao.xoaHocVien(maLop, hvID);
                        //cap nhat si so lop
                        dklDao.CapNhatSiSoLop();
                        hienThongTinLop(maLop, dataGrView_DSLop.Rows.Count.ToString());//cập nhật lại trạng thái 

                        //xoa lich su phieu thu
                        ptDao.xoaLichSuThu(hvID, maLop);

                        taiDSLop(dataGrView_DSLop,maLop);
                        taiDSHV_KhongLop(dataGrView_DSHocVien);
                        hienThongTinLop(maLop, (dtg.Rows.Count).ToString());
                    }
                }
            }
            catch (Exception ex)
            {

            }

        }

        
        //tim kiem + reset DSHV
        private void txt_SearchHVChuaCoLop_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                thucHienTimKiem(dataGrView_DSHocVien, txt_SearchHVChuaCoLop.Text.ToString(), typeof(nameCol_DSHV));
            }
            else
                if (e.KeyCode == Keys.Escape)
            {
                thucHienReset(dataGrView_DSHocVien, txt_SearchHVChuaCoLop, ref isEmpty_Search_DSHV);
            }
        }
        //tim kiem + reset DSL
        private void txt_SearchDSLopHoc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                thucHienTimKiem(dataGrView_DSLop, txt_SearchDSLopHoc.Text.ToString(), typeof(nameCol_DSL));
            }
            else
               if (e.KeyCode == Keys.Escape)
            {
                thucHienReset(dataGrView_DSLop, txt_SearchDSLopHoc, ref isEmpty_Search_DSHV);
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
        private void thucHienReset(DataGridView dtg, TextBox txt_Search,ref bool isEmptyText)
        {
            // hiển thị tất cả các dòng
            dtg.Rows.Cast<DataGridViewRow>().ToList().ForEach(r => r.Visible = true);
            hien_SearchText(txt_Search, ref isEmptyText);
        }

        //danh STT
        private void dataGrView_DSLop_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            DataGridViewRow row = dataGrView_DSLop.Rows[e.RowIndex];
            row.Cells[0].Value = (e.RowIndex + 1).ToString();
        }
        private void dataGrView_DSHocVien_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            DataGridViewRow row = dataGrView_DSHocVien.Rows[e.RowIndex];
            row.Cells[0].Value = (e.RowIndex + 1).ToString();
        }


    }
}
