using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Forms;

namespace DemoDoAn.ChildPage.QLThuChi
{
    public partial class F_THUCHI_TAOPHIEUTHU : Form
    {
        PhieuThuDao ptDao = new PhieuThuDao();
        DataTable dtLopHoc = new DataTable();
        string malop;

        public F_THUCHI_TAOPHIEUTHU()
        {
            InitializeComponent();
        }


        private void btn_Thoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_Them_Click(object sender, EventArgs e)
        {
            if(ktraThongTin())
            {
                string maPT = "";
                string loaiPT = "Học phí";
                PhieuThu pt = new PhieuThu(maPT, loaiPT, Convert.ToDateTime(datePTime_NgayChi.Value), Convert.ToInt32(txt_TongTien.Text), txt_NguoiNhan.Text.ToString(), malop);
                ptDao.taoPhieuThu(pt);
                this.Close();
            }
            else
            {
                MessageBox.Show("Thông tin không hợp lẹ!");
            }
        }

        //load ten + lop hoc
        private void txt_NguoiNhan_TextChanged(object sender, EventArgs e)
        {
            string hvid = txt_NguoiNhan.Text.ToString();
            loadNguoiNop(hvid);
            taiCbbLopHoc(hvid);
        }

        //load ten nguoi nop tien
        private void loadNguoiNop(string hvid)
        {
            DataTable dt = new DataTable();
            dt = ptDao.loadNguoiNop(hvid);
            if (dt.Rows.Count > 0)
            {
                txt_HoTen.Text = dt.Rows[0]["HOTEN"].ToString();
            }
            else
            {
                txt_HoTen.Text = null;
            }
        }

        //lay malop
        private void cbb_LopHoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ComboBox cbb = sender as ComboBox;
                malop = ((DataRowView)cbb.SelectedItem)["MaLop"].ToString();
            }
            catch
            {
                MessageBox.Show("Lớp học không khả dụng!");            }
        }

        //load cbb LopHoc
        private void taiCbbLopHoc(string hvid)
        {
            dtLopHoc.Clear();
            dtLopHoc = ptDao.taiLopHoc(hvid);
            loadCombobox(cbb_LopHoc, dtLopHoc, "TenMon", "MaLop");
        }
        //load combobox
        private void loadCombobox(ComboBox cbb, DataTable dt, string displayMember, string valueMember)
        {
            cbb.DataSource = dt;
            cbb.DisplayMember = displayMember;
            cbb.ValueMember = displayMember;
        }

        //ktra thong tin
        private bool ktraThongTin()
        {

            if (String.IsNullOrEmpty(txt_HoTen.Text) || String.IsNullOrEmpty(txt_TongTien.Text) || String.IsNullOrEmpty(malop) ||
                String.IsNullOrEmpty(txt_NguoiNhan.Text) || String.IsNullOrEmpty(txt_NguoiNhan.Text))
                return false;
            return true;
        }

    }
}
