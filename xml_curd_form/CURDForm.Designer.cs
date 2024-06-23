namespace xml_curd_form
{
    partial class CURDForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dataGridView1 = new DataGridView();
            btnAdd = new Button();
            btnEdit = new Button();
            btnDelete = new Button();
            btnSave = new Button();
            btnBrowse = new Button();
            btnImport = new Button();
            lbldtSource = new Label();
            txtFileName = new TextBox();
            lblNames = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(30, 115);
            dataGridView1.Margin = new Padding(5, 4, 5, 4);
            dataGridView1.MultiSelect = false;
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(986, 427);
            dataGridView1.TabIndex = 0;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(479, 588);
            btnAdd.Margin = new Padding(5, 4, 5, 4);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(101, 36);
            btnAdd.TabIndex = 1;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnEdit
            // 
            btnEdit.Location = new Point(696, 588);
            btnEdit.Margin = new Padding(5, 4, 5, 4);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(101, 36);
            btnEdit.TabIndex = 2;
            btnEdit.Text = "Edit";
            btnEdit.UseVisualStyleBackColor = true;
            btnEdit.Click += btnEdit_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(806, 588);
            btnDelete.Margin = new Padding(5, 4, 5, 4);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(101, 36);
            btnDelete.TabIndex = 3;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(915, 588);
            btnSave.Margin = new Padding(5, 4, 5, 4);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(101, 36);
            btnSave.TabIndex = 4;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnBrowse
            // 
            btnBrowse.Location = new Point(813, 37);
            btnBrowse.Margin = new Padding(5, 4, 5, 4);
            btnBrowse.Name = "btnBrowse";
            btnBrowse.Size = new Size(101, 36);
            btnBrowse.TabIndex = 5;
            btnBrowse.Text = "Browse";
            btnBrowse.UseVisualStyleBackColor = true;
            btnBrowse.Click += btnBrowse_Click;
            // 
            // btnImport
            // 
            btnImport.Location = new Point(586, 588);
            btnImport.Margin = new Padding(5, 4, 5, 4);
            btnImport.Name = "btnImport";
            btnImport.Size = new Size(101, 36);
            btnImport.TabIndex = 6;
            btnImport.Text = "Import";
            btnImport.UseVisualStyleBackColor = true;
            btnImport.Click += btnImport_Click;
            // 
            // lbldtSource
            // 
            lbldtSource.AutoSize = true;
            lbldtSource.Location = new Point(30, 37);
            lbldtSource.Name = "lbldtSource";
            lbldtSource.Size = new Size(100, 20);
            lbldtSource.TabIndex = 7;
            lbldtSource.Text = "Data Source ::";
            // 
            // txtFileName
            // 
            txtFileName.Location = new Point(127, 37);
            txtFileName.Margin = new Padding(3, 4, 3, 4);
            txtFileName.Name = "txtFileName";
            txtFileName.ReadOnly = true;
            txtFileName.Size = new Size(678, 27);
            txtFileName.TabIndex = 8;
            // 
            // lblNames
            // 
            lblNames.AutoSize = true;
            lblNames.Location = new Point(30, 641);
            lblNames.Name = "lblNames";
            lblNames.Size = new Size(50, 20);
            lblNames.TabIndex = 9;
            lblNames.Text = "label1";
            // 
            // CURDForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1066, 692);
            Controls.Add(lblNames);
            Controls.Add(txtFileName);
            Controls.Add(lbldtSource);
            Controls.Add(btnImport);
            Controls.Add(btnBrowse);
            Controls.Add(btnSave);
            Controls.Add(btnDelete);
            Controls.Add(btnEdit);
            Controls.Add(btnAdd);
            Controls.Add(dataGridView1);
            Margin = new Padding(5, 4, 5, 4);
            Name = "CURDForm";
            Text = "CRUD Application";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        public DataGridView dataGridView1;
        public Button btnAdd;
        public Button btnEdit;
        public Button btnDelete;
        public Button btnSave;
        public Button btnBrowse;
        public Button btnImport;
        public Label lbldtSource;
        public TextBox txtFileName;
        public Label lblNames;
    }
}