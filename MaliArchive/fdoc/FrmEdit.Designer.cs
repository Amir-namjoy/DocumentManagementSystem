namespace MaliArchive
{
    internal partial class FrmEdit
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmEdit));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label14 = new System.Windows.Forms.Label();
            this.comb_estekdam = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.comb_eshteghal = new System.Windows.Forms.ComboBox();
            this.txtb_tozihat = new System.Windows.Forms.TextBox();
            this.txtb_nationalCode = new System.Windows.Forms.TextBox();
            this.txtb_passid = new System.Windows.Forms.TextBox();
            this.txtb_fathername = new System.Windows.Forms.TextBox();
            this.txtb_family = new System.Windows.Forms.TextBox();
            this.txtb_name = new System.Windows.Forms.TextBox();
            this.txtb_daftarkol = new System.Windows.Forms.TextBox();
            this.txtb_personalid = new System.Windows.Forms.TextBox();
            this.txtb_parvandeh = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.fdate_tarikTaskil = new FarsiLibrary.Win.Controls.FADatePicker();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_scan = new System.Windows.Forms.Button();
            this.dGAttachments = new System.Windows.Forms.DataGridView();
            this.Filename = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.extension = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fileSize = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.filePath = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.picId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.filebytesize = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblSumSize = new System.Windows.Forms.Label();
            this.btnSaveAttachments = new System.Windows.Forms.Button();
            this.btnViewAttachments = new System.Windows.Forms.Button();
            this.btn_Remove_Attach = new System.Windows.Forms.Button();
            this.btn_Attach = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.SaveChangestoolStripButton = new System.Windows.Forms.ToolStripButton();
            this.ExittoolStripButton = new System.Windows.Forms.ToolStripButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dGAttachments)).BeginInit();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "OK-16.png");
            this.imageList1.Images.SetKeyName(1, "Delete, Cancel-16.png");
            this.imageList1.Images.SetKeyName(2, "plus_16.png");
            this.imageList1.Images.SetKeyName(3, "Search.png");
            this.imageList1.Images.SetKeyName(4, "Floppy.png");
            this.imageList1.Images.SetKeyName(5, "scaner.ico");
            this.imageList1.Images.SetKeyName(6, "flatbed-scanner-icon-39800.png");
            this.imageList1.Images.SetKeyName(7, "Oxygen-Icons.org-Oxygen-Devices-scanner.ico");
            this.imageList1.Images.SetKeyName(8, "Umut-Pulat-Tulliana-2-Scanner.ico");
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Location = new System.Drawing.Point(342, 212);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(119, 18);
            this.checkBox1.TabIndex = 156;
            this.checkBox1.Text = "برگ شماري نشده";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Enabled = false;
            this.numericUpDown1.Location = new System.Drawing.Point(467, 211);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(63, 22);
            this.numericUpDown1.TabIndex = 158;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(533, 213);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label14.Size = new System.Drawing.Size(96, 14);
            this.label14.TabIndex = 162;
            this.label14.Text = "تعداد برگ پرونده :";
            // 
            // comb_estekdam
            // 
            this.comb_estekdam.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comb_estekdam.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comb_estekdam.FormattingEnabled = true;
            this.comb_estekdam.Items.AddRange(new object[] {
            "",
            "قراردادي",
            "پيماني",
            "رسمي"});
            this.comb_estekdam.Location = new System.Drawing.Point(13, 210);
            this.comb_estekdam.Margin = new System.Windows.Forms.Padding(4);
            this.comb_estekdam.Name = "comb_estekdam";
            this.comb_estekdam.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.comb_estekdam.Size = new System.Drawing.Size(190, 22);
            this.comb_estekdam.TabIndex = 159;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(211, 213);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label13.Size = new System.Drawing.Size(74, 14);
            this.label13.TabIndex = 161;
            this.label13.Text = "نوع استخدام:";
            // 
            // comb_eshteghal
            // 
            this.comb_eshteghal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comb_eshteghal.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comb_eshteghal.FormattingEnabled = true;
            this.comb_eshteghal.ItemHeight = 14;
            this.comb_eshteghal.Items.AddRange(new object[] {
            "",
            "شاغل",
            "بازنشسته"});
            this.comb_eshteghal.Location = new System.Drawing.Point(13, 182);
            this.comb_eshteghal.Margin = new System.Windows.Forms.Padding(4);
            this.comb_eshteghal.Name = "comb_eshteghal";
            this.comb_eshteghal.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.comb_eshteghal.Size = new System.Drawing.Size(190, 22);
            this.comb_eshteghal.TabIndex = 155;
            // 
            // txtb_tozihat
            // 
            this.txtb_tozihat.Location = new System.Drawing.Point(13, 240);
            this.txtb_tozihat.Margin = new System.Windows.Forms.Padding(4);
            this.txtb_tozihat.Multiline = true;
            this.txtb_tozihat.Name = "txtb_tozihat";
            this.txtb_tozihat.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtb_tozihat.Size = new System.Drawing.Size(517, 62);
            this.txtb_tozihat.TabIndex = 160;
            // 
            // txtb_nationalCode
            // 
            this.txtb_nationalCode.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtb_nationalCode.Location = new System.Drawing.Point(13, 152);
            this.txtb_nationalCode.Margin = new System.Windows.Forms.Padding(4);
            this.txtb_nationalCode.MaxLength = 15;
            this.txtb_nationalCode.Name = "txtb_nationalCode";
            this.txtb_nationalCode.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtb_nationalCode.Size = new System.Drawing.Size(190, 22);
            this.txtb_nationalCode.TabIndex = 151;
            // 
            // txtb_passid
            // 
            this.txtb_passid.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtb_passid.Location = new System.Drawing.Point(342, 182);
            this.txtb_passid.Margin = new System.Windows.Forms.Padding(4);
            this.txtb_passid.MaxLength = 10;
            this.txtb_passid.Name = "txtb_passid";
            this.txtb_passid.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtb_passid.Size = new System.Drawing.Size(190, 22);
            this.txtb_passid.TabIndex = 148;
            // 
            // txtb_fathername
            // 
            this.txtb_fathername.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtb_fathername.Location = new System.Drawing.Point(342, 152);
            this.txtb_fathername.Margin = new System.Windows.Forms.Padding(4);
            this.txtb_fathername.MaxLength = 50;
            this.txtb_fathername.Name = "txtb_fathername";
            this.txtb_fathername.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtb_fathername.Size = new System.Drawing.Size(190, 22);
            this.txtb_fathername.TabIndex = 153;
            // 
            // txtb_family
            // 
            this.txtb_family.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtb_family.Location = new System.Drawing.Point(13, 122);
            this.txtb_family.Margin = new System.Windows.Forms.Padding(4);
            this.txtb_family.MaxLength = 50;
            this.txtb_family.Name = "txtb_family";
            this.txtb_family.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtb_family.Size = new System.Drawing.Size(190, 22);
            this.txtb_family.TabIndex = 147;
            // 
            // txtb_name
            // 
            this.txtb_name.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtb_name.Location = new System.Drawing.Point(342, 122);
            this.txtb_name.Margin = new System.Windows.Forms.Padding(4);
            this.txtb_name.MaxLength = 50;
            this.txtb_name.Name = "txtb_name";
            this.txtb_name.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtb_name.Size = new System.Drawing.Size(190, 22);
            this.txtb_name.TabIndex = 145;
            // 
            // txtb_daftarkol
            // 
            this.txtb_daftarkol.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtb_daftarkol.Location = new System.Drawing.Point(13, 92);
            this.txtb_daftarkol.Margin = new System.Windows.Forms.Padding(4);
            this.txtb_daftarkol.MaxLength = 10;
            this.txtb_daftarkol.Name = "txtb_daftarkol";
            this.txtb_daftarkol.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtb_daftarkol.Size = new System.Drawing.Size(190, 22);
            this.txtb_daftarkol.TabIndex = 143;
            // 
            // txtb_personalid
            // 
            this.txtb_personalid.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtb_personalid.Location = new System.Drawing.Point(342, 92);
            this.txtb_personalid.Margin = new System.Windows.Forms.Padding(4);
            this.txtb_personalid.MaxLength = 10;
            this.txtb_personalid.Name = "txtb_personalid";
            this.txtb_personalid.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtb_personalid.Size = new System.Drawing.Size(190, 22);
            this.txtb_personalid.TabIndex = 141;
            this.txtb_personalid.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtb_KeyPress);
            // 
            // txtb_parvandeh
            // 
            this.txtb_parvandeh.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtb_parvandeh.Location = new System.Drawing.Point(342, 62);
            this.txtb_parvandeh.Margin = new System.Windows.Forms.Padding(4);
            this.txtb_parvandeh.Name = "txtb_parvandeh";
            this.txtb_parvandeh.ReadOnly = true;
            this.txtb_parvandeh.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtb_parvandeh.Size = new System.Drawing.Size(190, 22);
            this.txtb_parvandeh.TabIndex = 157;
            this.txtb_parvandeh.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(533, 243);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label11.Size = new System.Drawing.Size(54, 14);
            this.label11.TabIndex = 154;
            this.label11.Text = "توضيحات:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(211, 155);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label10.Size = new System.Drawing.Size(50, 14);
            this.label10.TabIndex = 152;
            this.label10.Text = "كد ملي:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(537, 185);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label9.Size = new System.Drawing.Size(101, 14);
            this.label9.TabIndex = 150;
            this.label9.Text = "شماره شناسنامه:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(537, 155);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label8.Size = new System.Drawing.Size(43, 14);
            this.label8.TabIndex = 149;
            this.label8.Text = "نام پدر:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(211, 125);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label7.Size = new System.Drawing.Size(76, 14);
            this.label7.TabIndex = 146;
            this.label7.Text = "نام خانوادگي:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(537, 125);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label6.Size = new System.Drawing.Size(25, 14);
            this.label6.TabIndex = 144;
            this.label6.Text = "نام:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(211, 95);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label5.Size = new System.Drawing.Size(87, 14);
            this.label5.TabIndex = 142;
            this.label5.Text = "شماره دفتر كل:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(537, 95);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label4.Size = new System.Drawing.Size(92, 14);
            this.label4.TabIndex = 140;
            this.label4.Text = "شماره پرسنلي :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(211, 185);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label3.Size = new System.Drawing.Size(87, 14);
            this.label3.TabIndex = 139;
            this.label3.Text = "وضعيت اشتغال:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(211, 65);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label2.Size = new System.Drawing.Size(105, 14);
            this.label2.TabIndex = 138;
            this.label2.Text = "تاريخ تشكيل پرونده:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(537, 65);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label1.Size = new System.Drawing.Size(77, 14);
            this.label1.TabIndex = 136;
            this.label1.Text = "شماره پرونده:";
            // 
            // fdate_tarikTaskil
            // 
            this.fdate_tarikTaskil.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fdate_tarikTaskil.Location = new System.Drawing.Point(13, 62);
            this.fdate_tarikTaskil.Name = "fdate_tarikTaskil";
            this.fdate_tarikTaskil.ScrollOption = FarsiLibrary.Win.Enums.ScrollOptionTypes.Day;
            this.fdate_tarikTaskil.Size = new System.Drawing.Size(191, 20);
            this.fdate_tarikTaskil.TabIndex = 176;
            this.fdate_tarikTaskil.Theme = FarsiLibrary.Win.Enums.ThemeTypes.Office2003;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_scan);
            this.groupBox1.Controls.Add(this.dGAttachments);
            this.groupBox1.Controls.Add(this.lblSumSize);
            this.groupBox1.Controls.Add(this.btnSaveAttachments);
            this.groupBox1.Controls.Add(this.btnViewAttachments);
            this.groupBox1.Controls.Add(this.btn_Remove_Attach);
            this.groupBox1.Controls.Add(this.btn_Attach);
            this.groupBox1.Location = new System.Drawing.Point(13, 309);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(608, 174);
            this.groupBox1.TabIndex = 178;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "تصاوير و ضمائم پرونده";
            // 
            // btn_scan
            // 
            this.btn_scan.Enabled = false;
            this.btn_scan.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_scan.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_scan.ImageKey = "flatbed-scanner-icon-39800.png";
            this.btn_scan.ImageList = this.imageList1;
            this.btn_scan.Location = new System.Drawing.Point(7, 80);
            this.btn_scan.Margin = new System.Windows.Forms.Padding(4);
            this.btn_scan.Name = "btn_scan";
            this.btn_scan.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btn_scan.Size = new System.Drawing.Size(85, 27);
            this.btn_scan.TabIndex = 142;
            this.btn_scan.Text = "اسكن";
            this.btn_scan.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_scan.UseVisualStyleBackColor = true;
            // 
            // dGAttachments
            // 
            this.dGAttachments.AllowUserToAddRows = false;
            this.dGAttachments.AllowUserToDeleteRows = false;
            this.dGAttachments.AllowUserToResizeRows = false;
            this.dGAttachments.BackgroundColor = System.Drawing.Color.White;
            this.dGAttachments.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dGAttachments.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dGAttachments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGAttachments.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Filename,
            this.extension,
            this.fileSize,
            this.filePath,
            this.picId,
            this.filebytesize});
            this.dGAttachments.Location = new System.Drawing.Point(98, 21);
            this.dGAttachments.Name = "dGAttachments";
            this.dGAttachments.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dGAttachments.RowHeadersVisible = false;
            this.dGAttachments.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.dGAttachments.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dGAttachments.Size = new System.Drawing.Size(500, 129);
            this.dGAttachments.TabIndex = 141;
            this.dGAttachments.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dGAttachments_CellDoubleClick);
            this.dGAttachments.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dGAttachments_RowsAdded);
            this.dGAttachments.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.dGAttachments_RowsRemoved);
            // 
            // Filename
            // 
            this.Filename.FillWeight = 250F;
            this.Filename.HeaderText = "نام فايل";
            this.Filename.Name = "Filename";
            this.Filename.ReadOnly = true;
            this.Filename.Width = 120;
            // 
            // extension
            // 
            this.extension.HeaderText = "نوع";
            this.extension.Name = "extension";
            this.extension.ReadOnly = true;
            this.extension.Width = 50;
            // 
            // fileSize
            // 
            this.fileSize.HeaderText = "حجم";
            this.fileSize.Name = "fileSize";
            this.fileSize.ReadOnly = true;
            // 
            // filePath
            // 
            this.filePath.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.filePath.HeaderText = "مسير فايل";
            this.filePath.Name = "filePath";
            this.filePath.ReadOnly = true;
            // 
            // picId
            // 
            this.picId.HeaderText = "picID";
            this.picId.Name = "picId";
            this.picId.ReadOnly = true;
            this.picId.Visible = false;
            // 
            // filebytesize
            // 
            this.filebytesize.HeaderText = "filebytesize";
            this.filebytesize.Name = "filebytesize";
            this.filebytesize.ReadOnly = true;
            this.filebytesize.Visible = false;
            // 
            // lblSumSize
            // 
            this.lblSumSize.AutoSize = true;
            this.lblSumSize.Location = new System.Drawing.Point(271, 153);
            this.lblSumSize.Name = "lblSumSize";
            this.lblSumSize.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblSumSize.Size = new System.Drawing.Size(119, 14);
            this.lblSumSize.TabIndex = 179;
            this.lblSumSize.Text = "                            ";
            // 
            // btnSaveAttachments
            // 
            this.btnSaveAttachments.Enabled = false;
            this.btnSaveAttachments.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveAttachments.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSaveAttachments.ImageKey = "Floppy.png";
            this.btnSaveAttachments.ImageList = this.imageList1;
            this.btnSaveAttachments.Location = new System.Drawing.Point(7, 140);
            this.btnSaveAttachments.Margin = new System.Windows.Forms.Padding(4);
            this.btnSaveAttachments.Name = "btnSaveAttachments";
            this.btnSaveAttachments.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnSaveAttachments.Size = new System.Drawing.Size(85, 27);
            this.btnSaveAttachments.TabIndex = 139;
            this.btnSaveAttachments.Text = "ذخيره";
            this.btnSaveAttachments.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSaveAttachments.UseVisualStyleBackColor = true;
            this.btnSaveAttachments.Click += new System.EventHandler(this.btnSaveAttachments_Click);
            // 
            // btnViewAttachments
            // 
            this.btnViewAttachments.Enabled = false;
            this.btnViewAttachments.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnViewAttachments.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnViewAttachments.ImageKey = "Search.png";
            this.btnViewAttachments.ImageList = this.imageList1;
            this.btnViewAttachments.Location = new System.Drawing.Point(7, 110);
            this.btnViewAttachments.Margin = new System.Windows.Forms.Padding(4);
            this.btnViewAttachments.Name = "btnViewAttachments";
            this.btnViewAttachments.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnViewAttachments.Size = new System.Drawing.Size(85, 27);
            this.btnViewAttachments.TabIndex = 138;
            this.btnViewAttachments.Text = "مشاهده";
            this.btnViewAttachments.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnViewAttachments.UseVisualStyleBackColor = true;
            this.btnViewAttachments.Click += new System.EventHandler(this.btnViewAttachments_Click);
            // 
            // btn_Remove_Attach
            // 
            this.btn_Remove_Attach.Enabled = false;
            this.btn_Remove_Attach.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Remove_Attach.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Remove_Attach.ImageKey = "Delete, Cancel-16.png";
            this.btn_Remove_Attach.ImageList = this.imageList1;
            this.btn_Remove_Attach.Location = new System.Drawing.Point(7, 52);
            this.btn_Remove_Attach.Margin = new System.Windows.Forms.Padding(4);
            this.btn_Remove_Attach.Name = "btn_Remove_Attach";
            this.btn_Remove_Attach.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btn_Remove_Attach.Size = new System.Drawing.Size(85, 27);
            this.btn_Remove_Attach.TabIndex = 137;
            this.btn_Remove_Attach.Text = "حذف";
            this.btn_Remove_Attach.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Remove_Attach.UseVisualStyleBackColor = true;
            this.btn_Remove_Attach.Click += new System.EventHandler(this.btn_Remove_Attach_Click);
            // 
            // btn_Attach
            // 
            this.btn_Attach.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Attach.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Attach.ImageKey = "plus_16.png";
            this.btn_Attach.ImageList = this.imageList1;
            this.btn_Attach.Location = new System.Drawing.Point(7, 21);
            this.btn_Attach.Margin = new System.Windows.Forms.Padding(4);
            this.btn_Attach.Name = "btn_Attach";
            this.btn_Attach.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btn_Attach.Size = new System.Drawing.Size(85, 27);
            this.btn_Attach.TabIndex = 136;
            this.btn_Attach.Text = "الحاق";
            this.btn_Attach.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Attach.UseVisualStyleBackColor = true;
            this.btn_Attach.Click += new System.EventHandler(this.btn_Attach_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackgroundImage = global::MaliArchive.Properties.Resources.toolbar_BackgroundImage;
            this.toolStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.toolStrip1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(36, 36);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SaveChangestoolStripButton,
            this.ExittoolStripButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.toolStrip1.Size = new System.Drawing.Size(641, 43);
            this.toolStrip1.TabIndex = 181;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // SaveChangestoolStripButton
            // 
            this.SaveChangestoolStripButton.Image = global::MaliArchive.Properties.Resources.Save_icon;
            this.SaveChangestoolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.SaveChangestoolStripButton.Name = "SaveChangestoolStripButton";
            this.SaveChangestoolStripButton.Size = new System.Drawing.Size(155, 40);
            this.SaveChangestoolStripButton.Text = "ذخيره تغييرات          ";
            this.SaveChangestoolStripButton.ToolTipText = "ذخيره تغييرات ايجاد شده در پرونده";
            this.SaveChangestoolStripButton.Click += new System.EventHandler(this.SaveChangestoolStripButton_Click);
            // 
            // ExittoolStripButton
            // 
            this.ExittoolStripButton.Image = global::MaliArchive.Properties.Resources.exit1;
            this.ExittoolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ExittoolStripButton.Name = "ExittoolStripButton";
            this.ExittoolStripButton.Size = new System.Drawing.Size(104, 40);
            this.ExittoolStripButton.Text = "    خروج    ";
            this.ExittoolStripButton.ToolTipText = "خروج";
            this.ExittoolStripButton.Click += new System.EventHandler(this.ExittoolStripButton_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::MaliArchive.Properties.Resources.folder_txt;
            this.pictureBox1.Location = new System.Drawing.Point(559, 259);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(70, 43);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 177;
            this.pictureBox1.TabStop = false;
            // 
            // FrmEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(641, 490);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.fdate_tarikTaskil);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.comb_estekdam);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.comb_eshteghal);
            this.Controls.Add(this.txtb_tozihat);
            this.Controls.Add(this.txtb_nationalCode);
            this.Controls.Add(this.txtb_passid);
            this.Controls.Add(this.txtb_fathername);
            this.Controls.Add(this.txtb_family);
            this.Controls.Add(this.txtb_name);
            this.Controls.Add(this.txtb_daftarkol);
            this.Controls.Add(this.txtb_personalid);
            this.Controls.Add(this.txtb_parvandeh);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FrmEdit";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ويرايش پرونده شماره :  ";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmEdit_FormClosing);
            this.Load += new System.EventHandler(this.frm_edit_Load);
            this.Shown += new System.EventHandler(this.FrmEdit_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dGAttachments)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox comb_estekdam;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox comb_eshteghal;
        private System.Windows.Forms.TextBox txtb_tozihat;
        private System.Windows.Forms.TextBox txtb_nationalCode;
        private System.Windows.Forms.TextBox txtb_passid;
        private System.Windows.Forms.TextBox txtb_fathername;
        private System.Windows.Forms.TextBox txtb_family;
        private System.Windows.Forms.TextBox txtb_name;
        private System.Windows.Forms.TextBox txtb_daftarkol;
        private System.Windows.Forms.TextBox txtb_personalid;
        private System.Windows.Forms.TextBox txtb_parvandeh;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private FarsiLibrary.Win.Controls.FADatePicker fdate_tarikTaskil;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnSaveAttachments;
        private System.Windows.Forms.Button btnViewAttachments;
        private System.Windows.Forms.Button btn_Remove_Attach;
        private System.Windows.Forms.Button btn_Attach;
        private System.Windows.Forms.Label lblSumSize;
        private System.Windows.Forms.DataGridView dGAttachments;
        private System.Windows.Forms.DataGridViewTextBoxColumn Filename;
        private System.Windows.Forms.DataGridViewTextBoxColumn extension;
        private System.Windows.Forms.DataGridViewTextBoxColumn fileSize;
        private System.Windows.Forms.DataGridViewTextBoxColumn filePath;
        private System.Windows.Forms.DataGridViewTextBoxColumn picId;
        private System.Windows.Forms.DataGridViewTextBoxColumn filebytesize;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button btn_scan;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton SaveChangestoolStripButton;
        private System.Windows.Forms.ToolStripButton ExittoolStripButton;


    }
}