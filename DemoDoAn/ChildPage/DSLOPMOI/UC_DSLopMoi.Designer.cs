namespace DemoDoAn.ChildPage
{
    partial class UC_DSLopMoi
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txt_TimKiem = new System.Windows.Forms.TextBox();
            this.cbb_KhoaHoc = new System.Windows.Forms.ComboBox();
            this.cbb_TrangThai = new System.Windows.Forms.ComboBox();
            this.btn_TimKiem = new System.Windows.Forms.Button();
            this.btn_addTest = new System.Windows.Forms.Button();
            this.fPnl_QLiLop = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // txt_TimKiem
            // 
            this.txt_TimKiem.ForeColor = System.Drawing.Color.Gray;
            this.txt_TimKiem.Location = new System.Drawing.Point(42, 28);
            this.txt_TimKiem.Multiline = true;
            this.txt_TimKiem.Name = "txt_TimKiem";
            this.txt_TimKiem.Size = new System.Drawing.Size(285, 39);
            this.txt_TimKiem.TabIndex = 0;
            this.txt_TimKiem.Text = "nhap thong tin tim kiem";
            // 
            // cbb_KhoaHoc
            // 
            this.cbb_KhoaHoc.FormattingEnabled = true;
            this.cbb_KhoaHoc.Items.AddRange(new object[] {
            "Listening 1",
            "Listening 2",
            "Toiec 1",
            "Toiec 2"});
            this.cbb_KhoaHoc.Location = new System.Drawing.Point(355, 28);
            this.cbb_KhoaHoc.Name = "cbb_KhoaHoc";
            this.cbb_KhoaHoc.Size = new System.Drawing.Size(160, 24);
            this.cbb_KhoaHoc.TabIndex = 1;
            // 
            // cbb_TrangThai
            // 
            this.cbb_TrangThai.FormattingEnabled = true;
            this.cbb_TrangThai.Items.AddRange(new object[] {
            "Đã đầy",
            "Hoạt động"});
            this.cbb_TrangThai.Location = new System.Drawing.Point(532, 28);
            this.cbb_TrangThai.Name = "cbb_TrangThai";
            this.cbb_TrangThai.Size = new System.Drawing.Size(160, 24);
            this.cbb_TrangThai.TabIndex = 1;
            // 
            // btn_TimKiem
            // 
            this.btn_TimKiem.Location = new System.Drawing.Point(794, 28);
            this.btn_TimKiem.Name = "btn_TimKiem";
            this.btn_TimKiem.Size = new System.Drawing.Size(75, 23);
            this.btn_TimKiem.TabIndex = 2;
            this.btn_TimKiem.Text = "Tim kiem";
            this.btn_TimKiem.UseVisualStyleBackColor = true;
            // 
            // btn_addTest
            // 
            this.btn_addTest.Location = new System.Drawing.Point(1176, 28);
            this.btn_addTest.Name = "btn_addTest";
            this.btn_addTest.Size = new System.Drawing.Size(75, 23);
            this.btn_addTest.TabIndex = 2;
            this.btn_addTest.Text = "add";
            this.btn_addTest.UseVisualStyleBackColor = true;
            this.btn_addTest.Click += new System.EventHandler(this.btn_addTest_Click);
            // 
            // fPnl_QLiLop
            // 
            this.fPnl_QLiLop.AutoScroll = true;
            this.fPnl_QLiLop.Location = new System.Drawing.Point(28, 131);
            this.fPnl_QLiLop.Name = "fPnl_QLiLop";
            this.fPnl_QLiLop.Size = new System.Drawing.Size(1409, 747);
            this.fPnl_QLiLop.TabIndex = 3;
            // 
            // UC_DSLopMoi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.fPnl_QLiLop);
            this.Controls.Add(this.btn_addTest);
            this.Controls.Add(this.btn_TimKiem);
            this.Controls.Add(this.cbb_TrangThai);
            this.Controls.Add(this.cbb_KhoaHoc);
            this.Controls.Add(this.txt_TimKiem);
            this.Name = "UC_DSLopMoi";
            this.Size = new System.Drawing.Size(1456, 902);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_TimKiem;
        private System.Windows.Forms.ComboBox cbb_KhoaHoc;
        private System.Windows.Forms.ComboBox cbb_TrangThai;
        private System.Windows.Forms.Button btn_TimKiem;
        private System.Windows.Forms.Button btn_addTest;
        private System.Windows.Forms.FlowLayoutPanel fPnl_QLiLop;
    }
}
