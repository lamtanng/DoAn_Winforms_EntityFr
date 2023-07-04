namespace DemoDoAn
{
    partial class SignUp
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
            this.components = new System.ComponentModel.Container();
            this.lbl_CreateAcc = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbl_HoTen = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtPassword1 = new System.Windows.Forms.TextBox();
            this.panel6 = new System.Windows.Forms.Panel();
            this.lbl_RePassword = new System.Windows.Forms.Label();
            this.panel10 = new System.Windows.Forms.Panel();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.lbl_Password = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.checkBox_Agree = new System.Windows.Forms.CheckBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.panel9 = new System.Windows.Forms.Panel();
            this.lbl_UserName = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lbl_Email = new System.Windows.Forms.Label();
            this.panel8 = new System.Windows.Forms.Panel();
            this.pnl_SIGUP_LEFT = new System.Windows.Forms.Panel();
            this.pnl_ErrorPassword1 = new System.Windows.Forms.Panel();
            this.pnl_ErrorPassword = new System.Windows.Forms.Panel();
            this.pnl_ErrorUsername = new System.Windows.Forms.Panel();
            this.pnl_ErrorEmail = new System.Windows.Forms.Panel();
            this.pnl_ErrorName = new System.Windows.Forms.Panel();
            this.btn_Signup = new System.Windows.Forms.Button();
            this.pnl_SIGUP_RIGHT = new System.Windows.Forms.Panel();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.panel2.SuspendLayout();
            this.panel10.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel9.SuspendLayout();
            this.panel8.SuspendLayout();
            this.pnl_SIGUP_LEFT.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_CreateAcc
            // 
            this.lbl_CreateAcc.AutoSize = true;
            this.lbl_CreateAcc.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_CreateAcc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(163)))), ((int)(((byte)(252)))));
            this.lbl_CreateAcc.Location = new System.Drawing.Point(189, 42);
            this.lbl_CreateAcc.Name = "lbl_CreateAcc";
            this.lbl_CreateAcc.Size = new System.Drawing.Size(310, 29);
            this.lbl_CreateAcc.TabIndex = 0;
            this.lbl_CreateAcc.Text = "CREATE YOUR ACCOUNT";
            // 
            // txtName
            // 
            this.txtName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.20339F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtName.Location = new System.Drawing.Point(37, 52);
            this.txtName.Multiline = true;
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(291, 29);
            this.txtName.TabIndex = 1;
            this.txtName.TextChanged += new System.EventHandler(this.txtName_TextChanged);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(163)))), ((int)(((byte)(252)))));
            this.panel1.Location = new System.Drawing.Point(37, 82);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(400, 2);
            this.panel1.TabIndex = 2;
            // 
            // lbl_HoTen
            // 
            this.lbl_HoTen.AutoSize = true;
            this.lbl_HoTen.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_HoTen.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lbl_HoTen.Location = new System.Drawing.Point(32, 15);
            this.lbl_HoTen.Name = "lbl_HoTen";
            this.lbl_HoTen.Size = new System.Drawing.Size(64, 25);
            this.lbl_HoTen.TabIndex = 0;
            this.lbl_HoTen.Text = "Name";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.txtName);
            this.panel2.Controls.Add(this.panel1);
            this.panel2.Controls.Add(this.lbl_HoTen);
            this.panel2.Location = new System.Drawing.Point(78, 100);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(498, 92);
            this.panel2.TabIndex = 5;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // txtPassword1
            // 
            this.txtPassword1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPassword1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.20339F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPassword1.Location = new System.Drawing.Point(37, 49);
            this.txtPassword1.Multiline = true;
            this.txtPassword1.Name = "txtPassword1";
            this.txtPassword1.Size = new System.Drawing.Size(291, 29);
            this.txtPassword1.TabIndex = 1;
            this.txtPassword1.TextChanged += new System.EventHandler(this.txtPassword1_TextChanged);
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(163)))), ((int)(((byte)(252)))));
            this.panel6.Location = new System.Drawing.Point(37, 81);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(400, 2);
            this.panel6.TabIndex = 2;
            // 
            // lbl_RePassword
            // 
            this.lbl_RePassword.AutoSize = true;
            this.lbl_RePassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_RePassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lbl_RePassword.Location = new System.Drawing.Point(32, 17);
            this.lbl_RePassword.Name = "lbl_RePassword";
            this.lbl_RePassword.Size = new System.Drawing.Size(98, 25);
            this.lbl_RePassword.TabIndex = 0;
            this.lbl_RePassword.Text = "Password";
            // 
            // panel10
            // 
            this.panel10.Controls.Add(this.txtPassword);
            this.panel10.Controls.Add(this.panel5);
            this.panel10.Controls.Add(this.lbl_Password);
            this.panel10.Location = new System.Drawing.Point(78, 396);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(498, 95);
            this.panel10.TabIndex = 5;
            // 
            // txtPassword
            // 
            this.txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.20339F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPassword.Location = new System.Drawing.Point(38, 52);
            this.txtPassword.Multiline = true;
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(291, 29);
            this.txtPassword.TabIndex = 1;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(163)))), ((int)(((byte)(252)))));
            this.panel5.Location = new System.Drawing.Point(38, 84);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(400, 2);
            this.panel5.TabIndex = 2;
            // 
            // lbl_Password
            // 
            this.lbl_Password.AutoSize = true;
            this.lbl_Password.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Password.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lbl_Password.Location = new System.Drawing.Point(33, 20);
            this.lbl_Password.Name = "lbl_Password";
            this.lbl_Password.Size = new System.Drawing.Size(98, 25);
            this.lbl_Password.TabIndex = 0;
            this.lbl_Password.Text = "Password";
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.txtPassword1);
            this.panel7.Controls.Add(this.panel6);
            this.panel7.Controls.Add(this.lbl_RePassword);
            this.panel7.Location = new System.Drawing.Point(79, 497);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(498, 92);
            this.panel7.TabIndex = 5;
            // 
            // checkBox_Agree
            // 
            this.checkBox_Agree.AutoSize = true;
            this.checkBox_Agree.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.932204F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox_Agree.ForeColor = System.Drawing.Color.Gray;
            this.checkBox_Agree.Location = new System.Drawing.Point(118, 607);
            this.checkBox_Agree.Name = "checkBox_Agree";
            this.checkBox_Agree.Size = new System.Drawing.Size(342, 21);
            this.checkBox_Agree.TabIndex = 4;
            this.checkBox_Agree.Text = "By Signing Up, I Agree with Terms and Conditions";
            this.checkBox_Agree.UseVisualStyleBackColor = true;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(163)))), ((int)(((byte)(252)))));
            this.panel4.Location = new System.Drawing.Point(38, 86);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(400, 2);
            this.panel4.TabIndex = 2;
            // 
            // txtUsername
            // 
            this.txtUsername.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.20339F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsername.Location = new System.Drawing.Point(38, 54);
            this.txtUsername.Multiline = true;
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(291, 29);
            this.txtUsername.TabIndex = 1;
            // 
            // panel9
            // 
            this.panel9.Controls.Add(this.txtUsername);
            this.panel9.Controls.Add(this.panel4);
            this.panel9.Controls.Add(this.lbl_UserName);
            this.panel9.Location = new System.Drawing.Point(79, 295);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(498, 95);
            this.panel9.TabIndex = 5;
            // 
            // lbl_UserName
            // 
            this.lbl_UserName.AutoSize = true;
            this.lbl_UserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_UserName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lbl_UserName.Location = new System.Drawing.Point(33, 22);
            this.lbl_UserName.Name = "lbl_UserName";
            this.lbl_UserName.Size = new System.Drawing.Size(102, 25);
            this.lbl_UserName.TabIndex = 0;
            this.lbl_UserName.Text = "Username";
            // 
            // txtEmail
            // 
            this.txtEmail.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.20339F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmail.Location = new System.Drawing.Point(38, 49);
            this.txtEmail.Multiline = true;
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(291, 29);
            this.txtEmail.TabIndex = 1;
            this.txtEmail.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(163)))), ((int)(((byte)(252)))));
            this.panel3.Location = new System.Drawing.Point(38, 81);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(400, 2);
            this.panel3.TabIndex = 2;
            // 
            // lbl_Email
            // 
            this.lbl_Email.AutoSize = true;
            this.lbl_Email.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Email.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lbl_Email.Location = new System.Drawing.Point(32, 14);
            this.lbl_Email.Name = "lbl_Email";
            this.lbl_Email.Size = new System.Drawing.Size(60, 25);
            this.lbl_Email.TabIndex = 0;
            this.lbl_Email.Text = "Email";
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.txtEmail);
            this.panel8.Controls.Add(this.panel3);
            this.panel8.Controls.Add(this.lbl_Email);
            this.panel8.Location = new System.Drawing.Point(79, 198);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(498, 91);
            this.panel8.TabIndex = 5;
            // 
            // pnl_SIGUP_LEFT
            // 
            this.pnl_SIGUP_LEFT.BackColor = System.Drawing.Color.Transparent;
            this.pnl_SIGUP_LEFT.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnl_SIGUP_LEFT.Controls.Add(this.pnl_ErrorPassword1);
            this.pnl_SIGUP_LEFT.Controls.Add(this.pnl_ErrorPassword);
            this.pnl_SIGUP_LEFT.Controls.Add(this.pnl_ErrorUsername);
            this.pnl_SIGUP_LEFT.Controls.Add(this.pnl_ErrorEmail);
            this.pnl_SIGUP_LEFT.Controls.Add(this.pnl_ErrorName);
            this.pnl_SIGUP_LEFT.Controls.Add(this.btn_Signup);
            this.pnl_SIGUP_LEFT.Controls.Add(this.panel8);
            this.pnl_SIGUP_LEFT.Controls.Add(this.panel9);
            this.pnl_SIGUP_LEFT.Controls.Add(this.panel10);
            this.pnl_SIGUP_LEFT.Controls.Add(this.panel7);
            this.pnl_SIGUP_LEFT.Controls.Add(this.panel2);
            this.pnl_SIGUP_LEFT.Controls.Add(this.checkBox_Agree);
            this.pnl_SIGUP_LEFT.Controls.Add(this.lbl_CreateAcc);
            this.pnl_SIGUP_LEFT.Location = new System.Drawing.Point(0, -1);
            this.pnl_SIGUP_LEFT.Name = "pnl_SIGUP_LEFT";
            this.pnl_SIGUP_LEFT.Size = new System.Drawing.Size(640, 754);
            this.pnl_SIGUP_LEFT.TabIndex = 1;
            this.pnl_SIGUP_LEFT.Paint += new System.Windows.Forms.PaintEventHandler(this.pnl_SIGUP_LEFT_Paint);
            // 
            // pnl_ErrorPassword1
            // 
            this.pnl_ErrorPassword1.Location = new System.Drawing.Point(583, 546);
            this.pnl_ErrorPassword1.Name = "pnl_ErrorPassword1";
            this.pnl_ErrorPassword1.Size = new System.Drawing.Size(27, 27);
            this.pnl_ErrorPassword1.TabIndex = 9;
            this.pnl_ErrorPassword1.Paint += new System.Windows.Forms.PaintEventHandler(this.pnl_ErrorPassword1_Paint);
            // 
            // pnl_ErrorPassword
            // 
            this.pnl_ErrorPassword.Location = new System.Drawing.Point(583, 455);
            this.pnl_ErrorPassword.Name = "pnl_ErrorPassword";
            this.pnl_ErrorPassword.Size = new System.Drawing.Size(27, 27);
            this.pnl_ErrorPassword.TabIndex = 11;
            // 
            // pnl_ErrorUsername
            // 
            this.pnl_ErrorUsername.Location = new System.Drawing.Point(583, 349);
            this.pnl_ErrorUsername.Name = "pnl_ErrorUsername";
            this.pnl_ErrorUsername.Size = new System.Drawing.Size(27, 27);
            this.pnl_ErrorUsername.TabIndex = 10;
            // 
            // pnl_ErrorEmail
            // 
            this.pnl_ErrorEmail.Location = new System.Drawing.Point(583, 247);
            this.pnl_ErrorEmail.Name = "pnl_ErrorEmail";
            this.pnl_ErrorEmail.Size = new System.Drawing.Size(27, 27);
            this.pnl_ErrorEmail.TabIndex = 9;
            // 
            // pnl_ErrorName
            // 
            this.pnl_ErrorName.Location = new System.Drawing.Point(583, 152);
            this.pnl_ErrorName.Name = "pnl_ErrorName";
            this.pnl_ErrorName.Size = new System.Drawing.Size(27, 27);
            this.pnl_ErrorName.TabIndex = 8;
            // 
            // btn_Signup
            // 
            this.btn_Signup.BackColor = System.Drawing.Color.Transparent;
            this.btn_Signup.BackgroundImage = global::DemoDoAn.Properties.Resources.ThanhLogin_3x;
            this.btn_Signup.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_Signup.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Signup.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btn_Signup.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_Signup.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_Signup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Signup.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.762712F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Signup.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btn_Signup.Location = new System.Drawing.Point(177, 661);
            this.btn_Signup.Name = "btn_Signup";
            this.btn_Signup.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btn_Signup.Size = new System.Drawing.Size(308, 60);
            this.btn_Signup.TabIndex = 6;
            this.btn_Signup.Text = "S I G N   U P";
            this.btn_Signup.UseVisualStyleBackColor = false;
            this.btn_Signup.Click += new System.EventHandler(this.btn_Signup_Click);
            // 
            // pnl_SIGUP_RIGHT
            // 
            this.pnl_SIGUP_RIGHT.BackColor = System.Drawing.Color.DodgerBlue;
            this.pnl_SIGUP_RIGHT.BackgroundImage = global::DemoDoAn.Properties.Resources.Login_LEFT;
            this.pnl_SIGUP_RIGHT.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnl_SIGUP_RIGHT.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnl_SIGUP_RIGHT.Location = new System.Drawing.Point(637, 0);
            this.pnl_SIGUP_RIGHT.Name = "pnl_SIGUP_RIGHT";
            this.pnl_SIGUP_RIGHT.Size = new System.Drawing.Size(625, 753);
            this.pnl_SIGUP_RIGHT.TabIndex = 2;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // SignUp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1262, 753);
            this.Controls.Add(this.pnl_SIGUP_LEFT);
            this.Controls.Add(this.pnl_SIGUP_RIGHT);
            this.Name = "SignUp";
            this.Text = "SignUp";
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel10.ResumeLayout(false);
            this.panel10.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.panel9.ResumeLayout(false);
            this.panel9.PerformLayout();
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.pnl_SIGUP_LEFT.ResumeLayout(false);
            this.pnl_SIGUP_LEFT.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbl_CreateAcc;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbl_HoTen;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txtPassword1;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label lbl_RePassword;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label lbl_Password;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.CheckBox checkBox_Agree;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Label lbl_UserName;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lbl_Email;
        private System.Windows.Forms.Button btn_Signup;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Panel pnl_SIGUP_LEFT;
        private System.Windows.Forms.Panel pnl_SIGUP_RIGHT;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Panel pnl_ErrorPassword1;
        private System.Windows.Forms.Panel pnl_ErrorPassword;
        private System.Windows.Forms.Panel pnl_ErrorUsername;
        private System.Windows.Forms.Panel pnl_ErrorEmail;
        private System.Windows.Forms.Panel pnl_ErrorName;
    }
}