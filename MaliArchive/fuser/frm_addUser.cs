using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using FarsiLibrary.Win.Controls;
using FarsiLibrary.Win.Enums;

namespace MaliArchive
{
    public partial class frm_addUser : Form
    {
        public frm_addUser()
        {
            InitializeComponent();
            common.setLanguageToFarsi();
        }
        
        private const string AddUser_MESSAGEBOX = "AddUserBox";

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                FAMessageBox msg;
                msg = FAMessageBoxManager.GetMessageBox(AddUser_MESSAGEBOX);
                if (FAMessageBoxManager.GetMessageBox(AddUser_MESSAGEBOX) == null)
                {
                    msg = FAMessageBoxManager.CreateMessageBox(AddUser_MESSAGEBOX, true);
                    msg.AddButtons(MessageBoxButtons.OK);
                }

                // msg.AllowSaveResponse = true;
                //msg.SaveResponseText = "سوال را تکرار نکن";
                msg.Caption = "افزودن كاربر جديد";
                msg.Icon = FarsiMessageBoxExIcon.Warning;
                msg.PlaySound = true;
                msg.Text = "";
               
                if (txtpass.Text != txtpass2.Text)
                    msg.Text += "رمزهاي عبور وارد شده يكي نيستند*\n";

                if (txtpass.Text.Trim() == "")
                    msg.Text += "رمز عبور را وارد كنيد*\n";
                
                if (txtname.Text.Trim()=="")
                    msg.Text += "نام را وارد كنيد*\n";
                
                if (txtfamily.Text.Trim() == "")
                    msg.Text += "نام خانوادگي را وارد كنيد*\n";
                
                if (txtusername.Text.Trim() == "")
                    msg.Text += "نام كاربري را وارد كنيد*\n";

                if (txtusername.Text.Trim() != "" && (DA.check_is_in_table("select name from users where username='" + txtusername.Text + "'")))
                    msg.Text += "*نام كاربري وارد شده تكراري مي باشد\n";
                if (txtpersonalId.Text.Trim() != "" && (DA.check_is_in_table("select name from users where personalid='" + txtpersonalId.Text + "'")))
                    msg.Text += "*شماره پرسنلي وارد شده تكراري مي باشد\n";

                if (msg.Text.Length > 0)
                {
                    msg.Show(this);
                    FAMessageBoxManager.DeleteMessageBox(AddUser_MESSAGEBOX);
                    return;
                }

                using (SqlConnection myconnection = new SqlConnection(DA.ConnectionString))
                {
                    using (SqlCommand mycommand = new SqlCommand())
                    {
                        myconnection.Open();
                        mycommand.Connection = myconnection;
                        string q = "insert into users values('" + txtusername.Text.Trim() + "','" + common.GetHashedPassword(txtpass.Text)
                                    + "','" + txtname.Text + "','" + txtfamily.Text + "','" + txtpersonalId.Text + "','" + txtsemat.Text
                                    + "','" + combGender.Text + "','" + cLBpermissions.GetItemChecked(0) + "','"
                                    + cLBpermissions.GetItemChecked(1) + "','" + cLBpermissions.GetItemChecked(2) + "','"
                                    + cLBpermissions.GetItemChecked(3) + "','" + cLBpermissions.GetItemChecked(4) + "','"
                                    + cLBpermissions.GetItemChecked(5) + "','" + cLBpermissions.GetItemChecked(6) + "','"
                                    + cLBpermissions.GetItemChecked(7) + "','" + cLBpermissions.GetItemChecked(8) + "','"
                                    + checkAllowLogin.Checked + "')"; 
                        
                        mycommand.CommandText = q;
                        mycommand.ExecuteNonQuery();

                        string log = "  نام كاربري     " + txtusername.Text.Trim() +"     نام      " + txtname.Text
                                   + "  نام خانوادگي     " + txtfamily.Text + "    شماره پرسنلي    " + txtpersonalId.Text
                                   + "  سمت     " + txtsemat.Text + "  جنسيت    " + combGender.Text + "        "
                                   + cLBpermissions.Items[0].ToString() + "  " + cLBpermissions.GetItemChecked(0)
                                   + cLBpermissions.Items[1].ToString() + "  " + cLBpermissions.GetItemChecked(1)
                                   + cLBpermissions.Items[2].ToString() + "  " + cLBpermissions.GetItemChecked(2)
                                   + cLBpermissions.Items[3].ToString() + "  " + cLBpermissions.GetItemChecked(3)
                                   + cLBpermissions.Items[4].ToString() + "  " + cLBpermissions.GetItemChecked(4)
                                   + cLBpermissions.Items[5].ToString() + "  " + cLBpermissions.GetItemChecked(5)
                                   + cLBpermissions.Items[6].ToString() + "  " + cLBpermissions.GetItemChecked(6)
                                   + cLBpermissions.Items[7].ToString() + "  " + cLBpermissions.GetItemChecked(7)
                                   + cLBpermissions.Items[8].ToString() + "  " + cLBpermissions.GetItemChecked(8)
                                   + "  اجازه ورود به سيستم     " + checkAllowLogin.Checked;
                        
                        common.writelog(3, "ايجاد كاربر جديد", log,  cUser.uid,"");
                        MessageBox.Show("اطلاعات كاربر جديد با موفقیت در پایگاه ثبت شد", "كاربر جديد", MessageBoxButtons.OK, MessageBoxIcon.Information);

                     }
                    myconnection.Close();
                }

                this.Close();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.ToString(), "بروز خطا", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }



 
    }
}
