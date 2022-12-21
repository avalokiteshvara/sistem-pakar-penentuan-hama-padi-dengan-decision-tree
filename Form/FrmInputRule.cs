using System;
using System.Globalization;
using System.Windows.Forms;
using DeteksiHama.Class;

namespace DeteksiHama.Form
{
    public partial class FrmInputRule : System.Windows.Forms.Form
    {
        readonly ClassDbConnect _dbConnect = new ClassDbConnect();
        private string _selectedkode = "NONE";
        private const string strQryPertanyaan = "SELECT id," +
                                               // "       CAST(RIGHT(id,LENGTH(id) - 1) as DECIMAL) as urut," +
                                                "       no_urut as urut," +                                    
                                                "       arr_jawaban " +
                                                "FROM pertanyaan " +
                                                "ORDER BY urut";

        public FrmInputRule()
        {
            InitializeComponent();
        }


        ///private void Create_dtGridViewColumn()

        private void LoadData()
        {
            var dtSolusi = _dbConnect.GetRecord("SELECT id," +
                                                //"       CAST(RIGHT(id,LENGTH(id) - 1) as DECIMAL) as urut " +
                                                "       no_urut as urut " +                                                
                                                "FROM solusi " +
                                                "ORDER BY urut");


            var dtPertanyaan = _dbConnect.GetRecord(strQryPertanyaan);

            //create pertanyaan Column
            for (int i = 0; i < dtPertanyaan.Rows.Count; i++)
            {
                string[] str = dtPertanyaan.Rows[i][2].ToString().Split(',');

                var dgvColumn = new DataGridViewComboBoxColumn
                                    {
                                        HeaderText = dtPertanyaan.Rows[i][0].ToString(),
                                        Name = dtPertanyaan.Rows[i][0].ToString()
                                    };
                for (int index = 0; index < str.Length; index++)
                {
                    string t = str[index];
                    dgvColumn.Items.Add(t);
                }
                dtGridView.Columns.Add(dgvColumn);
            }

            //create solusi column
            var dgvColumnSolusi = new DataGridViewComboBoxColumn
                                      {
                                          HeaderText = "Solusi",
                                          Name = "dgvSolusi"
                                      };
            for (int i = 0; i < dtSolusi.Rows.Count; i++)
            {
                dgvColumnSolusi.Items.Add(dtSolusi.Rows[i][0].ToString());
            }
            dtGridView.Columns.Add(dgvColumnSolusi);

            //set the values
            var dt = _dbConnect.GetRecord("SELECT id,arr_fakta,solusi " +
                                          "FROM rule");

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                AddRule();
                string[] str = dt.Rows[i][1].ToString().Split(',');

                for (int j = 0; j < dtGridView.Columns.Count - 1; j++)
                {
                    dtGridView[j, i].Value = str[j];
                }
                dtGridView[dtGridView.Columns.Count - 1, i].Value = dt.Rows[i][2].ToString();
            }

            //RuleCount();
        }

        private void FrmRule_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void RuleCount()
        {
            //return dtGridView.Rows.Count;
            lblTotalRule.Text = string.Format("Jumlah Rule: {0}", 
                dtGridView.Rows.Count.ToString(CultureInfo.InvariantCulture));
        }



        private void btnTutup_Click(object sender, EventArgs e)
        {
            //1.delete all record from database
            //2.insert new data

            _dbConnect.ExecuteNonQuery("TRUNCATE TABLE rule");

            for (int i = 0; i < dtGridView.Rows.Count; i++)
            {
                string str = null;
                for (int j = 0; j < dtGridView.Columns.Count - 1; j++)
                {
                    str += dtGridView[j, i].Value + ",";
                }
                //if (str != null) MessageBox.Show(str.Substring(0,str.Length - 1));
                if (str != null)
                {
                    var q = string.Format("INSERT INTO rule(id,arr_fakta,solusi) " +
                                          "VALUES({0},'{1}','{2}')",
                                          (i + 1), str.Substring(0, str.Length - 1),
                                          dtGridView[dtGridView.Columns.Count - 1, i].Value);
                    _dbConnect.ExecuteNonQuery(q);
                }
            }
        }

        private void AddRule()
        {
            dtGridView.Rows.Add(1);
            var dt = _dbConnect.GetRecord(strQryPertanyaan);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string[] str = dt.Rows[i][2].ToString().Split(',');
                dtGridView[i, dtGridView.Rows.Count - 1].Value = str[0];
            }

            RuleCount();
        }

        private void btnAddRow_Click(object sender, EventArgs e)
        {
            AddRule();
        }

        private void dtGridView_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {

        }

        private void dtGridView_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            RuleCount();
        }
    }
}
