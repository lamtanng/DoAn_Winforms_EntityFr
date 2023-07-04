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
    public partial class UC_DSLopMoi : UserControl
    {
        public UC_DSLopMoi()
        {
            InitializeComponent();
        }

        private void btn_addTest_Click(object sender, EventArgs e)
        {
            ChildPage.UC_DSLopMoi_FormClass uc_ClassForm = new UC_DSLopMoi_FormClass();
            fPnl_QLiLop.Controls.Add(uc_ClassForm);
        }
    }
}
