using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DemoDoAn.ChildPage.QLThuChi
{
    public partial class UC_THUCHI_THU_FormAVT : UserControl
    {
        DataGridViewRow dtgRow = new DataGridViewRow();

        enum dinhDangThang
        {
            JAN = 1,
            FEB = 2,
            MAR = 3,
            APR = 4,
            MAY = 5,
            JUN = 6,
            JUL = 7,
            AUG = 8,
            SEP = 9,
            OCT = 10,
            NOV = 11,
            DEC = 12
        }

        public UC_THUCHI_THU_FormAVT()
        {
            InitializeComponent();
        }
        public UC_THUCHI_THU_FormAVT(DataGridViewRow dtgRow)
        {
            InitializeComponent();
            this.dtgRow = dtgRow;
            taiThongTin();
        }

        //load thong tin
        private void taiThongTin()
        {
            lbl_SoTien.Text = dtgRow.Cells["SoTienDong"].Value.ToString();
            lbl_LoaiThu.Text = dtgRow.Cells["LoaiTien"].Value.ToString();
            lbl_NgayThu.Text = Convert.ToDateTime (dtgRow.Cells["Ngay"].Value).Day.ToString();
            lbl_ThangThu.Text = doiDinhDangThang(Convert.ToDateTime(dtgRow.Cells["Ngay"].Value).Month.ToString());
        }
        //Chuyen dinh dang thang
        private string doiDinhDangThang(string thang)
        {
            int m = (int)dinhDangThang.NOV;
            foreach (dinhDangThang day in Enum.GetValues(typeof(dinhDangThang)))
            {
                if(Convert.ToUInt32( thang) == (int)day)
                {
                    thang = day.ToString();
                    return thang;
                }
            }
            return thang;
        }
    }
}
