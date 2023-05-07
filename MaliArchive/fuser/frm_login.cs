using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Net.NetworkInformation;
using System.Net;
using System.Xml.Serialization;
using System.IO;
using System.Collections;
using FarsiLibrary.Win.Controls;
using FarsiLibrary.Win.Enums;

namespace MaliArchive
{
    public partial class frm_login : Form
    {
        public frm_login()
        {
            InitializeComponent();
            xmlFilePath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\MaliArchive";
        }

        private const string Login_MESSAGEBOX = "LoginBox";
        public bool LogonSuccessful = false;

        LogedUser Info = new LogedUser();
        string xmlFilePath = "";
        string xmlFileName = "\\Logins.xml";

        [Serializable]
        public class Users
        {
            /// <summary>
            /// Default constructor for this class (required for serialization).
            /// </summary>
            public Users()
            {
            }

            // Specify that this field should be serialized as an XML attribute 
            // instead of an element to demonstrate the formatting differences in an XML file. 
            [XmlAttribute]
            public string UserName = null;

            [XmlAttribute]
            public bool LastUser = false;

        }

        [XmlRootAttribute("Logins", Namespace = "", IsNullable = false)]
        public class LogedUser
        {

            /// <summary>
            /// Default constructor for this class (required for serialization).
            /// </summary>
            public LogedUser()
            {
            }

            // Set this 'DateTimeValue' field to be an attribute of the root node.
            [XmlAttributeAttribute(DataType = "date")]
            public DateTime Create = DateTime.Now;

            // Serializes an ArrayList as a "LogedUsers" array of XML elements of custom type EmailAddress named "EmailAddress".
            [XmlArray("LogedUsers"), XmlArrayItem("LogedUser", typeof(Users))]
            public ArrayList listUsers = new System.Collections.ArrayList();
        }

        public void Write_Into_XML_File()
        {
            if (!Directory.Exists(xmlFilePath))
            {
                Directory.CreateDirectory(xmlFilePath);
            }
            FileStream XmlStream = new
            FileStream(xmlFilePath + xmlFileName, FileMode.Create, FileAccess.Write);
            XmlSerializer XmlSerializer = new XmlSerializer(typeof(LogedUser));
            XmlSerializer.Serialize(XmlStream, Info);
            XmlStream.Close();
        }
        
        private void btn_cancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void login()
        {
            using (SqlConnection myconnection = new SqlConnection(DA.ConnectionString))
            {
                using (SqlCommand mycommand = new SqlCommand())
                {
                    myconnection.Open();
                    mycommand.Connection = myconnection;

                    mycommand.Parameters.AddWithValue("@user", comb_username.Text);
                    mycommand.Parameters.AddWithValue("@pass", common.GetHashedPassword(txt_password.Text));
                    string q = "select * from users where username=@user and password=@pass";
                    mycommand.CommandText = q;
                    SqlDataReader myreader = mycommand.ExecuteReader();

                    FAMessageBox msgAddDoc;
                    msgAddDoc = FAMessageBoxManager.GetMessageBox(Login_MESSAGEBOX);
                    if (FAMessageBoxManager.GetMessageBox(Login_MESSAGEBOX) == null)
                    {
                        msgAddDoc = FAMessageBoxManager.CreateMessageBox(Login_MESSAGEBOX, true);
                        msgAddDoc.AddButtons(MessageBoxButtons.OK);
                    }
                   
                    if (myreader.HasRows)
                    {

                        while (myreader.Read())
                        {
                            cUser.uid = myreader["uid"].ToString();
                            cUser.username = myreader["username"].ToString();
                            cUser.name = myreader["name"].ToString();
                            cUser.family = myreader["family"].ToString();

                            cUser.addNew = (bool)myreader["addNew"];
                            cUser.editdoc = (bool)myreader["editdoc"];
                            cUser.showdoc = (bool)myreader["showdoc"];
                            cUser.gozaresh = (bool)myreader["gozaresh"];
                            cUser.addUser = (bool)myreader["addUser"]; ;
                            cUser.editUser = (bool)myreader["editUser"];
                            cUser.viewLog = (bool)myreader["viewLog"];
                            cUser.allowLogin = (bool)myreader["allowLogin"];
                            cUser.manageUsers = (bool)myreader["manageUsers"];
                            cUser.manageAshkas = (bool)myreader["manageAshkas"];

                            if (cUser.allowLogin)
                            {
                                LogonSuccessful = true;
                                //Login XML File
                                bool userbood = false;
                                foreach (Users a in Info.listUsers)
                                {
                                    if (a.UserName == comb_username.Text)
                                    {
                                        a.LastUser = true;
                                        userbood = true;
                                    }
                                    else
                                        a.LastUser = false;

                                }

                                if (!userbood)
                                {
                                    Users user = new Users();
                                    user.UserName = comb_username.Text;
                                    user.LastUser = true;
                                    Info.listUsers.Add(user);
                                }

                                Write_Into_XML_File();
                                //بدست آوردن مك آدرس
                                var macAddr = (from nic in NetworkInterface.GetAllNetworkInterfaces()
                                                where nic.OperationalStatus == OperationalStatus.Up
                                                select nic.GetPhysicalAddress().ToString()).FirstOrDefault();
                                IPAddress ip = null;
                                String LogedIP = "";
                                if (common.GetResolvedConnecionIPAddress(Environment.MachineName, out ip))
                                {
                                    LogedIP = ip.ToString();
                                }
                                common.writelog(1, "ورود كاربر",
                                    string.Format("ورود موفق به  سيستم توسط كاربر با [نام كاربري: {0}]  [از ماشين با نام: {1}] و [IP: {2}] و [MacAddress: {3}] [مدل اعتبار سنجي :Normal] ", cUser.username, Environment.MachineName, LogedIP , macAddr.ToString())
                                    , cUser.uid, "");
                            }
                            else
                            {
                                common.writelog(17, "عدم اجازه ورود به سيستم", cUser.username, cUser.uid, "");
                                
                                msgAddDoc.Caption = "ورود به سيستم";
                                msgAddDoc.Icon = FarsiMessageBoxExIcon.Stop;
                                msgAddDoc.PlaySound = true;
                                msgAddDoc.Text = "!شما اجازه ورود به سيستم را نداريد";

                                msgAddDoc.Show(this);
                                FAMessageBoxManager.DeleteMessageBox(Login_MESSAGEBOX);
                            }
                        }
                        this.Close();

                    }
                    else
                    {

                        common.writelog(2, "ورود رمز اشتباه", comb_username.Text, "", "");
                        
                        msgAddDoc.Caption = "ورود به سيستم";
                        msgAddDoc.Icon = FarsiMessageBoxExIcon.Stop;
                        msgAddDoc.PlaySound = true;
                        msgAddDoc.Text = "نام کاربری یا کلمه عبور وارد شده اشتباه است!";

                        msgAddDoc.Show(this);
                        FAMessageBoxManager.DeleteMessageBox(Login_MESSAGEBOX);

                    }
                    myconnection.Close();
                }
            } 
        }

        private void btn_ok_Click(object sender, EventArgs e)
        {
            login();
        }

        private void frm_login_Load(object sender, EventArgs e)
        {
            if (File.Exists(xmlFilePath + xmlFileName))
            {

                FileStream XmlStream = new FileStream(xmlFilePath + xmlFileName, FileMode.Open, FileAccess.Read);
                XmlSerializer XmlReader = new XmlSerializer(typeof(LogedUser));

                Info = (LogedUser)XmlReader.Deserialize(XmlStream);

                XmlStream.Close();

                foreach (Users a in Info.listUsers)
                {
                    comb_username.Items.Add(a.UserName);
                    if (a.LastUser)
                        comb_username.SelectedIndex = comb_username.Items.Count - 1;
                }


            }
            //txt_password.Focus();
            if (comb_username.Text == "")
                this.ActiveControl = comb_username;
            else
                this.ActiveControl = txt_password;
            
        }

  
    }
}
