namespace xml_curd_form
{
    partial class AddEditRecordForm
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
            btnSave = new Button();
            btnCancel = new Button();
            label1 = new Label();
            txtTitle = new TextBox();
            label2 = new Label();
            dtpStart = new TextBox();
            label3 = new Label();
            dtpEnd = new TextBox();
            label4 = new Label();
            txtDistance = new TextBox();
            label5 = new Label();
            cbStatus = new ComboBox();
            label6 = new Label();
            dtpCreatedDatetime = new DateTimePicker();
            SuspendLayout();
            // 
            // btnSave
            // 
            btnSave.Location = new Point(102, 348);
            btnSave.Margin = new Padding(5, 4, 5, 4);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(101, 36);
            btnSave.TabIndex = 0;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(204, 348);
            btnCancel.Margin = new Padding(5, 4, 5, 4);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(101, 36);
            btnCancel.TabIndex = 1;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(16, 36);
            label1.Margin = new Padding(5, 0, 5, 0);
            label1.Name = "label1";
            label1.Size = new Size(84, 20);
            label1.TabIndex = 2;
            label1.Text = "Route Title:";
            // 
            // txtTitle
            // 
            txtTitle.Location = new Point(102, 33);
            txtTitle.Margin = new Padding(5, 4, 5, 4);
            txtTitle.Name = "txtTitle";
            txtTitle.Size = new Size(266, 27);
            txtTitle.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(16, 83);
            label2.Margin = new Padding(5, 0, 5, 0);
            label2.Name = "label2";
            label2.Size = new Size(43, 20);
            label2.TabIndex = 4;
            label2.Text = "Start:";
            // 
            // dtpStart
            // 
            dtpStart.Location = new Point(102, 73);
            dtpStart.Margin = new Padding(5, 4, 5, 4);
            dtpStart.Name = "dtpStart";
            dtpStart.Size = new Size(266, 27);
            dtpStart.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(16, 127);
            label3.Margin = new Padding(5, 0, 5, 0);
            label3.Name = "label3";
            label3.Size = new Size(37, 20);
            label3.TabIndex = 6;
            label3.Text = "End:";
            // 
            // dtpEnd
            // 
            dtpEnd.Location = new Point(102, 117);
            dtpEnd.Margin = new Padding(5, 4, 5, 4);
            dtpEnd.Name = "dtpEnd";
            dtpEnd.Size = new Size(266, 27);
            dtpEnd.TabIndex = 7;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(16, 169);
            label4.Margin = new Padding(5, 0, 5, 0);
            label4.Name = "label4";
            label4.Size = new Size(69, 20);
            label4.TabIndex = 8;
            label4.Text = "Distance:";
            // 
            // txtDistance
            // 
            txtDistance.Location = new Point(102, 164);
            txtDistance.Margin = new Padding(5, 4, 5, 4);
            txtDistance.Name = "txtDistance";
            txtDistance.Size = new Size(266, 27);
            txtDistance.TabIndex = 9;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(16, 213);
            label5.Margin = new Padding(5, 0, 5, 0);
            label5.Name = "label5";
            label5.Size = new Size(52, 20);
            label5.TabIndex = 10;
            label5.Text = "Status:";
            // 
            // cbStatus
            // 
            cbStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cbStatus.FormattingEnabled = true;
            cbStatus.Items.AddRange(new object[] { "Active", "Inactive" });
            cbStatus.Location = new Point(102, 209);
            cbStatus.Margin = new Padding(5, 4, 5, 4);
            cbStatus.Name = "cbStatus";
            cbStatus.Size = new Size(266, 28);
            cbStatus.TabIndex = 11;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(16, 261);
            label6.Margin = new Padding(5, 0, 5, 0);
            label6.Name = "label6";
            label6.Size = new Size(130, 20);
            label6.TabIndex = 12;
            label6.Text = "Created Datetime:";
            // 
            // dtpCreatedDatetime
            // 
            dtpCreatedDatetime.Location = new Point(150, 252);
            dtpCreatedDatetime.Margin = new Padding(5, 4, 5, 4);
            dtpCreatedDatetime.Name = "dtpCreatedDatetime";
            dtpCreatedDatetime.Size = new Size(218, 27);
            dtpCreatedDatetime.TabIndex = 13;
            // 
            // AddEditRecordForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(385, 427);
            Controls.Add(dtpCreatedDatetime);
            Controls.Add(label6);
            Controls.Add(cbStatus);
            Controls.Add(label5);
            Controls.Add(txtDistance);
            Controls.Add(label4);
            Controls.Add(dtpEnd);
            Controls.Add(label3);
            Controls.Add(dtpStart);
            Controls.Add(label2);
            Controls.Add(txtTitle);
            Controls.Add(label1);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Margin = new Padding(5, 4, 5, 4);
            Name = "AddEditRecordForm";
            Text = "AddEditRecordForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        public Button btnSave;
        public Button btnCancel;
        public Label label1;
        public TextBox txtTitle;
        public Label label2;
        public TextBox dtpStart;
        public Label label3;
        public TextBox dtpEnd;
        public Label label4;
        public TextBox txtDistance;
        public Label label5;
        public ComboBox cbStatus;
        public Label label6;
        public DateTimePicker dtpCreatedDatetime;
    }

}