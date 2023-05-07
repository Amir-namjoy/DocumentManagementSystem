using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Globalization;
using System.Data.SqlClient;
using System.Runtime.InteropServices;
using FarsiLibrary.Utils;
using FarsiLibrary.Win.Controls;
using FarsiLibrary.Win.Enums;

namespace MaliArchive
{
    public partial class frm_main : Form
    {
 
        string frm_caption = "نرم افزار بايگاني اسناد ---  اداره كل امور مالي و ذيحسابي";
        int count = 1;

        private const string Exit_MESSAGEBOX = "ExitMessageBox";
              
        frm_add_new frm_add_new_i;
        FrmGozaresh frm_gozaresh_i;
        frm_viewlogs frm_viewlog_i;
        frm_peygiri_amanat frm_peygiri_amanat_i;
        frm_usersmanagement frm_um;
        frm_amanatgirandegan frm_amanatgirandegan_i;
        frm_savabeg_amanat frm_savabeg_amanat_i;

        public frm_main()
        {
            InitializeComponent();
            
            // كنترل دسترسي هاي كاربر
            AddDoctoolStripButton.Enabled = cUser.addNew;
            ReporttoolStripButton.Enabled = cUser.gozaresh;
            usersLogToolStripMenuItem.Enabled = cUser.viewLog;
            userManagementToolStripMenuItem.Enabled = cUser.manageUsers;
            ashkasToolStripMenuItem.Enabled = cUser.manageAshkas;

            
           

            this.Text = "نرم افزار بايگاني اسناد ---  اداره كل امور مالي و ذيحسابي";
            timer_frm_caption.Enabled = Properties.Settings.Default.anim_cap;

            back_image();
            toolStripStatusLabel3.Text = "كاربر جاري: " + cUser.name + " " + cUser.family;
            //toolStripLabelKartabl.Text = "كارتابل ( " + cUser.name + " " + cUser.family + " ) / پيام هاي ورودي";
            PersianDate pd = PersianDate.Now;
          // toolStripStatusLabel2.Text = common.persian_date(DateTime.Now);
            toolStripStatusLabel2.Text = pd.ToString("D");
            toolStripStatusLabelNegaresh.Text = "نگارش: " + ProductVersion;
      
            //this.radTreeView1.Nodes.Add(new Telerik.WinControls.UI.RadTreeNode("كارپوشه (امير نامجوي)", Properties.Resources.folder_share)); 
           // this.radTreeView1.Nodes[0].Nodes.Add(new Telerik.WinControls.UI.RadTreeNode("پيام هاي ورودي", Properties.Resources.folder_share));
            
        }

         private void back_image()
        {
            switch (Properties.Settings.Default.mfp)
            {
                case 0:
                    this.BackgroundImage = null;
                    break;
                case 1:
                    this.BackgroundImage = Properties.Resources.Archive_shelving_Hull_History_Centre_01;
                    break;
                case 2:
                    if (Properties.Settings.Default.main_frm_back != "")
                        this.BackgroundImage = Image.FromFile(Properties.Settings.Default.main_frm_back);
                    break;
            }
            
            switch(Properties.Settings.Default.frm_main_pic_lay)
            {
                /*None
                Title
                Center
                Stretch
                Zoom*/
                case "None":
                    this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
                    break;
                case "Title":
                    this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Tile;
                    break;
                case "Center":
                    this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
                    break;
                case "Stretch":
                    this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
                    break;
                case "Zoom":
                    this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
                    break;
            }
            
        }
        private void timer_frm_Caption_Tick(object sender, EventArgs e)
        {
            if (frm_caption.Length < count)
                this.Text = frm_caption;
            else
                this.Text = frm_caption.Substring(0, count);

            count++;
                if (frm_caption.Length+50 < count)
                    count=1;
 
        }

        private void خروجToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void بايگانيپروندToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void frm_add_new_i_FormClosing(object sender, FormClosingEventArgs e)
        {
            frm_add_new_i = null;
        }

        private void گزارش_پرونده_هاToolStripMenuItem_Click(object sender, EventArgs e)
        {


        }

       /* private void frm_gozaresh_i_FormClosing(object sender, FormClosingEventArgs e)
        {
            frm_gozaresh_i = null;
        }
        */
 
        private void دربارهToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_about frm_about_i = new frm_about();
            frm_about_i.ShowDialog();
        }

        private void frm_main_FormClosing(object sender, FormClosingEventArgs e)
        {

            if (!common.inLoad)
            {
                FAMessageBox msg;

                msg = FAMessageBoxManager.GetMessageBox(Exit_MESSAGEBOX);
                if (FAMessageBoxManager.GetMessageBox(Exit_MESSAGEBOX) == null)
                {
                    msg = FAMessageBoxManager.CreateMessageBox(Exit_MESSAGEBOX, true);
                    msg.AddButton("خير", "NO");
                    msg.AddButton("بله", "Yes");

                    // msg.AddButtons(MessageBoxButtons.YesNo);
                }

                // msg.AllowSaveResponse = true;
                //msg.SaveResponseText = "سوال را تکرار نکن";
                msg.Text = "آيا مايل به خروج از برنامه هستيد؟";
                msg.Caption = "خروج از برنامه بايگاني";
                msg.Icon = FarsiMessageBoxExIcon.Question;
                msg.PlaySound = true;


                if (msg.Show(this) == "NO")
                {
                    e.Cancel = true;
                }
                else
                {
                    common.writelog(11, "خروج كاربر از سيستم",
                        string.Format(" كاربر با نام كاربري {0} و شناسه {1} از سيستم خارج شد", cUser.username, cUser.uid), cUser.uid, "");
                    Properties.Settings.Default.Save();
                    common.DeleteTempFolder("");
                    /* for (int i = 0; i < 100; i++)
                     {
                         this.Opacity -= 0.01;
                         System.Threading.Thread.Sleep(10);
                     }*/
                }
            }   

        }

        private void frm_main_Load(object sender, EventArgs e)
        {
     
       
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = DateTime.Now.ToString("h:mm:ss tt");
        }


 
        private void MaliArchive_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            WindowState = FormWindowState.Maximized;
        }

        private void مديريتكاربرانToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_usersmanagement frm_um = new frm_usersmanagement();
            frm_um.ShowDialog();

        }

 
        private void frm_viewlog_i_FormClosing(object sender, FormClosingEventArgs e)
        {
            frm_viewlog_i = null;
        }

        private void اشخاصامانتگيرندهپروندهToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_amanatgirandegan frm_amanatgirandegan_i = new frm_amanatgirandegan();
            frm_amanatgirandegan_i.ShowDialog();
        }

 
        private void frm_peygiri_amanat_i_FormClosing(object sender, FormClosingEventArgs e)
        {
            frm_peygiri_amanat_i = null;
        }

 

        private void ReporttoolStripButton_Click(object sender, EventArgs e)
        {
            //FrmGozaresh frm_gozaresh_i = new FrmGozaresh();
         //   frm_gozaresh_i.Show();
            if (frm_gozaresh_i != null)
            {
                frm_gozaresh_i.Show();
                frm_gozaresh_i.Activate();
            }
            else
            {
                frm_gozaresh_i = new FrmGozaresh();
               // frm_gozaresh_i.MdiParent = this;
                frm_gozaresh_i.Show();
                frm_gozaresh_i.FormClosing += frm_gozaresh_i_FormClosing;
            }
        }

        private void frm_gozaresh_i_FormClosing(object sender, FormClosingEventArgs e)
        {
            frm_gozaresh_i = null;
        }

        private void PeygiritoolStripButton_Click(object sender, EventArgs e)
        {
            if (frm_peygiri_amanat_i != null)
            {
                frm_peygiri_amanat_i.Show();
                frm_peygiri_amanat_i.Activate();
            }
            else
            {
                frm_peygiri_amanat_i = new frm_peygiri_amanat();
               // frm_peygiri_amanat_i.MdiParent = this;
                frm_peygiri_amanat_i.Show();
                frm_peygiri_amanat_i.FormClosing += frm_peygiri_amanat_i_FormClosing;
            }
        }

        private void changePassToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_changepass_curent frm_ccup_i = new frm_changepass_curent();
            frm_ccup_i.ShowDialog();
        }

        private void userManagementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            if (frm_um != null)
            {
                frm_um.Show();
                frm_um.Activate();
            }
            else
            {
                frm_um = new frm_usersmanagement();

                frm_um.Show();
                frm_um.FormClosing += frm_um_FormClosing;
            }
            
            frm_um.Show();
            
        }

        private void frm_um_FormClosing(object sender, FormClosingEventArgs e)
        {
            frm_um = null;
        }


        private void ashkasToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (frm_amanatgirandegan_i != null)
            {

                frm_amanatgirandegan_i.Show();
                frm_amanatgirandegan_i.Activate();
            }
            else
            {
                frm_amanatgirandegan_i = new frm_amanatgirandegan();
                frm_amanatgirandegan_i.Show();
                frm_amanatgirandegan_i.FormClosing += frm_amanatgirandegan_i_FormClosing;
            }
        }
        
        private void frm_amanatgirandegan_i_FormClosing(object sender, FormClosingEventArgs e)
        {
            frm_amanatgirandegan_i = null;
        }

        private void programSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_settings frm_settings_i = new frm_settings();
            frm_settings_i.ShowDialog();
            if (Properties.Settings.Default.anim_cap)
                timer_frm_caption.Enabled = true;
            else
            {
                timer_frm_caption.Enabled = false;
                this.Text = "نرم افزار بايگاني اسناد ---  اداره كل امور مالي و ذيحسابي";
            }
            back_image();
        }

        private void usersLogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frm_viewlog_i != null)
            {
                frm_viewlog_i.Show();
                frm_viewlog_i.Activate();
            }
            else
            {
                frm_viewlog_i = new frm_viewlogs();
                //frm_viewlog_i.MdiParent = this;
                frm_viewlog_i.Show();
                frm_viewlog_i.FormClosing += frm_viewlog_i_FormClosing;
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_about frm_about_i = new frm_about();
            frm_about_i.ShowDialog();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddDoctoolStripButton_Click(object sender, EventArgs e)
        {
            if (frm_add_new_i != null)
            {

                frm_add_new_i.Show();
                frm_add_new_i.Activate();
            }
            else
            {
                frm_add_new_i = new frm_add_new();
               // frm_add_new_i.MdiParent = this;
               // frm_add_new_i.TopLevel = false;
              //  frm_add_new_i.AutoScroll = true;
               // splitContainer1.Panel2.Controls.Add(frm_add_new_i);
                //frm_add_new_i.FormBorderStyle = FormBorderStyle.None;
                frm_add_new_i.Show();
                frm_add_new_i.FormClosing += frm_add_new_i_FormClosing;
            }
        }

        [DllImport("user32.dll")]
        public static extern bool LockWorkStation();
        private void windowsLockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LockWorkStation();
        }

        private void خروجToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void تغييررمزعبورToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_changepass_curent frm_ccup_i = new frm_changepass_curent();
            frm_ccup_i.ShowDialog();
        }

        private void amanattoolStripButton_Click(object sender, EventArgs e)
        {
            if (frm_savabeg_amanat_i != null)
            {
                frm_savabeg_amanat_i.Show();
                frm_savabeg_amanat_i.Activate();
            }
            else
            {
                frm_savabeg_amanat_i = new frm_savabeg_amanat();
                // frm_peygiri_amanat_i.MdiParent = this;
                frm_savabeg_amanat_i.Show();
                frm_savabeg_amanat_i.FormClosing += frm_savabeg_amanat_i_FormClosing;
            }
        }
        private void frm_savabeg_amanat_i_FormClosing(object sender, FormClosingEventArgs e)
        {
            frm_savabeg_amanat_i = null;
        }
       

 
    }
}
