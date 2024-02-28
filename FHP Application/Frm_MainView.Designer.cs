namespace FHP_Application
{
    partial class Frm_MainView
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_MainView));
            this.dgv_EmployeeData = new System.Windows.Forms.DataGridView();
            this.SerialNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Prefix = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FirstName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MiddleName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LastName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Qualification = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.JoiningDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CurrentCompany = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CurrentAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DOB = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menu_New = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_Update = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_Delete = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_View = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_aboutUs = new System.Windows.Forms.ToolStripMenuItem();
            this.lbl_Status = new System.Windows.Forms.Label();
            this.txtBox_searchRecords = new System.Windows.Forms.TextBox();
            this.btn_clearFilterAndSearch = new System.Windows.Forms.Button();
            this.lbl_role = new System.Windows.Forms.Label();
            this.btn_search = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_EmployeeData)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgv_EmployeeData
            // 
            this.dgv_EmployeeData.AllowUserToDeleteRows = false;
            this.dgv_EmployeeData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_EmployeeData.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Blue;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_EmployeeData.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_EmployeeData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_EmployeeData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SerialNo,
            this.Prefix,
            this.FirstName,
            this.MiddleName,
            this.LastName,
            this.Qualification,
            this.JoiningDate,
            this.CurrentCompany,
            this.CurrentAddress,
            this.DOB});
            this.dgv_EmployeeData.GridColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dgv_EmployeeData.Location = new System.Drawing.Point(0, 90);
            this.dgv_EmployeeData.Name = "dgv_EmployeeData";
            this.dgv_EmployeeData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_EmployeeData.Size = new System.Drawing.Size(1529, 591);
            this.dgv_EmployeeData.TabIndex = 0;
            this.dgv_EmployeeData.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_EmployeeData_CellClick);
            this.dgv_EmployeeData.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_EmployeeData_CellDoubleClick);
            this.dgv_EmployeeData.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgv_EmployeeData_CellPainting);
            this.dgv_EmployeeData.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_EmployeeData_CellValueChanged);
            this.dgv_EmployeeData.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgv_EmployeeData_EditingControlShowing);
            this.dgv_EmployeeData.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgv_EmployeeData_RowHeaderMouseClick);
            this.dgv_EmployeeData.RowHeaderMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgv_EmployeeData_RowHeaderMouseDoubleClick);
            this.dgv_EmployeeData.SelectionChanged += new System.EventHandler(this.dgv_EmployeeData_SelectionChanged);
            // 
            // SerialNo
            // 
            this.SerialNo.HeaderText = "S No.";
            this.SerialNo.MaxInputLength = 100000;
            this.SerialNo.Name = "SerialNo";
            this.SerialNo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.SerialNo.Width = 50;
            // 
            // Prefix
            // 
            this.Prefix.HeaderText = "Prefix";
            this.Prefix.Name = "Prefix";
            this.Prefix.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Prefix.Width = 80;
            // 
            // FirstName
            // 
            this.FirstName.HeaderText = "First Name";
            this.FirstName.Name = "FirstName";
            this.FirstName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.FirstName.Width = 150;
            // 
            // MiddleName
            // 
            this.MiddleName.HeaderText = "Middle Name";
            this.MiddleName.Name = "MiddleName";
            this.MiddleName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.MiddleName.Width = 150;
            // 
            // LastName
            // 
            this.LastName.HeaderText = "Last Name";
            this.LastName.Name = "LastName";
            this.LastName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.LastName.Width = 150;
            // 
            // Qualification
            // 
            this.Qualification.HeaderText = "Qualification";
            this.Qualification.Name = "Qualification";
            this.Qualification.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Qualification.Width = 250;
            // 
            // JoiningDate
            // 
            this.JoiningDate.HeaderText = "Joining Date";
            this.JoiningDate.Name = "JoiningDate";
            this.JoiningDate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.JoiningDate.Width = 130;
            // 
            // CurrentCompany
            // 
            this.CurrentCompany.HeaderText = "Current Company";
            this.CurrentCompany.Name = "CurrentCompany";
            this.CurrentCompany.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.CurrentCompany.Width = 150;
            // 
            // CurrentAddress
            // 
            this.CurrentAddress.HeaderText = "Current Address";
            this.CurrentAddress.Name = "CurrentAddress";
            this.CurrentAddress.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.CurrentAddress.Width = 250;
            // 
            // DOB
            // 
            this.DOB.HeaderText = "DOB";
            this.DOB.Name = "DOB";
            this.DOB.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.DOB.Width = 130;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menu_New,
            this.menu_Update,
            this.menu_Delete,
            this.menu_View,
            this.menu_aboutUs});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1541, 29);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menu_New
            // 
            this.menu_New.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.menu_New.Enabled = false;
            this.menu_New.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menu_New.Name = "menu_New";
            this.menu_New.Size = new System.Drawing.Size(60, 25);
            this.menu_New.Text = "NEW";
            this.menu_New.Click += new System.EventHandler(this.menu_New_Click);
            // 
            // menu_Update
            // 
            this.menu_Update.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.menu_Update.Enabled = false;
            this.menu_Update.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menu_Update.Name = "menu_Update";
            this.menu_Update.Size = new System.Drawing.Size(84, 25);
            this.menu_Update.Text = "UPDATE";
            this.menu_Update.Click += new System.EventHandler(this.menu_Update_Click);
            // 
            // menu_Delete
            // 
            this.menu_Delete.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.menu_Delete.Enabled = false;
            this.menu_Delete.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menu_Delete.Name = "menu_Delete";
            this.menu_Delete.Size = new System.Drawing.Size(78, 25);
            this.menu_Delete.Text = "DELETE";
            this.menu_Delete.Click += new System.EventHandler(this.menu_Delete_Click);
            // 
            // menu_View
            // 
            this.menu_View.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.menu_View.Enabled = false;
            this.menu_View.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menu_View.Name = "menu_View";
            this.menu_View.Size = new System.Drawing.Size(63, 25);
            this.menu_View.Text = "VIEW";
            this.menu_View.Click += new System.EventHandler(this.menu_View_Click);
            // 
            // menu_aboutUs
            // 
            this.menu_aboutUs.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.menu_aboutUs.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menu_aboutUs.Name = "menu_aboutUs";
            this.menu_aboutUs.Size = new System.Drawing.Size(101, 25);
            this.menu_aboutUs.Text = "ABOUT US";
            this.menu_aboutUs.Click += new System.EventHandler(this.menu_aboutUs_Click);
            // 
            // lbl_Status
            // 
            this.lbl_Status.AutoSize = true;
            this.lbl_Status.Font = new System.Drawing.Font("Nirmala UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Status.Location = new System.Drawing.Point(12, 62);
            this.lbl_Status.Name = "lbl_Status";
            this.lbl_Status.Size = new System.Drawing.Size(161, 25);
            this.lbl_Status.TabIndex = 5;
            this.lbl_Status.Text = "Total Records -> ";
            this.lbl_Status.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtBox_searchRecords
            // 
            this.txtBox_searchRecords.Location = new System.Drawing.Point(1173, 31);
            this.txtBox_searchRecords.Multiline = true;
            this.txtBox_searchRecords.Name = "txtBox_searchRecords";
            this.txtBox_searchRecords.Size = new System.Drawing.Size(262, 38);
            this.txtBox_searchRecords.TabIndex = 6;
            // 
            // btn_clearFilterAndSearch
            // 
            this.btn_clearFilterAndSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_clearFilterAndSearch.Location = new System.Drawing.Point(1071, 32);
            this.btn_clearFilterAndSearch.Name = "btn_clearFilterAndSearch";
            this.btn_clearFilterAndSearch.Size = new System.Drawing.Size(96, 37);
            this.btn_clearFilterAndSearch.TabIndex = 7;
            this.btn_clearFilterAndSearch.Text = "Clear Search/Filter";
            this.btn_clearFilterAndSearch.UseVisualStyleBackColor = true;
            this.btn_clearFilterAndSearch.Click += new System.EventHandler(this.btn_clearFilterAndSearch_Click);
            // 
            // lbl_role
            // 
            this.lbl_role.AutoSize = true;
            this.lbl_role.BackColor = System.Drawing.Color.MintCream;
            this.lbl_role.Font = new System.Drawing.Font("Nirmala UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_role.Location = new System.Drawing.Point(1153, 0);
            this.lbl_role.Name = "lbl_role";
            this.lbl_role.Size = new System.Drawing.Size(103, 30);
            this.lbl_role.TabIndex = 9;
            this.lbl_role.Text = "Welcome";
            // 
            // btn_search
            // 
            this.btn_search.BackgroundImage = global::FHP_Application.Properties.Resources.search;
            this.btn_search.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_search.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_search.Location = new System.Drawing.Point(1441, 31);
            this.btn_search.Name = "btn_search";
            this.btn_search.Size = new System.Drawing.Size(55, 36);
            this.btn_search.TabIndex = 8;
            this.btn_search.UseVisualStyleBackColor = true;
            this.btn_search.Click += new System.EventHandler(this.btn_search_Click);
            // 
            // Frm_MainView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1541, 803);
            this.Controls.Add(this.lbl_role);
            this.Controls.Add(this.btn_search);
            this.Controls.Add(this.btn_clearFilterAndSearch);
            this.Controls.Add(this.txtBox_searchRecords);
            this.Controls.Add(this.lbl_Status);
            this.Controls.Add(this.dgv_EmployeeData);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Frm_MainView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FHP";
            ((System.ComponentModel.ISupportInitialize)(this.dgv_EmployeeData)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridViewTextBoxColumn MiddleNameq;
        private System.Windows.Forms.DataGridView dgv_EmployeeData;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menu_New;
        private System.Windows.Forms.ToolStripMenuItem menu_Update;
        private System.Windows.Forms.ToolStripMenuItem menu_Delete;
        private System.Windows.Forms.ToolStripMenuItem menu_View;
        private System.Windows.Forms.Label lbl_Status;
        private System.Windows.Forms.TextBox txtBox_searchRecords;
        private System.Windows.Forms.Button btn_clearFilterAndSearch;
        private System.Windows.Forms.Button btn_search;
        private System.Windows.Forms.DataGridViewTextBoxColumn SerialNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Prefix;
        private System.Windows.Forms.DataGridViewTextBoxColumn FirstName;
        private System.Windows.Forms.DataGridViewTextBoxColumn MiddleName;
        private System.Windows.Forms.DataGridViewTextBoxColumn LastName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Qualification;
        private System.Windows.Forms.DataGridViewTextBoxColumn JoiningDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn CurrentCompany;
        private System.Windows.Forms.DataGridViewTextBoxColumn CurrentAddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn DOB;
        private System.Windows.Forms.Label lbl_role;
        private System.Windows.Forms.ToolStripMenuItem menu_aboutUs;
    }
}

