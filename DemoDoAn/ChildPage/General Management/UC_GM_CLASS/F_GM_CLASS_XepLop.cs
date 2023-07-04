using DemoDoAn.Custom_Control;
//using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DemoDoAn.ChildPage.General_Management.UC_GM_CLASS
{
    public partial class F_GM_CLASS_XepLop : Form
    {
        LopHocDao LopHocDao = new LopHocDao();
        LichHocDao LichHocDao = new LichHocDao();
        DataTable dtKhoaHoc = new DataTable();
        DataTable dtLichHoc = new DataTable();
        int soBuoiHoc = 0;

        string malop, tenlop, maKH, tenKH;
        enum TrangThaiLopHoc
        {

        }

        public F_GM_CLASS_XepLop()
        {
            InitializeComponent();
        }

        public F_GM_CLASS_XepLop(string malop, string tenlop, string maKH, string tenKH)
        {
            InitializeComponent();
            this.malop = malop;
            this.tenlop = tenlop;
            this.maKH = maKH;
            this.tenKH = tenKH;
            hienThongTin();
        }

        #region XULIDOHOa
        #region hàm dùng chung 
        private void SelectBtn(FlowLayoutPanel fLPnl, Button btnFLPnl, Button btn, bool select)
        {
            fLPnl.Height = fLPnl.MinimumSize.Height;
            select_TrangThai = false;
            btnFLPnl.Text = btn.Text;
        }
        // show/hide list lựa chọn 
        bool select_TrangThai = false;
        private void ShowListChoss(FlowLayoutPanel fLPnl, Timer t, ref bool select)
        {
            if (select == false)
            {
                fLPnl.Height += 15;
                if (fLPnl.Height >= fLPnl.MaximumSize.Height)
                {
                    t.Stop();
                    select = true;
                }
            }
            else
            {
                fLPnl.Height -= 15;
                if (fLPnl.Height <= fLPnl.MinimumSize.Height)
                {
                    t.Stop();
                    select = false;
                }
            }
        }

        #endregion//hàm load các thanh trạng thái(fake combobox)
        private void closeForm()
        {
            this.Close();
        }
        private void timer_LoadTrangThai_Tick(object sender, EventArgs e)
        {
            ShowListChoss(fLPnl_TrangThai, timer_LoadTrangThai, ref select_TrangThai);
        }
        private void btn_Huy_Click(object sender, EventArgs e)
        {
            closeForm();
        }
        private void btn_TrangThai_Click(object sender, EventArgs e)
        {
            timer_LoadTrangThai.Start();
        }
        private void btn_TT_DaDay_Click(object sender, EventArgs e)
        {
            SelectBtn(fLPnl_TrangThai, btn_TrangThai, btn_TT_DaDay, select_TrangThai);
        }
        private void btn_TT_HoatDong_Click(object sender, EventArgs e)
        {
            SelectBtn(fLPnl_TrangThai, btn_TrangThai, btn_TT_HoatDong, select_TrangThai);
        }
        #endregion

        private void F_GM_CLASS_XepLop_Load(object sender, EventArgs e)
        {
            dtKhoaHoc = LopHocDao.LayDanhSachLop();
            //load combobox
            loadCbb_GioHoc();
            loadLichHoc();
            chonSoBuoiHoc();
        }

        //tai thong tin
        private void hienThongTin()
        {
            lbl_TenKH.Text = tenKH.ToString();
            lbl_TenLH.Text = tenlop.ToString();
        }

        //cap nhat
        private void btn_HoanThanh_Click(object sender, EventArgs e)
        {
            try
            {   //kiểm tra xem đã đủ thông tin hay chưa
                if (chonDuSoNgayHoc() && chonSoHocVien())
                {
                    //string maLop = ((DataRowView)cbb_ChonLopHoc.SelectedItem)["MaLop"].ToString();
                    //string tenLop = ((DataRowView)cbb_ChonLopHoc.SelectedItem)["TenMon"].ToString();
                    string trangThai = btn_TrangThai.Text.ToString();
                    //string khoaHoc = ((DataRowView)cbb_ChonKhoaHoc.SelectedItem)["MaKH"].ToString();
                    int soHV = Convert.ToInt32(txt_SLHocVien.Text.ToString());
                    DateTime ngayBD = datePTime_NgayBatDau.Value;
                    DateTime ngayKT = datePTime_NgayKetThuc.Value;
                    string GvID = ((DataRowView)cbb_GiangVien.SelectedItem)["GvID"].ToString();
                    string soBuoi = (cbb_ChonSoBuoiHoc.SelectedItem).ToString();
                    string ca = ((DataRowView)cbb_GioHoc.SelectedItem)["Ca"].ToString();
                    string phong = ((DataRowView)cbb_PhongHoc.SelectedItem)["Phong"].ToString();

                    //xep lop
                    LopHoc lop = new LopHoc(malop, tenlop, trangThai, maKH, soHV, ngayBD, ngayKT, "", GvID, soBuoi, tenlop);
                    LopHocDao.XepLop(lop);


                    //DataTable checkLich = new DataTable();
                    //checkLich = LopHocDao.checkLichHoc(maLop);

                    //xoa lich hoc cu
                    LichHocDao.xoaLichHoc(malop);
                    //update thong tin lop hoc
                    LopHocDao.capNhatThongTinLop(lop);
                    //tao lich hoc moi
                    foreach (CheckBox cbox in pnl_QLNgayHoc.Controls.OfType<CheckBox>())
                    {
                        if (cbox.Checked == true)
                        {
                            //chuẩn hóa 'Thứ 2' -> '2'
                            string thu = chuanHoa(cbox.Text.ToString());
                            LichHocDao.xepLichHoc(malop, thu, ca, phong);
                        }
                    }
                    this.Close();

                }
                else//chưa nhập đủ thông tin
                {
                    MessageBox.Show("Thông tin chưa chính xác!");
                }
            }
            catch//lỗi 
            {
                MessageBox.Show("Không hoàn thành!");
            }

        }

        //load combobox
        private void loadCombobox(ComboBox cbb, DataTable dt, string displayMember, string valueMember)
        {
            cbb.DataSource = dt;
            cbb.DisplayMember = displayMember;
            cbb.ValueMember = displayMember;
        }

        //Xu li chon so buoi hoc
        private void cbb_ChonSoBuoiHoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cbb = sender as ComboBox;
            pnl_QLNgayHoc.Enabled = true;
            if (cbb.SelectedIndex >= 0)
            {
                //lưu lại số buổi học đã chọn
                soBuoiHoc = Convert.ToInt32((cbb.SelectedItem).ToString());
                //tắt checked tất cả các Thứ để chọn lại từ đầu khi mỗi lần số buổi được thiết lập lại 
                foreach (CheckBox cbox in pnl_QLNgayHoc.Controls.OfType<CheckBox>())
                {
                    cbox.Checked = false;
                }
                //load Phòng/GV học trống 
                loadCbb_PhongHoc();
                loadCbb_GiaoVien();
                //
                pnl_QLNgayHoc.Visible = true;
            }
            else
            {
                pnl_QLNgayHoc.Enabled = false;
            }
        }

        //xử lí giờ học
        private void cbb_GioHoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cbb = sender as ComboBox;
            if (cbb.SelectedIndex != null)
            {
                //mỗi khi giờ học được chọn thì hiển thị lại số 'phòng học' mà Thứ + Ca đó trống
                loadCbb_PhongHoc();
                loadCbb_GiaoVien();
            }
        }

        //load cbb gio hoc
        private void loadCbb_GioHoc()
        {
            DataTable dtGioHoc = new DataTable();
            dtGioHoc = LopHocDao.gioHoc();
            dtGioHoc.Columns.Add("GioHoc");

            for (int r = 0; r < dtGioHoc.Rows.Count; r++)
            {
                string gioHoc = "Ca " + dtGioHoc.Rows[r]["Ca"].ToString() + ": " + dtGioHoc.Rows[r]["GioBatDau"].ToString() + " - " + dtGioHoc.Rows[r]["GioKetThuc"].ToString();
                dtGioHoc.Rows[r]["GioHoc"] = gioHoc;
            }
            loadCombobox(cbb_GioHoc, dtGioHoc, "GioHoc", "Ca");
        }

        //load cbb phong hoc
        private void loadCbb_PhongHoc()
        {
            DataTable dtPhongHoc = new DataTable();
            dtPhongHoc = LopHocDao.phongHoc();
            checkLichTrong(dtPhongHoc, "Phong");
            loadCombobox(cbb_PhongHoc, dtPhongHoc, "Phong", "Phong");

        }

        //check lịch trống
        private void checkLichTrong(DataTable dtCheck, string thuocTinhCheck)
        {
            //kiểm tra những "Thứ" nào được chọn
            foreach (CheckBox cbox in pnl_QLNgayHoc.Controls.OfType<CheckBox>())
            {
                if (cbox.Checked == true)
                {
                    //chuẩn hóa 'Thứ 2' -> '2'
                    string thu = chuanHoa(cbox.Text.ToString());
                    //tìm tra Table lịch học all môn
                    for (int r = 0; r < dtLichHoc.Rows.Count; r++)
                    {   //tìm những "Thứ" và "Ca" đã được chọn đã có lịch dạy của môn khác hay chưa
                        if (dtLichHoc.Rows[r]["Thu"].ToString().Trim() == thu && dtLichHoc.Rows[r]["Ca"].ToString().Trim() == ((DataRowView)cbb_GioHoc.SelectedItem)["Ca"].ToString().Trim())
                        {
                            //nếu có thì phòng/GV đó đã có lịch
                            for (int i = dtCheck.Rows.Count- 1; i >=0 ; i--)
                            {
                                if (dtCheck.Rows[i][thuocTinhCheck].ToString().Trim() == dtLichHoc.Rows[r][thuocTinhCheck].ToString().Trim())
                                {
                                    MessageBox.Show(dtCheck.Rows.Count.ToString());
                                    //xóa phòng/GV đó khỏi DataTable
                                    dtCheck.Rows[i].Delete();
                                    dtCheck.AcceptChanges();

                                    MessageBox.Show(dtCheck.Rows.Count.ToString());
                                    break;
                                }
                            }
                        }
                    }
                }
            }

        }

        //load cbb giao vien
        private void loadCbb_GiaoVien()
        {
            DataTable dtGV = new DataTable();
            dtGV = LopHocDao.giangVien();
            checkLichTrong(dtGV, "GvID");
            loadCombobox(cbb_GiangVien, dtGV, "HOTEN", "GvID");
        }

        //load lịch học all môn
        private void loadLichHoc()
        {
            dtLichHoc = LopHocDao.lichHocCacMon();
        }

        //chuẩn hóa 'Thứ 2' về '2':
        private string chuanHoa(string s)
        {
            // Xóa tất cả các dấu cách trong chuỗi
            s = s.Replace(" ", "");

            // Loại bỏ tất cả các kí tự không phải số
            s = Regex.Replace(s, "[^0-9]", "");

            return s;
        }

        //ktra chọn đủ số buổi học chưa
        private void kiemTraNgayHoc(CheckBox cb)
        {
            if (cb.Checked == true)
            {
                --soBuoiHoc;
            }
            else
            {
                ++soBuoiHoc;
            }
            //Nếu có lỗi số buổi học > khi chọn trên cbb thì đưa về đúng số buổi đã chọn
            if (soBuoiHoc > Convert.ToInt32((cbb_ChonSoBuoiHoc.SelectedItem).ToString()))
                soBuoiHoc = Convert.ToInt32((cbb_ChonSoBuoiHoc.SelectedItem).ToString());
            //nếu đã chọn đủ số lượng buổi học thì không được chọn thêm buổi nào nữa
            if (soBuoiHoc == 0)
            {
                foreach (CheckBox cbox in pnl_QLNgayHoc.Controls.OfType<CheckBox>())
                {
                    if (cbox.Checked == false)
                        cbox.Enabled = false;
                }
            }
            else//ngược lại nếu chưa đủ thì tất cả checkbox đều được chọn
            {
                foreach (CheckBox cbox in pnl_QLNgayHoc.Controls.OfType<CheckBox>())
                {
                    cbox.Enabled = true;
                }
            }
        }
        private void cbox_Thu2_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox cb = sender as CheckBox;
            try
            {
                kiemTraNgayHoc(cb);
                loadCbb_PhongHoc();
                loadCbb_GiaoVien();
            }
            catch
            {
                //MessageBox.Show("Bạn chưa chọn số buổi học!");
                cb.Checked = false;
            }
            return;

        }
        private void cbox_Thu3_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox cb = sender as CheckBox;
            kiemTraNgayHoc(cb);
            loadCbb_PhongHoc();
            loadCbb_GiaoVien();
        }
        private void cbox_Thu4_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox cb = sender as CheckBox;
            kiemTraNgayHoc(cb);
            loadCbb_PhongHoc();
            loadCbb_GiaoVien();
        }
        private void cbox_Thu5_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox cb = sender as CheckBox;
            kiemTraNgayHoc(cb);
            loadCbb_PhongHoc();
            loadCbb_GiaoVien();
        }
        private void cbox_Thu6_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox cb = sender as CheckBox;
            kiemTraNgayHoc(cb);
            loadCbb_PhongHoc();
            loadCbb_GiaoVien();
        }
        private void cbox_Thu7_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox cb = sender as CheckBox;
            kiemTraNgayHoc(cb);
            loadCbb_PhongHoc();
            loadCbb_GiaoVien();
        }

        #region checkLoi
        //ktra đã chọn sô buổi học chưa
        private void chonSoBuoiHoc()
        {
            if (cbb_ChonSoBuoiHoc.SelectedIndex < 0)
                pnl_QLNgayHoc.Enabled = false;
            else pnl_QLNgayHoc.Enabled = true;
        }
        //ktra thanh trang thai
        //private bool chonTrangThai()
        //{
        //    if (btn_TrangThai.Text.ToString() != @"Hoạt Động" && btn_TrangThai.Text.ToString() != @"Đã đầy")
        //        return false;
        //    return true;
        //}
        //ktra soHocVien
        private bool chonSoHocVien()
        {
            int soLuongHV;
            bool isInt = int.TryParse(txt_SLHocVien.Text.ToString(), out soLuongHV);
            //ktra txtboxHocVien có rỗng hay có phải số nguyên không
            if (String.IsNullOrEmpty(txt_SLHocVien.Text.ToString()) || !isInt)
            {
                return false;
            }
            return true;
        }
        //ktra tích đủ số thứ học 
        private bool chonDuSoNgayHoc()
        {
            int soNgayHoc = 0;
            foreach (CheckBox cb in pnl_QLNgayHoc.Controls.OfType<CheckBox>())
            {
                if (cb.Checked) ++soNgayHoc;
            }
            if (soNgayHoc == Convert.ToInt32(cbb_ChonSoBuoiHoc.SelectedItem.ToString()))
                return true;
            return false;

        }
        #endregion

#if false //load cbb lophoc, khoahoc
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

        //load cbb khoa hoc
        private void loadCbb_KhoaHoc()
        {
            DataTable distinctMaKH = dtKhoaHoc.DefaultView.ToTable(true, new string[] { "MaKH", "TenKH" });
            loadCombobox(cbb_ChonKhoaHoc, distinctMaKH, "TenKH", "MaKH");
        }
#endif

    }
}
