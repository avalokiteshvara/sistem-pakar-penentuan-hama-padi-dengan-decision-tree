using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using DeteksiHama.Class;

namespace DeteksiHama.Form
{
    public partial class FrmDiagnosa : System.Windows.Forms.Form
    {
        readonly ClassDbConnect _dbConnect = new ClassDbConnect();
        private string _curParent;
        private readonly List<string> _hasilDiagnosa = new List<string>();
        private const string SELESAI = "SELESAI";

        public FrmDiagnosa()
        {
            InitializeComponent();
        }

        private void FrmDiagnosa_Load(object sender, System.EventArgs e)
        {
            //build all stuft
            //ClassGenerateDBTree buildtree = new ClassGenerateDBTree();
            //buildtree.BuildDecisionTree();
            ClassGenerateDBTree.BuildDecisionTree();


            //id = 1 pada decesion tree merupakan root. 
            //attribute ngambil aja pada tabel yang sama

            var dtrootNodeName =
                _dbConnect.GetRecord("SELECT b.id,b.isi " +
                                     "FROM decision_tree a " +
                                     "LEFT JOIN pertanyaan b " +
                                     "ON a.node = b.id " +
                                     "WHERE a.parent = 'NULL' " +
                                     "      AND a.parent_attribute = 'NULL'");

            lblPertanyaan.Text = dtrootNodeName.Rows[0][1].ToString();
            _curParent = dtrootNodeName.Rows[0][0].ToString();


            var dtPertanyaan = _dbConnect.GetRecord(string.Format("SELECT parent_attribute " +
                                                                  "FROM decision_tree " +
                                                                  "WHERE parent = '{0}'", dtrootNodeName.Rows[0][0]));

            cmbJawaban.DataSource = dtPertanyaan;
            cmbJawaban.DisplayMember = "parent_attribute";
        }

        private void btnLanjut_Click(object sender, System.EventArgs e)
        {
            if (btnLanjut.Text == SELESAI)
            {
                Close();
                return;
            }

            _hasilDiagnosa.Add(string.Format("{0}: {1}", lblPertanyaan.Text, cmbJawaban.Text));
            var dt = _dbConnect.GetRecord(string.Format("SELECT child,node " +
                                                        "FROM decision_tree " +
                                                        "WHERE parent ='{0}' AND " +
                                                        "      parent_attribute ='{1}'", _curParent, cmbJawaban.Text));

            lblPertanyaan.Text = "";
            if (int.Parse(dt.Rows[0][0].ToString()) == 0)
            {
                //brarti udah selesai

                //_hasilDiagnosa += string.Format("Solusi:{0}","test_ajah");
                var _solusi = _dbConnect.strExecuteScalar(string.Format("SELECT isi " +
                                                                        "FROM solusi " +
                                                                        "WHERE id='{0}'", dt.Rows[0][1]));
                _hasilDiagnosa.Add("\nSOLUSI => " + _solusi.ToString(CultureInfo.InvariantCulture));

                //lets make it string array
                //var strQ = _hasilDiagnosa.ToArray();

                foreach (var t in _hasilDiagnosa)
                {
                    lblPertanyaan.Text += t + "\n";
                }
                cmbJawaban.Visible = false;
                lblOption.Visible = false;
                btnLanjut.Text = "SELESAI";
            }
            else
            {
                //cari lagi nodenya
                var dtGetNextQ = _dbConnect.GetRecord(
                    string.Format("SELECT a.node,b.isi " +
                                  "FROM decision_tree a " +
                                  "LEFT JOIN pertanyaan b " +
                                  "ON a.node = b.id " +
                                  "WHERE a.parent='{0}' AND " +
                                  "      a.parent_attribute='{1}'", _curParent, cmbJawaban.Text));

                _curParent = dtGetNextQ.Rows[0][0].ToString();
                lblPertanyaan.Text = dtGetNextQ.Rows[0][1].ToString();
                //_hasilDiagnosa.Add(string.Format("{0}: {1}", lblPertanyaan.Text, cmbJawaban.Text));
                var dtPertanyaan = _dbConnect.GetRecord(string.Format("SELECT parent_attribute " +
                                                                  "FROM decision_tree " +
                                                                  "WHERE parent = '{0}'", _curParent));

                cmbJawaban.DataSource = dtPertanyaan;
                cmbJawaban.DisplayMember = "parent_attribute";
            }
        }
    }
}
