namespace MaliArchive
{
    partial class frm_usersmanagement
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_usersmanagement));
            this.dgv1 = new System.Windows.Forms.DataGridView();
            this.uid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.username = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.family = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.personalid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.semat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gender = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.addnew = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.showdoc = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.editdoc = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.gozaresh = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.manageUsers = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.addUser = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.editUser = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.manageAshkas = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.viewlog = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.allowLogin = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.كاربرجديدToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.مشخصاتToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.تغييررمزعبورToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.جستجوToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.بازآوريToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgv1
            // 
            this.dgv1.AllowUserToAddRows = false;
            this.dgv1.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Lavender;
            this.dgv1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv1.BackgroundColor = System.Drawing.Color.LightSteelBlue;
            this.dgv1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgv1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.uid,
            this.username,
            this.name,
            this.family,
            this.personalid,
            this.semat,
            this.gender,
            this.addnew,
            this.showdoc,
            this.editdoc,
            this.gozaresh,
            this.manageUsers,
            this.addUser,
            this.editUser,
            this.manageAshkas,
            this.viewlog,
            this.allowLogin});
            this.dgv1.Location = new System.Drawing.Point(12, 29);
            this.dgv1.MultiSelect = false;
            this.dgv1.Name = "dgv1";
            this.dgv1.RowHeadersVisible = false;
            this.dgv1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv1.Size = new System.Drawing.Size(872, 371);
            this.dgv1.TabIndex = 2;
            this.dgv1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv1_CellDoubleClick);
            // 
            // uid
            // 
            this.uid.HeaderText = "uid";
            this.uid.Name = "uid";
            this.uid.ReadOnly = true;
            this.uid.Visible = false;
            // 
            // username
            // 
            this.username.HeaderText = "نام كاربري";
            this.username.Name = "username";
            this.username.ReadOnly = true;
            // 
            // name
            // 
            this.name.HeaderText = "نام";
            this.name.Name = "name";
            this.name.ReadOnly = true;
            // 
            // family
            // 
            this.family.HeaderText = "نام خانوادگي";
            this.family.Name = "family";
            this.family.ReadOnly = true;
            // 
            // personalid
            // 
            this.personalid.HeaderText = "شماره پرسنلي";
            this.personalid.Name = "personalid";
            this.personalid.ReadOnly = true;
            // 
            // semat
            // 
            this.semat.HeaderText = "سمت";
            this.semat.Name = "semat";
            this.semat.ReadOnly = true;
            // 
            // gender
            // 
            this.gender.HeaderText = "جنسيت";
            this.gender.Name = "gender";
            this.gender.ReadOnly = true;
            // 
            // addnew
            // 
            this.addnew.HeaderText = "ثبت پرونده";
            this.addnew.Name = "addnew";
            this.addnew.ReadOnly = true;
            this.addnew.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.addnew.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // showdoc
            // 
            this.showdoc.HeaderText = "نمايش پرونده";
            this.showdoc.Name = "showdoc";
            this.showdoc.ReadOnly = true;
            this.showdoc.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.showdoc.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // editdoc
            // 
            this.editdoc.HeaderText = "ويرايش پرونده";
            this.editdoc.Name = "editdoc";
            this.editdoc.ReadOnly = true;
            this.editdoc.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.editdoc.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // gozaresh
            // 
            this.gozaresh.HeaderText = "گزارشگيري";
            this.gozaresh.Name = "gozaresh";
            this.gozaresh.ReadOnly = true;
            this.gozaresh.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.gozaresh.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // manageUsers
            // 
            this.manageUsers.HeaderText = "مديريت كاربران";
            this.manageUsers.Name = "manageUsers";
            this.manageUsers.ReadOnly = true;
            // 
            // addUser
            // 
            this.addUser.HeaderText = "افزودن كاربر";
            this.addUser.Name = "addUser";
            this.addUser.ReadOnly = true;
            this.addUser.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.addUser.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // editUser
            // 
            this.editUser.HeaderText = "ويرايش كاربر";
            this.editUser.Name = "editUser";
            this.editUser.ReadOnly = true;
            this.editUser.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.editUser.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // manageAshkas
            // 
            this.manageAshkas.HeaderText = "مديريت اشخاص";
            this.manageAshkas.Name = "manageAshkas";
            this.manageAshkas.ReadOnly = true;
            // 
            // viewlog
            // 
            this.viewlog.HeaderText = "مشاهده رويدادنگاري";
            this.viewlog.Name = "viewlog";
            this.viewlog.ReadOnly = true;
            this.viewlog.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.viewlog.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // allowLogin
            // 
            this.allowLogin.HeaderText = "اجازه ورود به سيستم";
            this.allowLogin.Name = "allowLogin";
            this.allowLogin.ReadOnly = true;
            this.allowLogin.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.allowLogin.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.كاربرجديدToolStripMenuItem,
            this.مشخصاتToolStripMenuItem,
            this.تغييررمزعبورToolStripMenuItem,
            this.جستجوToolStripMenuItem,
            this.بازآوريToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(896, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // كاربرجديدToolStripMenuItem
            // 
            this.كاربرجديدToolStripMenuItem.Image = global::MaliArchive.Properties.Resources.list_add_user;
            this.كاربرجديدToolStripMenuItem.Name = "كاربرجديدToolStripMenuItem";
            this.كاربرجديدToolStripMenuItem.Size = new System.Drawing.Size(86, 20);
            this.كاربرجديدToolStripMenuItem.Text = "كاربر جديد";
            this.كاربرجديدToolStripMenuItem.Click += new System.EventHandler(this.كاربرجديدToolStripMenuItem_Click);
            // 
            // مشخصاتToolStripMenuItem
            // 
            this.مشخصاتToolStripMenuItem.Image = global::MaliArchive.Properties.Resources.properties;
            this.مشخصاتToolStripMenuItem.Name = "مشخصاتToolStripMenuItem";
            this.مشخصاتToolStripMenuItem.Size = new System.Drawing.Size(85, 20);
            this.مشخصاتToolStripMenuItem.Text = "مشخصات";
            this.مشخصاتToolStripMenuItem.Click += new System.EventHandler(this.مشخصاتToolStripMenuItem_Click);
            // 
            // تغييررمزعبورToolStripMenuItem
            // 
            this.تغييررمزعبورToolStripMenuItem.Image = global::MaliArchive.Properties.Resources.keys;
            this.تغييررمزعبورToolStripMenuItem.Name = "تغييررمزعبورToolStripMenuItem";
            this.تغييررمزعبورToolStripMenuItem.Size = new System.Drawing.Size(100, 20);
            this.تغييررمزعبورToolStripMenuItem.Text = "تغيير رمز عبور";
            this.تغييررمزعبورToolStripMenuItem.Click += new System.EventHandler(this.تغييررمزعبورToolStripMenuItem_Click);
            // 
            // جستجوToolStripMenuItem
            // 
            this.جستجوToolStripMenuItem.Image = global::MaliArchive.Properties.Resources.find;
            this.جستجوToolStripMenuItem.Name = "جستجوToolStripMenuItem";
            this.جستجوToolStripMenuItem.Size = new System.Drawing.Size(73, 20);
            this.جستجوToolStripMenuItem.Text = "جستجو";
            // 
            // بازآوريToolStripMenuItem
            // 
            this.بازآوريToolStripMenuItem.Image = global::MaliArchive.Properties.Resources.refresh;
            this.بازآوريToolStripMenuItem.Name = "بازآوريToolStripMenuItem";
            this.بازآوريToolStripMenuItem.Size = new System.Drawing.Size(68, 20);
            this.بازآوريToolStripMenuItem.Text = "بازآوري";
            this.بازآوريToolStripMenuItem.Click += new System.EventHandler(this.بازآوريToolStripMenuItem_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancel.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnCancel.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnCancel.Location = new System.Drawing.Point(12, 409);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(87, 32);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "بستن";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // frm_usersmanagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(896, 450);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.dgv1);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "frm_usersmanagement";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "مديريت كاربران";
            this.Load += new System.EventHandler(this.frm_usersmanagement_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem كاربرجديدToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem مشخصاتToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem تغييررمزعبورToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem جستجوToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem بازآوريToolStripMenuItem;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.DataGridViewTextBoxColumn uid;
        private System.Windows.Forms.DataGridViewTextBoxColumn username;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn family;
        private System.Windows.Forms.DataGridViewTextBoxColumn personalid;
        private System.Windows.Forms.DataGridViewTextBoxColumn semat;
        private System.Windows.Forms.DataGridViewTextBoxColumn gender;
        private System.Windows.Forms.DataGridViewCheckBoxColumn addnew;
        private System.Windows.Forms.DataGridViewCheckBoxColumn showdoc;
        private System.Windows.Forms.DataGridViewCheckBoxColumn editdoc;
        private System.Windows.Forms.DataGridViewCheckBoxColumn gozaresh;
        private System.Windows.Forms.DataGridViewCheckBoxColumn manageUsers;
        private System.Windows.Forms.DataGridViewCheckBoxColumn addUser;
        private System.Windows.Forms.DataGridViewCheckBoxColumn editUser;
        private System.Windows.Forms.DataGridViewCheckBoxColumn manageAshkas;
        private System.Windows.Forms.DataGridViewCheckBoxColumn viewlog;
        private System.Windows.Forms.DataGridViewCheckBoxColumn allowLogin;
    }
}