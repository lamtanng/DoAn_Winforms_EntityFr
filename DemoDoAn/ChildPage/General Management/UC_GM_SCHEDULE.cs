using DemoDoAn.ChildPage.General_Management.UC_GM_CLASS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DemoDoAn.ChildPage.General_Management
{
    public partial class UC_GM_SCHEDULE : UserControl
    {
        LichHocDao lichHocDao = new LichHocDao();
        enum nameCol_LichHoc
        {
            STT,
            MaLop,
            TenMon,
            Thu,
            Ca,
            Phong,
            CapNhat,
            Xoa
        }

        public UC_GM_SCHEDULE()
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

        private void UC_GM_SCHEDULE_Load(object sender, EventArgs e)
        {
            taiLichHoc();
        }

        //tai DSNV
        private void taiLichHoc()
        {
            loadForm(dataGrView_LichDay, lichHocDao.taiLichHoc());
            //ẩn full các cột     
            for (int i = 0; i < dataGrView_LichDay.Columns.Count; i++)
            {
                DataGridViewColumn colDtg = dataGrView_LichDay.Columns[i];
                colDtg.Visible = false;
            }
            //hiện những cột cần, name của các cột được lưu trong Enum
            foreach (nameCol_LichHoc day in Enum.GetValues(typeof(nameCol_LichHoc)))
            {
                for (int i = 0; i < dataGrView_LichDay.Columns.Count; i++)
                {
                    DataGridViewColumn colDtg = dataGrView_LichDay.Columns[i];
                    if (colDtg.Name.ToString() == day.ToString())
                    {
                        colDtg.Visible = true;
                        break;
                    }
                }
            }
            dataGrView_LichDay.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        //load dtg
        private void loadForm(DataGridView dtg, DataTable dt)
        {
            dtg.DataSource = dt;
        }

        //danhSTT
        private void dataGrView_LichDay_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            DataGridViewRow row = dataGrView_LichDay.Rows[e.RowIndex];
            if (row != dataGrView_LichDay.Rows[dataGrView_LichDay.Rows.Count - 1])
            {
                row.Cells[0].Value = (e.RowIndex + 1).ToString();
            }
        }

        //tim kiem + reset
        private void txt_Search_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                thucHienTimKiem(dataGrView_LichDay, txt_Search.Text.ToString());
            }
            else
                if (e.KeyCode == Keys.Escape)
            {
                thucHienReset(dataGrView_LichDay, txt_Search);
            }
        }
        //thuc hien tim kiem
        private void thucHienTimKiem(DataGridView dtg, string duLieu)
        {
            locDuLieuTimKiem(dtg, duLieu);
        }
        //lọc dữ liệu để tìm kiếm trong DataGridView
        private void locDuLieuTimKiem(DataGridView dtg, string searchText)
        {
            if (string.IsNullOrEmpty(searchText))
            {
                // Nếu không có dữ liệu nhập vào, hiển thị tất cả các dòng
                dtg.Rows.Cast<DataGridViewRow>().ToList().ForEach(r => r.Visible = true);
            }
            else
            {
                for (int r = 0; r < dtg.Rows.Count - 1; r++)
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
                        foreach (nameCol_LichHoc day in Enum.GetValues(typeof(nameCol_LichHoc)))
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
        private void thucHienReset(DataGridView dtg, TextBox txt_Search)
        {
            // hiển thị tất cả các dòng
            dtg.Rows.Cast<DataGridViewRow>().ToList().ForEach(r => r.Visible = true);
            hien_SearchText(txt_Search, ref isEmpty_Search);
        }
        

        //xep lop
        private void btn_XepLop_Click(object sender, EventArgs e)
        {
            F_GM_CLASS_XepLop xeplich  = new F_GM_CLASS_XepLop();
            xeplich.ShowDialog();
        }

        //xoa + xep lich
        private void dataGrView_LichDay_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dtg = sender as DataGridView;
            DataGridViewRow row = dtg.Rows[e.RowIndex];
            if (dtg.Columns[e.ColumnIndex].HeaderText == "Xóa")
            {
                if (MessageBox.Show("Bạn muốn xóa lịch học?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    lichHocDao.xoaLichHoc(Convert.ToString(row.Cells["MaLop"].Value));
                    taiLichHoc();
                }
            }
            else if (dtg.Columns[e.ColumnIndex].Name == "CapNhat")
            {
                if (MessageBox.Show("Bạn muốn thay đổi lịch học?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string malop = row.Cells["MaLop"].Value.ToString().Trim();
                    string tenlop = row.Cells["TenMon"].Value.ToString().Trim();
                    string maKH = row.Cells["MaKH"].Value.ToString().Trim();
                    string tenKH = row.Cells["TenKH"].Value.ToString().Trim();
                    General_Management.UC_GM_CLASS.F_GM_CLASS_XepLop xepLop = new General_Management.UC_GM_CLASS.F_GM_CLASS_XepLop(malop, tenlop, maKH, tenKH);
                    xepLop.ShowDialog();
                    taiLichHoc();
                }
            }
        }
    }
}
