using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MaliArchive
{
    public partial class frm_settings : Form
    {
        public  frm_settings()
        {
            InitializeComponent();

            txtPicPath.Text = Properties.Settings.Default.main_frm_back;

            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            switch (Properties.Settings.Default.mfp)
           {
               case 0:
                   radioNoPic.Checked = true;
                   pictureBox1.Image = null;
                   break;
               case 1:
                   radioDefPic.Checked = true;
                   pictureBox1.Image = Properties.Resources.Archive_shelving_Hull_History_Centre_01;
                   break;
               case 2:
                   radioChoPic.Checked = true;
                   btn_selpic.Enabled = true;
                   if (txtPicPath.Text != "")
                       pictureBox1.Image = Image.FromFile(txtPicPath.Text);
                   break;
           }
        }

        private void btn_selpic_Click(object sender, EventArgs e)
        {
            OpenFileDialog theDialog = new OpenFileDialog();
            theDialog.Title = "انتخاب تصوير زمينه اصلي";
            theDialog.Filter = "Image Files|*.gif;*.jpg;*.jpeg;*.bmp;*.wmf;*.png";
           // theDialog.InitialDirectory = @"C:\";
            if (theDialog.ShowDialog() == DialogResult.OK)
            {
                txtPicPath.Text=theDialog.FileName.ToString();
                pictureBox1.Image = Image.FromFile(txtPicPath.Text);
            }
                    
        }

        private void frm_settings_FormClosing(object sender, FormClosingEventArgs e)
        {


        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.main_frm_back = txtPicPath.Text;
            if (radioNoPic.Checked)
                Properties.Settings.Default.mfp = 0;
            if (radioDefPic.Checked)
                Properties.Settings.Default.mfp = 1;
            if (radioChoPic.Checked)
                Properties.Settings.Default.mfp = 2;

            this.Close();

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frm_settings_Load(object sender, EventArgs e)
        {

        }

        private void radioNoPic_CheckedChanged(object sender, EventArgs e)
        {
            if (radioNoPic.Checked)
                pictureBox1.Image = null;
        }

        private void radioDefPic_CheckedChanged(object sender, EventArgs e)
        {
            if (radioDefPic.Checked)
                pictureBox1.Image = Properties.Resources.Archive_shelving_Hull_History_Centre_01;
        }

        private void radioChoPic_CheckedChanged(object sender, EventArgs e)
        {
            if (radioChoPic.Checked)
            {
                btn_selpic.Enabled = true;
                if (txtPicPath.Text != "")
                    pictureBox1.Image = Image.FromFile(txtPicPath.Text);
            }
        }

 


    }
}
