using DemoDoAn.ChildPage.General_Management.UC_GM_CLASS;
using DemoDoAn.ChildPage.General_Management.UC_GM_ROOM;
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
    public partial class UC_GM_ROOM : UserControl
    {
        PhongHocDao phongHocDao = new PhongHocDao();
        DataTable dtPhong = new DataTable();

        enum nameCol_DSPhong
        {
            STT,
            Phong
        }

        public UC_GM_ROOM()
        {
            InitializeComponent();
        }

        #region XuLiDoHoa
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

        private void LoadForm(DataTable dt)
        {
            this.dataGrView_DSPhongHoc.DataSource = dt;
        }
        private void UC_GM_ROOM_Load(object sender, EventArgs e)
        {
            taiDSPhong(dataGrView_DSPhongHoc);

        }

        //tai DSL
        private void taiDSPhong(DataGridView dtg)
        {
            dtPhong.Rows.Clear();
            dtPhong = phongHocDao.LayDanhSachPhong();
            dtPhong = dtPhong.AsEnumerable().OrderByDescending(row => row.Field<int>("TrangThai")).CopyToDataTable();
            LoadForm(dataGrView_DSPhongHoc, dtPhong);

            //ẩn full các cột     
            for (int i = 0; i < dtg.Columns.Count; i++)
            {
                DataGridViewColumn colDtg = dtg.Columns[i];
                colDtg.Visible = false;
            }
            //hiện những cột cần, name của các cột được lưu trong Enum
            foreach (nameCol_DSPhong day in Enum.GetValues(typeof(nameCol_DSPhong)))
            {
                for (int i = 0; i < dtg.Columns.Count; i++)
                {
                    DataGridViewColumn colDtg = dtg.Columns[i];
                    if (colDtg.Name.ToString() == day.ToString())
                    {
                        colDtg.Visible = true;
                        break;
                    }
                }
            }

            //them cojt trang thai, xoa
            addCollums(dtg, "Trạng thái", "TrangThaiIcon");
            addCollums(dtg, "Xóa", "XoaIcon");
            dtg.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            //dataGrView_DSL.Sort(dataGrView_DSL.Columns["TrangThaiIcon"], ListSortDirection.Descending);
        }
        //load dtg
        private void LoadForm(DataGridView dtg, DataTable dt)
        {
            dtg.DataSource = dt;
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

        //thêm
        private void btnTaoPhongMoi_Click(object sender, EventArgs e)
        {
            General_Management.UC_GM_ROOM.F_GM_ROOM_ADDNEWROOM frm = new General_Management.UC_GM_ROOM.F_GM_ROOM_ADDNEWROOM();
            frm.ShowDialog();
            resetDataGrView();
            taiDSPhong(dataGrView_DSPhongHoc);
        }


        //tim kiem + reset
        private void txt_Search_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                thucHienTimKiem(dataGrView_DSPhongHoc, txt_Search.Text.ToString());
            }
            else
                if (e.KeyCode == Keys.Escape)
            {
                thucHienReset(dataGrView_DSPhongHoc, txt_Search);
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
                        foreach (nameCol_DSPhong day in Enum.GetValues(typeof(nameCol_DSPhong)))
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


        //Xóa, sua
        private void dataGrView_DSPhongHoc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dtg = sender as DataGridView;
            DataGridViewRow row = new DataGridViewRow();

            if (dtg.Columns[e.ColumnIndex].HeaderText == "Xóa")
            {
                row = dataGrView_DSPhongHoc.Rows[e.RowIndex];
                if (MessageBox.Show("Bạn muốn xóa phòng học?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    PhongHoc phong = new PhongHoc(Convert.ToString(row.Cells["Phong"].Value), Convert.ToString(row.Cells["TrangThai"].Value));
                    phongHocDao.Xoa(phong);
                    resetDataGrView();
                    taiDSPhong(dataGrView_DSPhongHoc);
                }
            }
            else if (dtg.Columns[e.ColumnIndex].Name == "TrangThaiIcon")
            {
                row = dataGrView_DSPhongHoc.Rows[e.RowIndex];
                if (MessageBox.Show("Bạn muốn cập nhật phòng học?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    //cap nhat trang thai dong mo lop
                    capNhatTTPhongDtg(e.RowIndex, "TrangThai", dataGrView_DSPhongHoc);
                    PhongHoc phong = new PhongHoc(row.Cells["Phong"].Value.ToString().Trim(), row.Cells["TrangThai"].Value.ToString().Trim());
                    phongHocDao.capNhat(phong);
                    resetDataGrView();
                    taiDSPhong(dataGrView_DSPhongHoc);
                }
            }

        }
        //capnhat trang thai tren datagridview
        private void capNhatTTPhongDtg(int r, string colUpdate, DataGridView dtg)
        {
            if (Convert.ToInt32(dtg.Rows[r].Cells[colUpdate].Value) == 0)
            {
                dtg.Rows[r].Cells[colUpdate].Value = 1;
            }
            else
            {
                dtg.Rows[r].Cells[colUpdate].Value = 0;
            }
        }

        //reset datagridview
        private void resetDataGrView()
        {
            dataGrView_DSPhongHoc.Columns.Remove("XoaIcon");
            dataGrView_DSPhongHoc.Columns.Remove("TrangThaiIcon");
            for (int i = dataGrView_DSPhongHoc.Rows.Count - 1; i >= 0; i--)
            {
                dataGrView_DSPhongHoc.Rows.RemoveAt(i);
            }
        }

        //danh STT, gan icon
        private void dataGrView_DSPhongHoc_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            DataGridViewRow row = dataGrView_DSPhongHoc.Rows[e.RowIndex];

            row.Cells[0].Value = (e.RowIndex + 1).ToString();
            //img for TrangThai
            if (row.Cells["TrangThaiIcon"].Value == null)
                    if (Convert.ToInt32(row.Cells["TrangThai"].Value) == 0)
                        row.Cells["TrangThaiIcon"].Value = new Bitmap(Application.StartupPath + "\\Resources\\Offline.png");
                    else row.Cells["TrangThaiIcon"].Value = new Bitmap(Application.StartupPath + "\\Resources\\OnlineTT_1.png");
            //img for Xoa
            if (row.Cells["XoaIcon"].Value == null)
                row.Cells["XoaIcon"].Value = new Bitmap(Application.StartupPath + "\\Resources\\delete.png");
            
        }
    }
}
