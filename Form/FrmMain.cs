using System.Windows.Forms;

namespace DeteksiHama.Form
{
    public partial class FrmMain : System.Windows.Forms.Form
    {
        public FrmMain(bool enabled_form_input)
        {
            InitializeComponent();
            formToolStripMenuItem.Enabled = enabled_form_input;
        }

        private void FrmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void keluarToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            Application.Exit();
        }

        private void pertanyaanToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            var frmPertanyaan = new FrmInputPertanyaan{ MdiParent = this };
            frmPertanyaan.Show();
        }

        private void solusiToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            var frmSolusi = new FrmInputSolusi { MdiParent = this };
            frmSolusi.Show();
        }

        private void ruleToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            var frmRule = new FrmInputRule{ MdiParent = this };
            frmRule.Show();
        }

        private void diagnosaToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            
        }

        private void diagnosaToolStripMenuItem1_Click(object sender, System.EventArgs e)
        {
            var frmDiagnosa = new FrmDiagnosa { MdiParent = this };
            frmDiagnosa.Show();
        }

        private void treeGraphToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            var frmTreGraph = new FrmTreeGraph { MdiParent = this };
            frmTreGraph.Show();
        }

        private void tentangToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            var frmInfo = new FrmInfo { MdiParent = this };
            frmInfo.Show();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
