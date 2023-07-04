using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DemoDoAn.GIANGVIEN
{
    public partial class UC_XACNHANLOP_CHILD : UserControl
    {
        LopHocDao lhDao = new LopHocDao();
        GiaoVienDao gvDao = new GiaoVienDao();
        string tenLH, maLH, phong, giobd, giokt, thu, ngaybd, ngaykt;

        public event EventHandler DeleteClicked;

        

        public UC_XACNHANLOP_CHILD()
        {
            InitializeComponent();
        }
        public UC_XACNHANLOP_CHILD(string maLH, string tenLH, string phong, string thu, string giobd, string giokt, string ngaybd, string ngaykt)
        {
            InitializeComponent();
            this.maLH = maLH;
            this.tenLH = tenLH;
            this.phong = phong;
            this.thu = thu;
            this.giobd = giobd;
            this.giokt = giokt;
            this.ngaybd = ngaybd;
            this.ngaykt = ngaykt;
        }
        public string MALH { get { return maLH; } set { maLH = value; } }
        public string TENLH { get { return tenLH; } set { tenLH = value; } }
        public string PHONG { get { return phong; } set { phong = value; } }
        public string THU { get { return thu; } set { thu = value; } }
        public string GIOBD { get { return giobd; } set { giobd = value; } }
        public string GIOKT { get { return giokt; } set { giokt = value; } }
        public string NGAYBD { get { return ngaybd; } set { ngaybd = value; } }
        public string NGAYKT { get { return ngaykt; } set { ngaykt = value; } }

        private void UC_DANGKYLOP_CHILD_Load(object sender, EventArgs e)
        {
            hienThongTin();
        }
        //load thong tin
        private void hienThongTin()
        {
            lbl_MaLH.Text = maLH.ToString().Trim();
            lbl_TenLH.Text = tenLH.ToString().Trim();
            lbl_Thu.Text = thu.ToString().Trim();
            lbl_Ca.Text = giobd + " - " + giokt;
            lbl_NgayBD.Text = ngaybd;
            lbl_NgayKT.Text = ngaykt; 
        }

        //huy
        private void btn_Huy_Click(object sender, EventArgs e)
        {
            //xoa giang vien
            lhDao.capNhatGiangVienChoLop(maLH, null);
            EventHandler handler = DeleteClicked;
            if (handler != null)
            {
                handler(this, e);
            }
        }
        //xac nhan
        private void btn_XacNhan_Click(object sender, EventArgs e)
        {
            //xac nhan day
            gvDao.xacNhanDay(maLH,1);
            EventHandler handler = DeleteClicked;
            if (handler != null)
            {
                handler(this, e);
            }
        }
    }
}
