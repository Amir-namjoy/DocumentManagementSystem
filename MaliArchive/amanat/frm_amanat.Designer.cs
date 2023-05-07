namespace MaliArchive
{
    partial class frm_amanat
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_amanat));
            this.btn_closefrm = new System.Windows.Forms.Button();
            this.btnamanat = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvpi = new System.Windows.Forms.DataGridView();
            this.RowNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tarikTashkil = new FarsiLibrary.Win.Controls.DataGridViewFADateTimePickerColumn();
            this.personalid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.daftarkol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.family = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.passid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nationalcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.father = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.eshteghal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tedadbarg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.estekdam = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tozihat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.raked = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.amanat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.amanat_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fdate_amanat_to = new FarsiLibrary.Win.Controls.FADatePicker();
            this.fdate_amanat_from = new FarsiLibrary.Win.Controls.FADatePicker();
            this.txtb_tozihat = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lbltel = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lblmahalkar = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblsemat = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.comblpersons = new System.Windows.Forms.ComboBox();
            this.lblname = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvpi)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_closefrm
            // 
            this.btn_closefrm.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btn_closefrm.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_closefrm.ForeColor = System.Drawing.Color.Black;
            this.btn_closefrm.Location = new System.Drawing.Point(15, 473);
            this.btn_closefrm.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btn_closefrm.Name = "btn_closefrm";
            this.btn_closefrm.Size = new System.Drawing.Size(99, 33);
            this.btn_closefrm.TabIndex = 167;
            this.btn_closefrm.Text = "خروج";
            this.btn_closefrm.UseVisualStyleBackColor = false;
            this.btn_closefrm.Click += new System.EventHandler(this.btn_closefrm_Click);
            // 
            // btnamanat
            // 
            this.btnamanat.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnamanat.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnamanat.ForeColor = System.Drawing.Color.Black;
            this.btnamanat.Location = new System.Drawing.Point(124, 473);
            this.btnamanat.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnamanat.Name = "btnamanat";
            this.btnamanat.Size = new System.Drawing.Size(99, 33);
            this.btnamanat.TabIndex = 168;
            this.btnamanat.Text = "تاييد";
            this.btnamanat.UseVisualStyleBackColor = false;
            this.btnamanat.Click += new System.EventHandler(this.btnamanat_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvpi);
            this.groupBox1.Controls.Add(this.fdate_amanat_to);
            this.groupBox1.Controls.Add(this.fdate_amanat_from);
            this.groupBox1.Controls.Add(this.txtb_tozihat);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(14, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(700, 315);
            this.groupBox1.TabIndex = 170;
            this.groupBox1.TabStop = false;
            // 
            // dgvpi
            // 
            this.dgvpi.AllowUserToAddRows = false;
            this.dgvpi.AllowUserToDeleteRows = false;
            this.dgvpi.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvpi.BackgroundColor = System.Drawing.Color.White;
            this.dgvpi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvpi.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.RowNumber,
            this.id,
            this.tarikTashkil,
            this.personalid,
            this.daftarkol,
            this.name,
            this.family,
            this.passid,
            this.nationalcode,
            this.father,
            this.eshteghal,
            this.tedadbarg,
            this.estekdam,
            this.tozihat,
            this.raked,
            this.amanat,
            this.amanat_id});
            this.dgvpi.Location = new System.Drawing.Point(6, 21);
            this.dgvpi.Name = "dgvpi";
            this.dgvpi.ReadOnly = true;
            this.dgvpi.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvpi.Size = new System.Drawing.Size(688, 115);
            this.dgvpi.TabIndex = 185;
            // 
            // RowNumber
            // 
            this.RowNumber.HeaderText = "شماره سطر";
            this.RowNumber.Name = "RowNumber";
            this.RowNumber.ReadOnly = true;
            this.RowNumber.ToolTipText = "شماره سطر";
            this.RowNumber.Visible = false;
            this.RowNumber.Width = 50;
            // 
            // id
            // 
            this.id.HeaderText = "شماره پرونده";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.ToolTipText = "شماره پرونده";
            this.id.Width = 70;
            // 
            // tarikTashkil
            // 
            this.tarikTashkil.HeaderText = "تاريخ تشكيل پرونده";
            this.tarikTashkil.HorizontalAlignment = System.Drawing.StringAlignment.Near;
            this.tarikTashkil.Name = "tarikTashkil";
            this.tarikTashkil.ReadOnly = true;
            this.tarikTashkil.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.tarikTashkil.SelectedDateTime = new System.DateTime(((long)(0)));
            this.tarikTashkil.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.tarikTashkil.Theme = FarsiLibrary.Win.Enums.ThemeTypes.Office2000;
            this.tarikTashkil.ToolTipText = "تاريخ تشكيل پرونده";
            this.tarikTashkil.VerticalAlignment = System.Drawing.StringAlignment.Near;
            // 
            // personalid
            // 
            this.personalid.HeaderText = "شماره پرسنلي";
            this.personalid.Name = "personalid";
            this.personalid.ReadOnly = true;
            this.personalid.ToolTipText = "شماره پرسنلي";
            // 
            // daftarkol
            // 
            this.daftarkol.HeaderText = "شماره دفتر كل";
            this.daftarkol.Name = "daftarkol";
            this.daftarkol.ReadOnly = true;
            this.daftarkol.ToolTipText = "شماره دفتر كل";
            // 
            // name
            // 
            this.name.HeaderText = "نام";
            this.name.Name = "name";
            this.name.ReadOnly = true;
            this.name.ToolTipText = "نام";
            // 
            // family
            // 
            this.family.HeaderText = "نام خانوادگي";
            this.family.Name = "family";
            this.family.ReadOnly = true;
            this.family.ToolTipText = "نام خانوادگي";
            // 
            // passid
            // 
            this.passid.HeaderText = "شماره شناسنامه";
            this.passid.Name = "passid";
            this.passid.ReadOnly = true;
            this.passid.ToolTipText = "شماره شناسنامه";
            // 
            // nationalcode
            // 
            this.nationalcode.HeaderText = "كد ملي";
            this.nationalcode.Name = "nationalcode";
            this.nationalcode.ReadOnly = true;
            this.nationalcode.ToolTipText = "كد ملي";
            // 
            // father
            // 
            this.father.HeaderText = "نام پدر";
            this.father.Name = "father";
            this.father.ReadOnly = true;
            this.father.ToolTipText = "نام پدر";
            // 
            // eshteghal
            // 
            this.eshteghal.HeaderText = "وضعيت اشتغال";
            this.eshteghal.Name = "eshteghal";
            this.eshteghal.ReadOnly = true;
            this.eshteghal.ToolTipText = "وضعيت اشتغال";
            // 
            // tedadbarg
            // 
            this.tedadbarg.HeaderText = "تعداد برگ";
            this.tedadbarg.Name = "tedadbarg";
            this.tedadbarg.ReadOnly = true;
            this.tedadbarg.ToolTipText = "تعداد برگ";
            // 
            // estekdam
            // 
            this.estekdam.HeaderText = "استخدام";
            this.estekdam.Name = "estekdam";
            this.estekdam.ReadOnly = true;
            this.estekdam.ToolTipText = "استخدام";
            // 
            // tozihat
            // 
            this.tozihat.HeaderText = "توضيحات";
            this.tozihat.Name = "tozihat";
            this.tozihat.ReadOnly = true;
            this.tozihat.ToolTipText = "توضيحات";
            // 
            // raked
            // 
            this.raked.HeaderText = "raked";
            this.raked.Name = "raked";
            this.raked.ReadOnly = true;
            this.raked.Visible = false;
            // 
            // amanat
            // 
            this.amanat.HeaderText = "amanat";
            this.amanat.Name = "amanat";
            this.amanat.ReadOnly = true;
            this.amanat.Visible = false;
            // 
            // amanat_id
            // 
            this.amanat_id.HeaderText = "amanat_id";
            this.amanat_id.Name = "amanat_id";
            this.amanat_id.ReadOnly = true;
            this.amanat_id.Visible = false;
            // 
            // fdate_amanat_to
            // 
            this.fdate_amanat_to.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fdate_amanat_to.FormatInfo = FarsiLibrary.Win.Enums.FormatInfoTypes.DateShortTime;
            this.fdate_amanat_to.Location = new System.Drawing.Point(113, 179);
            this.fdate_amanat_to.Name = "fdate_amanat_to";
            this.fdate_amanat_to.ScrollOption = FarsiLibrary.Win.Enums.ScrollOptionTypes.Day;
            this.fdate_amanat_to.Size = new System.Drawing.Size(189, 20);
            this.fdate_amanat_to.TabIndex = 181;
            this.fdate_amanat_to.Theme = FarsiLibrary.Win.Enums.ThemeTypes.Office2003;
            // 
            // fdate_amanat_from
            // 
            this.fdate_amanat_from.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fdate_amanat_from.FormatInfo = FarsiLibrary.Win.Enums.FormatInfoTypes.DateShortTime;
            this.fdate_amanat_from.Location = new System.Drawing.Point(383, 179);
            this.fdate_amanat_from.Name = "fdate_amanat_from";
            this.fdate_amanat_from.ScrollOption = FarsiLibrary.Win.Enums.ScrollOptionTypes.Day;
            this.fdate_amanat_from.Size = new System.Drawing.Size(189, 20);
            this.fdate_amanat_from.TabIndex = 180;
            this.fdate_amanat_from.Theme = FarsiLibrary.Win.Enums.ThemeTypes.Office2003;
            // 
            // txtb_tozihat
            // 
            this.txtb_tozihat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtb_tozihat.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtb_tozihat.Location = new System.Drawing.Point(8, 220);
            this.txtb_tozihat.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtb_tozihat.Multiline = true;
            this.txtb_tozihat.Name = "txtb_tozihat";
            this.txtb_tozihat.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtb_tozihat.Size = new System.Drawing.Size(612, 80);
            this.txtb_tozihat.TabIndex = 177;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(628, 223);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 41);
            this.label3.TabIndex = 176;
            this.label3.Text = "توضيحات امانت";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(307, 179);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 14);
            this.label2.TabIndex = 175;
            this.label2.Text = "تا تاريخ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(575, 179);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 14);
            this.label1.TabIndex = 171;
            this.label1.Text = "مهلت امانت از تاريخ";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lbltel);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.lblmahalkar);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.lblsemat);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.comblpersons);
            this.groupBox2.Controls.Add(this.lblname);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Location = new System.Drawing.Point(14, 334);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(700, 132);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "اطلاعات شخص امانت گيرنده";
            // 
            // lbltel
            // 
            this.lbltel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbltel.Location = new System.Drawing.Point(13, 105);
            this.lbltel.Name = "lbltel";
            this.lbltel.Size = new System.Drawing.Size(238, 14);
            this.lbltel.TabIndex = 32;
            this.lbltel.Text = "----";
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(257, 105);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(29, 14);
            this.label10.TabIndex = 31;
            this.label10.Text = "تلفن";
            // 
            // lblmahalkar
            // 
            this.lblmahalkar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblmahalkar.Location = new System.Drawing.Point(13, 77);
            this.lblmahalkar.Name = "lblmahalkar";
            this.lblmahalkar.Size = new System.Drawing.Size(238, 14);
            this.lblmahalkar.TabIndex = 30;
            this.lblmahalkar.Text = "----";
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(257, 77);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(48, 14);
            this.label7.TabIndex = 29;
            this.label7.Text = "محل كار";
            // 
            // lblsemat
            // 
            this.lblsemat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblsemat.Location = new System.Drawing.Point(13, 49);
            this.lblsemat.Name = "lblsemat";
            this.lblsemat.Size = new System.Drawing.Size(238, 14);
            this.lblsemat.TabIndex = 28;
            this.lblsemat.Text = "----";
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(257, 49);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(37, 14);
            this.label9.TabIndex = 27;
            this.label9.Text = "سمت";
            // 
            // comblpersons
            // 
            this.comblpersons.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.comblpersons.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comblpersons.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comblpersons.FormattingEnabled = true;
            this.comblpersons.Location = new System.Drawing.Point(335, 46);
            this.comblpersons.MaxLength = 50;
            this.comblpersons.Name = "comblpersons";
            this.comblpersons.Size = new System.Drawing.Size(237, 22);
            this.comblpersons.TabIndex = 24;
            this.comblpersons.SelectedValueChanged += new System.EventHandler(this.comblpersons_SelectedValueChanged);
            // 
            // lblname
            // 
            this.lblname.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblname.Location = new System.Drawing.Point(13, 21);
            this.lblname.Name = "lblname";
            this.lblname.Size = new System.Drawing.Size(238, 14);
            this.lblname.TabIndex = 23;
            this.lblname.Text = "----";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(257, 21);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(21, 14);
            this.label5.TabIndex = 22;
            this.label5.Text = "نام";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(579, 49);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(99, 14);
            this.label6.TabIndex = 20;
            this.label6.Text = "نام خانوادگي و نام";
            // 
            // frm_amanat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(727, 513);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnamanat);
            this.Controls.Add(this.btn_closefrm);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_amanat";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ثبت امانت پرونده شماره  :  ";
            this.Load += new System.EventHandler(this.frm_amanat_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvpi)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_closefrm;
        private System.Windows.Forms.Button btnamanat;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtb_tozihat;
        private System.Windows.Forms.Label lblname;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comblpersons;
        private System.Windows.Forms.Label lblsemat;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lbltel;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lblmahalkar;
        private System.Windows.Forms.Label label7;
        private FarsiLibrary.Win.Controls.FADatePicker fdate_amanat_to;
        private FarsiLibrary.Win.Controls.FADatePicker fdate_amanat_from;
        private System.Windows.Forms.DataGridView dgvpi;
        private System.Windows.Forms.DataGridViewTextBoxColumn RowNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private FarsiLibrary.Win.Controls.DataGridViewFADateTimePickerColumn tarikTashkil;
        private System.Windows.Forms.DataGridViewTextBoxColumn personalid;
        private System.Windows.Forms.DataGridViewTextBoxColumn daftarkol;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn family;
        private System.Windows.Forms.DataGridViewTextBoxColumn passid;
        private System.Windows.Forms.DataGridViewTextBoxColumn nationalcode;
        private System.Windows.Forms.DataGridViewTextBoxColumn father;
        private System.Windows.Forms.DataGridViewTextBoxColumn eshteghal;
        private System.Windows.Forms.DataGridViewTextBoxColumn tedadbarg;
        private System.Windows.Forms.DataGridViewTextBoxColumn estekdam;
        private System.Windows.Forms.DataGridViewTextBoxColumn tozihat;
        private System.Windows.Forms.DataGridViewTextBoxColumn raked;
        private System.Windows.Forms.DataGridViewTextBoxColumn amanat;
        private System.Windows.Forms.DataGridViewTextBoxColumn amanat_id;
    }
}