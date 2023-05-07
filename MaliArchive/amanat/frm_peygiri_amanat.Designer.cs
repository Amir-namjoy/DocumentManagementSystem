namespace MaliArchive
{
    partial class frm_peygiri_amanat
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_peygiri_amanat));
            this.dgvamanat = new System.Windows.Forms.DataGridView();
            this.parvandeh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.girandeh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tarik = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mohlat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.takhir = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dahandeh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tozihat_amanat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnClose = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.txtResultTozihat = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvamanat)).BeginInit();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvamanat
            // 
            this.dgvamanat.AllowUserToAddRows = false;
            this.dgvamanat.AllowUserToDeleteRows = false;
            this.dgvamanat.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvamanat.BackgroundColor = System.Drawing.Color.White;
            this.dgvamanat.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvamanat.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.parvandeh,
            this.girandeh,
            this.tarik,
            this.mohlat,
            this.takhir,
            this.dahandeh,
            this.tozihat_amanat});
            this.dgvamanat.GridColor = System.Drawing.Color.LightSteelBlue;
            this.dgvamanat.Location = new System.Drawing.Point(0, 3);
            this.dgvamanat.Name = "dgvamanat";
            this.dgvamanat.ReadOnly = true;
            this.dgvamanat.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvamanat.Size = new System.Drawing.Size(855, 408);
            this.dgvamanat.TabIndex = 3;
            this.dgvamanat.SelectionChanged += new System.EventHandler(this.dgvamanat_SelectionChanged);
            // 
            // parvandeh
            // 
            this.parvandeh.HeaderText = "شماره پرونده";
            this.parvandeh.Name = "parvandeh";
            this.parvandeh.ReadOnly = true;
            this.parvandeh.Width = 50;
            // 
            // girandeh
            // 
            this.girandeh.FillWeight = 200F;
            this.girandeh.HeaderText = "نام امانت گيرنده";
            this.girandeh.Name = "girandeh";
            this.girandeh.ReadOnly = true;
            this.girandeh.Width = 150;
            // 
            // tarik
            // 
            this.tarik.HeaderText = "تاريخ امانت";
            this.tarik.Name = "tarik";
            this.tarik.ReadOnly = true;
            // 
            // mohlat
            // 
            this.mohlat.HeaderText = "مهلت امانت";
            this.mohlat.Name = "mohlat";
            this.mohlat.ReadOnly = true;
            // 
            // takhir
            // 
            this.takhir.HeaderText = "تاخير - روز";
            this.takhir.Name = "takhir";
            this.takhir.ReadOnly = true;
            this.takhir.Width = 50;
            // 
            // dahandeh
            // 
            this.dahandeh.FillWeight = 200F;
            this.dahandeh.HeaderText = "نام امانت دهنده";
            this.dahandeh.Name = "dahandeh";
            this.dahandeh.ReadOnly = true;
            this.dahandeh.Width = 150;
            // 
            // tozihat_amanat
            // 
            this.tozihat_amanat.FillWeight = 300F;
            this.tozihat_amanat.HeaderText = "توضيحات امانت";
            this.tozihat_amanat.Name = "tozihat_amanat";
            this.tozihat_amanat.ReadOnly = true;
            this.tozihat_amanat.Width = 200;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnClose.Image = global::MaliArchive.Properties.Resources.go_back;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.Location = new System.Drawing.Point(14, 491);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(74, 34);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "خروج";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox5.Controls.Add(this.txtResultTozihat);
            this.groupBox5.Location = new System.Drawing.Point(0, 412);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(855, 77);
            this.groupBox5.TabIndex = 4;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "توضيحات امانت";
            // 
            // txtResultTozihat
            // 
            this.txtResultTozihat.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtResultTozihat.Location = new System.Drawing.Point(6, 16);
            this.txtResultTozihat.Multiline = true;
            this.txtResultTozihat.Name = "txtResultTozihat";
            this.txtResultTozihat.Size = new System.Drawing.Size(843, 57);
            this.txtResultTozihat.TabIndex = 0;
            // 
            // frm_peygiri_amanat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(857, 526);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.dgvamanat);
            this.Controls.Add(this.btnClose);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frm_peygiri_amanat";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "پيگيري امانات";
            this.Load += new System.EventHandler(this.frm_peygiri_amanat_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvamanat)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.DataGridView dgvamanat;
        private System.Windows.Forms.DataGridViewTextBoxColumn parvandeh;
        private System.Windows.Forms.DataGridViewTextBoxColumn girandeh;
        private System.Windows.Forms.DataGridViewTextBoxColumn tarik;
        private System.Windows.Forms.DataGridViewTextBoxColumn mohlat;
        private System.Windows.Forms.DataGridViewTextBoxColumn takhir;
        private System.Windows.Forms.DataGridViewTextBoxColumn dahandeh;
        private System.Windows.Forms.DataGridViewTextBoxColumn tozihat_amanat;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TextBox txtResultTozihat;
    }
}