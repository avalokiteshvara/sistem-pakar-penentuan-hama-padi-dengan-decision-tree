using System;
using System.Globalization;
using System.Windows.Forms;
using DeteksiHama.Class;

namespace DeteksiHama.Form
{
    public partial class FrmInputSolusi : System.Windows.Forms.Form
    {
        readonly ClassDbConnect _dbConnect = new ClassDbConnect();
        private string _selectedkode = "NONE";

        public FrmInputSolusi()
        {
            InitializeComponent();
        }

        private void LoadData()
        {
            ClassHelper.ClearTextBox(this);
            var dt = _dbConnect.GetRecord("SELECT no_urut," +
                                          "       id," +
                                          "       isi " +
                                          //"       CAST(RIGHT(id,LENGTH(id) - 1) as DECIMAL) as urut  " +
                                          "FROM solusi " +
                                          "ORDER BY no_urut");
            dtGridView.DataSource = dt;
        }

        private void SetEnabledOnBtn(bool btnNewEnable, bool btnCancelEnable, bool btnSaveEnable)
        {
            btnTambah.Enabled = btnNewEnable;
            btnBatal.Enabled = btnCancelEnable;
            btnSimpan.Enabled = btnSaveEnable;
            //ClassHelper.SetReadOnlyOnTextBox(this, btnNewEnable);
            txtId.ReadOnly = txtNoUrut.ReadOnly = txtSolusi.ReadOnly = btnNewEnable;

        }

        private void FrmSolusi_Load(object sender, EventArgs e)
        {
            LoadData();
            SetEnabledOnBtn(true, false, false);
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            if (_selectedkode != "NONE")
            {//update data
                var q = string.Format(
                    "UPDATE solusi " +
                    "SET id ='{0}'," +
                    "    isi='{1}'," +
                    "    no_urut ={3} " +
                    "WHERE id='{2}'",
                    txtId.Text, txtSolusi.Text, _selectedkode,txtNoUrut.Text);
                _dbConnect.ExecuteNonQuery(q);
            }
            else
            {//insert data
                var q = string.Format(
                    "INSERT INTO solusi(id,isi,no_urut) " +
                    "VALUES('{0}','{1}',{2})", txtId.Text, txtSolusi.Text,txtNoUrut.Text);
                _dbConnect.ExecuteNonQuery(q);
            }

            _selectedkode = "NONE";
            txtId.Clear();
            txtSolusi.Clear();
            txtNoUrut.Clear();
            SetEnabledOnBtn(true, false, false);
            LoadData();
        }

        private void dtGridView_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (MessageBox.Show("Yakin ingin menghapus data ini?", "Konfirmasi", MessageBoxButtons.YesNo) !=
               DialogResult.Yes) return;
            if (dtGridView.SelectedRows.Count <= 0) return;

            var id = dtGridView[1, dtGridView.SelectedRows[0].Index].Value.ToString();
            var q = string.Format("DELETE FROM solusi WHERE id = ('{0}')", id);
            _dbConnect.ExecuteNonQuery(q);
            _dbConnect.ExecuteNonQuery("CALL proc_2()");
        }

        private void dtGridView_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            _selectedkode = "NONE";
            txtId.Clear();
            txtSolusi.Clear();
            txtNoUrut.Clear();
            SetEnabledOnBtn(true, false, false);
            LoadData();
        }

        private void btnTambah_Click(object sender, EventArgs e)
        {
            //ClassHelper.ClearTextBox(this);
            txtId.Clear();
            txtSolusi.Clear();
            txtNoUrut.Clear();

            SetEnabledOnBtn(false, true, true);
            _selectedkode = "NONE";
            txtNoUrut.Text = _dbConnect.intExecuteScalar("SELECT IFNULL(MAX(no_urut),0) + 1 " +
                                                         "FROM solusi").ToString(CultureInfo.InvariantCulture);
        }

        private void btnBatal_Click(object sender, EventArgs e)
        {
            txtId.Clear();
            txtSolusi.Clear();
            txtNoUrut.Clear();
            SetEnabledOnBtn(true, false, false);
        }

        private void dtGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            SetEnabledOnBtn(false, true, true);

            txtNoUrut.Text = dtGridView[0, dtGridView.SelectedRows[0].Index].Value.ToString();
            _selectedkode = dtGridView[1, dtGridView.SelectedRows[0].Index].Value.ToString();
            txtId.Text = dtGridView[1, dtGridView.SelectedRows[0].Index].Value.ToString();
            txtSolusi.Text = dtGridView[2, dtGridView.SelectedRows[0].Index].Value.ToString();
            
        }

        private void btnTutup_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dtGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
