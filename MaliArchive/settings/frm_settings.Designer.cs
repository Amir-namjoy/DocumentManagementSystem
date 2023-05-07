namespace MaliArchive
{
    partial class frm_settings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_settings));
            this.btn_selpic = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPicPath = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.radioNoPic = new System.Windows.Forms.RadioButton();
            this.radioChoPic = new System.Windows.Forms.RadioButton();
            this.radioDefPic = new System.Windows.Forms.RadioButton();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.check_animCap = new System.Windows.Forms.CheckBox();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_selpic
            // 
            this.btn_selpic.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_selpic.Enabled = false;
            this.btn_selpic.Location = new System.Drawing.Point(10, 86);
            this.btn_selpic.Name = "btn_selpic";
            this.btn_selpic.Size = new System.Drawing.Size(87, 25);
            this.btn_selpic.TabIndex = 1;
            this.btn_selpic.Text = "انتخاب...";
            this.btn_selpic.UseVisualStyleBackColor = true;
            this.btn_selpic.Click += new System.EventHandler(this.btn_selpic_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.comboBox1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtPicPath);
            this.groupBox1.Controls.Add(this.pictureBox1);
            this.groupBox1.Controls.Add(this.radioNoPic);
            this.groupBox1.Controls.Add(this.btn_selpic);
            this.groupBox1.Controls.Add(this.radioChoPic);
            this.groupBox1.Controls.Add(this.radioDefPic);
            this.groupBox1.Location = new System.Drawing.Point(14, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox1.Size = new System.Drawing.Size(411, 166);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "تصوير زمينه";
            // 
            // comboBox1
            // 
            this.comboBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox1.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::MaliArchive.Properties.Settings.Default, "frm_main_pic_lay", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "None",
            "Title",
            "Center",
            "Stretch",
            "Zoom"});
            this.comboBox1.Location = new System.Drawing.Point(105, 130);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(184, 22);
            this.comboBox1.TabIndex = 8;
            this.comboBox1.Text = global::MaliArchive.Properties.Settings.Default.frm_main_pic_lay;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(296, 134);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 14);
            this.label1.TabIndex = 8;
            this.label1.Text = "حالت نمايش تصوير:";
            // 
            // txtPicPath
            // 
            this.txtPicPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPicPath.Location = new System.Drawing.Point(105, 88);
            this.txtPicPath.Name = "txtPicPath";
            this.txtPicPath.ReadOnly = true;
            this.txtPicPath.Size = new System.Drawing.Size(193, 22);
            this.txtPicPath.TabIndex = 8;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(10, 17);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(87, 62);
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // radioNoPic
            // 
            this.radioNoPic.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.radioNoPic.AutoSize = true;
            this.radioNoPic.Location = new System.Drawing.Point(319, 41);
            this.radioNoPic.Name = "radioNoPic";
            this.radioNoPic.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.radioNoPic.Size = new System.Drawing.Size(77, 18);
            this.radioNoPic.TabIndex = 2;
            this.radioNoPic.TabStop = true;
            this.radioNoPic.Text = "بدون تصوير";
            this.radioNoPic.UseVisualStyleBackColor = true;
            this.radioNoPic.CheckedChanged += new System.EventHandler(this.radioNoPic_CheckedChanged);
            // 
            // radioChoPic
            // 
            this.radioChoPic.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.radioChoPic.AutoSize = true;
            this.radioChoPic.Location = new System.Drawing.Point(310, 89);
            this.radioChoPic.Name = "radioChoPic";
            this.radioChoPic.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.radioChoPic.Size = new System.Drawing.Size(86, 18);
            this.radioChoPic.TabIndex = 4;
            this.radioChoPic.TabStop = true;
            this.radioChoPic.Text = "انتخاب تصوير";
            this.radioChoPic.UseVisualStyleBackColor = true;
            this.radioChoPic.CheckedChanged += new System.EventHandler(this.radioChoPic_CheckedChanged);
            // 
            // radioDefPic
            // 
            this.radioDefPic.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.radioDefPic.AutoSize = true;
            this.radioDefPic.Location = new System.Drawing.Point(291, 65);
            this.radioDefPic.Name = "radioDefPic";
            this.radioDefPic.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.radioDefPic.Size = new System.Drawing.Size(105, 18);
            this.radioDefPic.TabIndex = 3;
            this.radioDefPic.TabStop = true;
            this.radioDefPic.Text = "تصوير پيش فرض";
            this.radioDefPic.UseVisualStyleBackColor = true;
            this.radioDefPic.CheckedChanged += new System.EventHandler(this.radioDefPic_CheckedChanged);
            // 
            // btnOk
            // 
            this.btnOk.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnOk.ForeColor = System.Drawing.Color.Black;
            this.btnOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOk.ImageKey = "OK-16.png";
            this.btnOk.ImageList = this.imageList1;
            this.btnOk.Location = new System.Drawing.Point(318, 257);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(107, 26);
            this.btnOk.TabIndex = 6;
            this.btnOk.Text = "اعمال تنظيمات";
            this.btnOk.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnOk.UseVisualStyleBackColor = false;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnCancel.ForeColor = System.Drawing.Color.Black;
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.ImageKey = "Delete, Cancel-16.png";
            this.btnCancel.ImageList = this.imageList1;
            this.btnCancel.Location = new System.Drawing.Point(14, 258);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(97, 25);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "انصراف";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.check_animCap);
            this.groupBox2.Location = new System.Drawing.Point(14, 185);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox2.Size = new System.Drawing.Size(412, 66);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            // 
            // check_animCap
            // 
            this.check_animCap.AutoSize = true;
            this.check_animCap.Checked = global::MaliArchive.Properties.Settings.Default.anim_cap;
            this.check_animCap.CheckState = System.Windows.Forms.CheckState.Checked;
            this.check_animCap.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::MaliArchive.Properties.Settings.Default, "anim_cap", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.check_animCap.Location = new System.Drawing.Point(256, 32);
            this.check_animCap.Name = "check_animCap";
            this.check_animCap.Size = new System.Drawing.Size(140, 18);
            this.check_animCap.TabIndex = 10;
            this.check_animCap.Text = "حركت عنوان فرم اصلي";
            this.check_animCap.UseVisualStyleBackColor = true;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "OK-16.png");
            this.imageList1.Images.SetKeyName(1, "Delete, Cancel-16.png");
            // 
            // frm_settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(440, 288);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_settings";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "تنظيمات";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frm_settings_FormClosing);
            this.Load += new System.EventHandler(this.frm_settings_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_selpic;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.RadioButton radioNoPic;
        private System.Windows.Forms.RadioButton radioDefPic;
        private System.Windows.Forms.RadioButton radioChoPic;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox txtPicPath;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox check_animCap;
        private System.Windows.Forms.ImageList imageList1;
    }
}