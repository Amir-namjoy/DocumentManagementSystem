using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FarsiLibrary.Win.Controls;
using FarsiLibrary.Win.Enums;

namespace MaliArchive
{
    public partial class frm_add_ashkas : Form
    {

        private const string AddAskhas_MESSAGEBOX = "AddAshkasBox";

        public frm_add_ashkas()
        {
            InitializeComponent();
            common.setLanguageToFarsi();
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
                msg = FAMessageBoxManager.GetMessageBox(AddAskhas_MESSAGEBOX);
                if (FAMessageBoxManager.GetMessageBox(AddAskhas_MESSAGEBOX) == null)
                {
                    msg = FAMessageBoxManager.CreateMessageBox(AddAskhas_MESSAGEBOX, true);
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
                if (txtname.Text.Trim() != "" && (DA.check_is_in_table("select name from ashkas where name='" + txtname.Text + "'")))
                    msg.Text += "*نام خانوادگي و نام وارد شده تكراري مي باشد\n";
                if (txtpersonalId.Text.Trim() != "" && (DA.check_is_in_table("select name from ashkas where personalid='" + txtpersonalId.Text + "'")))
                    msg.Text += "*شماره پرسنلي وارد شده تكراري مي باشد\n";

                if (msg.Text.Length > 0)
                {
                    msg.Show(this);
                    FAMessageBoxManager.DeleteMessageBox(AddAskhas_MESSAGEBOX);
                    return;
                }

                string q = "insert into ashkas values('" + txtname.Text + "','" + txtpersonalId.Text + "','" + txtsemat.Text + "','" + txtmahalkar.Text  + "','" + txttel.Text + "','" + txtmobile.Text + "','" + combGender.Text + "','" + txttozihat.Text + "')";
                DA.run_Query(q);
                string log = string.Format(" نام: {0}   شماره پرسنلي: {1}   سمت: {2}    محل كار: {3}    تلفن: {4}   موبايل: {5}     جنسيت: {6}  توضيحات: {7} ",
                    txtname.Text, txtpersonalId.Text, txtsemat.Text, txtmahalkar.Text, txttel.Text, txtmobile.Text, combGender.Text, txttozihat.Text);
                common.writelog(14, "افزودن شخص جديد", log, cUser.uid, "");
               // MessageBox.Show("اطلاعات كاربر جديد با موفقیت در پایگاه ثبت شد", "كاربر جديد", MessageBoxButtons.OK, MessageBoxIcon.Information);


                this.Close();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.ToString(), "بروز خطا", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }
    }
}
