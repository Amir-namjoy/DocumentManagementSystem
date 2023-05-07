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
using System.IO;

namespace MaliArchive
{
    internal partial class FrmEdit : Form
    {

        private const string EditDocMessagebox = "EditDocBox";
        private const string AddDoc_MESSAGEBOX = "AddDocBox";
        private const string FileExist_MESSAGEBOX = "fileExistBox";
        private const string Editedby_MESSAGEBOX = "EditedbyBox";
        private const string Exit_MESSAGEBOX = "EditDocExitMessageBox";

        long sumsize = 0;
        string deletedPicsID = "";
        string deletedPicsName = "";
        string AddedPicsName = "";
        bool SavedChanges = false;
        bool editedBy = false;

        Doc DocBeforeChange = new Doc();
        
        //public Doc DocNewValue { get; set; }
                
        public FrmEdit(Doc currentdoc)
        {
            InitializeComponent();
            common.setLanguageToFarsi();
           /* btn_edit.Visible = btnedit;
           btn_raked.Visible = btnraked;

            txtb_parvandeh.ReadOnly = !btnedit;
            txtb_tarikTaskil.ReadOnly = !btnedit;
            txtb_personalid.ReadOnly = !btnedit;
            txtb_daftarkol.ReadOnly = !btnedit;
            txtb_name.ReadOnly = !btnedit;
            txtb_family.ReadOnly = !btnedit;
            txtb_passid.ReadOnly = !btnedit;
            txtb_nationalCode.ReadOnly = !btnedit;
            txtb_fathername.ReadOnly = !btnedit;
            comb_eshteghal.Enabled = btnedit;
            numericUpDown1.ReadOnly = !btnedit;
            comb_estekdam.Enabled = btnedit;
            txtb_tozihat.ReadOnly = !btnedit;
            checkAmanat.Enabled = btnedit;
            checkRaked.Enabled = btnedit;*/
            DocBeforeChange = currentdoc;
            this.Text += currentdoc.id;

            txtb_parvandeh.Text = currentdoc.id.ToString();
            //string[] prdate = currentdoc.tariktashkil.Split('/');
            fdate_tarikTaskil.SelectedDateTime = currentdoc.tariktashkil;
           // fdate_tarikTaskil.mm.Text = prdate[1];
           // fdate_tarikTaskil.dd.Text = prdate[2];
            txtb_personalid.Text = currentdoc.personalid;
            txtb_daftarkol.Text = currentdoc.daftarkol;
            txtb_name.Text = currentdoc.name;
            txtb_family.Text = currentdoc.family;
            txtb_passid.Text = currentdoc.passid;
            txtb_nationalCode.Text = currentdoc.nationalcode;
            txtb_fathername.Text = currentdoc.father;
            comb_eshteghal.Text = currentdoc.eshteghal;
            numericUpDown1.Value = currentdoc.tedadbarg;
            if (currentdoc.tedadbarg > 0)
            {
                numericUpDown1.Enabled = true;
                checkBox1.Checked = false;
            }
            else
            {
                numericUpDown1.Enabled = false;
                checkBox1.Checked = true;
            }
            
            comb_estekdam.Text = currentdoc.estekdam;
            txtb_tozihat.Text = currentdoc.tozihat;
           // checkRaked.Checked = raked;
            //checkAmanat.Checked = amanat;



        }


        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (numericUpDown1.Value > 0)
            {

                checkBox1.Checked = false;
            }
            else
            {
                checkBox1.Checked = true;
            }
            //numericUpDown1.Enabled = !numericUpDown1.Enabled;
        }

        private void frm_edit_Load(object sender, EventArgs e)
        {


        }

        private void txtb_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!((int)e.KeyChar >= 48 && (int)e.KeyChar <= 58 || (int)e.KeyChar == (int)Keys.Back))
                e.KeyChar = (char)27;
        }

        private void btnViewAttachments_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection myconnection = new SqlConnection(DA.ConnectionString))
                {
                    using (SqlCommand mycommand = new SqlCommand())
                    {
                        myconnection.Open();
                        mycommand.Connection = myconnection;
                        foreach (DataGridViewRow item in dGAttachments.SelectedRows)
                        {
                            mycommand.CommandText = "SELECT pic, picname, picExten FROM docimages WHERE picId = " + item.Cells["picid"].Value.ToString();
                            SqlDataReader myreader = mycommand.ExecuteReader();

                            if (myreader.HasRows)
                                while (myreader.Read())
                                {
                                    Byte[] data = new Byte[0];
                                    data = (Byte[])(myreader["pic"]);
                                    //MemoryStream mem = new MemoryStream(data);
                                    //pictureBox1.Image = Image.FromStream(mem);    
                                    string tempFolderPath = common.GetTempFolderPath(txtb_parvandeh.Text);
                                    using (FileStream file = new FileStream((tempFolderPath + "\\"  +myreader["picName"].ToString() + myreader["picExten"].ToString())
                                        , FileMode.Create, System.IO.FileAccess.Write))
                                    {
                                       
                                        file.Write(data, 0, data.Length);
                                        // mem.Close();
                                    }
                                    System.Diagnostics.Process.Start(tempFolderPath + "\\"  +myreader["picName"].ToString() + myreader["picExten"].ToString());

                                }
                            myreader.Close();
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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

                        foreach (DataGridViewRow item in dGAttachments.Rows)
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
                            dGAttachments.Rows.Add(Path.GetFileNameWithoutExtension(file), Path.GetExtension(file), common.SizeSuffix(filelength), file, "", filelength);

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

            if (dGAttachments.RowCount > 0)
            {
                foreach (DataGridViewRow item in dGAttachments.SelectedRows)
                {
                    if (!item.Cells["picid"].Value.Equals(""))
                    {
                        if (deletedPicsID.Length > 0)
                        {
                            deletedPicsID += ",";
                            deletedPicsName += " , ";
                        }
                        deletedPicsID += item.Cells["picid"].Value.ToString();
                        deletedPicsName += item.Cells["Filename"].Value.ToString() + item.Cells["extension"].Value.ToString();
                    }
                    sumsize -= Convert.ToInt64(item.Cells["filebytesize"].Value);
                    lblSumSize.Text = common.SizeSuffix(sumsize);
                    dGAttachments.Rows.RemoveAt(item.Index);
                }

              /*  using (SqlConnection myconnection = new SqlConnection(DA.ConnectionString))
                {
                    using (SqlCommand mycommand = new SqlCommand())
                    {
                        myconnection.Open();
                        mycommand.Connection = myconnection;

                        #region  Delete Attachments
                        mycommand.CommandText = "delete from docimages where picid in (" + deletedPicsID + ")";
                        //mycommand.Parameters.AddWithValue("@deletedPicsID", deletedPicsID);
                        mycommand.ExecuteNonQuery();

                        #endregion Delete Attachments
                    }
                    myconnection.Close();
                }*/


            }
        }

        private void btnSaveAttachments_Click(object sender, EventArgs e)
        {
            try
            {
                if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                {
                    
                    using (SqlConnection myconnection = new SqlConnection(DA.ConnectionString))
                    {
                        using (SqlCommand mycommand = new SqlCommand())
                        {
                            myconnection.Open();
                            mycommand.Connection = myconnection;

                            foreach (DataGridViewRow item in dGAttachments.SelectedRows)
                            {
                                if (!item.Cells["picid"].Value.ToString().Equals(""))
                                {
                                    mycommand.CommandText = "SELECT pic, picname, picExten FROM docimages WHERE picId = " + item.Cells["picid"].Value.ToString();
                                    SqlDataReader myreader = mycommand.ExecuteReader();
                                    Byte[] data = new Byte[0];
                                    if (myreader.HasRows)
                                    {
                                        while (myreader.Read())
                                        {
                                            data = (Byte[])(myreader["pic"]);
                                            //MemoryStream mem = new MemoryStream(data);
                                            //pictureBox1.Image = Image.FromStream(mem);

                                            string pathString = (folderBrowserDialog1.SelectedPath + "\\" + myreader["picName"] + myreader["picExten"]).ToString();
                                            bool writeFile = true;
                                            if (System.IO.File.Exists(pathString))
                                            {
                                                FAMessageBox msgFileExist;
                                                msgFileExist = FAMessageBoxManager.GetMessageBox(FileExist_MESSAGEBOX);
                                                if (FAMessageBoxManager.GetMessageBox(FileExist_MESSAGEBOX) == null)
                                                {
                                                    msgFileExist = FAMessageBoxManager.CreateMessageBox(FileExist_MESSAGEBOX, true);
                                                    msgFileExist.AddButtons(MessageBoxButtons.YesNoCancel);
                                                }

                                                ///msg.AllowSaveResponse = true;
                                                //msg.SaveResponseText = "سوال را تکرار نکن";
                                                msgFileExist.Caption = "ذخيره ضمائم پرونده";
                                                msgFileExist.Icon = FarsiMessageBoxExIcon.Warning;
                                                msgFileExist.PlaySound = true;
                                                msgFileExist.Text = "  فايل با نام " + myreader["picName"].ToString() + " در مسير مشخص شده وجود دارد، آيا مي خواهيد جايگزين شود؟ ";
                                                string msgResult = msgFileExist.Show(this);
                                                switch (msgResult)
                                                {
                                                    case "YES":
                                                        writeFile = true;
                                                        break;
                                                    case "NO":
                                                        writeFile = false;
                                                        break;
                                                    case "CANCEL":
                                                        FAMessageBoxManager.DeleteMessageBox(FileExist_MESSAGEBOX);
                                                        return;


                                                }

                                                FAMessageBoxManager.DeleteMessageBox(FileExist_MESSAGEBOX);
                                            }
                                            if (writeFile)
                                            {
                                                using (FileStream file = new FileStream(pathString, FileMode.Create, System.IO.FileAccess.Write))
                                                {
                                                    file.Write(data, 0, data.Length);
                                                }
                                            }
                                        }
                                    }
                                    myreader.Close();
                                }
                                else
                                {
                                    string pathString = (folderBrowserDialog1.SelectedPath + "\\" + item.Cells["filename"].Value.ToString() + item.Cells["extension"].Value.ToString());
                                    bool writeFile = true;
                                    if (System.IO.File.Exists(pathString))
                                    {
                                        FAMessageBox msgFileExist;
                                        msgFileExist = FAMessageBoxManager.GetMessageBox(FileExist_MESSAGEBOX);
                                        if (FAMessageBoxManager.GetMessageBox(FileExist_MESSAGEBOX) == null)
                                        {
                                            msgFileExist = FAMessageBoxManager.CreateMessageBox(FileExist_MESSAGEBOX, true);
                                            msgFileExist.AddButtons(MessageBoxButtons.YesNoCancel);
                                        }

                                        ///msg.AllowSaveResponse = true;
                                        //msg.SaveResponseText = "سوال را تکرار نکن";
                                        msgFileExist.Caption = "ذخيره ضمائم پرونده";
                                        msgFileExist.Icon = FarsiMessageBoxExIcon.Warning;
                                        msgFileExist.PlaySound = true;
                                        msgFileExist.Text = "  فايل با نام " + item.Cells["filename"].Value.ToString() + item.Cells["extension"].Value.ToString() + " در مسير مشخص شده وجود دارد، آيا مي خواهيد جايگزين شود؟ ";
                                        string msgResult = msgFileExist.Show(this);
                                        switch (msgResult)
                                        {
                                            case "YES":
                                                writeFile = true;
                                                break;
                                            case "NO":
                                                writeFile = false;
                                                break;
                                            case "CANCEL":
                                                FAMessageBoxManager.DeleteMessageBox(FileExist_MESSAGEBOX);
                                                return;


                                        }

                                        FAMessageBoxManager.DeleteMessageBox(FileExist_MESSAGEBOX);
                                    }
                                    if (writeFile)
                                    {
                                        File.Copy(item.Cells["filePath"].Value.ToString(), pathString);
                                    }
                                }
                            }
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dGAttachments_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {

                try
                {
                    using (SqlConnection myconnection = new SqlConnection(DA.ConnectionString))
                    {
                        using (SqlCommand mycommand = new SqlCommand())
                        {
                            myconnection.Open();
                            mycommand.Connection = myconnection;

                            mycommand.CommandText = "SELECT pic, picname, picExten FROM docimages WHERE picId = " + dGAttachments.Rows[e.RowIndex].Cells["picid"].Value.ToString();
                            SqlDataReader myreader = mycommand.ExecuteReader();

                            if (myreader.HasRows)
                                while (myreader.Read())
                                {
                                    Byte[] data = new Byte[0];
                                    data = (Byte[])(myreader["pic"]);
                                    //MemoryStream mem = new MemoryStream(data);

                                    //pictureBox1.Image = Image.FromStream(mem);
                                    string tempFolderPath = common.GetTempFolderPath(txtb_parvandeh.Text);
                                    using (FileStream file = new FileStream((tempFolderPath + "\\" + myreader["picName"].ToString() + myreader["picExten"].ToString())
                                        , FileMode.Create, System.IO.FileAccess.Write))
                                    {

                                        file.Write(data, 0, data.Length);
                                        // mem.Close();
                                    }

                                    System.Diagnostics.Process.Start(tempFolderPath + "\\" + myreader["picName"].ToString() + myreader["picExten"].ToString());

                                }
                            myreader.Close();

                        }
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void FrmEdit_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!SavedChanges && !editedBy)
            {
                FAMessageBox msg;

                msg = FAMessageBoxManager.GetMessageBox(Exit_MESSAGEBOX);
                if (FAMessageBoxManager.GetMessageBox(Exit_MESSAGEBOX) == null)
                {
                    msg = FAMessageBoxManager.CreateMessageBox(Exit_MESSAGEBOX, true);
                    msg.AddButton("انصراف", "Cancel");
                    msg.AddButton("خير", "No");
                    msg.AddButton("بله", "Yes");
                    // msg.AddButtons(MessageBoxButtons.YesNo);
                }

                // msg.AllowSaveResponse = true;
                //msg.SaveResponseText = "سوال را تکرار نکن";
                msg.Text = "آيا تمايل داريد تغييراتي كه در پرونده ايجاد شده ذخيره شود؟";
                msg.Caption = "ويرايش پرونده";
                msg.Icon = FarsiMessageBoxExIcon.Question;
                msg.PlaySound = true;

                switch (msg.Show(this))
                {
                    case "Cancel":
                        e.Cancel = true;
                        break;
                    case "Yes":
                        SaveDocChanges();
                        common.DeleteTempFolder(txtb_parvandeh.Text);
                        break;
                    case "No":
                        EndDocEdit();
                        common.DeleteTempFolder(txtb_parvandeh.Text);
                        /* for (int i = 0; i < 100; i++)
                        {
                            this.Opacity -= 0.01;
                            System.Threading.Thread.Sleep(10);
                        }*/
                        break;


                }
            }
            
        }

        private void EndDocEdit()
        {
            using (SqlConnection myconnection = new SqlConnection(DA.ConnectionString))
            {
                using (SqlCommand mycommand = new SqlCommand())
                {
                    myconnection.Open();
                    mycommand.Connection = myconnection;

                    mycommand.CommandText = "update parvandeh set editBy = NULL where id = @DocID";
                    mycommand.Parameters.AddWithValue("@DocId", txtb_parvandeh.Text);
                    mycommand.ExecuteNonQuery();
                }
                myconnection.Close();
            }
                   
        }

        private void FrmEdit_Shown(object sender, EventArgs e)
        {
            using (SqlConnection myconnection = new SqlConnection(DA.ConnectionString))
            {
                using (SqlCommand mycommand = new SqlCommand())
                {
                    myconnection.Open();
                    mycommand.Connection = myconnection;

                    #region  Check edited by other user
                    mycommand.CommandText = @"select 
					users.name, users.family
                    from users
                    join parvandeh on users.uid=parvandeh.editBy
                    where parvandeh.id = @DocId and users.uid != @userId";
                    mycommand.Parameters.AddWithValue("@DocId", txtb_parvandeh.Text);
                    mycommand.Parameters.AddWithValue("@userId", cUser.uid);
                    SqlDataReader myreader = mycommand.ExecuteReader();
                    string editbyName = "", editbyFamily = "";
                    byte countEditby = 0;
                    if (myreader.HasRows)
                    {
                        while (myreader.Read())
                        {
                            editbyName = myreader["name"].ToString();
                            editbyFamily = myreader["family"].ToString();
                            countEditby++;
                        }
                        if (countEditby > 1)
                            MessageBox.Show("خطايي رخ داده لطفاً به مدير سيستم اطلاع دهيد" + countEditby);
                        else
                        {
                            FAMessageBox msg;
                            msg = FAMessageBoxManager.GetMessageBox(Editedby_MESSAGEBOX);
                            if (FAMessageBoxManager.GetMessageBox(Editedby_MESSAGEBOX) == null)
                            {
                                msg = FAMessageBoxManager.CreateMessageBox(Editedby_MESSAGEBOX, true);
                                msg.AddButtons(MessageBoxButtons.OK);
                            }

                            // msg.AllowSaveResponse = true;
                            //msg.SaveResponseText = "سوال را تکرار نکن";
                            msg.Caption = "ويرايش پرونده";
                            msg.Icon = FarsiMessageBoxExIcon.Warning;
                            msg.PlaySound = true;
                            msg.Text = string.Format("اين پرونده توسط كاربر {0} {1} در حال ويرايش است", editbyName, editbyFamily);

                            msg.Show(this);
                            FAMessageBoxManager.DeleteMessageBox(Editedby_MESSAGEBOX);
                            editedBy = true;
                            this.Close();
                        }

                    }
                    else
                    {
                        myreader.Close();
                        mycommand.CommandText = "update parvandeh set editBy = @userId where id = @DocID";
                        mycommand.ExecuteNonQuery();
                    }
                    myreader.Close();

                    lblSumSize.Text = common.SizeSuffix(sumsize);

                    #endregion Check edited by other user

                    #region  load Attachments gridview
                    mycommand.CommandText = "SELECT picName, picExten, picid, picSize FROM docimages WHERE DocId = @DocId";
                    //mycommand.Parameters.AddWithValue("@DocId", txtb_parvandeh.Text);
                    myreader = mycommand.ExecuteReader();

                    if (myreader.HasRows)
                    {
                        while (myreader.Read())
                        {
                            dGAttachments.Rows.Add(myreader["picName"].ToString(), myreader["picExten"].ToString(),
                               common.SizeSuffix(Convert.ToInt64(myreader["picSize"])), "", myreader["picid"].ToString(), myreader["picSize"].ToString());

                            sumsize += Convert.ToInt64(myreader["picSize"]);
                        }

                    }
                    myreader.Close();

                    lblSumSize.Text = common.SizeSuffix(sumsize);

                    #endregion load Attachments gridview
                }
                myconnection.Close();
            }

            common.writelog(13, "مشاهده پرونده از طريق ويرايش", txtb_parvandeh.Text, cUser.uid, txtb_parvandeh.Text);
        }

        private void ExittoolStripButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SaveDocChanges()
        {
            FAMessageBox msg;
            msg = FAMessageBoxManager.GetMessageBox(EditDocMessagebox);
            if (FAMessageBoxManager.GetMessageBox(EditDocMessagebox) == null)
            {
                msg = FAMessageBoxManager.CreateMessageBox(EditDocMessagebox, true);
                msg.AddButtons(MessageBoxButtons.OK);
            }

            // msg.AllowSaveResponse = true;
            //msg.SaveResponseText = "سوال را تکرار نکن";
            msg.Caption = "ويرايش پرونده";
            msg.Icon = FarsiMessageBoxExIcon.Warning;
            msg.PlaySound = true;
            msg.Text = "";

            if (fdate_tarikTaskil.IsNull)
                msg.Text += "*تاريخ تشكيل پرونده را مشخص نمائيد\n";

            if (txtb_personalid.Text.Trim() != "" && (DA.check_is_in_table("select name from parvandeh where personalid='"
                + txtb_personalid.Text + "'" + " and id !='" + txtb_parvandeh.Text + "'")))
                msg.Text += "*شماره پرسنلي وارد شده تكراري مي باشد\n";
            if (txtb_daftarkol.Text.Trim() != "" && (DA.check_is_in_table("select name from parvandeh where daftarkol='"
                + txtb_daftarkol.Text + "'" + " and id !='" + txtb_parvandeh.Text + "'")))
                msg.Text += "*شماره دفتركل وارد شده تكراري مي باشد\n";
            if (txtb_nationalCode.Text.Trim() != "" && (DA.check_is_in_table("select name from parvandeh where nationalcode='"
                + txtb_nationalCode.Text + "'" + " and id !='" + txtb_parvandeh.Text + "'")))
                msg.Text += "*كدملي وارد شده تكراري مي باشد\n";

            if (msg.Text.Length > 0)
            {
                msg.Show(this);
                FAMessageBoxManager.DeleteMessageBox(EditDocMessagebox);
                return;
            }

            using (SqlConnection myconnection = new SqlConnection(DA.ConnectionString))
            {
                using (SqlCommand mycommand = new SqlCommand())
                {
                    myconnection.Open();
                    mycommand.Connection = myconnection;
                    string q = "update parvandeh set tarikTashkil='" + fdate_tarikTaskil.SelectedDateTime.ToString("yyyy/MM/dd")
                        + "', personalid='" + txtb_personalid.Text + "', daftarkol='" + txtb_daftarkol.Text
                        + "' ,name='" + txtb_name.Text + "' , family='" + txtb_family.Text + "' , passid='"
                        + txtb_passid.Text + "' , nationalcode='" + txtb_nationalCode.Text + "' , father='"
                        + txtb_fathername.Text + "' , eshteghal='" + comb_eshteghal.Text + "' , tedadbarg='"
                        + numericUpDown1.Value + "' , estekdam='" + comb_estekdam.Text + "', tozihat='" + txtb_tozihat.Text
                        + "' where id=" + txtb_parvandeh.Text;
                    mycommand.CommandText = q;
                    mycommand.ExecuteNonQuery();

                    //******************************** Save attachs
                    #region Save Image to DB
                    int added_attachs = 0;
                    try
                    {
                        if (dGAttachments.RowCount > 0)
                        {
                            foreach (DataGridViewRow item in dGAttachments.Rows)
                            {
                                if (!item.Cells["filePath"].Value.Equals(""))
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
                                    if (AddedPicsName.Length > 0)
                                        AddedPicsName += " , ";
                                    AddedPicsName += item.Cells["filename"].Value.ToString() + item.Cells["extension"].Value.ToString()
                                        + " @ " + item.Cells["fileSize"].Value.ToString();
                                }
                            }
                            //dGAttachments.Rows.Clear();
                            //lblSumSize.Text = "";
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

                    #region  Delete Attachments
                    if (deletedPicsID.Length > 0)
                    {
                        mycommand.CommandText = "delete from docimages where picid in (" + deletedPicsID + ")";
                        mycommand.ExecuteNonQuery();
                    }
                    #endregion Delete Attachments

                    common.TempDoc.tariktashkil = fdate_tarikTaskil.SelectedDateTime;
                    common.TempDoc.personalid = txtb_personalid.Text;
                    common.TempDoc.daftarkol = txtb_daftarkol.Text;
                    common.TempDoc.name = txtb_name.Text;
                    common.TempDoc.family = txtb_family.Text;
                    common.TempDoc.passid = txtb_passid.Text;
                    common.TempDoc.nationalcode = txtb_nationalCode.Text;
                    common.TempDoc.father = txtb_fathername.Text;
                    common.TempDoc.eshteghal = comb_eshteghal.Text;
                    common.TempDoc.tedadbarg = Convert.ToInt32(numericUpDown1.Value);
                    common.TempDoc.estekdam = comb_estekdam.Text;
                    common.TempDoc.tozihat = txtb_tozihat.Text;

                    string log = "";

                    if (DocBeforeChange.tariktashkil.ToString("yyyy/MM/dd") != fdate_tarikTaskil.SelectedDateTime.ToString("yyyy/MM/dd"))
                        log += string.Format(" تاريخ تشكيل پرونده از {0} به {1} تغيير يافت \n ", DocBeforeChange.tariktashkil.ToString("yyyy/MM/dd"), fdate_tarikTaskil.SelectedDateTime.ToString("yyyy/MM/dd"));

                    if (DocBeforeChange.personalid != txtb_personalid.Text)
                        log += string.Format(" شماره پرسنلي از {0} به {1} تغيير يافت \n ", DocBeforeChange.personalid, txtb_personalid.Text);

                    if (DocBeforeChange.daftarkol != txtb_daftarkol.Text)
                        log += string.Format(" شماره دفتركل از {0} به {1} تغيير يافت \n ", DocBeforeChange.daftarkol, txtb_daftarkol.Text);

                    if (DocBeforeChange.name != txtb_name.Text)
                        log += string.Format(" نام از {0} به {1} تغيير يافت \n ", DocBeforeChange.name, txtb_name.Text);

                    if (DocBeforeChange.family != txtb_family.Text)
                        log += string.Format(" نام خانوادگي از {0} به {1} تغيير يافت \n ", DocBeforeChange.family, txtb_family.Text);

                    if (DocBeforeChange.father != txtb_fathername.Text)
                        log += string.Format(" نام پدر از {0} به {1} تغيير يافت \n ", DocBeforeChange.father, txtb_fathername.Text);

                    if (DocBeforeChange.nationalcode != txtb_nationalCode.Text)
                        log += string.Format(" كدملي از {0} به {1} تغيير يافت \n ", DocBeforeChange.nationalcode, txtb_nationalCode.Text);

                    if (DocBeforeChange.passid != txtb_passid.Text)
                        log += string.Format(" شماره شناسنامه از {0} به {1} تغيير يافت \n ", DocBeforeChange.passid, txtb_passid.Text);

                    if (DocBeforeChange.eshteghal != comb_eshteghal.Text)
                        log += string.Format(" وضعيت اشتغال از {0} به {1} تغيير يافت \n ", DocBeforeChange.eshteghal, comb_eshteghal.Text);

                    if (DocBeforeChange.tedadbarg != numericUpDown1.Value)
                        log += string.Format(" تعداد برگ پرونده از {0} به {1} تغيير يافت \n ", DocBeforeChange.tedadbarg, numericUpDown1.Value);

                    if (DocBeforeChange.estekdam != comb_estekdam.Text)
                        log += string.Format(" نوع استخدام از {0} به {1} تغيير يافت \n ", DocBeforeChange.estekdam, comb_estekdam.Text);

                    if (DocBeforeChange.tozihat != txtb_tozihat.Text)
                        log += string.Format(" توضيحات از ({0}) به ({1}) تغيير يافت \n ", DocBeforeChange.tozihat, txtb_tozihat.Text);

                    if (deletedPicsName.Length > 0)
                        log += string.Format(" ضمائم  ({0}) حذف شدند \n ", deletedPicsName);

                    if (AddedPicsName.Length > 0)
                        log += string.Format(" ضمائم  ({0}) اضافه شدند \n ", AddedPicsName);

                    myconnection.Close();

                    if (!log.Equals(""))
                        common.writelog(10, "ويرايش پرونده", log, cUser.uid, txtb_parvandeh.Text);
                    EndDocEdit();
                    MessageBox.Show("تغييرات با موفقیت در پایگاه ثبت شد", "ويرايش اطلاعات پرونده", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    SavedChanges = true;
                    this.Close();
                }
            }
        }

        private void SaveChangestoolStripButton_Click(object sender, EventArgs e)
        {
            SaveDocChanges();
        }

        private void dGAttachments_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            btn_Remove_Attach.Enabled = true;
            btnViewAttachments.Enabled = true;
            btnSaveAttachments.Enabled = true;
        }

        private void dGAttachments_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            if (dGAttachments.RowCount <= 0)
            {
                btn_Remove_Attach.Enabled = false;
                btnViewAttachments.Enabled = false;
                btnSaveAttachments.Enabled = false;
            }
        }

       /*  private void btn_raked_Click(object sender, EventArgs e)
        {
            using (SqlConnection myconnection = new SqlConnection(Properties.Settings.Default.connection_string))
            {
                using (SqlCommand mycommand = new SqlCommand())
                {
                    myconnection.Open();
                    mycommand.Connection = myconnection;
                    string q = "update parvandeh set vaziyat_parvandeh=2 where id=" + txtb_parvandeh.Text;
                    mycommand.CommandText = q;
                    mycommand.ExecuteNonQuery();
                    MessageBox.Show("پرونده راكد شد", "راكد كردن پرونده", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                    myconnection.Close();
                }
            }
        }*/


    }
}
