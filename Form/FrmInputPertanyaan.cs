using System;
using System.Windows.Forms;
using DeteksiHama.Class;

namespace DeteksiHama.Form
{
    public partial class FrmInputPertanyaan : System.Windows.Forms.Form
    {

        readonly ClassDbConnect _dbConnect = new ClassDbConnect();
        private string _selectedkode = "NONE";


        public FrmInputPertanyaan()
        {
            InitializeComponent();
        }

        private void LoadData()
        {
            ClassHelper.ClearTextBox(this);
            var dt = _dbConnect.GetRecord("SELECT no_urut as urut," +
                                          "       id," +
                                          "       isi," +
                                          "       arr_jawaban " +
                                          //"       CAST(RIGHT(id,LENGTH(id) - 1) as DECIMAL) as urut " +
                                          "FROM pertanyaan " +
                                          "ORDER BY urut");

            dtGridView.DataSource = dt;
            //dtGridView.Columns[3].Visible = false;
        }

        private void SetEnabledOnBtn(bool btnNewEnable, bool btnCancelEnable, bool btnSaveEnable)
        {
            btnTambah.Enabled = btnNewEnable;
            btnBatal.Enabled = btnCancelEnable;
            btnSimpan.Enabled = btnSaveEnable;
            //ClassHelper.SetReadOnlyOnTextBox(this, btnNewEnable);
            txtId.ReadOnly = txtNoUrut.ReadOnly =txtPertanyaan.ReadOnly = 
                txtArrJawaban.ReadOnly = btnNewEnable;
        }


        private void FrmPertanyaan_Load(object sender, EventArgs e)
        {
            LoadData();
            SetEnabledOnBtn(true, false, false);
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            if(_selectedkode != "NONE")
            {//update data
                var q = string.Format(
                    "UPDATE pertanyaan " +
                    "SET id ='{0}'," +
                    "    isi='{1}'," +
                    "    arr_jawaban ='{3}'," +
                    "    no_urut = {4} " +
                    "WHERE id='{2}'",
                    txtId.Text,
                    txtPertanyaan.Text,
                    _selectedkode,
                    txtArrJawaban.Text,
                    txtNoUrut.Text);
                _dbConnect.ExecuteNonQuery(q);


            }else
            {//insert data
                var q = string.Format(
                    "INSERT INTO pertanyaan(id,isi,arr_jawaban,no_urut) " +
                    "VALUES('{0}','{1}','{2}',{3})",
                    txtId.Text,txtPertanyaan.Text,txtArrJawaban.Text,txtNoUrut.Text);
                _dbConnect.ExecuteNonQuery(q);
            }

            _selectedkode = "NONE";
            txtId.Clear();
            txtPertanyaan.Clear();
            SetEnabledOnBtn(true, false, false);
            LoadData();
        }

        private void dtGridView_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (MessageBox.Show("Yakin ingin menghapus data ini?", "Konfirmasi", MessageBoxButtons.YesNo) !=
               DialogResult.Yes) return;
            if (dtGridView.SelectedRows.Count <= 0) return;

            var id = dtGridView[1, dtGridView.SelectedRows[0].Index].Value.ToString();
            var q = string.Format("DELETE FROM pertanyaan " +
                                  "WHERE id = ('{0}')", id);
            _dbConnect.ExecuteNonQuery(q);
            _dbConnect.ExecuteNonQuery("CALL proc_1()");
        }

        private void dtGridView_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {

            _selectedkode = "NONE";
            txtId.Clear();
            txtPertanyaan.Clear();
            SetEnabledOnBtn(true, false, false);
            LoadData();

        }

        private void btnTambah_Click(object sender, EventArgs e)
        {
            //ClassHelper.ClearTextBox(this);
            txtId.Clear();
            txtPertanyaan.Clear();
            txtNoUrut.Clear();
            SetEnabledOnBtn(false, true, true);
            _selectedkode = "NONE";
            txtNoUrut.Text = _dbConnect.intExecuteScalar("SELECT IFNULL(MAX(no_urut),0) + 1 " +
                                                         "FROM pertanyaan").ToString();
        }

        private void btnBatal_Click(object sender, EventArgs e)
        {
            txtId.Clear();
            txtPertanyaan.Clear();
            txtNoUrut.Clear();
            SetEnabledOnBtn(true, false, false);
        }

        private void dtGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            SetEnabledOnBtn(false, true, true);

            txtNoUrut.Text = dtGridView[0, dtGridView.SelectedRows[0].Index].Value.ToString();
            _selectedkode = dtGridView[1, dtGridView.SelectedRows[0].Index].Value.ToString();
            txtId.Text = dtGridView[1, dtGridView.SelectedRows[0].Index].Value.ToString();
            txtPertanyaan.Text = dtGridView[2, dtGridView.SelectedRows[0].Index].Value.ToString();
            txtArrJawaban.Text = dtGridView[3, dtGridView.SelectedRows[0].Index].Value.ToString();
            
        }

        private void btnTutup_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txtId_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
