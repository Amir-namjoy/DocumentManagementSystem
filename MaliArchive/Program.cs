using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using MaliArchive;
using System.Threading;


namespace MaliArchive
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("fa-IR");
            Thread.CurrentThread.CurrentUICulture = Thread.CurrentThread.CurrentCulture;
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            
            frm_load frm_load_i = new frm_load();
            frm_load_i.ShowDialog();
            if (!frm_load_i.dbconnection)
            {
                frm_SqlServerSetting frmconnctionstring = new frm_SqlServerSetting();
                frmconnctionstring.ShowDialog();
                if (!frmconnctionstring.testok)
                {
                    Application.Exit();
                    return;
                }
            }
                      
 
            frm_login frm_login_i = new frm_login();
            frm_login_i.ShowDialog();
           
            if (frm_login_i.LogonSuccessful)
             {
                Application.Run(new frm_main());
             }
             else
             {
                Application.Exit();
             }  
            
            
           /*DA.ConnectionString = "Data Source=.;Initial Catalog=MyArchiveDB;Integrated Security=SSPI;";
            cUser.uid = "13";
            cUser.username = "96049325";
            cUser.name = "امير";
            cUser.family = "نامجوي";
            cUser.addNew = true;
            cUser.addUser = true;
            cUser.allowLogin = true;
            cUser.editdoc = true;
            cUser.editUser = true;
            cUser.showdoc = true;
            cUser.viewLog = true;
            cUser.gozaresh = true;
            cUser.manageUsers = true;
            cUser.manageAshkas = true;
            Application.Run(new frm_main());*/

        }

    }

}
