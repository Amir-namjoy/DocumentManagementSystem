namespace MaliArchive
{
    partial class frm_amanatgirandegan
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_amanatgirandegan));
            this.btnCancel = new System.Windows.Forms.Button();
            this.dgv1 = new System.Windows.Forms.DataGridView();
            this.person_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.personalid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.semat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tozihat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mahalkar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mobile = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gender = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.كاربرجديدToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.مشخصاتToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.جستجوToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.بازآوريToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dgv1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancel.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnCancel.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnCancel.ForeColor = System.Drawing.Color.Black;
            this.btnCancel.Location = new System.Drawing.Point(12, 444);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(87, 32);
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Text = "بستن";
            this.btnCancel.UseVisualStyleBackColor = false;
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
            this.dgv1.BackgroundColor = System.Drawing.Color.White;
            this.dgv1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgv1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.person_id,
            this.name,
            this.personalid,
            this.semat,
            this.tozihat,
            this.mahalkar,
            this.tel,
            this.mobile,
            this.gender});
            this.dgv1.Location = new System.Drawing.Point(12, 27);
            this.dgv1.MultiSelect = false;
            this.dgv1.Name = "dgv1";
            this.dgv1.RowHeadersVisible = false;
            this.dgv1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv1.Size = new System.Drawing.Size(526, 411);
            this.dgv1.TabIndex = 9;
            this.dgv1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv1_CellDoubleClick);
            // 
            // person_id
            // 
            this.person_id.HeaderText = "uid";
            this.person_id.Name = "person_id";
            this.person_id.ReadOnly = true;
            this.person_id.Visible = false;
            // 
            // name
            // 
            this.name.FillWeight = 200F;
            this.name.HeaderText = "نام";
            this.name.Name = "name";
            this.name.ReadOnly = true;
            this.name.Width = 150;
            // 
            // personalid
            // 
            this.personalid.HeaderText = "شماره پرسنلي";
            this.personalid.Name = "personalid";
            this.personalid.ReadOnly = true;
            // 
            // semat
            // 
            this.semat.FillWeight = 200F;
            this.semat.HeaderText = "سمت";
            this.semat.Name = "semat";
            this.semat.ReadOnly = true;
            this.semat.Width = 130;
            // 
            // tozihat
            // 
            this.tozihat.FillWeight = 200F;
            this.tozihat.HeaderText = "توضيحات";
            this.tozihat.Name = "tozihat";
            this.tozihat.ReadOnly = true;
            this.tozihat.Width = 140;
            // 
            // mahalkar
            // 
            this.mahalkar.HeaderText = "mahalkar";
            this.mahalkar.Name = "mahalkar";
            this.mahalkar.ReadOnly = true;
            this.mahalkar.Visible = false;
            // 
            // tel
            // 
            this.tel.HeaderText = "tel";
            this.tel.Name = "tel";
            this.tel.ReadOnly = true;
            this.tel.Visible = false;
            // 
            // mobile
            // 
            this.mobile.HeaderText = "mobile";
            this.mobile.Name = "mobile";
            this.mobile.ReadOnly = true;
            this.mobile.Visible = false;
            // 
            // gender
            // 
            this.gender.HeaderText = "gender";
            this.gender.Name = "gender";
            this.gender.ReadOnly = true;
            this.gender.Visible = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.كاربرجديدToolStripMenuItem,
            this.مشخصاتToolStripMenuItem,
            this.جستجوToolStripMenuItem,
            this.بازآوريToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(550, 24);
            this.menuStrip1.TabIndex = 10;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // كاربرجديدToolStripMenuItem
            // 
            this.كاربرجديدToolStripMenuItem.Image = global::MaliArchive.Properties.Resources.list_add_user;
            this.كاربرجديدToolStripMenuItem.Name = "كاربرجديدToolStripMenuItem";
            this.كاربرجديدToolStripMenuItem.Size = new System.Drawing.Size(134, 20);
            this.كاربرجديدToolStripMenuItem.Text = "افزودن شخص جديد";
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
            // frm_amanatgirandegan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(550, 488);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.dgv1);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_amanatgirandegan";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "امانت گيرندگان پرونده";
            this.Load += new System.EventHandler(this.frm_amanatgirandegan_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.DataGridView dgv1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem كاربرجديدToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem مشخصاتToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem جستجوToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem بازآوريToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn person_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn personalid;
        private System.Windows.Forms.DataGridViewTextBoxColumn semat;
        private System.Windows.Forms.DataGridViewTextBoxColumn tozihat;
        private System.Windows.Forms.DataGridViewTextBoxColumn mahalkar;
        private System.Windows.Forms.DataGridViewTextBoxColumn tel;
        private System.Windows.Forms.DataGridViewTextBoxColumn mobile;
        private System.Windows.Forms.DataGridViewTextBoxColumn gender;
    }
}