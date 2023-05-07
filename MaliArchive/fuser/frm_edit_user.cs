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
    public partial class frm_edit_user : Form
    {
        string uid;
        User UserbeforeChange = new User();
        private const string EditAskhas_MESSAGEBOX = "EditUserBox";
        public frm_edit_user(User seluser)
        {
            InitializeComponent();
            common.setLanguageToFarsi();

            UserbeforeChange = seluser;
            txtname.Text = seluser.name;
            txtfamily.Text = seluser.family;
            txtusername.Text = seluser.username;
            txtpersonalId.Text = seluser.personalid;
            txtsemat.Text = seluser.semat;
            checkAllowLogin.Checked = seluser.allowLogin;
            combGender.Text = seluser.gender;

            cLBpermissions.SetItemChecked(0, seluser.addNew);
            cLBpermissions.SetItemChecked(1, seluser.showdoc);
            cLBpermissions.SetItemChecked(2, seluser.editdoc);
            cLBpermissions.SetItemChecked(3, seluser.gozaresh);
            cLBpermissions.SetItemChecked(4, seluser.manageUsers);
            cLBpermissions.SetItemChecked(5, seluser.addUser);
            cLBpermissions.SetItemChecked(6, seluser.editUser);
            cLBpermissions.SetItemChecked(7, seluser.manageAshkas);
            cLBpermissions.SetItemChecked(8, seluser.viewLog);

            uid = seluser.uid;

        }

        private void btnChangepass_Click(object sender, EventArgs e)
        {
            frm_changepass frm_changepass_i = new frm_changepass(uid, txtusername.Text,txtname.Text,txtfamily.Text);
            frm_changepass_i.ShowDialog();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                FAMessageBox msg;
                msg = FAMessageBoxManager.GetMessageBox(EditAskhas_MESSAGEBOX);
                if (FAMessageBoxManager.GetMessageBox(EditAskhas_MESSAGEBOX) == null)
                {
                    msg = FAMessageBoxManager.CreateMessageBox(EditAskhas_MESSAGEBOX, true);
                    msg.AddButtons(MessageBoxButtons.OK);
                }

                // msg.AllowSaveResponse = true;
                //msg.SaveResponseText = "سوال را تکرار نکن";
                msg.Caption = "ويرايش كاربر";
                msg.Icon = FarsiMessageBoxExIcon.Warning;
                msg.PlaySound = true;
                msg.Text = "";

                if (txtname.Text.Trim() == "")
                    msg.Text += "نام را وارد كنيد*\n";

                if (txtfamily.Text.Trim() == "")
                    msg.Text += "نام خانوادگي را وارد كنيد*\n";

                if (txtusername.Text.Trim() == "")
                    msg.Text += "نام كاربري را وارد كنيد*\n";

                if (txtname.Text.Trim() == "")
                    msg.Text += "نام خانوادگي و نام شخص را وارد كنيد*\n";
                
                if (txtname.Text.Trim() != "" && (DA.check_is_in_table("select name from users where name='"
                    + txtname.Text + "' and family='" + txtfamily.Text + "' and uid !='" + uid + "'")))
                    msg.Text += "*نام خانوادگي و نام وارد شده تكراري مي باشد\n";
                
                if (txtpersonalId.Text.Trim() != "" && (DA.check_is_in_table("select name from users where personalid='"
                    + txtpersonalId.Text + "'" + " and uid !='" + uid + "'")))
                    msg.Text += "*شماره پرسنلي وارد شده تكراري مي باشد\n";

                if (msg.Text.Length > 0)
                {
                    msg.Show(this);
                    FAMessageBoxManager.DeleteMessageBox(EditAskhas_MESSAGEBOX);
                    return;
                }

                using (SqlConnection myconnection = new SqlConnection(DA.ConnectionString))
                {
                    using (SqlCommand mycommand = new SqlCommand())
                    {
                        myconnection.Open();
                        mycommand.Connection = myconnection;
 
                        string q = "update users set username='" + txtusername.Text.Trim() + "', name='" + txtname.Text + "', family='" + txtfamily.Text 
                            + "', personalid='" + txtpersonalId.Text + "', semat='" + txtsemat.Text + "', gender='" + combGender.Text 
                            + "', addnew='" + cLBpermissions.GetItemChecked(0) + "', showdoc='" + cLBpermissions.GetItemChecked(1)
                            + "', editdoc='" + cLBpermissions.GetItemChecked(2) + "', gozaresh='" + cLBpermissions.GetItemChecked(3)
                            + "', manageusers='" + cLBpermissions.GetItemChecked(4) + "', adduser='" + cLBpermissions.GetItemChecked(5)
                            + "', edituser='" + cLBpermissions.GetItemChecked(6) + "', manageAshkas='" + cLBpermissions.GetItemChecked(7)
                            + "', viewlog='" + cLBpermissions.GetItemChecked(8) + "', allowlogin='" + checkAllowLogin.Checked 
                            + "' where uid=" + uid;
                        mycommand.CommandText = q;
                        mycommand.ExecuteNonQuery();

                        common.TempUser.username = txtusername.Text;
                        common.TempUser.name = txtname.Text;
                        common.TempUser.family = txtfamily.Text;
                        common.TempUser.personalid = txtpersonalId.Text;
                        common.TempUser.semat = txtsemat.Text;
                        common.TempUser.gender = combGender.Text;
                        common.TempUser.addNew = cLBpermissions.GetItemChecked(0);
                        common.TempUser.showdoc = cLBpermissions.GetItemChecked(1);
                        common.TempUser.editdoc = cLBpermissions.GetItemChecked(2);
                        common.TempUser.gozaresh = cLBpermissions.GetItemChecked(3);
                        common.TempUser.manageUsers = cLBpermissions.GetItemChecked(4);
                        common.TempUser.addUser = cLBpermissions.GetItemChecked(5);
                        common.TempUser.editUser = cLBpermissions.GetItemChecked(6);
                        common.TempUser.manageAshkas = cLBpermissions.GetItemChecked(7);
                        common.TempUser.viewLog = cLBpermissions.GetItemChecked(8);
                        common.TempUser.allowLogin = checkAllowLogin.Checked;

                        string log = "";

                        if (UserbeforeChange.username.Trim() != txtusername.Text.Trim())
                            log += string.Format(" نام كاربري از {0} به {1} تغيير يافت \n ", UserbeforeChange.username, txtusername.Text);

                        if (UserbeforeChange.name != txtname.Text)
                            log += string.Format(" نام از {0} به {1} تغيير يافت \n ", UserbeforeChange.name , txtname.Text);

                        if (UserbeforeChange.family != txtfamily.Text)
                            log += string.Format(" نام خانوادگي از {0} به {1} تغيير يافت \n ", UserbeforeChange.family, txtfamily.Text);

                        if (UserbeforeChange.personalid != txtpersonalId.Text)
                            log += string.Format(" شماره پرسنلي از {0} به {1} تغيير يافت \n ", UserbeforeChange.personalid, txtpersonalId.Text);

                        if (UserbeforeChange.semat != txtsemat.Text)
                            log += string.Format(" سمت از {0} به {1} تغيير يافت \n ", UserbeforeChange.semat, txtsemat.Text);

                        if (UserbeforeChange.gender != combGender.Text)
                            log += string.Format(" جنسيت از {0} به {1} تغيير يافت \n ", UserbeforeChange.semat, combGender.Text);
                        // دسترسي ها
                        if (UserbeforeChange.addNew != cLBpermissions.GetItemChecked(0))
                            log += string.Format(" دسترسي ثبت پرونده از {0} به {1} تغيير يافت \n ", UserbeforeChange.addNew, cLBpermissions.GetItemChecked(0));

                        if (UserbeforeChange.showdoc != cLBpermissions.GetItemChecked(1))
                            log += string.Format(" دسترسي مشاهده پرونده از {0} به {1} تغيير يافت \n ", UserbeforeChange.showdoc, cLBpermissions.GetItemChecked(1));

                        if (UserbeforeChange.editdoc != cLBpermissions.GetItemChecked(2))
                            log += string.Format(" دسترسي ويرايش پرونده از {0} به {1} تغيير يافت \n ", UserbeforeChange.editdoc, cLBpermissions.GetItemChecked(2));

                        if (UserbeforeChange.gozaresh != cLBpermissions.GetItemChecked(3))
                            log += string.Format(" دسترسي گزارشگيري از {0} به {1} تغيير يافت \n ", UserbeforeChange.gozaresh, cLBpermissions.GetItemChecked(3));

                        if (UserbeforeChange.manageUsers != cLBpermissions.GetItemChecked(4))
                            log += string.Format(" دسترسي مديريت كاربران از {0} به {1} تغيير يافت \n ", UserbeforeChange.manageUsers, cLBpermissions.GetItemChecked(4));

                        if (UserbeforeChange.addUser != cLBpermissions.GetItemChecked(5))
                            log += string.Format(" دسترسي افزودن كاربر جديد از {0} به {1} تغيير يافت \n ", UserbeforeChange.addUser, cLBpermissions.GetItemChecked(5));

                        if (UserbeforeChange.editUser != cLBpermissions.GetItemChecked(6))
                            log += string.Format(" دسترسي ويرايش اطلاعات و دسترسي هاي كاربر از {0} به {1} تغيير يافت \n ", UserbeforeChange.editUser, cLBpermissions.GetItemChecked(6));

                        if (UserbeforeChange.manageAshkas != cLBpermissions.GetItemChecked(7))
                            log += string.Format(" دسترسي مديريت امانت گيرندگان از {0} به {1} تغيير يافت \n ", UserbeforeChange.manageAshkas, cLBpermissions.GetItemChecked(7));

                        if (UserbeforeChange.viewLog != cLBpermissions.GetItemChecked(8))
                            log += string.Format(" دسترسي گزارش رويدادنگاري كاربران از {0} به {1} تغيير يافت \n ", UserbeforeChange.viewLog, cLBpermissions.GetItemChecked(8));

                        if (UserbeforeChange.allowLogin != checkAllowLogin.Checked)
                            log += string.Format(" اجازه ورود به سيستم كاربر از {0} به {1} تغيير يافت \n ", UserbeforeChange.allowLogin, checkAllowLogin.Checked);

                        if (!log.Equals(""))
                            common.writelog(4, "ويرايش اطلاعات كاربر", log, cUser.uid,"");
                        //MessageBox.Show("ويرايش مشخصات كاربر با موفقيت انجام شد", "ويرايش مشخصات كاربر", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        
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
    }
}
