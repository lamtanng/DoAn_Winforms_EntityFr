namespace DemoDoAn.ChildPage
{
    partial class UC_GM_INFO_UPDATE
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
            this.picBox_Avatar = new System.Windows.Forms.PictureBox();
            this.lbl_Name = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picBox_Avatar)).BeginInit();
            this.SuspendLayout();
            // 
            // picBox_Avatar
            // 
            this.picBox_Avatar.Location = new System.Drawing.Point(105, 13);
            this.picBox_Avatar.Name = "picBox_Avatar";
            this.picBox_Avatar.Size = new System.Drawing.Size(180, 168);
            this.picBox_Avatar.TabIndex = 0;
            this.picBox_Avatar.TabStop = false;
            // 
            // lbl_Name
            // 
            this.lbl_Name.AutoSize = true;
            this.lbl_Name.Location = new System.Drawing.Point(151, 202);
            this.lbl_Name.Name = "lbl_Name";
            this.lbl_Name.Size = new System.Drawing.Size(51, 17);
            this.lbl_Name.TabIndex = 1;
            this.lbl_Name.Text = "HoTen";
            // 
            // UC_GM_INFO_UPDATE
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.lbl_Name);
            this.Controls.Add(this.picBox_Avatar);
            this.Name = "UC_GM_INFO_UPDATE";
            this.Size = new System.Drawing.Size(397, 543);
            ((System.ComponentModel.ISupportInitialize)(this.picBox_Avatar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picBox_Avatar;
        private System.Windows.Forms.Label lbl_Name;
    }
}
