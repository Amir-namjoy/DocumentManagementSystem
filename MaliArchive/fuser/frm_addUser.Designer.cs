namespace MaliArchive
{
    partial class frm_addUser
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_addUser));
            this.label1 = new System.Windows.Forms.Label();
            this.txtname = new System.Windows.Forms.TextBox();
            this.txtpass = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtsemat = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtpersonalId = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtusername = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtfamily = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtpass2 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.checkAllowLogin = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cLBpermissions = new System.Windows.Forms.CheckedListBox();
            this.combGender = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnSelectPic = new System.Windows.Forms.Button();
            this.btnRemovePic = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(522, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(21, 14);
            this.label1.TabIndex = 15;
            this.label1.Text = "نام";
            // 
            // txtname
            // 
            this.txtname.Location = new System.Drawing.Point(12, 12);
            this.txtname.MaxLength = 50;
            this.txtname.Name = "txtname";
            this.txtname.Size = new System.Drawing.Size(442, 22);
            this.txtname.TabIndex = 1;
            // 
            // txtpass
            // 
            this.txtpass.Location = new System.Drawing.Point(12, 152);
            this.txtpass.MaxLength = 50;
            this.txtpass.Name = "txtpass";
            this.txtpass.PasswordChar = '*';
            this.txtpass.Size = new System.Drawing.Size(442, 22);
            this.txtpass.TabIndex = 6;
            this.txtpass.UseSystemPasswordChar = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(497, 155);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 14);
            this.label2.TabIndex = 17;
            this.label2.Text = "رمز عبور";
            // 
            // txtsemat
            // 
            this.txtsemat.Location = new System.Drawing.Point(12, 124);
            this.txtsemat.MaxLength = 50;
            this.txtsemat.Name = "txtsemat";
            this.txtsemat.Size = new System.Drawing.Size(442, 22);
            this.txtsemat.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(506, 127);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 14);
            this.label3.TabIndex = 19;
            this.label3.Text = "سمت";
            // 
            // txtpersonalId
            // 
            this.txtpersonalId.Location = new System.Drawing.Point(12, 96);
            this.txtpersonalId.MaxLength = 15;
            this.txtpersonalId.Name = "txtpersonalId";
            this.txtpersonalId.Size = new System.Drawing.Size(442, 22);
            this.txtpersonalId.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(459, 99);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 14);
            this.label4.TabIndex = 21;
            this.label4.Text = "شماره پرسنلي";
            // 
            // txtusername
            // 
            this.txtusername.Location = new System.Drawing.Point(12, 68);
            this.txtusername.MaxLength = 50;
            this.txtusername.Name = "txtusername";
            this.txtusername.Size = new System.Drawing.Size(442, 22);
            this.txtusername.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(486, 71);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 14);
            this.label5.TabIndex = 23;
            this.label5.Text = "نام كاربري";
            // 
            // txtfamily
            // 
            this.txtfamily.Location = new System.Drawing.Point(12, 40);
            this.txtfamily.MaxLength = 50;
            this.txtfamily.Name = "txtfamily";
            this.txtfamily.Size = new System.Drawing.Size(442, 22);
            this.txtfamily.TabIndex = 2;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(471, 43);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 14);
            this.label6.TabIndex = 25;
            this.label6.Text = "نام خانوادگي";
            // 
            // txtpass2
            // 
            this.txtpass2.Location = new System.Drawing.Point(12, 180);
            this.txtpass2.MaxLength = 50;
            this.txtpass2.Name = "txtpass2";
            this.txtpass2.PasswordChar = '*';
            this.txtpass2.Size = new System.Drawing.Size(442, 22);
            this.txtpass2.TabIndex = 7;
            this.txtpass2.UseSystemPasswordChar = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(472, 183);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(71, 14);
            this.label7.TabIndex = 27;
            this.label7.Text = "تكرار رمز عبور";
            // 
            // checkAllowLogin
            // 
            this.checkAllowLogin.AutoSize = true;
            this.checkAllowLogin.Checked = true;
            this.checkAllowLogin.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkAllowLogin.Location = new System.Drawing.Point(269, 212);
            this.checkAllowLogin.Name = "checkAllowLogin";
            this.checkAllowLogin.Size = new System.Drawing.Size(185, 18);
            this.checkAllowLogin.TabIndex = 8;
            this.checkAllowLogin.Text = "كاربر اجازه كار با سيستم را دارد";
            this.checkAllowLogin.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cLBpermissions);
            this.groupBox1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.groupBox1.Location = new System.Drawing.Point(138, 236);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(402, 180);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "دسترسي هاي كاربر";
            // 
            // cLBpermissions
            // 
            this.cLBpermissions.CheckOnClick = true;
            this.cLBpermissions.ForeColor = System.Drawing.Color.DarkBlue;
            this.cLBpermissions.FormattingEnabled = true;
            this.cLBpermissions.Items.AddRange(new object[] {
            "ثبت پرونده جديد",
            "مشاهده پرونده",
            "ويرايش پرونده",
            "گزارش گيري",
            "مديريت كاربران",
            "افزودن كاربر جديد",
            "ويرايش اطلاعات و دسترسي هاي كاربران",
            "افزودن اشخاص امانت گيرنده پرونده",
            "گزارش رويدادنگاري كاربران"});
            this.cLBpermissions.Location = new System.Drawing.Point(6, 22);
            this.cLBpermissions.Name = "cLBpermissions";
            this.cLBpermissions.Size = new System.Drawing.Size(390, 140);
            this.cLBpermissions.TabIndex = 32;
            // 
            // combGender
            // 
            this.combGender.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combGender.FormattingEnabled = true;
            this.combGender.Items.AddRange(new object[] {
            "مرد",
            "زن"});
            this.combGender.Location = new System.Drawing.Point(12, 208);
            this.combGender.Name = "combGender";
            this.combGender.Size = new System.Drawing.Size(140, 22);
            this.combGender.TabIndex = 9;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(158, 211);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(47, 14);
            this.label8.TabIndex = 31;
            this.label8.Text = "جنسيت";
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnCancel.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnCancel.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnCancel.Location = new System.Drawing.Point(12, 422);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(87, 32);
            this.btnCancel.TabIndex = 17;
            this.btnCancel.Text = "انصراف";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnOK.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnOK.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnOK.Location = new System.Drawing.Point(115, 422);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(87, 32);
            this.btnOK.TabIndex = 16;
            this.btnOK.Text = "تاييد";
            this.btnOK.UseVisualStyleBackColor = false;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnSelectPic);
            this.groupBox2.Controls.Add(this.btnRemovePic);
            this.groupBox2.Controls.Add(this.pictureBox1);
            this.groupBox2.Enabled = false;
            this.groupBox2.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.groupBox2.Location = new System.Drawing.Point(12, 236);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(120, 180);
            this.groupBox2.TabIndex = 62;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "تصوير كاربر";
            // 
            // btnSelectPic
            // 
            this.btnSelectPic.Location = new System.Drawing.Point(6, 129);
            this.btnSelectPic.Name = "btnSelectPic";
            this.btnSelectPic.Size = new System.Drawing.Size(107, 23);
            this.btnSelectPic.TabIndex = 36;
            this.btnSelectPic.Text = "انتخاب تصوير";
            this.btnSelectPic.UseVisualStyleBackColor = true;
            // 
            // btnRemovePic
            // 
            this.btnRemovePic.Location = new System.Drawing.Point(6, 152);
            this.btnRemovePic.Name = "btnRemovePic";
            this.btnRemovePic.Size = new System.Drawing.Size(107, 23);
            this.btnRemovePic.TabIndex = 35;
            this.btnRemovePic.Text = "حذف تصوير";
            this.btnRemovePic.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(6, 21);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(107, 103);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 34;
            this.pictureBox1.TabStop = false;
            // 
            // frm_addUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(554, 462);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.combGender);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.checkAllowLogin);
            this.Controls.Add(this.txtpass2);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtfamily);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtusername);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtpersonalId);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtsemat);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtpass);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtname);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frm_addUser";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "كاربر جديد";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtname;
        private System.Windows.Forms.TextBox txtpass;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtsemat;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtpersonalId;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtusername;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtfamily;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtpass2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox checkAllowLogin;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox combGender;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.CheckedListBox cLBpermissions;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnSelectPic;
        private System.Windows.Forms.Button btnRemovePic;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}