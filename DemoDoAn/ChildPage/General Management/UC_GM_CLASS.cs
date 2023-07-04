using DemoDoAn.ChildPage.General_Management.UC_GM_CLASS;
using DemoDoAn.Custom_Control;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DemoDoAn.ChildPage
{
    public partial class UC_GM_CLASS : UserControl
    {
        LopHocDao lopDao = new LopHocDao();
        KhoaHocDao khoaHocDao = new KhoaHocDao();
        DataTable dtLopHoc = new DataTable();

        enum nameCol_DSL
        {
            MaLop,
            TenMon,
            HocPhi,
            SoHocVien,
            NgayBatDau,
            NgayKetThuc

        }

        public UC_GM_CLASS()
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

        private void UC_GM_CLASS_Load(object sender, EventArgs e)
        {
            taiDSL();
        }

        //tai DSL
        private void taiDSL()
        {
            
            dtLopHoc.Rows.Clear();
            dtLopHoc = lopDao.LayDanhSachLop();
            dtLopHoc = dtLopHoc.AsEnumerable().OrderByDescending(row => row.Field<int>("TTMoLop")).CopyToDataTable();
            LoadForm(dataGrView_DSL, dtLopHoc);
            
            //ẩn full các cột     
            for (int i = 0; i < dataGrView_DSL.Columns.Count; i++)
            {
                DataGridViewColumn colDtg = dataGrView_DSL.Columns[i];
                colDtg.Visible = false;
            }
            //hiện những cột cần, name của các cột được lưu trong Enum
            foreach (nameCol_DSL day in Enum.GetValues(typeof(nameCol_DSL)))
            {
                for (int i = 0; i < dataGrView_DSL.Columns.Count; i++)
                {
                    DataGridViewColumn colDtg = dataGrView_DSL.Columns[i];
                    if (colDtg.Name.ToString() == day.ToString())
                    {
                        colDtg.Visible = true;
                        break;
                    }
                }
            }

            //them cojt trang thai, xoa
            addCollums(dataGrView_DSL, "Trạng thái", "TrangThaiIcon");
            addCollums(dataGrView_DSL, "Xóa", "XoaIcon");
            dataGrView_DSL.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            //dataGrView_DSL.Sort(dataGrView_DSL.Columns["TrangThaiIcon"], ListSortDirection.Descending);
        }
        //load dtg
        private void LoadForm(DataGridView dtg, DataTable dt)
        {
            dtg.DataSource = dt;
        }

        //them lop hoc
        private void btnTaoLopMoi_Click(object sender, EventArgs e)
        {
            F_GM_CLASS_TaoLopMoi taoLop = new F_GM_CLASS_TaoLopMoi();
            taoLop.ShowDialog();
            resetDataGrView();
            taiDSL();

        }

        //add columns 
        private void addCollums(DataGridView dtg, string headerCol, string nameCol)
        {
            DataGridViewImageColumn img = new DataGridViewImageColumn();
            dtg.Columns.Add(img);
            img.HeaderText = headerCol;
            img.Name = nameCol;
            img.Image = null;
        }


        //tim kiem + reset
        private void txt_Search_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                thucHienTimKiem(dataGrView_DSL, txt_Search.Text.ToString(), typeof(nameCol_DSL));
            }
            else
                if (e.KeyCode == Keys.Escape)
            {
                thucHienReset(dataGrView_DSL, txt_Search, ref isEmpty_Search);
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


        //xu li + Xoa lop
        private void dataGrView_DSL_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dtg = sender as DataGridView;
            DataGridViewRow row = new DataGridViewRow();
            if (dtg.Columns[e.ColumnIndex].HeaderText == "Xóa")
            {
                if (MessageBox.Show("Bạn muốn xóa lớp học?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    row = dtg.Rows[e.RowIndex];
                    lopDao.Xoa(Convert.ToString(row.Cells["MaLop"].Value));
                    resetDataGrView();
                    taiDSL();
                }
            }
            else if (dtg.Columns[e.ColumnIndex].Name == "TrangThaiIcon")
            {
                row = dtg.Rows[e.RowIndex];
                if (MessageBox.Show("Bạn muốn thay đổi trạng thái lớp?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    //check KH còn hoạt động khong:
                    if (Convert.ToInt32(row.Cells["TrangThaiKH"].Value) == 1)
                    {
                        //cap nhat trang thai dong mo lop
                        capNhatTTLopDtg(e.RowIndex);
                        lopDao.capNhatTrangThai(row.Cells["MaLop"].Value.ToString().Trim(), Convert.ToInt32(row.Cells["TTMoLop"].Value));
                        resetDataGrView();
                        taiDSL();
                    }
                    else
                    {
                        MessageBox.Show("Khóa học đã ngưng hoạt động!");
                    }
                    
                }
            }
        }

        //capnhat trang thai tren datagridview
        private void capNhatTTLopDtg(int r)
        {
            if (Convert.ToInt32( dataGrView_DSL.Rows[r].Cells["TTMoLop"].Value) == 0)
            {
                dataGrView_DSL.Rows[r].Cells["TTMoLop"].Value = 1;
            }
            else
            {
                dataGrView_DSL.Rows[r].Cells["TTMoLop"].Value = 0;
            }
        }

        //reset datagridview
        private void resetDataGrView()
        {
            dataGrView_DSL.Columns.Remove("XoaIcon");
            dataGrView_DSL.Columns.Remove("TrangThaiIcon");
            for (int i = dataGrView_DSL.Rows.Count - 1; i >= 0; i--)
            {
                dataGrView_DSL.Rows.RemoveAt(i);
            }
        }

        //insert icon
        private void dataGrView_DSL_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            DataGridViewRow row = dataGrView_DSL.Rows[e.RowIndex];
            DataRow dtRow = dtLopHoc.Rows[e.RowIndex];


            //img for TrangThai
            if (row.Cells["TrangThaiIcon"].Value == null)
                if (Convert.ToInt32(row.Cells["TTMoLop"].Value) == 0)
                    row.Cells["TrangThaiIcon"].Value = new Bitmap(Application.StartupPath + "\\Resources\\Offline.png");
                else row.Cells["TrangThaiIcon"].Value = new Bitmap(Application.StartupPath + "\\Resources\\OnlineTT_1.png");
            //img for Xoa
            if (row.Cells["XoaIcon"].Value == null)
                row.Cells["XoaIcon"].Value = new Bitmap(Application.StartupPath + "\\Resources\\delete.png");
            //if (row.Cells["CapNhatIcon"].Value == null)
            //    row.Cells["CapNhatIcon"].Value = new Bitmap(Application.StartupPath + "\\Resources\\refresh.png");

        }
        
       
    }
}
