using xml_curd_form.Model;
using xml_curd_form.Services;

namespace xml_curd_form
{
    public partial class CURDForm : Form
    {
        UserRole userrole = new();
        public List<Route> records;
        public string xmlFilePath = "";
       public SaveFileDialog saveFileDialog = new SaveFileDialog();
        public CURDForm(string username, string usertext)
        {
            InitializeComponent();
            records = new List<Route>();
            lblNames.Text = "Role:: " + username + " , User Name:: " + usertext;
            if (username == "OPERATOR")
            {
                //btnEdit.Visible = false;
                //btnDelete.Visible = false;
                btnEdit.Enabled = false;
                btnDelete.Enabled = false;
            }

            // Define DataGridView columns
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.Columns.Add("Title", "Route Title");
            dataGridView1.Columns.Add("Start", "First Station");
            dataGridView1.Columns.Add("End", "Last Station");
            dataGridView1.Columns.Add("Distance", "Distance");
            dataGridView1.Columns.Add("Status", "Status");
            dataGridView1.Columns.Add("CreatedDatetime", "Created Datetime");
        }
        public void LoadRecordsFromXml(string filePath)
        {
            if (!File.Exists(filePath))
            {
                MessageBox.Show("File does not exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            records.Clear();
        //    dataGridView1.Rows.Clear();
           XmlHelper xmlhelp = new();
            records = xmlhelp.LoadRecords(filePath);
            foreach (var record in records)
            {
                dataGridView1.Rows.Add(record.Title, record.Start, record.End, record.Distance, record.Status, record.CreatedDateTime);
            }

        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            saveFileDialog.Filter = "XML Files (*.xml)|*.xml";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                xmlFilePath = saveFileDialog.FileName;
                XmlHelper xmlHelp = new();
                xmlHelp.SaveRecordsToXml(xmlFilePath, records);
                MessageBox.Show("Records saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "XML Files (*.xml)|*.xml";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                xmlFilePath = openFileDialog.FileName;
                txtFileName.Text = xmlFilePath;

            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddEditRecordForm addEditForm = new AddEditRecordForm();
            if (addEditForm.ShowDialog() == DialogResult.OK)
            {
                Route record = addEditForm.Record;
                records.Add(record);
                dataGridView1.Rows.Add(record.Title, record.Start, record.End, record.Distance, record.Status, record.CreatedDateTime);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int selectedIndex = dataGridView1.SelectedRows[0].Index;
                Route selectedRecord = records[selectedIndex];

                AddEditRecordForm addEditForm = new AddEditRecordForm(selectedRecord);
                if (addEditForm.ShowDialog() == DialogResult.OK)
                {
                    records[selectedIndex] = addEditForm.Record;
                    dataGridView1.Rows[selectedIndex].SetValues(addEditForm.Record.Title, addEditForm.Record.Start, addEditForm.Record.End, addEditForm.Record.Distance, addEditForm.Record.Status, addEditForm.Record.CreatedDateTime);
                }
            }
            else
            {
                MessageBox.Show("Please select a record to edit.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int selectedIndex = dataGridView1.SelectedRows[0].Index;
                dataGridView1.Rows.RemoveAt(selectedIndex);
                records.RemoveAt(selectedIndex);
            }
            else
            {
                MessageBox.Show("Please select a record to delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            LoadRecordsFromXml(txtFileName.Text);
        }


    }

}

