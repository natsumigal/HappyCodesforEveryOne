using xml_curd_form.Model;

namespace xml_curd_form
{
    public partial class AddEditRecordForm : Form
    {
        public Route Record { get; private set; }

        public AddEditRecordForm()
        {
            InitializeComponent();
            Record = new Route();
        }

        public AddEditRecordForm(Route record) : this()
        {
            Record = record;
            PopulateFields();
        }

        private void PopulateFields()
        {
            txtTitle.Text = Record.Title;
            dtpStart.Text = Record.Start;
            dtpEnd.Text = Record.End;
            txtDistance.Text = Record.Distance.ToString();
            cbStatus.SelectedItem = Record.Status;
            dtpCreatedDatetime.Value = Record.CreatedDateTime;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Record.Title = txtTitle.Text;
            Record.Start = dtpStart.Text;
            Record.End = dtpEnd.Text;

            // Check if the input is a valid decimal
            if (decimal.TryParse(txtDistance.Text, out _))
            {
                if (Convert.ToDecimal(txtDistance.Text) < 0)
                {
                    MessageBox.Show("Distance cannot be less than 0.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                Record.Distance = Convert.ToDecimal(txtDistance.Text);
                 Record.Status= cbStatus.SelectedItem.ToString();
                Record.CreatedDateTime = dtpCreatedDatetime.Value;
                int year = DateTime.Now.Year; // Assuming current year
                int month = DateTime.Now.Month; // Assuming current month
                int day = DateTime.Now.Day; // Assuming current day
                string routeTitle = txtTitle.Text;
                DialogResult = DialogResult.OK;
                Close();
            }
            // Check if the distance is less than 0
            else
            {
                MessageBox.Show("Not a valid decimal.");
                return;
            }

        }
        private string GetFirst4Characters(string input)
        {
            return input.Substring(0, Math.Min(input.Length, 4));
        }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }

}
