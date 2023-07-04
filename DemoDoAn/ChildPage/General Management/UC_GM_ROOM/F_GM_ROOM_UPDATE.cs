using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DemoDoAn.ChildPage.General_Management.UC_GM_ROOM
{
    public partial class F_GM_ROOM_UPDATE : Form
    {
        PhongHocDao phongDao =  new PhongHocDao();
        string phong;
        public F_GM_ROOM_UPDATE()
        {
            InitializeComponent();
        }
        public F_GM_ROOM_UPDATE(string phong)
        {
            InitializeComponent();
            this.phong = phong;
        }

        #region XuLiDoHoa
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

        #endregion

        private void btn_TrangThai_Click(object sender, EventArgs e)
        {
            timer_LoadTrangThai.Start();
        }
        private void timer_LoadTrangThai_Tick(object sender, EventArgs e)
        {
            ShowListChoss(fLPnl_TrangThai, timer_LoadTrangThai, ref select_TrangThai);
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

        private void F_GM_ROOM_UPDATE_Load(object sender, EventArgs e)
        {
            taiThongTin();
        }

        private void taiThongTin()
        {
            lbl_TenPhong.Text = phong.ToString().Trim();
        }

        private void btn_Huy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_HoanThanh_Click(object sender, EventArgs e)
        {
            try
            {
                if(checkTrangThai())
                {
                    PhongHoc phong = new PhongHoc(lbl_TenPhong.Text.ToString(), btn_TrangThai.Text.ToString());
                    phongDao.capNhat(phong);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Vui lòng kiểm tra lại thông tin!");
                }
                
            }
            catch
            {
                MessageBox.Show("Không thành công!");
            }
        }

        //ktra trang thai
        private bool checkTrangThai()
        {
            if(btn_TrangThai.Text.ToString() != @"Hoạt Động" && btn_TrangThai.Text.ToString() != @"Đã Đầy")
                return false;
            return true;
        }
    }
}
