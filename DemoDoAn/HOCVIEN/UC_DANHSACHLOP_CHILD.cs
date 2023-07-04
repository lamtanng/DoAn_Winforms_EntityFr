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
    public partial class UC_DANHSACHLOP_CHILD : UserControl
    {
        string tenKH, tenLop, hocPhi, GV;

        public UC_DANHSACHLOP_CHILD()
        {
            InitializeComponent();
        }
         public UC_DANHSACHLOP_CHILD(string tenKH, string tenLop, string hocPhi, string GV)
        {
            InitializeComponent();
            this.tenKH = tenKH;
            this.tenLop = tenLop;
            this.hocPhi = hocPhi;
            this.GV = GV;
        }
        private void UC_DANHSACHLOP_CHILD_Load(object sender, EventArgs e)
        {
            lbl_TT_TenKhoaHoc.Text = tenKH.ToString();
            lbl_TT_TenLopHoc.Text = tenLop.ToString();
            btn_HocPhi.Text = hocPhi.ToString();
            lbl_TenGiangVien.Text = GV.ToString();
        }
    }
}
