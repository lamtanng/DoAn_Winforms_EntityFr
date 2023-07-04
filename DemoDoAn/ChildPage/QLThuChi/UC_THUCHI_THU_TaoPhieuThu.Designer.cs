namespace DemoDoAn.ChildPage.QLThuChi
{
    partial class UC_THUCHI_THU_TaoPhieuThu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbl_ThongTin = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cbb_LoaiPhieuThu = new System.Windows.Forms.ComboBox();
            this.txt_MaHV = new System.Windows.Forms.TextBox();
            this.txt_TenHV = new System.Windows.Forms.TextBox();
            this.txt_DiaChi = new System.Windows.Forms.TextBox();
            this.txt_TenNguoiNop = new System.Windows.Forms.TextBox();
            this.txt_TienThu = new System.Windows.Forms.TextBox();
            this.cbb_NhanVienThu = new System.Windows.Forms.ComboBox();
            this.datePTime_NgayThu = new System.Windows.Forms.DateTimePicker();
            this.txt_NoiDung = new System.Windows.Forms.TextBox();
            this.cbb_TrangThai = new System.Windows.Forms.ComboBox();
            this.cbb_MaLop = new System.Windows.Forms.ComboBox();
            this.cbb_TenLop = new System.Windows.Forms.ComboBox();
            this.lbl_ChiTietPhieuThu = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.STT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaPhieu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LoaiPhieu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HocVien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NgayThu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenNguoiThu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NguoiNop = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Sua = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Xoa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btn_Them = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lbl_ThongTin);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1262, 81);
            this.panel1.TabIndex = 0;
            // 
            // lbl_ThongTin
            // 
            this.lbl_ThongTin.AutoSize = true;
            this.lbl_ThongTin.Location = new System.Drawing.Point(33, 32);
            this.lbl_ThongTin.Name = "lbl_ThongTin";
            this.lbl_ThongTin.Size = new System.Drawing.Size(131, 17);
            this.lbl_ThongTin.TabIndex = 0;
            this.lbl_ThongTin.Text = "Thông tin phiếu thu";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btn_Them);
            this.panel2.Controls.Add(this.datePTime_NgayThu);
            this.panel2.Controls.Add(this.txt_TenNguoiNop);
            this.panel2.Controls.Add(this.txt_NoiDung);
            this.panel2.Controls.Add(this.txt_DiaChi);
            this.panel2.Controls.Add(this.txt_TenHV);
            this.panel2.Controls.Add(this.txt_TienThu);
            this.panel2.Controls.Add(this.txt_MaHV);
            this.panel2.Controls.Add(this.cbb_TrangThai);
            this.panel2.Controls.Add(this.cbb_NhanVienThu);
            this.panel2.Controls.Add(this.cbb_TenLop);
            this.panel2.Controls.Add(this.cbb_MaLop);
            this.panel2.Controls.Add(this.cbb_LoaiPhieuThu);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 81);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1262, 349);
            this.panel2.TabIndex = 1;
            // 
            // cbb_LoaiPhieuThu
            // 
            this.cbb_LoaiPhieuThu.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.cbb_LoaiPhieuThu.FormattingEnabled = true;
            this.cbb_LoaiPhieuThu.Items.AddRange(new object[] {
            "Học phí",
            "Mua khóa học online",
            "Quỹ Lớp",
            "Khác"});
            this.cbb_LoaiPhieuThu.Location = new System.Drawing.Point(25, 22);
            this.cbb_LoaiPhieuThu.Name = "cbb_LoaiPhieuThu";
            this.cbb_LoaiPhieuThu.Size = new System.Drawing.Size(169, 24);
            this.cbb_LoaiPhieuThu.TabIndex = 0;
            this.cbb_LoaiPhieuThu.Text = "loại phiếu thu ";
            // 
            // txt_MaHV
            // 
            this.txt_MaHV.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.txt_MaHV.Location = new System.Drawing.Point(213, 23);
            this.txt_MaHV.Name = "txt_MaHV";
            this.txt_MaHV.Size = new System.Drawing.Size(160, 22);
            this.txt_MaHV.TabIndex = 1;
            this.txt_MaHV.Text = "Mã học viên";
            // 
            // txt_TenHV
            // 
            this.txt_TenHV.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.txt_TenHV.Location = new System.Drawing.Point(390, 22);
            this.txt_TenHV.Name = "txt_TenHV";
            this.txt_TenHV.Size = new System.Drawing.Size(160, 22);
            this.txt_TenHV.TabIndex = 1;
            this.txt_TenHV.Text = "Tên học viên";
            // 
            // txt_DiaChi
            // 
            this.txt_DiaChi.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.txt_DiaChi.Location = new System.Drawing.Point(566, 22);
            this.txt_DiaChi.Name = "txt_DiaChi";
            this.txt_DiaChi.Size = new System.Drawing.Size(351, 22);
            this.txt_DiaChi.TabIndex = 1;
            this.txt_DiaChi.Text = "Địa chỉ";
            // 
            // txt_TenNguoiNop
            // 
            this.txt_TenNguoiNop.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.txt_TenNguoiNop.Location = new System.Drawing.Point(938, 22);
            this.txt_TenNguoiNop.Name = "txt_TenNguoiNop";
            this.txt_TenNguoiNop.Size = new System.Drawing.Size(234, 22);
            this.txt_TenNguoiNop.TabIndex = 1;
            this.txt_TenNguoiNop.Text = "Tên người nộp";
            // 
            // txt_TienThu
            // 
            this.txt_TienThu.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.txt_TienThu.Location = new System.Drawing.Point(25, 71);
            this.txt_TienThu.Name = "txt_TienThu";
            this.txt_TienThu.Size = new System.Drawing.Size(160, 22);
            this.txt_TienThu.TabIndex = 1;
            this.txt_TienThu.Text = "Tổng tiền";
            // 
            // cbb_NhanVienThu
            // 
            this.cbb_NhanVienThu.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.cbb_NhanVienThu.FormattingEnabled = true;
            this.cbb_NhanVienThu.Items.AddRange(new object[] {
            "Nguyễn Văn A",
            "Trần Thị B"});
            this.cbb_NhanVienThu.Location = new System.Drawing.Point(213, 69);
            this.cbb_NhanVienThu.Name = "cbb_NhanVienThu";
            this.cbb_NhanVienThu.Size = new System.Drawing.Size(160, 24);
            this.cbb_NhanVienThu.TabIndex = 0;
            this.cbb_NhanVienThu.Text = "Nhân viên thu";
            // 
            // datePTime_NgayThu
            // 
            this.datePTime_NgayThu.Location = new System.Drawing.Point(390, 70);
            this.datePTime_NgayThu.Name = "datePTime_NgayThu";
            this.datePTime_NgayThu.Size = new System.Drawing.Size(178, 22);
            this.datePTime_NgayThu.TabIndex = 2;
            // 
            // txt_NoiDung
            // 
            this.txt_NoiDung.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.txt_NoiDung.Location = new System.Drawing.Point(574, 69);
            this.txt_NoiDung.Name = "txt_NoiDung";
            this.txt_NoiDung.Size = new System.Drawing.Size(343, 22);
            this.txt_NoiDung.TabIndex = 1;
            this.txt_NoiDung.Text = "Nội dung ";
            // 
            // cbb_TrangThai
            // 
            this.cbb_TrangThai.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.cbb_TrangThai.FormattingEnabled = true;
            this.cbb_TrangThai.Items.AddRange(new object[] {
            "Hoàn thành",
            "Chưa hoàn thành"});
            this.cbb_TrangThai.Location = new System.Drawing.Point(938, 68);
            this.cbb_TrangThai.Name = "cbb_TrangThai";
            this.cbb_TrangThai.Size = new System.Drawing.Size(160, 24);
            this.cbb_TrangThai.TabIndex = 0;
            this.cbb_TrangThai.Text = "Trạng thái";
            // 
            // cbb_MaLop
            // 
            this.cbb_MaLop.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.cbb_MaLop.FormattingEnabled = true;
            this.cbb_MaLop.Items.AddRange(new object[] {
            "Học phí",
            "Mua khóa học online",
            "Quỹ Lớp",
            "Khác"});
            this.cbb_MaLop.Location = new System.Drawing.Point(25, 132);
            this.cbb_MaLop.Name = "cbb_MaLop";
            this.cbb_MaLop.Size = new System.Drawing.Size(169, 24);
            this.cbb_MaLop.TabIndex = 0;
            this.cbb_MaLop.Text = "mã lớp";
            // 
            // cbb_TenLop
            // 
            this.cbb_TenLop.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.cbb_TenLop.FormattingEnabled = true;
            this.cbb_TenLop.Items.AddRange(new object[] {
            "Học phí",
            "Mua khóa học online",
            "Quỹ Lớp",
            "Khác"});
            this.cbb_TenLop.Location = new System.Drawing.Point(213, 132);
            this.cbb_TenLop.Name = "cbb_TenLop";
            this.cbb_TenLop.Size = new System.Drawing.Size(169, 24);
            this.cbb_TenLop.TabIndex = 0;
            this.cbb_TenLop.Text = "tên lớp";
            // 
            // lbl_ChiTietPhieuThu
            // 
            this.lbl_ChiTietPhieuThu.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbl_ChiTietPhieuThu.Location = new System.Drawing.Point(0, 430);
            this.lbl_ChiTietPhieuThu.Name = "lbl_ChiTietPhieuThu";
            this.lbl_ChiTietPhieuThu.Size = new System.Drawing.Size(1262, 37);
            this.lbl_ChiTietPhieuThu.TabIndex = 0;
            this.lbl_ChiTietPhieuThu.Text = "Chi tiết phiếu thu";
            this.lbl_ChiTietPhieuThu.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.STT,
            this.MaPhieu,
            this.LoaiPhieu,
            this.HocVien,
            this.NgayThu,
            this.TenNguoiThu,
            this.NguoiNop,
            this.Tien,
            this.Sua,
            this.Xoa});
            this.dataGridView1.Location = new System.Drawing.Point(3, 481);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 50;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1247, 242);
            this.dataGridView1.TabIndex = 5;
            // 
            // STT
            // 
            this.STT.HeaderText = "STT";
            this.STT.MinimumWidth = 6;
            this.STT.Name = "STT";
            this.STT.Width = 50;
            // 
            // MaPhieu
            // 
            this.MaPhieu.HeaderText = "Mã Phiếu";
            this.MaPhieu.MinimumWidth = 6;
            this.MaPhieu.Name = "MaPhieu";
            this.MaPhieu.Width = 123;
            // 
            // LoaiPhieu
            // 
            this.LoaiPhieu.HeaderText = "Loại Phiếu";
            this.LoaiPhieu.MinimumWidth = 6;
            this.LoaiPhieu.Name = "LoaiPhieu";
            this.LoaiPhieu.Width = 123;
            // 
            // HocVien
            // 
            this.HocVien.HeaderText = "Tên Học Viên";
            this.HocVien.MinimumWidth = 6;
            this.HocVien.Name = "HocVien";
            this.HocVien.Width = 123;
            // 
            // NgayThu
            // 
            this.NgayThu.HeaderText = "Ngày Thu";
            this.NgayThu.MinimumWidth = 6;
            this.NgayThu.Name = "NgayThu";
            this.NgayThu.Width = 123;
            // 
            // TenNguoiThu
            // 
            this.TenNguoiThu.HeaderText = "Tên Người Thu";
            this.TenNguoiThu.MinimumWidth = 6;
            this.TenNguoiThu.Name = "TenNguoiThu";
            this.TenNguoiThu.Width = 135;
            // 
            // NguoiNop
            // 
            this.NguoiNop.HeaderText = "Người Nộp";
            this.NguoiNop.MinimumWidth = 6;
            this.NguoiNop.Name = "NguoiNop";
            this.NguoiNop.Width = 123;
            // 
            // Tien
            // 
            this.Tien.HeaderText = "Tổng Tiền";
            this.Tien.MinimumWidth = 6;
            this.Tien.Name = "Tien";
            this.Tien.Width = 123;
            // 
            // Sua
            // 
            this.Sua.HeaderText = "Sửa";
            this.Sua.MinimumWidth = 6;
            this.Sua.Name = "Sua";
            this.Sua.Width = 123;
            // 
            // Xoa
            // 
            this.Xoa.HeaderText = "Xóa";
            this.Xoa.MinimumWidth = 6;
            this.Xoa.Name = "Xoa";
            this.Xoa.Width = 123;
            // 
            // btn_Them
            // 
            this.btn_Them.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btn_Them.FlatAppearance.BorderSize = 0;
            this.btn_Them.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Them.Location = new System.Drawing.Point(927, 269);
            this.btn_Them.Name = "btn_Them";
            this.btn_Them.Size = new System.Drawing.Size(147, 37);
            this.btn_Them.TabIndex = 3;
            this.btn_Them.Text = "Them phieu thu";
            this.btn_Them.UseVisualStyleBackColor = false;
            // 
            // UC_THUCHI_THU_TaoPhieuThu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1262, 754);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.lbl_ChiTietPhieuThu);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "UC_THUCHI_THU_TaoPhieuThu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "UC_THUCHI_THU_TaoPhieuThu";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbl_ThongTin;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txt_TenNguoiNop;
        private System.Windows.Forms.TextBox txt_DiaChi;
        private System.Windows.Forms.TextBox txt_TenHV;
        private System.Windows.Forms.TextBox txt_TienThu;
        private System.Windows.Forms.TextBox txt_MaHV;
        private System.Windows.Forms.ComboBox cbb_NhanVienThu;
        private System.Windows.Forms.ComboBox cbb_LoaiPhieuThu;
        private System.Windows.Forms.DateTimePicker datePTime_NgayThu;
        private System.Windows.Forms.TextBox txt_NoiDung;
        private System.Windows.Forms.ComboBox cbb_TrangThai;
        private System.Windows.Forms.ComboBox cbb_TenLop;
        private System.Windows.Forms.ComboBox cbb_MaLop;
        private System.Windows.Forms.Label lbl_ChiTietPhieuThu;
        private System.Windows.Forms.Button btn_Them;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn STT;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaPhieu;
        private System.Windows.Forms.DataGridViewTextBoxColumn LoaiPhieu;
        private System.Windows.Forms.DataGridViewTextBoxColumn HocVien;
        private System.Windows.Forms.DataGridViewTextBoxColumn NgayThu;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenNguoiThu;
        private System.Windows.Forms.DataGridViewTextBoxColumn NguoiNop;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tien;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sua;
        private System.Windows.Forms.DataGridViewTextBoxColumn Xoa;
    }
}