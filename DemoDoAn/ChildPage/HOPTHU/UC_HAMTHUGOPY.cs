using DemoDoAn.ChildPage.HAMTHU;
using DemoDoAn.HOCVIEN.Class;
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
    public partial class UC_HAMTHUGOPY : UserControl
    {
        HocSinhDao hsDao = new HocSinhDao();
        HamThuDAO thuDao = new HamThuDAO();
        LoginDAO logDao = new LoginDAO();   

        DataTable dtDSThu = new DataTable("DSThu");
        DataTable dtFULL_INFO = new DataTable();
        string mathu;
        bool danhdau;
        #region DOHOA
        public void checkDanhDau(bool danhdau)
        {
            if (danhdau == true)
            {
                pBox_DanhDau.Image = new Bitmap(Application.StartupPath + "\\Resources\\star_Gold.png");
                pBox_DanhDau.SizeMode = PictureBoxSizeMode.Zoom;
            }
            else
            {
                pBox_DanhDau.Image = new Bitmap(Application.StartupPath + "\\Resources\\star_White.png");
                pBox_DanhDau.SizeMode = PictureBoxSizeMode.Zoom;
            }
        }
        private void pBox_DanhDau_Click(object sender, EventArgs e)
        {
            if (danhdau == false)
            {
                pBox_DanhDau.Image = new Bitmap(Application.StartupPath + "\\Resources\\star_Gold.png");
                pBox_DanhDau.SizeMode = PictureBoxSizeMode.Zoom;
                danhdau = true;
                thuDao.DanhDau(danhdau, mathu);
            }
            else
            {
                pBox_DanhDau.Image = new Bitmap(Application.StartupPath + "\\Resources\\star_White.png");
                pBox_DanhDau.SizeMode = PictureBoxSizeMode.Zoom;
                danhdau = false;
                thuDao.DanhDau(danhdau, mathu);
            }
            LoadThuDen();
        }
        #endregion
        public UC_HAMTHUGOPY()
        {
            InitializeComponent();
        }

        private void UC_HAMTHUGOPY_Load(object sender, EventArgs e)
        {
            taiFULL_INFO();
            LoadThuDen();
        }

        //tai thong tin nguoi gui
        private void taiFULL_INFO()
        {
            dtFULL_INFO = logDao.loadFull();
        }

        //load danh sách thư đến
        private void LoadThuDen()
        {
            fLPnl_ThuDen.Controls.Clear();

            //lay ID nguoi nhan
            string hvID = "";
            for (int r= 0; r < dtFULL_INFO.Rows.Count; r++)
            {
                DataRow row = dtFULL_INFO.Rows[r];
                if (row["USERNAME"].ToString().Trim() == Login.userName.ToString())
                {
                    hvID = row["ID"].ToString();
                    break;
                }
            }
            //string username = Login.userName.ToString();
            //string hoTen = dtFULL_INFO.AsEnumerable().Where(r => r.Field<string>("USERNAME") == username).Select(r => r.Field<string>("ID")).FirstOrDefault().ToString();
            //tai danh sach thu den
            dtDSThu = thuDao.LayThuDen(hvID);
            UC_HAMTHUGOPY_CHILD[] ucThuChild = new UC_HAMTHUGOPY_CHILD[dtDSThu.Rows.Count];

            for (int row = 0; row < dtDSThu.Rows.Count; row++)
            {
                
                //Hoten
                string hoten = "";
                for (int r = 0; r < dtFULL_INFO.Rows.Count; r++)
                {
                    DataRow dtrow = dtFULL_INFO.Rows[r];
                    if (dtDSThu.Rows[row]["IDGui"].ToString().Trim() == dtrow["ID"].ToString().Trim())
                    {
                        hoten = dtrow["HOTEN"].ToString().Trim();
                        break;
                    }
                }

                //Ngay
                DateTime Ngay = (DateTime)dtDSThu.Rows[row]["Ngay"];

                //Gio
                TimeSpan Gio = (TimeSpan)dtDSThu.Rows[row]["Gio"];
                DateTime gio = Ngay.Add(Gio);
                ucThuChild[row] = new UC_HAMTHUGOPY_CHILD(dtDSThu.Rows[row]["MaThu"].ToString(), hoten, 
                                                          dtDSThu.Rows[row]["TieuDe"].ToString(), dtDSThu.Rows[row]["Noidung"].ToString(), 
                                                          Ngay, gio, Convert.ToBoolean(dtDSThu.Rows[row]["DanhDau"]));
                fLPnl_ThuDen.Controls.Add(ucThuChild[row]);
            }

            for(int r = 0; r < dtDSThu.Rows.Count; r++)
            {
                ucThuChild[r].ReadClicked += UC_HAMTHUGOPY_ReadClicked;
                ucThuChild[r].DeleteClicked += UC_HAMTHUGOPY_DeleteClicked;
            }
        }

        //xoa thu
        private void UC_HAMTHUGOPY_DeleteClicked(object sender, EventArgs e)
        {
            UC_HAMTHUGOPY_CHILD ucThu = sender as UC_HAMTHUGOPY_CHILD;
            string mathu = ucThu.MATHU.ToString();
            thuDao.xoaThu(mathu);
            LoadThuDen();
        }

        //hien chi tiet thu
        private void UC_HAMTHUGOPY_ReadClicked(object sender, EventArgs e)
        {
            UC_HAMTHUGOPY_CHILD ucThu = sender as UC_HAMTHUGOPY_CHILD;

            mathu = ucThu.MATHU.ToString();
            danhdau = ucThu.DANHDAU;
            lbl_HoTen.Text = ucThu.TEN.ToString();
            lbl_TieuDe_CT.Text = ucThu.TIEUDE.ToString();
            lbl_NoiDung_CT.Text = ucThu.NOIDUNG.ToString();
            lbl_NgayThang.Text = ucThu.NGAY.ToString("dd/MM/yyyy");
            lbl_Gio.Text = ucThu.GIO.ToString("hh:mm:ss");
            checkDanhDau(danhdau);
        }

        private void pBox_Gui_Click(object sender, EventArgs e)
        {
            F_HAMTHU hopThu = new F_HAMTHU();
            hopThu.ShowDialog();
        }

#if false
        public void LoadNotice(string agent)
        {
            pnNotice.Controls.Clear();
            if (agent != user)
            {
                this.dt = notice.SelectNoticeByLop(agent);
            }
            else LoadBy(accountType);
            UcNoticeItem[] ucNoticeItems = new UcNoticeItem[dt.Rows.Count];

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ucNoticeItems[i] = new UcNoticeItem(user, dt.Rows[i]["maNguoiGui"].ToString(),
                                                    dt.Rows[i]["mathongbao"].ToString(), dt.Rows[i]["ngaygui"].ToString(),
                                                    dt.Rows[i]["hoten"].ToString(), dt.Rows[i]["malophoc"].ToString(),
                                                    dt.Rows[i]["makhoahoc"].ToString(),
                                                    dt.Rows[i]["tieude"].ToString(), dt.Rows[i]["noidung"].ToString());
                ucNoticeItems[i].Dock = DockStyle.Top;
                pnNotice.Controls.Add(ucNoticeItems[i]);
            }
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ucNoticeItems[i].btnReadClicked += myUserControl_btnReadClicked;
                ucNoticeItems[i].btnDeleteClicked += myUserControl_btnDeleteClicked;
            }


        }
        private void myUserControl_btnReadClicked(object sender, EventArgs e)
        {
            UcNoticeItem myUserControl = sender as UcNoticeItem;
            txtTieuDe.Text = myUserControl.TextTieuDe;
            txtNoiDung.Text = myUserControl.TextNoiDung;
            lbName.Text = myUserControl.NameGiaoVien;
            cbbMaLop.Text = myUserControl.IDLop;
            lbNgayGui.Text = myUserControl.NgayGui;
        }
#endif
    }
}
