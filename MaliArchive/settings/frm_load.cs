using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Threading;
using FarsiLibrary.Win;
using FarsiLibrary.Win.Controls;
using FarsiLibrary.Win.Enums;

namespace MaliArchive
{
    public partial class frm_load : Form
    {

        private const string InRun_MESSAGEBOX = "InRunMessageBox";

        public frm_load()
        {
            InitializeComponent();
            common.inLoad = true;
            labelVersion.Text = "نگارش: " + ProductVersion;
           backgroundWorker1.WorkerReportsProgress = true;
           // backgroundWorker1.WorkerSupportsCancellation = true;
        }
        System.Windows.Forms.Timer tmr,tmr2;
        int count = 0; 
       
        public bool dbconnection = false;
                
        private void frm_load_Shown(object sender, EventArgs e)
        {
            tasks.Text = "بررسي پردازش هاي در حال اجرا...";
            System.Diagnostics.Process[] prss = System.Diagnostics.Process.GetProcessesByName("MaliArchive");
            if (prss != null)
            {
                if (prss.Length > 1)
                {
                    FAMessageBox msg;
                    msg = FAMessageBoxManager.GetMessageBox(InRun_MESSAGEBOX);
                    if (FAMessageBoxManager.GetMessageBox(InRun_MESSAGEBOX) == null)
                    {
                        msg = FAMessageBoxManager.CreateMessageBox(InRun_MESSAGEBOX, true);
                        /*msg.AddButton("خير", "NO");
                        msg.AddButton("بله", "Yes");*/
                    }
            
                    // msg.AllowSaveResponse = true;
                    //msg.SaveResponseText = "سوال را تکرار نکن";
                    msg.Text = "برنامه هم اکنون در حال اجرا مي باشد و نمي توانيد مجددا آنرا اجرا نمائيد";
                    msg.Caption = common.ProgramName;
                    msg.Icon = FarsiMessageBoxExIcon.Warning;
                    msg.PlaySound = true;
                    msg.Show(this);
                    //MessageBox.Show("برنامه هم اکنون در حال اجرا مي باشد و نمي توانيد مجددا آنرا اجرا نمائيد", common.ProgramName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //prss[1].Kill();
                    
                    Application.Exit();
                }
            }

            tasks.Text = "بررسي تنظيمات...";
            Functions.filename = System.IO.Directory.GetCurrentDirectory() + "\\" + "MaliArchive.ansf";
    
            //tasks.Text = "در حال راه اندازي...";
            tmr = new System.Windows.Forms.Timer();
            //set time interval 3 sec
             tmr.Interval = 1;
            //starts the timer
            tmr.Start();
            tmr.Tick += tmr_Tick;


        }
        void tmr_Tick(object sender, EventArgs e)
        {


            if (count >= 50)
            {
                tmr.Stop();
                count = 0;
                tasks.Text = "در حال بارگذاري مقادير...";
                tmr2 = new System.Windows.Forms.Timer();
                tmr2.Interval = 1;
                //starts the timer2
                tmr2.Start();
                tmr2.Tick += tmr2_Tick;
              
            }
            else
            {
               count++;
                //tmr.Interval = tmr.Interval +1;
            }

        }
        void tmr2_Tick(object sender, EventArgs e)
        {


            if (count >= 100)
            {
                tmr2.Stop();
               /* for (int i = 0; i < 100; i++)
                {
                    this.Opacity -= 0.01;
                    System.Threading.Thread.Sleep(10);
                }*/

                backgroundWorker1.RunWorkerAsync();
            }
            else
            {
                count++;
                //tmr.Interval = tmr.Interval +1;
            }

        }
        
        private void minimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
            //Isminimized = true;
        }

        private void close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;

            FAThemeManager.Theme = FarsiLibrary.Win.Enums.ThemeTypes.Office2003;  
         
            String path = System.IO.Directory.GetCurrentDirectory();
            ConnectionManager cm = new ConnectionManager(Functions.filename);
            if (!System.IO.File.Exists(Functions.filename))
            {
                CreatePaperLessConnection();
            }
            cm.LoadSetting();
            backgroundWorker1.ReportProgress(50);
            Thread.Sleep(500);
            if (cm.TestConnection())
            {
                e.Result = true;
            }
            else
                e.Result = false;
   
        }

        // This event handler deals with the results of the background operation. 
        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled == true)
            {
                tasks.Text = "لغو عمليات كنترل ارتباط با پايگاه داده توسط كاربر";
                System.Threading.Thread.Sleep(500);
                
            }
            else if (e.Error != null)
            {
                tasks.Text = "Error: " + e.Error.Message;
            }
            else
            {
                if ((bool)e.Result)
                {
                    tasks.Text = "ارتباط با پايگاه داده برقرار شد";
                    System.Threading.Thread.Sleep(500);
                    dbconnection = true;
                }
                else
                {
                    tasks.Text = "!خطا در برقراري ارتباط با پايگاه ";
                    System.Threading.Thread.Sleep(500);
                    dbconnection = false;
                }
            }
            this.Close();
        }
 
        private static void CreatePaperLessConnection()
        {
            ConnectionManager cm = new ConnectionManager(Functions.filename);
            cm.SaveSetting();
        }


        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            tasks.Text = "در حال برقراري ارتباط با پايگاه داده...";
        }

        private void frm_load_FormClosed(object sender, FormClosedEventArgs e)
        {
            common.inLoad = false;
        }

    }
}
