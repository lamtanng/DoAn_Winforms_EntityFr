using DemoDoAn.HOCVIEN.Class;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.Windows.Controls;
using System.Windows.Forms;

namespace DemoDoAn.HOCVIEN
{
    public partial class F_HAMTHU : Form
    {
        LoginDAO logDao = new LoginDAO();
        HocSinhDao hsDao = new HocSinhDao();
        HamThuDAO thuDao = new HamThuDAO();

        DataTable dtFULL_INFO = new DataTable();
        string IDGui ;
        string IDNhan;

        public F_HAMTHU()
        {
            InitializeComponent();
            dtFULL_INFO = logDao.loadFull();
            layIDNguoiGui();
        }

        #region XuLiDoHoc
        bool isEmpty_Search = true;
        bool isEmpty_Title = true;
        bool isEmpty_Content = true;
        private void an_SearchText(TextBox txt_Search, ref bool isEmpty_Search)
        {
            if (isEmpty_Search == true)
            {
                txt_Search.Text = String.Empty;
                //txt_Search.Font = new Font(txt_Search.Font, FontStyle.Regular);
                //txt_Search.ForeColor = Color.DimGray;
                isEmpty_Search = false;
            }
        }
        private void hien_SearchText(TextBox txt_Search, ref bool isEmpty_Search)
        {
            txt_Search.Visible =true;
            txt_Search.Font = new Font("SFU Futura", 10F, FontStyle.Italic);
            txt_Search.ForeColor = Color.Silver;
            isEmpty_Search = true;
        }
        private void txt_IDNhan_Click(object sender, EventArgs e)
        {
            an_SearchText(txt_IDNhan, ref isEmpty_Search);
        }
        private void lbl_ContentTxt_Click(object sender, EventArgs e)
        {
            an_SearchText(txt_NoiDung, ref isEmpty_Content);
        }
        private void textBox1_Click(object sender, EventArgs e)
        {
            an_SearchText(txt_TieuDe, ref isEmpty_Title);
        }
        private void picBox_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        //lay accID nguoi gui
        private void layIDNguoiGui()
        {
           for(int i = 0; i < dtFULL_INFO.Rows.Count; i++)
            {
                DataRow row  = dtFULL_INFO.Rows[i];
                if (row["USERNAME"].ToString().Trim() == Login.userName.ToString().Trim()) 
                {
                    IDGui = row["ID"].ToString().Trim();
                }
            }
            
        }

        private void F_HAMTHU_Load(object sender, EventArgs e)
        {
            //string AccID = hsDao.Lay_MSSV(Login.userName);
            //dt_HV = hsDao.LoadThongTin(accID);
            //lbl_HoTen.Text = dtFULL_INFO.Rows[0]["HOTEN"].ToString();
            for (int i = 0; i < dtFULL_INFO.Rows.Count; i++)
            {
                DataRow row = dtFULL_INFO.Rows[i];
                if (row["USERNAME"].ToString().Trim() == Login.userName.ToString().Trim())
                {
                    lbl_HoTen.Text = row["HOTEN"].ToString().Trim();
                }
            }
        }

        //gui thu
        private void pBox_Gui_Click(object sender, EventArgs e)
        {
            //string accID = hsDao.LayAccID(Login.userName);
            if(checkNguoiNhan(IDNhan))
            {
                HamThu thu = new HamThu(IDGui, txt_TieuDe.Text.ToString(), txt_NoiDung.Text.ToString(), DateTime.Now, DateTime.Now, false, IDNhan, lbl_ChucVu.Text.ToString().Trim());
                thuDao.Them(thu);
            }
            else
            {
                MessageBox.Show("Không thể xác nhận người nhận!");
            }
            
        }

        //load thong tin ng nhan thu
        private void txt_IDNhan_TextChanged(object sender, EventArgs e)
        {
            IDNhan = txt_IDNhan.Text.ToString();
            for (int i = 0; i < dtFULL_INFO.Rows.Count; i++)
            {
                DataRow row = dtFULL_INFO.Rows[i];
                if (row["ID"].ToString().Trim() == IDNhan)
                {
                    lbl_HoTenNhan.Text = "(" + row["HOTEN"].ToString() + ")";
                    lbl_ChucVu.Text = row["ChucVu"].ToString().Trim();
                    return;
                }
                else
                {
                    lbl_HoTenNhan.Text = "Recipient";
                    lbl_ChucVu.Text = "Duty";
                }
            }
        }

        //check 
        private bool checkNguoiNhan(string ID)
        {
            for(int i = 0; i < dtFULL_INFO.Rows.Count; i++)
            {
                DataRow row  = dtFULL_INFO.Rows[i];
                if (row["ID"].ToString().Trim() == ID)
                {
                    return true;
                }    
            }
            return false;
        }


    }
}
