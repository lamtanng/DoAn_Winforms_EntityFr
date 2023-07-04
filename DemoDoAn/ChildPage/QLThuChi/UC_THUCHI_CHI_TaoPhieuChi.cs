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
    public partial class UC_THUCHI_CHI_TaoPhieuChi : Form
    {
        PhieuChiDao pcDao = new PhieuChiDao();
        string chucVuTable;
        string cotMaSo;
        string maso;

        //ten bang
        enum nameChucVu
        {
            HOCVIEN = 0,
            GIANGVIEN = 1,
            NHANVIEN = 2
        }

        //ten cac cot ID 
        enum nameCol_ID
        {
            HVID = 0,
            GvID = 1,
            NVID = 2
        }

        public UC_THUCHI_CHI_TaoPhieuChi()
        {
            InitializeComponent();
        }

        private void btn_Huy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //them
        private void button2_Click(object sender, EventArgs e)
        {
            if(checkThongTin())
            {
                string chucvu = cbb_ChucVu.SelectedItem.ToString();
                PhieuChi pc = new PhieuChi(txt_NguoiNhan.Text.ToString(), chucvu, txt_LoaiPhieuChi.Text.ToString(),
                                            Convert.ToInt32(txt_TongTien.Text), datePTime_NgayChi.Value);
                pcDao.themPhieuChi(pc);
                this.Close();
            }
            else
            {
                MessageBox.Show("Vui lòng kiểm tra lại thông tin!");
            }

        }

        //chon chuc vu
        private void cbb_ChucVu_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cbb = sender as ComboBox;
            if (cbb.SelectedIndex >= 0)
            {
                if(cbb.SelectedIndex == 0)
                {
                    chucVuTable = nameChucVu.HOCVIEN.ToString();
                    cotMaSo = nameCol_ID.HVID.ToString();
                }
                else if(cbb.SelectedIndex == 1)
                {
                    chucVuTable = nameChucVu.GIANGVIEN.ToString();
                    cotMaSo = nameCol_ID.GvID.ToString();
                }
                else if (cbb.SelectedIndex == 2)
                {
                    chucVuTable = nameChucVu.NHANVIEN.ToString();
                    cotMaSo = nameCol_ID.NVID.ToString();
                }
                loadNguoiNhan(chucVuTable, cotMaSo, maso);
            }
        }

        //load ten ng nhan
        private void loadNguoiNhan(string table, string cotmaso,string maso)
        {
            if (cbb_ChucVu.SelectedIndex >= 0)
            {
                DataTable dt = new DataTable();
                dt = pcDao.loadNguoiNhan(table, cotmaso, maso);
                if (dt.Rows.Count > 0)
                {
                    txt_HoTen.Text = dt.Rows[0]["HOTEN"].ToString();
                }
                else
                {
                    txt_HoTen.Text = null;
                }
            }

        }

        //
        private void txt_NguoiNhan_TextChanged(object sender, EventArgs e)
        {
            maso = txt_NguoiNhan.Text.ToString();
            loadNguoiNhan(chucVuTable,cotMaSo, maso);
        }

        //check thong tin
        private bool checkThongTin()
        {
            if (String.IsNullOrEmpty(txt_LoaiPhieuChi.Text) || String.IsNullOrEmpty(txt_HoTen.Text) || String.IsNullOrEmpty(txt_TongTien.Text))
                return false;
            return true;
        }

        private void btn_TitleQLTiTle_Click(object sender, EventArgs e)
        {

        }
    }
}
