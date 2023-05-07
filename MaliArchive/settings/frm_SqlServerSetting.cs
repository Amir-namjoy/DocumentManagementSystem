using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MaliArchive.settings;

namespace MaliArchive
{
    public partial class frm_SqlServerSetting : Form
    {
        frmProgress pgs;
        
        public bool testok=false;
        public frm_SqlServerSetting()
        {
            InitializeComponent();
           /* if (Control.IsKeyLocked(Keys.CapsLock))
            {
                MessageBox.Show("The Caps Lock key is ON.");
            }*/
            LoadData();
            
        }

 
        private void LoadData()
        {
            if (ConnectionSetting.SQLServerUsername.Equals(""))
                cmbConnectType.SelectedIndex = 0;
            else
            {
                cmbConnectType.SelectedIndex = 1;
                txtUser.Text = ConnectionSetting.SQLServerUsername;
                txtPassword.Text = ConnectionSetting.SQLServerPassword;
            }
            txtServer.Text = ConnectionSetting.SQLServerName;

        }

  
        private void btnOk_Click(object sender, EventArgs e)
        {
            
            if (txtServer.Text.Trim().Equals(""))
            {
                txtServer.Focus();
                MessageBox.Show("نام سرور را مشخص نمائيد", common.ProgramName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (cmbConnectType.SelectedIndex == 1)
            {
                if (txtUser.Text.Trim().Equals(""))
                {
                    txtUser.Focus();
                    MessageBox.Show("نام کاربر را مشخص نمائيد", common.ProgramName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

/*            if (combSQlServerType.SelectedIndex == )
            {
                if (txtUser.Text.Trim().Equals(""))
                {
                    txtUser.Focus();
                    MessageBox.Show("نام کاربر را مشخص نمائيد", common.ProgramName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }*/

            pgs = new frmProgress();
            pgs.Show();

            
            pgs.lbl_statValue = "در حال برقراري ارتباط با پايگاه داده...";

            if (backgroundWorker_TestConnection.IsBusy != true)
            {
                // Start the asynchronous operation.
                btnOk.Enabled = false;
                backgroundWorker_TestConnection.RunWorkerAsync();
            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

 
        private void cmbConnectType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbConnectType.SelectedIndex == 1)
            {
                lblS3.Enabled = true;
                lblS4.Enabled = true;
                txtUser.Enabled = true;
                txtPassword.Enabled = true;
            }
            else
            {
                lblS3.Enabled = false;
                lblS4.Enabled = false;
                txtUser.Text = "";
                txtPassword.Text = "";
                txtUser.Enabled = false;
                txtPassword.Enabled = false;

            }
        }

        // كنترل ارتباط با پايگاه داده
        private void backgroundWorker_TestConnection_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                BackgroundWorker worker = sender as BackgroundWorker;

                ConnectionManager cm = new ConnectionManager(Functions.filename);
                ConnectionSetting.SQLServerName = txtServer.Text;
                ConnectionSetting.SQLServerPassword = txtPassword.Text;
                ConnectionSetting.SQLServerUsername = txtUser.Text;

                if (cm.TestConnection())
                {
                    DA.ConnectionString = cm.GetConnectionString();
                    cm.SaveSetting();
                    e.Result = true;
                }
                else
                    e.Result = false;
            }
            catch
            {
                e.Result = false;
            }
        }

        // This event handler deals with the results of the background operation. 
        private void backgroundWorker_TestConnection_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
          
            if (e.Cancelled == true)
            {
                pgs.lbl_statValue = "لغو عمليات كنترل ارتباط با پايگاه داده توسط كاربر";
                System.Threading.Thread.Sleep(500);
                pgs.Close();
                btnOk.Enabled = true;
            }
            else if (e.Error != null)
            {
                pgs.lbl_statValue = "Error: " + e.Error.Message;
                pgs.Close();
                btnOk.Enabled = true;
            }
            else
            {
                if ((bool)e.Result)
                {
                    pgs.lbl_statValue = "ارتباط با پايگاه داده برقرار شد";
                    System.Threading.Thread.Sleep(500);
                    pgs.Close();
                    testok = true;
                    ConnectionManager cm = new ConnectionManager(Functions.filename);
                    ConnectionSetting.SQLServerName = txtServer.Text;
                    ConnectionSetting.SQLServerPassword = txtPassword.Text;
                    ConnectionSetting.SQLServerUsername = txtUser.Text;
                    ConnectionSetting.DatabaseName = "MaliArchiveDB";
                    cm.SaveSetting();
                    this.Close();
                }
                else
                {
                    pgs.lbl_statValue = "!خطا در برقراري ارتباط با پايگاه ";
                    System.Threading.Thread.Sleep(500);
                    testok = false;
                    pgs.Close();
                    btnOk.Enabled = true;
                    MessageBox.Show("!ارتباط با پايگاه داده برقرار نشد", common.ProgramName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            
        }


    }
}
