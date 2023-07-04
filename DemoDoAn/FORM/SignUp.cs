using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DemoDoAn
{
    public partial class SignUp : Form
    {
        public SignUp()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void pnl_SIGUP_LEFT_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {

        }
       
        private void btn_Signup_Click(object sender, EventArgs e)
        {

            HocSinh hs=new HocSinh();

            if (string.IsNullOrEmpty(txtName.Text))
            {
                errorProvider1.BlinkStyle = ErrorBlinkStyle.NeverBlink;
                errorProvider1.SetError(pnl_ErrorName, "No Fill !");
            }
            else
            {
                errorProvider1.Clear();
            }
            if (string.IsNullOrEmpty(txtEmail.Text))
            {
                errorProvider1.BlinkStyle = ErrorBlinkStyle.NeverBlink;
                errorProvider1.SetError(pnl_ErrorEmail, "No Fill !");
            }
            else
            {
                errorProvider1.Clear();
            }
            if (string.IsNullOrEmpty(txtPassword.Text))
            {
                errorProvider1.BlinkStyle = ErrorBlinkStyle.NeverBlink;
                errorProvider1.SetError(pnl_ErrorPassword, "No Fill !");
            }
            else
            {
                errorProvider1.Clear();
            }
            if (string.IsNullOrEmpty(txtPassword1.Text))
            {
                errorProvider1.BlinkStyle = ErrorBlinkStyle.NeverBlink;
                errorProvider1.SetError(pnl_ErrorPassword1, "No Fill !");
            }
            else
            {
                errorProvider1.Clear();
            }
            if (string.IsNullOrEmpty(txtUsername.Text))
            {
                errorProvider1.BlinkStyle = ErrorBlinkStyle.NeverBlink;
                errorProvider1.SetError(pnl_ErrorUsername, "No Fill !");
            }
            else
            {
                errorProvider1.Clear();
            }
        }

        private void pnl_ErrorPassword1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtPassword1_TextChanged(object sender, EventArgs e)
        {
            if (txtPassword1 == txtPassword1)
            {
               errorProvider1.BlinkStyle = ErrorBlinkStyle.NeverBlink;
               errorProvider1.SetError(pnl_ErrorPassword1, "Khong khop mat khau");
            }
        }
    }
}
