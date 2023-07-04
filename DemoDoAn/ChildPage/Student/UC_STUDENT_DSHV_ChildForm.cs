using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DemoDoAn.ChildPage.Student
{
    public partial class UC_STUDENT_DSHV_ChildForm : UserControl
    {
        HocSinhDao hs=new HocSinhDao();
        public UC_STUDENT_DSHV_ChildForm()
        {
            InitializeComponent();
        }

        private void txt_HoTen_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn_CapNhatThongTin_Click(object sender, EventArgs e)
        {
            ChildForm.F_UpdateHV a = new ChildForm.F_UpdateHV();
            a.Show();
        }

        private void btn_Xoa_Click(object sender, EventArgs e)
        {

        }
        //lbl1.Visible = false;

   /* ----gridview_Click
    {
    lbl1.Text = GridView.CurrentRow.Cells[0].Value.ToString();
    lbl1.Visible = true;*/
        private void UC_STUDENT_DSHV_ChildForm_Load(object sender, EventArgs e)
        {
            lbl_ID.Visible = false;
            
            hs.LayDanhSachSinhVien();
            
            /*  lblGioiTinh.DataBindings.Clear();
              f
              lbl_MaGV.DataBindings.Clear();
              lbl_MaGV.DataBindings.Add("Text", dataGrView_DSGV.DataSource, "GvID");
              lbl_TenGV.DataBindings.Clear();
              lbl_TenGV.DataBindings.Add("Text", dataGrView_DSGV.DataSource, "HOTEN");
              lbl_DiaChi.DataBindings.Clear();
              lbl_DiaChi.DataBindings.Add("Text", dataGrView_DSGV.DataSource, "DIACHI");
              lbl_NgaySinh.DataBindings.Clear();
              lbl_NgaySinh.DataBindings.Add("Text", dataGrView_DSGV.DataSource, "NGAYSINH");
              btn_SDT.DataBindings.Clear();
              btn_SDT.DataBindings.Add("Text", dataGrView_DSGV.DataSource, "SDT");
              btn_Email.DataBindings.Clear();
              btn_Email.DataBindings.Add("Text", dataGrView_DSGV.DataSource, "EMAIL");*/
        }

        private void txt_SDTPhuHuynh_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
