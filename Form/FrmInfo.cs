using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DeteksiHama.Form
{
    public partial class FrmInfo : System.Windows.Forms.Form
    {
        public FrmInfo()
        {
            InitializeComponent();
        }

        private void btnTutup_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
