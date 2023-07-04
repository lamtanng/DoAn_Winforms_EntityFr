using DemoDoAn.HOCVIEN;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DemoDoAn.FORM
{
    public partial class F_HOCVIEN : Form
    {
        int chucVu; // 0 la admin;  1 la hocvien;  2 la giao vien

        public F_HOCVIEN(int chucVu)
        {
            InitializeComponent();
            this.chucVu = chucVu;   
        }

        //ẩn menu con
        private void hideSubMenu()
        {
            foreach (var pnl in pnl_Menu.Controls.OfType<Panel>())
                pnl.Visible = false;
        }
        //hiện menu con 
        private void showSubMenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                hideSubMenu();
                subMenu.Visible = true;
            }
            else
                subMenu.Visible = false;
        }
        //
        private void selectButton(UserControl uc)
        {

           
            pnl_Page.Controls.Clear();
            pnl_Page.Controls.Add(uc);
        }

        private void picBox_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_DSLop_Click(object sender, EventArgs e)
        {
            UC_THONGTINHOCVIEN thongtin = new UC_THONGTINHOCVIEN(chucVu);
            selectButton(thongtin);
        }

        private void btn_QLHocSinh_Click(object sender, EventArgs e)
        {
            UC_HAMTHUGOPY hopthu = new UC_HAMTHUGOPY();
            selectButton(hopthu);
        }

        private void btn_QLChung_Click(object sender, EventArgs e)
        {
            UC_TKB tkb = new UC_TKB(chucVu,2);
            selectButton(tkb);
        }

        private void btn_QLHocTap_Click(object sender, EventArgs e)
        {
            UC_TKB tkb = new UC_TKB(chucVu,1);
            selectButton(tkb);
        }

        private void pBox_Logout_Click(object sender, EventArgs e)
        {
            Login log = new Login();
            if (MessageBox.Show("Bạn có muốn đăng xuất?", "Đăng xuất", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                // user clicked yes
                this.Close();
                log.Show();
            }
        }

        private void btn_QLNhanSu_Click(object sender, EventArgs e)
        {
            UC_DANGKILOP dsLop = new UC_DANGKILOP(chucVu);
            selectButton(dsLop);
        }
    }
}
