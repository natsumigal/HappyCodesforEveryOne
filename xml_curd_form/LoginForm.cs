using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using xml_curd_form.Model;

namespace xml_curd_form
{
    public partial class LoginForm : Form
    {
        UserRole userrole = new();

        public LoginForm()
        {
            InitializeComponent();
            InitializeUserRoleComboBox();
        }

        private void InitializeUserRoleComboBox()
        {
            // Populate ComboBox with user roles
            roleComboBox.Items.AddRange(userrole.userPasswords.Keys.ToArray());
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            string username = roleComboBox.SelectedItem?.ToString();
            string password = passwordTextBox.Text;

//#if DEBUG
//            //username = "ADMINISTRATOR";
//            //password = "Admin2024";

//            username = "OPERATOR";
//            password = "Operator2024";
//#endif
            if (username != null && userrole.userPasswords.ContainsKey(username) && userrole.userPasswords[username] == password)
            {
                CURDForm mainForm = new CURDForm(username, usernameTextBox.Text);
                mainForm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Invalid username or password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

