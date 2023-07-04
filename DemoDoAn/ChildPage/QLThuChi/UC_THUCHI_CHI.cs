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
    public partial class UC_THUCHI_CHI : UserControl
    {
        PhieuChiDao pcDao = new PhieuChiDao();
        DataTable dtPC = new DataTable();
        PhieuChi pc = new PhieuChi();

        enum nameCol_DSPC
        {
            STT,
            MaPC,
            LoaiTien,
            HOTEN,
            ChucVu,
            Ngay,
            SoTien
            //,Xoa
        }

        public UC_THUCHI_CHI()
        {
            InitializeComponent();
        }

        #region DOHOA
        bool isEmpty_Search = true;
        private void an_SearchText(TextBox txt_Search, ref bool isEmpty_Search)
        {
            if (isEmpty_Search == true)
            {
                txt_Search.Text = String.Empty;
                txt_Search.Font = new Font(txt_Search.Font, FontStyle.Regular);
                txt_Search.ForeColor = Color.DimGray;
                isEmpty_Search = false;
            }
        }
        private void hien_SearchText(TextBox txt_Search, ref bool isEmpty_Search)
        {
            txt_Search.Text = "Search...";
            txt_Search.Font = new Font("SFU Futura", 10F, FontStyle.Italic);
            txt_Search.ForeColor = Color.Silver;
            isEmpty_Search = true;
        }
        private void txt_Search_Click(object sender, EventArgs e)
        {
            an_SearchText(txt_Search, ref isEmpty_Search);
        }
        #endregion

        private void UC_THUCHI_CHI_Load(object sender, EventArgs e)
        {
            taiDSNV();
            thongKeChiTieu();
        }

        //tai DSNV
        private void taiDSNV()
        {
            dtPC.Rows.Clear();
            dtPC = pcDao.taiDSPC();
            loadForm(dataGrView_DSPhieuChi, dtPC);
            //ẩn full các cột     
            for (int i = 0; i < dataGrView_DSPhieuChi.Columns.Count; i++)
            {
                DataGridViewColumn colDtg = dataGrView_DSPhieuChi.Columns[i];
                colDtg.Visible = false;
            }
            //hiện những cột cần, name của các cột được lưu trong Enum
            foreach (nameCol_DSPC day in Enum.GetValues(typeof(nameCol_DSPC)))
            {
                for (int i = 0; i < dataGrView_DSPhieuChi.Columns.Count; i++)
                {
                    DataGridViewColumn colDtg = dataGrView_DSPhieuChi.Columns[i];
                    if (colDtg.Name.ToString() == day.ToString())
                    {
                        colDtg.Visible = true;
                        break;
                    }
                }
            }
            dataGrView_DSPhieuChi.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        //load dtg
        private void loadForm(DataGridView dtg, DataTable dt)
        {
            dtg.DataSource = dt;
        }

        //them  phieu thu
        private void btn_ThemPhieuThu_Click(object sender, EventArgs e)
        {
            UC_THUCHI_CHI_TaoPhieuChi ucTaoPC = new UC_THUCHI_CHI_TaoPhieuChi();
            ucTaoPC.ShowDialog();
            taiDSNV();
            thongKeChiTieu();
        }

        //thong ke chi tieu
        private void thongKeChiTieu()
        {
            int chiNgay = 0;
            int chiThang = 0;
            for (int r = 0; r < dtPC.Rows.Count; r++)
            {
                DataRow dr = dtPC.Rows[r];
                //tinh thu nhap trong ngay
                DateTime ngay = (DateTime)dr["Ngay"];
                if (ngay.ToString("dd/MM/yyyy") == DateTime.Today.ToString("dd/MM/yyyy"))
                {
                    int tien = Convert.ToInt32(dr["SoTien"]);
                    chiNgay += tien;
                }

                //tinh thu nhap trong thang
                DateTime thang = (DateTime)dr["Ngay"];
                if (thang.Month.ToString() == DateTime.Today.Month.ToString())
                {
                    int tien = Convert.ToInt32(dr["SoTien"]);
                    chiThang += tien;
                }
            }

            lbl_SoTienChiTrongNgay.Text = chiNgay.ToString();
            lbl_TongChiThang.Text = chiThang.ToString();
        }

        private void txt_Search_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                thucHienTimKiem(dataGrView_DSPhieuChi, txt_Search.Text.ToString(), typeof(nameCol_DSPC));
            }
            else if (e.KeyCode == Keys.Escape)
            {
                thucHienReset(dataGrView_DSPhieuChi, txt_Search, ref isEmpty_Search);
            }
        }
        //thuc hien tim kiem
        private void thucHienTimKiem(DataGridView dtg, string duLieu, Type enumType)
        {
            locDuLieuTimKiem(dtg, duLieu, enumType);
        }
        //lọc dữ liệu để tìm kiếm trong DataGridView
        private void locDuLieuTimKiem(DataGridView dtg, string searchText, Type enumType)
        {
            if (string.IsNullOrEmpty(searchText))
            {
                // Nếu không có dữ liệu nhập vào, hiển thị tất cả các dòng
                dtg.Rows.Cast<DataGridViewRow>().ToList().ForEach(r => r.Visible = true);
            }
            else
            {
                for (int r = 0; r < dtg.Rows.Count; r++)
                {
                    DataGridViewRow row = dtg.Rows[r];

                    //4 dòng fix lỗi : 'Row associated with the currency manager's position cannot be made invisible.'
                    CurrencyManager currencyManager1 = (CurrencyManager)BindingContext[dtg.DataSource];
                    currencyManager1.SuspendBinding();
                    row.Visible = false;
                    currencyManager1.ResumeBinding();

                    //tim kiem dữ liệu có chứa trong các ô của row không
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        //hiện những cột cần, name của các cột được lưu trong Enum
                        foreach (var day in Enum.GetValues(enumType))
                        {
                            //chỉ tìm trên các ô thuộc cột có trong enum:
                            if (dtg.Columns[cell.ColumnIndex].Name == day.ToString())
                            {
                                if (cell.Value != null && cell.Value.ToString().Contains(searchText))
                                {
                                    row.Visible = true;
                                    break;
                                }
                            }
                        }
                    }
                }


            }
        }
        //thuc hien reset
        private void thucHienReset(DataGridView dtg, TextBox txt_Search, ref bool isEmptyText)
        {
            // hiển thị tất cả các dòng
            dtg.Rows.Cast<DataGridViewRow>().ToList().ForEach(r => r.Visible = true);
            hien_SearchText(txt_Search, ref isEmptyText);
        }

        //danh STT
        private void dataGrView_DSPhieuChi_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            DataGridViewRow row = dataGrView_DSPhieuChi.Rows[e.RowIndex];
            row.Cells[0].Value = (e.RowIndex + 1).ToString();
        }

        //xoa PC
        private void pBox_XoaPC_Click(object sender, EventArgs e)
        {
            pcDao.xoaPhieuChi(pc.ID);
            taiDSNV();
        }

        //cap nhat phieu chi da chon tren dtg
        private void dataGrView_DSPhieuChi_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            try
            {
                DataGridView dtg = sender as DataGridView;
                DataGridViewRow row = dtg.Rows[e.RowIndex];
                PhieuChi pcTemp = new PhieuChi(row.Cells["MaPC"].Value.ToString(), row.Cells["ChucVu"].Value.ToString(), row.Cells["LoaiTien"].Value.ToString(), Convert.ToInt32(row.Cells["SoTien"].Value), Convert.ToDateTime(row.Cells["Ngay"].Value));
                pc = pcTemp;
            }
            catch
            {
            }
        }
    }
}
