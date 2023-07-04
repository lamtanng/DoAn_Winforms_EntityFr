using DemoDoAn.ChildPage.General_Management;
using DemoDoAn.ChildPage.HocTap;
using DemoDoAn.ChildPage.Personnel;
using DemoDoAn.ChildPage.QLThuChi;
using DemoDoAn.ChildPage.ThongKe;
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
    public partial class F_Addmin : Form
    {
        ImageList imgL = new ImageList();

        public F_Addmin()
        {
            InitializeComponent();
            //imgL.Images.Add("pic1", new Bitmap(Application.))
            hideSubMenu();
        }

        private void picBox_Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
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
        private void unselectButton()
        {
            foreach (var pnl in pnl_Menu.Controls.OfType<Panel>())
            {
                foreach (var btn in pnl.Controls.OfType<Button>())
                {
                    if (btn.BackColor == Color.FromArgb(32, 133, 233))
                    {
                        btn.FlatAppearance.MouseOverBackColor = Color.FromArgb(245, 248, 255);
                        btn.FlatAppearance.MouseDownBackColor = Color.FromArgb(245, 248, 255);
                        btn.BackColor = Color.FromArgb(245, 248, 255);
                        btn.ForeColor = Color.FromArgb(126, 127, 127);
                    }
                }
            }


            //case "pBox_LichHoc": pBox.Image = imgL.Images["pic1"]; break;
            changColorIcon(pBox_Class, "Dark_QLChung_Class.png", Color.FromArgb(245, 248, 255));
            changColorIcon(pBox_Room, "Dark_QLChung_Room.png", Color.FromArgb(245, 248, 255));
            changColorIcon(pBox_Course, "Dark_QLChung_Course.png", Color.FromArgb(245, 248, 255));
            changColorIcon(pBox_DiemSo, "Dark_DiemSo.png", Color.FromArgb(245, 248, 255));
            changColorIcon(pBox_DSHV, "Dark_DSHocVien.png", Color.FromArgb(245, 248, 255));
            changColorIcon(pBox_LichHoc, "Dark_Schedule.png", Color.FromArgb(245, 248, 255));
            changColorIcon(pBox_XepLop, "Dark_XepLop.png", Color.FromArgb(245, 248, 255));
            changColorIcon(pBox_GiangVien, "Dark_GiangVien.png", Color.FromArgb(245, 248, 255));
            changColorIcon(pBox_NhanVien, "Dark_NhanVien.png", Color.FromArgb(245, 248, 255));
            changColorIcon(pBox_BangLuong, "Dark_BangLuong.png", Color.FromArgb(245, 248, 255));
            changColorIcon(pBox_PhieuThu, "Dark_PhieuThu_Chi.png", Color.FromArgb(245, 248, 255));
            changColorIcon(pBox_PhieuChi, "Dark_PhieuThu_Chi.png", Color.FromArgb(245, 248, 255));
            changColorIcon(pBox_HocPhi, "Dark_HocPhi.png", Color.FromArgb(245, 248, 255));
            changColorIcon(pBox_GhiDanh, "Dark_GhiDanh.png", Color.FromArgb(245, 248, 255));
            changColorIcon(pBox_HocTap, "Dark_HocTap.png", Color.FromArgb(245, 248, 255));
            changColorIcon(pBox_ChamCong, "Dark_ChamCong.png", Color.FromArgb(245, 248, 255));
            changColorIcon(pBox_EmailBox, "Dark_Email.png", Color.FromArgb(245, 248, 255));

        }
        //
        private void changColorIcon(PictureBox pBox, string pathImage, Color backColor)
        {
            pBox.Image = new Bitmap(Application.StartupPath + "\\Resources\\" + pathImage);
            pBox.BackColor = backColor;
        }

        //
        private void selectButton(UserControl uc, PictureBox pBox, Button btn)
        {
            btn.FlatAppearance.MouseOverBackColor = Color.FromArgb(32, 133, 233);
            btn.FlatAppearance.MouseDownBackColor = Color.FromArgb(32, 133, 233);
            switch (pBox.Name)
            {

                case "pBox_LichHoc": pBox.Image = new Bitmap(Application.StartupPath + "\\Resources\\Ligth_Schedule.png"); break;
                case "pBox_Class": pBox.Image = new Bitmap(Application.StartupPath + "\\Resources\\Light_QLChung_Class.png"); break;
                case "pBox_Room": pBox.Image = new Bitmap(Application.StartupPath + "\\Resources\\Light_QLChung_Room.png"); break;
                case "pBox_Course": pBox.Image = new Bitmap(Application.StartupPath + "\\Resources\\Light_QLChung_Course.png"); break;
                case "pBox_DiemSo": pBox.Image = new Bitmap(Application.StartupPath + "\\Resources\\Light_DiemSo.png"); break;
                case "pBox_DSHV": pBox.Image = new Bitmap(Application.StartupPath + "\\Resources\\Light_DSHocVien.png"); break;
                case "pBox_DiemDanh": pBox.Image = new Bitmap(Application.StartupPath + "\\Resources\\Light_DiemDanh.png"); break;
                case "pBox_XepLop": pBox.Image = new Bitmap(Application.StartupPath + "\\Resources\\Light_XepLop.png"); break;
                case "pBox_GiangVien": pBox.Image = new Bitmap(Application.StartupPath + "\\Resources\\Light_GiangVien.png"); break;
                case "pBox_NhanVien": pBox.Image = new Bitmap(Application.StartupPath + "\\Resources\\Light_NhanVien.png"); break;
                case "pBox_BangLuong": pBox.Image = new Bitmap(Application.StartupPath + "\\Resources\\Light_BangLuong.png"); break;
                case "pBox_PhieuThu": pBox.Image = new Bitmap(Application.StartupPath + "\\Resources\\Light_PhieuThu_Chi.png"); break;
                case "pBox_PhieuChi": pBox.Image = new Bitmap(Application.StartupPath + "\\Resources\\Light_PhieuThu_Chi.png"); break;
                case "pBox_HocPhi": pBox.Image = new Bitmap(Application.StartupPath + "\\Resources\\Light_HocPhi.png"); break;
                case "pBox_GhiDanh": pBox.Image = new Bitmap(Application.StartupPath + "\\Resources\\Light_GhiDanh.png"); break;
                case "pBox_HocTap": pBox.Image = new Bitmap(Application.StartupPath + "\\Resources\\Light_HocTap.png"); break;
                case "pBox_ChamCong": pBox.Image = new Bitmap(Application.StartupPath + "\\Resources\\Light_ChamCong.png"); break;
                case "pBox_EmailBox": pBox.Image = new Bitmap(Application.StartupPath + "\\Resources\\Night_Email.png"); break;
                default: break;
            }

            btn.BackColor = Color.FromArgb(32, 133, 233);
            pBox.BackColor = btn.BackColor;
            btn.ForeColor = Color.FromArgb(249, 249, 249);
            pnl_Page.Controls.Clear();
            pnl_Page.Controls.Add(uc);
        }
        private void btn_QLChung_Click(object sender, EventArgs e)
        {

            showSubMenu(pnl_QLManagement);
        }

        private void btn_QLHocTap_Click(object sender, EventArgs e)
        {

            showSubMenu(pnl_QLHocTap);
        }

        private void btn_QLHocSinh_Click(object sender, EventArgs e)
        {
            showSubMenu(pnl_QLHocVien);
        }

        private void btn_QLNhanSu_Click(object sender, EventArgs e)
        {
            showSubMenu(pnl_QLNhanSu);
        }

        private void btn_QLThuChi_Click(object sender, EventArgs e)
        {
            showSubMenu(pnl_QLThuChi);
        }

        private void btn_QLThongKe_Click(object sender, EventArgs e)
        {
            showSubMenu(pnl_QLThongKe);
        }

        private void picBox_Minisize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btn_DSHocSinh_Click(object sender, EventArgs e)
        {
            ChildPage.Student.UC_STUDENT_DSHocVien ucGMInfo = new ChildPage.Student.UC_STUDENT_DSHocVien();
            unselectButton();
            selectButton(ucGMInfo, pBox_DSHV, btn_DSHocSinh);
        }

        private void btn_XepLop_Click(object sender, EventArgs e)
        {
            ChildPage.UC_STUDENT_XEPLOP ucXepLop = new ChildPage.UC_STUDENT_XEPLOP();
            unselectButton();
            selectButton(ucXepLop, pBox_XepLop, btn_XepLop);
        }

        private void btn_GiangVien_Click(object sender, EventArgs e)
        {
            ChildPage.UC_PERSONNEL_LECTURE ucLecture = new ChildPage.UC_PERSONNEL_LECTURE();
            unselectButton();
            selectButton(ucLecture, pBox_GiangVien, btn_GiangVien);
        }

        private void btn_DSLop_Click(object sender, EventArgs e)
        {
            ChildPage.UC_DSLopMoi uc_Class = new ChildPage.UC_DSLopMoi();
            unselectButton();
            selectButton(uc_Class, pBox_DSHV, btn_DSLop);
        }

        private void btn_Class_Click(object sender, EventArgs e)
        {
            ChildPage.UC_GM_CLASS uc_Class = new ChildPage.UC_GM_CLASS();
            unselectButton();
            selectButton(uc_Class, pBox_Class, btn_Class);
        }

        private void btn_Room_Click(object sender, EventArgs e)
        {
            ChildPage.UC_GM_ROOM ucRoom = new ChildPage.UC_GM_ROOM();
            unselectButton();
            selectButton(ucRoom, pBox_Room, btn_Room);
        }

        private void btn_PhieuThu_Click(object sender, EventArgs e)
        {
            ChildPage.QLThuChi.UC_THUCHI_THU ucThu = new ChildPage.QLThuChi.UC_THUCHI_THU();
            unselectButton();
            selectButton(ucThu, pBox_PhieuThu, btn_PhieuThu);
        }

        private void btn_PhieuChi_Click(object sender, EventArgs e)
        {
            UC_THUCHI_CHI uCChi = new UC_THUCHI_CHI();
            unselectButton();
            selectButton(uCChi, pBox_PhieuChi, btn_PhieuChi);
        }

        private void btn_Course_Click(object sender, EventArgs e)
        {
            UC_GM_COURSE uC_Course = new UC_GM_COURSE();
            unselectButton();
            selectButton(uC_Course, pBox_Course, btn_Course);
        }

        private void btn_NhanVien_Click(object sender, EventArgs e)
        {
            UC_PERSONNEL_NV ucNV = new UC_PERSONNEL_NV();
            unselectButton();
            selectButton(ucNV, pBox_NhanVien, btn_NhanVien);
        }

        private void btn_DiemSo_Click(object sender, EventArgs e)
        {
            UC_HOCTAP_QLDiem ucDiem = new UC_HOCTAP_QLDiem();
            unselectButton();
            selectButton(ucDiem, pBox_DiemSo, btn_DiemSo);
        }

        private void btn_HocPhi_Click(object sender, EventArgs e)
        {
            UC_THONGKE_HOCPHI uC_hocPhi = new UC_THONGKE_HOCPHI();
            unselectButton();
            selectButton(uC_hocPhi, pBox_HocPhi, btn_HocPhi);
        }

        private void pBox_DSHV_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            UC_HAMTHUGOPY hamThu = new UC_HAMTHUGOPY();
            unselectButton();
            selectButton(hamThu, pBox_EmailBox, btn_EmailBox);
        }

        private void btn_BangLuong_Click(object sender, EventArgs e)
        {
            UC_PERSONNEL_BANGLUONG bangLuong = new UC_PERSONNEL_BANGLUONG();
            unselectButton();
            selectButton(bangLuong, pBox_BangLuong, btn_BangLuong);
        }

        private void btn_GhiDanh_Click(object sender, EventArgs e)
        {
            UC_THONGKE_GHIDANH ghiDanh = new UC_THONGKE_GHIDANH();
            unselectButton();
            selectButton(ghiDanh, pBox_GhiDanh, btn_GhiDanh);
        }

        private void btn_HocTap_Click(object sender, EventArgs e)
        {
            UC_THONGKE_HOCTAP hocTap = new UC_THONGKE_HOCTAP();
            unselectButton();
            selectButton(hocTap, pBox_HocTap, btn_HocTap);
        }

        private void btn_ChamCong_Click(object sender, EventArgs e)
        {
            UC_THONGKE_CHAMCONG chamCong = new UC_THONGKE_CHAMCONG();
            unselectButton();
            selectButton(chamCong, pBox_ChamCong, btn_ChamCong);
        }

        private void btn_LichHoc_Click(object sender, EventArgs e)
        {
            UC_GM_SCHEDULE lichhoc = new UC_GM_SCHEDULE();
            unselectButton();
            selectButton(lichhoc, pBox_LichHoc, btn_LichHoc);
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
            else
            {
                // user clicked no
            }

        }
    }
}
