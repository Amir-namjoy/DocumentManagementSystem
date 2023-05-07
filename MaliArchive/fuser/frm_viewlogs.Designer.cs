namespace MaliArchive
{
    partial class frm_viewlogs
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_viewlogs));
            this.btnCancel = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.faenddate = new FarsiLibrary.Win.Controls.FADatePicker();
            this.fastartdate = new FarsiLibrary.Win.Controls.FADatePicker();
            this.combroydad = new System.Windows.Forms.ComboBox();
            this.lblfamily = new System.Windows.Forms.Label();
            this.lblname = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.comblogs = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnshowlog = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvlogs = new System.Windows.Forms.DataGridView();
            this.RowIndex = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.logdate = new FarsiLibrary.Win.Controls.DataGridViewFADateTimePickerColumn();
            this.username = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.roydad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tozihat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvlogs)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancel.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnCancel.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnCancel.ForeColor = System.Drawing.Color.Black;
            this.btnCancel.Location = new System.Drawing.Point(14, 568);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(87, 32);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "بستن";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.faenddate);
            this.groupBox1.Controls.Add(this.fastartdate);
            this.groupBox1.Controls.Add(this.combroydad);
            this.groupBox1.Controls.Add(this.lblfamily);
            this.groupBox1.Controls.Add(this.lblname);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.comblogs);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.btnshowlog);
            this.groupBox1.Location = new System.Drawing.Point(14, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(811, 123);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            // 
            // faenddate
            // 
            this.faenddate.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.faenddate.Location = new System.Drawing.Point(135, 84);
            this.faenddate.Name = "faenddate";
            this.faenddate.ScrollOption = FarsiLibrary.Win.Enums.ScrollOptionTypes.Day;
            this.faenddate.Size = new System.Drawing.Size(189, 20);
            this.faenddate.TabIndex = 177;
            this.faenddate.Theme = FarsiLibrary.Win.Enums.ThemeTypes.Office2003;
            // 
            // fastartdate
            // 
            this.fastartdate.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fastartdate.Location = new System.Drawing.Point(135, 57);
            this.fastartdate.Name = "fastartdate";
            this.fastartdate.ScrollOption = FarsiLibrary.Win.Enums.ScrollOptionTypes.Day;
            this.fastartdate.Size = new System.Drawing.Size(189, 20);
            this.fastartdate.TabIndex = 176;
            this.fastartdate.Theme = FarsiLibrary.Win.Enums.ThemeTypes.Office2003;
            // 
            // combroydad
            // 
            this.combroydad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combroydad.FormattingEnabled = true;
            this.combroydad.Items.AddRange(new object[] {
            "همه",
            " ورود كاربر به سيستم",
            " ورود رمز اشتباه ",
            " افزودن كاربر جديد",
            " ويرايش اطلاعات و دسترسي هاي كاربر",
            " تغيير رمز عبور كاربر",
            " تغيير رمز عبور كاربر جاري",
            "  تغيير رمز عبور كاربر جاري - ورود رمز اشتباه ",
            " تهيه گزارش",
            " افزودن پرونده جديد",
            " ويرايش پرونده",
            " خروج كاربر از سيستم",
            " مشاهده پرونده",
            " مشاهده پرونده از طريق ويرايش",
            "  افزودن شخص جديد",
            " تغيير مشخصات شخص",
            " گزارش رويدادنگاري",
            " عدم اجازه ورود به سيستم",
            "ثبت امانت",
            "تحويل امانت"});
            this.combroydad.Location = new System.Drawing.Point(41, 25);
            this.combroydad.Name = "combroydad";
            this.combroydad.Size = new System.Drawing.Size(283, 22);
            this.combroydad.TabIndex = 19;
            // 
            // lblfamily
            // 
            this.lblfamily.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblfamily.Location = new System.Drawing.Point(475, 84);
            this.lblfamily.Name = "lblfamily";
            this.lblfamily.Size = new System.Drawing.Size(238, 14);
            this.lblfamily.TabIndex = 18;
            this.lblfamily.Text = "----";
            // 
            // lblname
            // 
            this.lblname.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblname.Location = new System.Drawing.Point(475, 57);
            this.lblname.Name = "lblname";
            this.lblname.Size = new System.Drawing.Size(238, 14);
            this.lblname.TabIndex = 17;
            this.lblname.Text = "----";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(720, 57);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(25, 14);
            this.label5.TabIndex = 15;
            this.label5.Text = "نام:";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(720, 84);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 14);
            this.label4.TabIndex = 14;
            this.label4.Text = "نام خانوادگي:";
            // 
            // comblogs
            // 
            this.comblogs.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.comblogs.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comblogs.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comblogs.FormattingEnabled = true;
            this.comblogs.Location = new System.Drawing.Point(475, 25);
            this.comblogs.MaxLength = 50;
            this.comblogs.Name = "comblogs";
            this.comblogs.Size = new System.Drawing.Size(237, 22);
            this.comblogs.TabIndex = 11;
            this.comblogs.SelectedValueChanged += new System.EventHandler(this.comblogs_SelectedValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(331, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 14);
            this.label3.TabIndex = 13;
            this.label3.Text = "بازه زماني:";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(720, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 14);
            this.label1.TabIndex = 11;
            this.label1.Text = "نام كاربري:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(345, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 14);
            this.label2.TabIndex = 12;
            this.label2.Text = "عمليات:";
            // 
            // btnshowlog
            // 
            this.btnshowlog.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnshowlog.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnshowlog.ForeColor = System.Drawing.Color.Black;
            this.btnshowlog.Location = new System.Drawing.Point(7, 84);
            this.btnshowlog.Name = "btnshowlog";
            this.btnshowlog.Size = new System.Drawing.Size(87, 32);
            this.btnshowlog.TabIndex = 10;
            this.btnshowlog.Text = "مشاهده";
            this.btnshowlog.UseVisualStyleBackColor = false;
            this.btnshowlog.Click += new System.EventHandler(this.btnshowlog_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.dgvlogs);
            this.groupBox2.Location = new System.Drawing.Point(14, 142);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(811, 418);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "رويدادنگاري";
            // 
            // dgvlogs
            // 
            this.dgvlogs.AllowUserToAddRows = false;
            this.dgvlogs.AllowUserToDeleteRows = false;
            this.dgvlogs.BackgroundColor = System.Drawing.Color.White;
            this.dgvlogs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvlogs.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.RowIndex,
            this.logdate,
            this.username,
            this.roydad,
            this.tozihat});
            this.dgvlogs.Location = new System.Drawing.Point(7, 20);
            this.dgvlogs.Name = "dgvlogs";
            this.dgvlogs.ReadOnly = true;
            this.dgvlogs.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvlogs.Size = new System.Drawing.Size(798, 391);
            this.dgvlogs.TabIndex = 0;
            this.dgvlogs.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvlogs_CellDoubleClick);
            // 
            // RowIndex
            // 
            this.RowIndex.HeaderText = "رديف";
            this.RowIndex.Name = "RowIndex";
            this.RowIndex.ReadOnly = true;
            this.RowIndex.Width = 40;
            // 
            // logdate
            // 
            this.logdate.FillWeight = 250F;
            this.logdate.HeaderText = "تاريخ";
            this.logdate.HorizontalAlignment = System.Drawing.StringAlignment.Near;
            this.logdate.Name = "logdate";
            this.logdate.ReadOnly = true;
            this.logdate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.logdate.SelectedDateTime = new System.DateTime(((long)(0)));
            this.logdate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.logdate.Theme = FarsiLibrary.Win.Enums.ThemeTypes.Office2000;
            this.logdate.VerticalAlignment = System.Drawing.StringAlignment.Near;
            this.logdate.Width = 120;
            // 
            // username
            // 
            this.username.HeaderText = "نام كاربر";
            this.username.Name = "username";
            this.username.ReadOnly = true;
            // 
            // roydad
            // 
            this.roydad.FillWeight = 250F;
            this.roydad.HeaderText = "رويداد";
            this.roydad.Name = "roydad";
            this.roydad.ReadOnly = true;
            this.roydad.Width = 150;
            // 
            // tozihat
            // 
            this.tozihat.FillWeight = 600F;
            this.tozihat.HeaderText = "شرح";
            this.tozihat.Name = "tozihat";
            this.tozihat.ReadOnly = true;
            this.tozihat.Width = 400;
            // 
            // frm_viewlogs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(839, 612);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnCancel);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frm_viewlogs";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "گزارش رويدادنگاري";
            this.Load += new System.EventHandler(this.frm_viewlogs_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvlogs)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgvlogs;
        private System.Windows.Forms.Label lblfamily;
        private System.Windows.Forms.Label lblname;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comblogs;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnshowlog;
        private System.Windows.Forms.ComboBox combroydad;
        private FarsiLibrary.Win.Controls.FADatePicker faenddate;
        private FarsiLibrary.Win.Controls.FADatePicker fastartdate;
        private System.Windows.Forms.DataGridViewTextBoxColumn RowIndex;
        private FarsiLibrary.Win.Controls.DataGridViewFADateTimePickerColumn logdate;
        private System.Windows.Forms.DataGridViewTextBoxColumn username;
        private System.Windows.Forms.DataGridViewTextBoxColumn roydad;
        private System.Windows.Forms.DataGridViewTextBoxColumn tozihat;
    }
}