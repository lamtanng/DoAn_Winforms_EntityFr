using DemoDoAn.ChildPage.HAMTHU;
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
    public partial class UC_HAMTHUGOPY_CHILD : UserControl
    {
        UC_HAMTHU thu = new UC_HAMTHU();
        HamThuDAO thuDao = new HamThuDAO();
        string mathu, ten, tieude, noidung;
        DateTime ngay, gio;
        bool danhdau;

        #region DOHOA

        bool isVisible = true;
        //do hoa
        private void showDelete()
        {
            if (isVisible == true)
            {
                pnl_PhanCach.Visible = false;
                isVisible = false;
            }
            else
            {
                pnl_PhanCach.Visible = true;
                isVisible = true;
            }
        }

        public void checkDanhDau()
        {
            if (danhdau == true)
            {
                pBox_DanhDau.Image = new Bitmap(Application.StartupPath + "\\Resources\\star_Gold.png");
                pBox_DanhDau.SizeMode = PictureBoxSizeMode.Zoom;
            }
            else
            {
                pBox_DanhDau.Image = new Bitmap(Application.StartupPath + "\\Resources\\star_White.png");
                pBox_DanhDau.SizeMode = PictureBoxSizeMode.Zoom;
            }
        }

        private void pBox_DanhDau_Click(object sender, EventArgs e)
        {
            if (danhdau == false)
            {
                pBox_DanhDau.Image = new Bitmap(Application.StartupPath + "\\Resources\\star_Gold.png");
                pBox_DanhDau.SizeMode = PictureBoxSizeMode.Zoom;
                danhdau = true;
                thuDao.DanhDau(danhdau, lbl_MaThu.Text.ToString());
            }
            else
            {
                pBox_DanhDau.Image = new Bitmap(Application.StartupPath + "\\Resources\\star_White.png");
                pBox_DanhDau.SizeMode = PictureBoxSizeMode.Zoom;
                danhdau = false;
                thuDao.DanhDau(danhdau, lbl_MaThu.Text.ToString());
            }
        }
        #endregion

        public event EventHandler ReadClicked;
        public event EventHandler DeleteClicked;

        public UC_HAMTHUGOPY_CHILD()
        {
            InitializeComponent();
        }
        public UC_HAMTHUGOPY_CHILD(string mathu, string ten, string tieude, string noidung, DateTime ngay, DateTime gio, bool danhdau)
        {
            InitializeComponent();
            this.ten = ten;
            this.tieude = tieude;
            this.noidung = noidung;
            this.danhdau = danhdau;
            this.ngay = ngay;
            this.gio = gio;
            this.mathu = mathu;
            checkDanhDau();
        }

        public string MATHU { get { return mathu; } set { ten = mathu; } }
        public string TEN { get { return ten; } set {  ten = value; } }
        public string TIEUDE { get { return tieude; } set { tieude = value; } }
        public string NOIDUNG { get { return noidung; } set { noidung = value; } }
        public DateTime NGAY { get { return ngay; } set { ngay = value; } }
        public DateTime GIO { get { return gio; } set { gio = value; } }
        public bool DANHDAU { get { return danhdau; } set { danhdau = value; } }

        private void UC_HAMTHUGOPY_CHILD_Load(object sender, EventArgs e)
        {
            lbl_MaThu.Text = mathu.ToString();
            lbl_HoTen.Text = ten.ToString();
            lbl_NgayThang.Text = ngay.ToString("dd/MM/yyyy");
            lbl_TieuDe.Text = tieude.ToString();
            lbl_NoiDung.Text = noidung.ToString();
            lbl_Gio.Text = gio.ToString("hh:mm:ss");
        }

        //xoa thu
        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            EventHandler handler = DeleteClicked;
            if (handler != null)
            {
                handler(this, e);
            }
        }
        private void pBox_Xoa_Click(object sender, EventArgs e)
        {
            EventHandler handler = DeleteClicked;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        //hien chi tiet thu
        private void btn_NoiDung_Click(object sender, EventArgs e)
        {
            showDelete();
            EventHandler handler = ReadClicked;
            if (handler != null)
            {
                handler(this, e);
            }
        }

#if false

        public partial class UcNoticeItem : UserControl
        {
            Notice notice = new Notice();
            string noiDung;
            string maThongBao;
            public UcNoticeItem(string user, string maNguoiGui, string maThongBao, string ngayGui, string nameGV,
                string IDLop, string IDKhoa,
                string tieuDe, string noiDung)
            {
                InitializeComponent();
                txtTieuDe.Text = tieuDe;
                lbMaLop.Text = IDLop;
                lbMaKhoa.Text = IDKhoa;
                lbName.Text = nameGV;
                if (!maNguoiGui.Contains("gv")) lbName.Text = maNguoiGui;
                lbNgayGui.Text = ngayGui;
                this.noiDung = noiDung;
                this.maThongBao = maThongBao;
                if (user.Contains("sv")) btnDelete.Hide();
            }
            public string TextTieuDe
            {
                get { return txtTieuDe.Text; }
            }
            public string TextNoiDung
            {
                get { return noiDung; }
            }
            public string IDLop
            {
                get { return lbMaLop.Text; }
            }
            public string IDKhoa
            {
                get { return lbMaKhoa.Text; }
            }
            public string NameGiaoVien
            {
                get { return lbName.Text; }
            }
            public string NgayGui
            {
                get { return lbNgayGui.Text; }
            }
            public event EventHandler btnReadClicked;
            public event EventHandler btnDeleteClicked;

            private void btnRead_Click(object sender, EventArgs e)
            {
                EventHandler handler = btnReadClicked;
                if (handler != null)
                {
                    handler(this, e);
                }
            }

            private void btnDelete_Click(object sender, EventArgs e)
            {
                var r = notice.DeleteNotice(maThongBao);
                btnDeleteClicked?.Invoke(this, EventArgs.Empty);
            }

        }
#endif
    }
}
