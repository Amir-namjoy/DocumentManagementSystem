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
    public partial class frm_edit_ashkas : Form
    {
        int pid = -1;
        shaks ShaksBefore = new shaks();
        private const string EditAskhas_MESSAGEBOX = "EditAshkasBox";

        public frm_edit_ashkas(shaks current_shaks)
        {
            InitializeComponent();
            common.setLanguageToFarsi();
            ShaksBefore = current_shaks;
            pid = current_shaks.pid;
            txtname.Text = current_shaks.name;
            txtpersonalId.Text = current_shaks.personid;
            txtsemat.Text = current_shaks.semat;
            txtmahalkar.Text = current_shaks.mahalkar;
            txttel.Text = current_shaks.tel;
            txtmobile.Text = current_shaks.mobile;
            combGender.Text = current_shaks.gender;
            txttozihat.Text = current_shaks.tozihat;
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
                msg.Caption = "افزودن شخص جديد";
                msg.Icon = FarsiMessageBoxExIcon.Warning;
                msg.PlaySound = true;
                msg.Text = "";

                if (txtname.Text.Trim() == "")
                    msg.Text += "نام خانوادگي و نام شخص را وارد كنيد*\n";
                if (txtname.Text.Trim() != "" && (DA.check_is_in_table("select name from ashkas where name='"
                    + txtname.Text + "'" + " and pid !='" + pid + "'")))
                    msg.Text += "*نام خانوادگي و نام وارد شده تكراري مي باشد\n";
                if (txtpersonalId.Text.Trim() != "" && (DA.check_is_in_table("select name from ashkas where personalid='"
                    + txtpersonalId.Text + "'" + " and pid !='" + pid + "'")))
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
                        mycommand.Parameters.AddWithValue("@pid", pid);
                        mycommand.Parameters.AddWithValue("@name", txtname.Text);
                        mycommand.Parameters.AddWithValue("@personalid", txtpersonalId.Text);
                        mycommand.Parameters.AddWithValue("@semat", txtsemat.Text);
                        mycommand.Parameters.AddWithValue("@mahalkar", txtmahalkar.Text);
                        mycommand.Parameters.AddWithValue("@tel", txttel.Text);
                        mycommand.Parameters.AddWithValue("@mobile", txtmobile.Text);
                        mycommand.Parameters.AddWithValue("@gender", combGender.Text);
                        mycommand.Parameters.AddWithValue("@tozihat", txttozihat.Text);
                        string q = @"update ashkas 
                                     set name=@name, personalid=@personalid, semat=@semat, mahalkar=@mahalkar, 
                                     tel=@tel, mobile=@mobile, gender=@gender, tozihat=@tozihat
                                     where pid=@pid";
                        mycommand.CommandText = q;
                        mycommand.ExecuteNonQuery();

                        common.TempShaks.name = txtname.Text;
                        common.TempShaks.personid = txtpersonalId.Text;
                        common.TempShaks.semat = txtsemat.Text;
                        common.TempShaks.mahalkar = txtmahalkar.Text;
                        common.TempShaks.tel = txttel.Text;
                        common.TempShaks.mobile = txtmobile.Text;
                        common.TempShaks.gender = combGender.Text;
                        common.TempShaks.tozihat = txttozihat.Text;

                        string log = "";

                        if (ShaksBefore.name != txtname.Text)
                            log += string.Format(" نام از {0} به {1} تغيير يافت \n ", ShaksBefore.name, txtname.Text);

                        if (ShaksBefore.personid != txtpersonalId.Text)
                            log += string.Format(" شماره پرسنلي از {0} به {1} تغيير يافت \n ", ShaksBefore.personid, txtpersonalId.Text);

                        if (ShaksBefore.semat != txtsemat.Text)
                            log += string.Format(" سمت از {0} به {1} تغيير يافت \n ", ShaksBefore.semat, txtsemat.Text);

                        if (ShaksBefore.mahalkar != txtmahalkar.Text)
                            log += string.Format(" محل كار از {0} به {1} تغيير يافت \n ", ShaksBefore.mahalkar, txtmahalkar.Text);

                        if (ShaksBefore.tel != txttel.Text)
                            log += string.Format(" تلفن از {0} به {1} تغيير يافت \n ", ShaksBefore.tel, txttel.Text);

                        if (ShaksBefore.mobile != txtmobile.Text)
                            log += string.Format(" موبايل از {0} به {1} تغيير يافت \n ", ShaksBefore.mobile, txtmobile.Text);

                        if (ShaksBefore.gender != combGender.Text)
                            log += string.Format(" جنسيت از {0} به {1} تغيير يافت \n ", ShaksBefore.gender, combGender.Text);

                        if (ShaksBefore.tozihat != txttozihat.Text)
                            log += string.Format(" توضيحات از {0} به {1} تغيير يافت \n ", ShaksBefore.tozihat, txttozihat.Text);

                        if (!log.Equals(""))
                            common.writelog(15, "تغيير مشخصات شخص", log, cUser.uid, "");
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
