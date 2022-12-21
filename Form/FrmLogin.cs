//#define RELEASE
using System.Windows.Forms;
using DeteksiHama.Class;

namespace DeteksiHama.Form
{
    public partial class FrmLogin : System.Windows.Forms.Form
    {
        readonly ClassDbConnect _dbConnect = new ClassDbConnect();
        public FrmLogin()
        {
            InitializeComponent();
#if(RELEASE)
            txtPassword.Clear();
            txtUserID.Clear();
#endif
        }



        private void btnMasuk_Click(object sender, System.EventArgs e)
        {
            var s = cmbLevel.Text == "Pengguna" ? "AND is_admin = 'False'" : "AND is_admin = 'True'";

            var i = _dbConnect.intExecuteScalar(
                string.Format("SELECT COUNT(*) " +
                              "FROM user " +
                              "WHERE nama='{0}' AND password='{1}' {2}"
                              , txtUserID.Text, txtPassword.Text, s));

            if (i != 0)
            {
                
                if(cmbLevel.Text == "Pengguna")
                {
                    //frmMain.formToolStripMenuItem.Enabled = false;
                    var frmMain = new FrmMain(false);
                    frmMain.Show();
                }else
                {
                    var frmMain = new FrmMain(true);
                    frmMain.Show();
                }
                Hide();

            }
            else
            {
                MessageBox.Show("Nama atau Password Salah!","PERINGATAN",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }

        }

        private void FrmLogin_Load(object sender, System.EventArgs e)
        {

        }

        private void label1_Click(object sender, System.EventArgs e)
        {

        }
    }
}
