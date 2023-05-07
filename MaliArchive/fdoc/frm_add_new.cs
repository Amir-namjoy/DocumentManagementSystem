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
using System.IO;
using System.Data.SqlClient;

namespace MaliArchive
{
    public partial class frm_add_new : Form
    {
        //frm_main frmParent = null;

        private const string AddDoc_MESSAGEBOX = "AddDocBox";
        private const string CEAddDoc_MESSAGEBOX = "CancelAD";
        long sumsize = 0;
        
        public frm_add_new()
        {
            InitializeComponent();
            //this.frmParent = frmParent;
            common.setLanguageToFarsi();
            fdate_tarikTaskil.SelectedDateTime = DateTime.Now;
        }

         private void frm_add_new_Load(object sender, EventArgs e)
        {

             
        }

 
        private void btn_taksisNum_Click(object sender, EventArgs e)
        {
            txtb_parvandeh.Text = DA.ass_new_pnumber(fdate_tarikTaskil.SelectedDateTime.ToString("yyyy/MM/dd")).ToString();
            btn_taksisNum.Enabled = false;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            numericUpDown1.Enabled = !numericUpDown1.Enabled;

        }

        private string unsave_ask()
        {
            FAMessageBox msgCancel;
            msgCancel = FAMessageBoxManager.GetMessageBox(CEAddDoc_MESSAGEBOX);
            if (FAMessageBoxManager.GetMessageBox(CEAddDoc_MESSAGEBOX) == null)
            {
                msgCancel = FAMessageBoxManager.CreateMessageBox(CEAddDoc_MESSAGEBOX, true);
                msgCancel.AddButtons(MessageBoxButtons.YesNo);
            }

            // msg.AllowSaveResponse = true;
            //msg.SaveResponseText = "سوال را تکرار نکن";
            msgCancel.Caption = "ثبت پرونده";
            msgCancel.Icon = FarsiMessageBoxExIcon.Warning;
            msgCancel.PlaySound = true;
            msgCancel.Text = "شماره پرونده تخصيص داده شده! آيا مي خواهيد اطلاعات پرونده را بدون مقدار باقي بگذاريد، آيا مطمئن هستيد؟";
            string ResultMsg = msgCancel.Show();
            FAMessageBoxManager.DeleteMessageBox(CEAddDoc_MESSAGEBOX);
            return ResultMsg;
        }

        private void frm_add_new_FormClosing(object sender, FormClosingEventArgs e)
        {

            if (txtb_parvandeh.Text.Length > 0)
                if (unsave_ask() == "NO")
                {
                    e.Cancel = true;
                }
        }

        private void txtb_personalid_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!((int)e.KeyChar >= 48 && (int)e.KeyChar <= 58 || (int)e.KeyChar == (int)Keys.Back))
                e.KeyChar = (char)27;
        }

        private void txtb_passid_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!((int)e.KeyChar >= 48 && (int)e.KeyChar <= 58 || (int)e.KeyChar == (int)Keys.Back))
                e.KeyChar = (char)27;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void btn_Attach_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog fop = new OpenFileDialog(); //create object of open file dialog
                fop.Title = "انتخاب فايل ضميمه پرونده";
                //fop.InitialDirectory = @"C:\"; //set Initial directory
                fop.Filter = "Adobe PDF Files (*.pdf)|*.pdf|JPEG (*.jpg;*.jpeg;*.jpe;*.jfif)|*.jpg;*.jpeg;*.jpe;*.jfif|TIFF (*.tif;*.tiff;)|*.jpg;*.jpeg;*.jpe;*.jfif|All files (*.*)|*.*"; //set filter for select only .jpg files
                fop.Multiselect = true;
                if (fop.ShowDialog() == DialogResult.OK) //display open file dialog to user and only user select a image enter to if block
                {


                    //*******************
                    // Read the files
                    FAMessageBox msgAddDoc;
                    msgAddDoc = FAMessageBoxManager.GetMessageBox(AddDoc_MESSAGEBOX);
                    if (FAMessageBoxManager.GetMessageBox(AddDoc_MESSAGEBOX) == null)
                    {
                        msgAddDoc = FAMessageBoxManager.CreateMessageBox(AddDoc_MESSAGEBOX, true);
                        msgAddDoc.AddButtons(MessageBoxButtons.OK);
                    }

                    // msg.AllowSaveResponse = true;
                    //msg.SaveResponseText = "سوال را تکرار نکن";
                    msgAddDoc.Caption = "افزودن ضميمه پرونده";
                    msgAddDoc.Icon = FarsiMessageBoxExIcon.Warning;
                    msgAddDoc.PlaySound = true;
                    msgAddDoc.Text = "";

                    Boolean allowAdd;
                    long filelength;
                    foreach (String file in fop.FileNames)
                    {
                        allowAdd = true;
                        filelength = new System.IO.FileInfo(file).Length;

                        foreach (DataGridViewRow item in dGfileadd.Rows)
                        {
                            if (item.Cells["Filename"].Value.ToString() + item.Cells["extension"].Value.ToString() == Path.GetFileName(file))
                            {
                                allowAdd = false;
                                if (msgAddDoc.Text.Length == 0)
                                    msgAddDoc.Text += "امكان اضافه كردن دو فايل هم نام وجود ندارد\n";
                                msgAddDoc.Text += " فايل با نام  " + Path.GetFileName(file) + " تكراري است\n";
                            }

                        }
                        if (filelength >= (Convert.ToInt64(/*nUDmaxf.Value*/50) * 1024 * 1024))
                        {
                            allowAdd = false;
                            msgAddDoc.Text += " حجم فايل  " + Path.GetFileName(file) + " بيش از حد مجاز است\n";
                        }
                        if (filelength + sumsize >= (Convert.ToInt64(/*nUDmaxAf.Value*/50) * 1024 * 1024))
                        {
                            allowAdd = false;
                            msgAddDoc.Text += "  حجم مجموع فايل ها بيش از حد مجاز است\n";
                        }
                        if (allowAdd)
                        {

                            sumsize += filelength;
                            dGfileadd.Rows.Add(Path.GetFileNameWithoutExtension(file), Path.GetExtension(file), common.SizeSuffix(filelength), file, filelength);

                        }
                    }
                    //***************
                    if (msgAddDoc.Text.Length > 0)
                    {
                        msgAddDoc.Show(this);
                        FAMessageBoxManager.DeleteMessageBox(AddDoc_MESSAGEBOX);
                        //return;
                    }

                    lblSumSize.Text = common.SizeSuffix(sumsize);
                }

            }
            catch (Exception ex)//catch if any error occur
            {
                MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);//display error message with exception 
            }
            finally
            {

            }
        }

        private void btn_Remove_Attach_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow item in dGfileadd.SelectedRows)
            {
                sumsize -= Convert.ToInt64(item.Cells["filebytesize"].Value);
                dGfileadd.Rows.RemoveAt(item.Index);
                lblSumSize.Text = common.SizeSuffix(sumsize);
            }
        }

        private void btn_show_attach_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow item in dGfileadd.SelectedRows)
            {

                System.Diagnostics.Process.Start(item.Cells["filePath"].Value.ToString());

            }
        }

        private void dGfileadd_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                System.Diagnostics.Process.Start(dGfileadd.Rows[e.RowIndex].Cells["filePath"].Value.ToString());
            }
        }

        private void ExittoolStripButton_Click(object sender, EventArgs e)
        {

            this.Close();
            /*if (txtb_parvandeh.Text.Length > 0)
                if (unsave_ask() == "NO")
                    return;

            txtb_parvandeh.Clear();
            btn_taksisNum.Enabled = true;
            //fdate_tarikTaskil.SetDate(DateTime.Now);
            txtb_personalid.Clear();
            txtb_daftarkol.Clear();
            comb_eshteghal.SelectedIndex = -1;
            txtb_name.Clear();
            txtb_family.Clear();
            txtb_fathername.Clear();
            txtb_passid.Clear();
            txtb_nationalCode.Clear();
            txtb_tozihat.Clear();
            numericUpDown1.Value = 0;
            checkBox1.Checked = true;
            comb_estekdam.SelectedIndex = -1;*/
            // MessageBox.Show("اطلاعات در پایگاه ثبت نشد","انصراف",MessageBoxButtons.OK,MessageBoxIcon.Stop);
        }

        private void SaveChangestoolStripButton_Click(object sender, EventArgs e)
        {

            FAMessageBox msgAddDoc;
            msgAddDoc = FAMessageBoxManager.GetMessageBox(AddDoc_MESSAGEBOX);
            if (FAMessageBoxManager.GetMessageBox(AddDoc_MESSAGEBOX) == null)
            {
                msgAddDoc = FAMessageBoxManager.CreateMessageBox(AddDoc_MESSAGEBOX, true);
                msgAddDoc.AddButtons(MessageBoxButtons.OK);
            }

            // msg.AllowSaveResponse = true;
            //msg.SaveResponseText = "سوال را تکرار نکن";
            msgAddDoc.Caption = "ثبت پرونده";
            msgAddDoc.Icon = FarsiMessageBoxExIcon.Warning;
            msgAddDoc.PlaySound = true;
            msgAddDoc.Text = "";

            if (txtb_parvandeh.Text.Trim() == "")
                msgAddDoc.Text += "*شماره اي به پرونده اختصاص داده نشده است\n";

            if (fdate_tarikTaskil.IsNull)
                msgAddDoc.Text += "*تاريخ تشكيل پرونده را مشخص نمائيد\n";

            if (txtb_personalid.Text.Trim() != "" && (DA.check_is_in_table("select name from parvandeh where personalid='" + txtb_personalid.Text + "'")))
                msgAddDoc.Text += "*شماره پرسنلي وارد شده تكراري مي باشد\n";
            if (txtb_daftarkol.Text.Trim() != "" && (DA.check_is_in_table("select name from parvandeh where daftarkol='" + txtb_daftarkol.Text + "'")))
                msgAddDoc.Text += "*شماره دفتركل وارد شده تكراري مي باشد\n";
            if (txtb_nationalCode.Text.Trim() != "" && (DA.check_is_in_table("select name from parvandeh where nationalcode='" + txtb_nationalCode.Text + "'")))
                msgAddDoc.Text += "*كدملي وارد شده تكراري مي باشد\n";

            if (msgAddDoc.Text.Length > 0)
            {
                msgAddDoc.Show(this);
                FAMessageBoxManager.DeleteMessageBox(AddDoc_MESSAGEBOX);
                return;
            }
            bool has_attach = (dGfileadd.RowCount > 0);
            //string q = "insert into parvandeh values('" + txtb_parvandeh.Text + "','" + fdate_tarikTaskil.GetDate().ToString("yyyy/MM/dd") + "','" + txtb_personalid.Text + "','" + txtb_daftarkol.Text + "','" + txtb_name.Text + "','" + txtb_family.Text + "','" + txtb_passid.Text + "','" + txtb_nationalCode.Text + "','" + txtb_fathername.Text + "','" + comb_eshteghal.Text + "','" + numericUpDown1.Value + "','" + comb_estekdam.Text + "','" + txtb_tozihat.Text + "',0,0,0,-1)";
            string q = "update parvandeh set tarikTashkil='" + fdate_tarikTaskil.SelectedDateTime.ToString("yyyy/MM/dd") + "', personalid='"
                + txtb_personalid.Text + "', daftarkol='" + txtb_daftarkol.Text + "' ,name='" + txtb_name.Text + "' , family='"
                + txtb_family.Text + "' , passid='" + txtb_passid.Text + "' , nationalcode='" + txtb_nationalCode.Text + "' , father='"
                + txtb_fathername.Text + "' , eshteghal='" + comb_eshteghal.Text + "' , tedadbarg='" + numericUpDown1.Value + "' , estekdam='"
                + comb_estekdam.Text + "', tozihat='" + txtb_tozihat.Text /*+ "', attach='" + has_attach*/ + "' where id=" + txtb_parvandeh.Text;
            DA.run_Query(q);

            //******************************** Save attachs
            #region Save Image to DB
            int added_attachs = 0;
            try
            {
                if (dGfileadd.RowCount > 0)
                {
                    foreach (DataGridViewRow item in dGfileadd.Rows)
                    {

                        FileStream FS = new FileStream(@item.Cells["filePath"].Value.ToString(), FileMode.Open, FileAccess.Read); //create a file stream object associate to user selected file 
                        byte[] img = new byte[FS.Length]; //create a byte array with size of user select file stream length
                        FS.Read(img, 0, Convert.ToInt32(FS.Length));//read user selected file stream in to byte array

                        // q = "INSERT INTO docimages (DocId, pic, picName) VALUES (" + txtb_parvandeh.Text + "," + img + "," + item.Cells["filename"].Value.ToString() + item.Cells["extension"].Value.ToString() + ")";
                        SqlCommand sqlCommand = new SqlCommand("INSERT INTO docimages (DocId, pic, picName, picExten, picSize) VALUES (@DocId, @Image, @fileName, @fileExten, @fileSize)", null);
                        sqlCommand.Parameters.AddWithValue("@DocId", txtb_parvandeh.Text);
                        sqlCommand.Parameters.AddWithValue("@Image", img);
                        sqlCommand.Parameters.AddWithValue("@fileName", item.Cells["filename"].Value.ToString());
                        sqlCommand.Parameters.AddWithValue("@fileExten", item.Cells["extension"].Value.ToString());
                        sqlCommand.Parameters.AddWithValue("@fileSize", item.Cells["filebytesize"].Value.ToString());

                        DA.run_Query(sqlCommand);
                        added_attachs++;
                    }
                    dGfileadd.Rows.Clear();
                    lblSumSize.Text = "";
                    //MessageBox.Show("ضمائم در پايگاه داده ذخيره شد", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);//display save successful message to user
                }
                else
                {
                    //MessageBox.Show("ميشه بگي دقيقاً چي رو ذخيره كنم!!!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);//display message to force select a image 
                }

            }
            catch (Exception ex)//catch if any error occur
            {
                MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);//display error message with exception 
            }
            finally
            {
                //if (con.State == ConnectionState.Open)//check whether connection to database is open or not
                //   con.Close();//if connection is open then only close the connection

            }
            #endregion
            //***************************** end save attach

            string logq;
            logq = string.Format("تاريخ تشكيل پرونده: {0}        شماره پرسنلي: {1}         شماره دفتركل: {2}        نام: {3}         نام خانوادگي: {4}        نام پدر: {5}         كدملي: {6}         شماره شناسنامه: {7}         وضعيت اشتغال: {8}        تعداد برگ: {9}       استخدام: {10}          تعداد ضمائم: {11}        حجم ضمائم: {12}         توضيحات: {13}         شماره پرونده: {14}                ثبت شد",
                fdate_tarikTaskil.Text,
                txtb_personalid.Text,
                txtb_daftarkol.Text,
                txtb_name.Text,
                txtb_family.Text,
                txtb_fathername.Text,
                txtb_nationalCode.Text,
                txtb_passid.Text,
                comb_eshteghal.Text,
                numericUpDown1.Value,
                comb_estekdam.Text,
                added_attachs + "از" + dGfileadd.RowCount.ToString(),
                lblSumSize.Text,
                txtb_tozihat.Text,
                txtb_parvandeh.Text);
            /*logq = q.Remove(0, 29);
            logq = logq.Replace("where", " --- "); 
            logq = logq.Replace(")", "");
            logq = logq.Replace("'", " ");*/
            common.writelog(9, "ثبت پرونده جديد", logq, cUser.uid, txtb_parvandeh.Text);


            msgAddDoc.Icon = FarsiMessageBoxExIcon.Information;
            msgAddDoc.PlaySound = true;
            msgAddDoc.Text = "اطلاعات پرونده جديد با موفقیت ثبت شد";

            msgAddDoc.Show(this);

            txtb_parvandeh.Clear();
            //fdate_tarikTaskil.SetDate(DateTime.Now);
            txtb_personalid.Clear();
            txtb_daftarkol.Clear();
            comb_eshteghal.SelectedIndex = -1;
            txtb_name.Clear();
            txtb_family.Clear();
            txtb_fathername.Clear();
            txtb_passid.Clear();
            txtb_nationalCode.Clear();
            txtb_tozihat.Clear();
            numericUpDown1.Value = 0;
            checkBox1.Checked = true;
            comb_estekdam.SelectedIndex = -1;
            btn_taksisNum.Enabled = true;
        }

        private void dGfileadd_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            btn_Remove_Attach.Enabled = true;
            btn_show_attach.Enabled = true;
        }

        private void dGfileadd_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            if (dGfileadd.RowCount <= 0)
            {
                btn_Remove_Attach.Enabled = false;
                btn_show_attach.Enabled = false;
            }
        }


    }
}
