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
    public partial class UC_THONGTINHOCVIEN : UserControl
    {
        int chucVu; // 0 la admin;  1 la hocvien;  2 la giao vien
        string hvID;
        HocSinhDao hsDao = new HocSinhDao();
        GiaoVienDao gvDao =  new GiaoVienDao();

        DataTable dt = new DataTable();

        public UC_THONGTINHOCVIEN(int chucVu)
        {
            InitializeComponent();
            this.chucVu = chucVu;
        }

        private void btn_CapNhat_Click(object sender, EventArgs e)
        {

        }

        private void UC_THONGTINHOCVIEN_Load(object sender, EventArgs e)
        {
            
            //lay ID va chuc vu: 
            DataTable dt_ID= new DataTable();
            dt_ID = hsDao.Lay_MSSV(Login.userName);
            hvID = dt_ID.Rows[0]["ID"].ToString();

            //Học viên || Giảng Viên
            if(chucVu == 1) //la hoc vien
            {
                dt = hsDao.LoadThongTin(hvID);
                HocSinh hs = new HocSinh(dt.Rows[0]["HVID"].ToString(), dt.Rows[0]["HOTEN"].ToString(), dt.Rows[0]["CMND"].ToString(), dt.Rows[0]["GIOITINH"].ToString(), (DateTime)dt.Rows[0]["NGAYSINH"], dt.Rows[0]["SDT"].ToString(), dt.Rows[0]["EMAIL"].ToString(), dt.Rows[0]["DIACHI"].ToString(), (Int32)dt.Rows[0]["TienTaiKhoan"]);
                //
                dPTime_NgaySinhUpd.Value = hs.NGAYSINH;
                btn_Email.Text = hs.EMAIL.ToString().Trim();
                btn_CCCD.Text = hs.CMND.ToString().Trim();
                btn_SDT.Text = hs.SDT.ToString().Trim();
                btn_DiaChi.Text = hs.DIACHI.ToString().Trim();
                lbl_HoTen.Text = hs.HOTEN.ToString().Trim();
                lbl_GioiTinh.Text = hs.GIOITINH.ToString().Trim();
                lbl_MaHV.Text = hs.HSID.ToString().Trim();
                lbl_TaiKhoan.Text = hs.TIEN.ToString().Trim();
                //
                txt_NgaySinhUpd.Text = hs.NGAYSINH.ToString("dd/MM/yyyy");
                txt_EmailUpd.Text = hs.EMAIL.ToString().Trim();
                txt_CCCDUpd.Text = hs.CMND.ToString().Trim();
                txt_SDTUpd.Text = hs.SDT.ToString().Trim();
                txt_DiaChiUpd.Text = hs.DIACHI.ToString().Trim();
                txt_GioiTinhUpd.Text = hs.GIOITINH.ToString().Trim();
            }
            else if (chucVu == 2)//la giang vien
            {
                dt = gvDao.LayDanhSachGiaoVien();
                for(int i = 0;  i < dt.Rows.Count; i++)
                {
                    DataRow row = dt.Rows[i];
                    if (row["GvID"].ToString().Trim() == hvID.ToString())
                    {
                        GiaoVien gv = new GiaoVien(dt.Rows[0]["GvID"].ToString(), dt.Rows[0]["HOTEN"].ToString(), dt.Rows[0]["CMND"].ToString(),
                                                    (DateTime)dt.Rows[0]["NGAYSINH"], dt.Rows[0]["GIOITINH"].ToString(), dt.Rows[0]["SDT"].ToString(),
                                                    dt.Rows[0]["DIACHI"].ToString(), dt.Rows[0]["EMAIL"].ToString(), dt.Rows[0]["AccID_Tea"].ToString(),
                                                    dt.Rows[0]["username"].ToString(), dt.Rows[0]["pass"].ToString());
                        dPTime_NgaySinhUpd.Value = gv.NGAYSINH;
                        btn_Email.Text = gv.EMAIL.ToString().Trim();
                        btn_CCCD.Text = gv.CMND.ToString().Trim();
                        btn_SDT.Text = gv.SDT.ToString().Trim();
                        btn_DiaChi.Text = gv.DIACHI.ToString().Trim();
                        lbl_HoTen.Text = gv.HOTEN.ToString().Trim();
                        lbl_GioiTinh.Text = gv.GIOITINH.ToString().Trim();
                        lbl_MaHV.Text = gv.GVID.ToString().Trim();
                        //lbl_TaiKhoan.Text = gv.TIEN.ToString().Trim();
                        //
                        txt_NgaySinhUpd.Text = gv.NGAYSINH.ToString("dd/MM/yyyy");
                        txt_EmailUpd.Text = gv.EMAIL.ToString().Trim();
                        txt_CCCDUpd.Text = gv.CMND.ToString().Trim();
                        txt_SDTUpd.Text = gv.SDT.ToString().Trim();
                        txt_DiaChiUpd.Text = gv.DIACHI.ToString().Trim();
                        txt_GioiTinhUpd.Text = gv.GIOITINH.ToString().Trim();
                    }
                }
            }


        }
    }
}
