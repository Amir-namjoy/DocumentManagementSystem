using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using FarsiLibrary.Utils;
using FarsiLibrary.Win.Controls;
using FarsiLibrary.Win.Enums;
using System.IO;

namespace MaliArchive.fdoc
{
    public partial class frm_viewdoc : Form
    {
        
        private const string FileExist_MESSAGEBOX = "fileExistBox";
        long sumsize = 0;
        
        bool raked;
        public frm_viewdoc(Doc currentdoc)
        {
            InitializeComponent();

            this.Text += currentdoc.id;

            txtb_parvandeh.Text = currentdoc.id.ToString();
            PersianDate pd = currentdoc.tariktashkil;
            txtb_tarikTaskil.Text = pd.ToString("d");
            txtb_personalid.Text = currentdoc.personalid;
            txtb_daftarkol.Text = currentdoc.daftarkol;
            txtb_name.Text = currentdoc.name;
            txtb_family.Text = currentdoc.family;
            txtb_passid.Text = currentdoc.passid;
            txtb_nationalCode.Text = currentdoc.nationalcode;
            txtb_fathername.Text = currentdoc.father;
            txt_eshteghal.Text = currentdoc.eshteghal;

            txt_tedadbarg.Text = currentdoc.tedadbarg.ToString();
            txt_estekdam.Text = currentdoc.estekdam;
            txtb_tozihat.Text = currentdoc.tozihat;
            pictureBox1.Visible = currentdoc.amanat;
            pictureBox2.Visible = currentdoc.raked;
            if (currentdoc.amanat)
            {
                lblamanat.Text = "پرونده امانت مي باشد      ";
                lblamanat.ForeColor = Color.Green;
                lblamanat.BackColor = Color.FromArgb(192, 255, 192);
                
            }
            else
            {
                lblamanat.Text = "پرونده امانت نمي باشد     ";
                lblamanat.ForeColor = Color.Black;
                lblamanat.BackColor = Color.White;
            }

            raked = currentdoc.raked;
            
        }

        private void doc_Log_amanat_Load()
        {
            using (SqlConnection myconnection = new SqlConnection(DA.ConnectionString))
            {
                using (SqlCommand mycommand = new SqlCommand())
                {
                    myconnection.Open();
                    mycommand.Connection = myconnection;
                    
                    #region load logs gridview
                    mycommand.CommandText = @"select  userslog.*,n2.name+' '+n2.family username 
                                            from userslog 
                                            join users n2 on userslog.userid=n2.uid
                                            where pid= " + txtb_parvandeh.Text + " order by logdate DESC";
 
                    SqlDataReader myreader = mycommand.ExecuteReader();
                    dgvlogs.Rows.Clear();
                    if (myreader.HasRows)
                    {
                        while (myreader.Read())
                        {
                            dgvlogs.Rows.Add(common.persian_datetime((DateTime)myreader["logdate"]).ToString(),
                                myreader["roydad"].ToString(), myreader["username"].ToString(), myreader["tozihat"].ToString());

                        }

                    }
                    myreader.Close();
                    #endregion

                    #region  load amanat gridview
                    mycommand.CommandText =
                    @"select 
                    n1.name amanat_girandeh,
                    amanat.formdate,
                    amanat.todate,
                    DATEDIFF(DAY, amanat.todate, amanat.tahvildate) takhir,
                    amanat.tahvildate,
                    n2.name+' '+n2.family tah_dahandeh,
                    n3.name+' '+n3.family tah_girandeh,
                    amanat.tozihat_amanat,
                    amanat.tozihat_tahvil,
                    amanat.tahvil
                    from amanat
                    join ashkas n1 on amanat.personid=n1.pid
                    join users n2 on amanat.uid_dahandeh=n2.uid
                    join users n3 on amanat.uid_girandeh=n3.uid 
                            where amanat.parvandeh_id=" + txtb_parvandeh.Text + " order by amanatid DESC";
                    
                    myreader = mycommand.ExecuteReader();
                    dgvamanat.Rows.Clear();
                    if (myreader.HasRows)
                    {
                        while (myreader.Read())
                        {
                            dgvamanat.Rows.Add(myreader["amanat_girandeh"].ToString(),
                                myreader["formdate"],
                                myreader["todate"],
                                myreader["takhir"].ToString(),
                                myreader["tahvildate"],
                                myreader["tah_dahandeh"].ToString(), myreader["tah_girandeh"].ToString(),
                                myreader["tozihat_amanat"].ToString(), myreader["tozihat_tahvil"].ToString(),
                                myreader["tahvil"].ToString());

                        }

                    }
                    myreader.Close();

            #endregion load raked date label

                    #region Raked info load    
            if (raked)
            {
                mycommand.CommandText = "select raked_date from parvandeh where id=" + txtb_parvandeh.Text ;
                myreader = mycommand.ExecuteReader();
              
                if (myreader.HasRows)
                {
                    while (myreader.Read())
                    {
                        lblraked.Text = "پرونده در تاريخ" + common.persian_date((DateTime)myreader["raked_date"]).ToString() + " راكد شده است ";
                    }

                }
                myreader.Close();
               
                lblraked.BackColor = Color.FromArgb(255, 192, 192);
                lblraked.ForeColor = Color.Red;
            }
            else
            {
                lblraked.Text = "پرونده راكد نمي باشد      ";
                lblraked.BackColor = Color.White;
                lblraked.ForeColor = Color.Black;
            }

            #endregion

                    #region load amanat gridview امانت پس داده نشده
                    mycommand.CommandText =
                    @"select 
                    n1.name amanat_girandeh,
                    amanat.formdate,
                    amanat.todate,
                    DATEDIFF(DAY, amanat.todate, GETDATE()) takhir,
                    amanat.tahvildate,
                    n2.name+' '+n2.family tah_dahandeh,
					n1.semat, n1.mahalkar, n1.tel, 	
                    amanat.tozihat_amanat
                    from amanat
                    join ashkas n1 on amanat.personid=n1.pid
                    join users n2 on amanat.uid_dahandeh=n2.uid
					where tahvil=0
                    and amanat.parvandeh_id=" + txtb_parvandeh.Text + " order by amanatid DESC";

                    myreader = mycommand.ExecuteReader();
                   
                    if (myreader.HasRows)
                    {
                        int count_amanatjari=0;
                        while (myreader.Read())
                        {
                            count_amanatjari++;    
                            
                            lbltarikamanat.Text = common.persian_date((DateTime)myreader["formdate"]).ToString();
                            lblmohlatamanat.Text = common.persian_date((DateTime)myreader["todate"]).ToString();
                            lblamanatgirandeh.Text = myreader["amanat_girandeh"].ToString();
                            // Create the ToolTip and associate with the Form container.
                            ToolTip toolTip1 = new ToolTip();

                            // Set up the delays for the ToolTip.
                            toolTip1.AutoPopDelay = 5000;
                            toolTip1.InitialDelay = 500;
                            toolTip1.ReshowDelay = 500;
                            // Force the ToolTip text to be displayed whether or not the form is active.
                            toolTip1.ShowAlways = true;

                            // Set up the ToolTip text for the Button and Checkbox.
                            toolTip1.SetToolTip(this.lblamanatgirandeh, " امانت دهنده: " + myreader["tah_dahandeh"].ToString());
                             
                            lblsemat.Text = myreader["semat"].ToString();
                            lblmahalkar.Text = myreader["mahalkar"].ToString();
                            lbltel.Text = myreader["tel"].ToString();
                            txttozihat.Text =  myreader["tozihat_amanat"].ToString();

                            if (Convert.ToInt32(myreader["takhir"]) > 0)
                            {
                                lblmandeh.Text = myreader["takhir"].ToString() + "روز تاخير در تحويل پرونده تا امروز ";
                                lblmandeh.ForeColor = Color.Red;
                            }
                            if (Convert.ToInt32(myreader["takhir"]) == 0)
                            {
                                lblmandeh.Text = "امروز موعد تحويل پرونده است ";
                                lblmandeh.ForeColor = Color.Blue;
                            }
                            if (Convert.ToInt32(myreader["takhir"]) < 0)
                            {
                                lblmandeh.Text = Math.Abs(Convert.ToInt32(myreader["takhir"])) + "روز مانده به موعد تحويل پرونده تا امروز ";
                                lblmandeh.ForeColor = Color.DarkGreen;
                            }

                        }
                        if (count_amanatjari>1)
                             toolStripStatusLabelErr.Text ="خطايي در سيستم رخ داده، لطفاً به پشتيبان سيستم اطلاع دهيد";
                    }
                    myreader.Close();
                    #endregion

                    #region  load Attachments gridview
                    mycommand.CommandText ="SELECT picName, picExten, picid, picSize FROM docimages WHERE DocId = @DocId";
                    mycommand.Parameters.AddWithValue("@DocId", txtb_parvandeh.Text);
                    myreader = mycommand.ExecuteReader();
                    
                    if (myreader.HasRows)
                    {
                        while (myreader.Read())
                        {
                            dGAttachments.Rows.Add(myreader["picName"].ToString(), myreader["picExten"].ToString(),
                               common.SizeSuffix(Convert.ToInt64(myreader["picSize"])), myreader["picid"].ToString(), myreader["picSize"].ToString());

                            sumsize += Convert.ToInt64(myreader["picSize"]);
                        }

                    }
                    myreader.Close();
                    
                    lblSumSize.Text = common.SizeSuffix(sumsize);

                    #endregion load Attachments gridview

                }
                myconnection.Close();
            }
        }        
        
        
        private void frm_viewdoc_Load(object sender, EventArgs e)
        {

            doc_Log_amanat_Load();
            common.writelog(12, "مشاهده پرونده", txtb_parvandeh.Text, cUser.uid, txtb_parvandeh.Text);
        }
        
        private void btn_closefrm_Click(object sender, EventArgs e)
        {
           
        }

        private void dgvamanat_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvamanat.CurrentRow.Index >= 0)
            {
                txtbTozihatAmanat.Text = dgvamanat.CurrentRow.Cells["tozihat_amanat"].Value.ToString();
                txtbTozihatTahvil.Text = dgvamanat.CurrentRow.Cells["tozihat_tahvil"].Value.ToString();
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
                                    using (FileStream file = new FileStream(( tempFolderPath + "\\" + myreader["picName"].ToString() + myreader["picExten"].ToString())
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

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void frm_viewdoc_FormClosing(object sender, FormClosingEventArgs e)
        {
            common.DeleteTempFolder(txtb_parvandeh.Text);
        }

        private void ExittoolStripButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvlogs_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                ClassLog CurrentLog = new ClassLog();
                CurrentLog.LogTime = dgvlogs.CurrentRow.Cells["logdate"].Value.ToString();
                CurrentLog.UserName = dgvlogs.CurrentRow.Cells["username"].Value.ToString();
                CurrentLog.Subject = dgvlogs.CurrentRow.Cells["roydad"].Value.ToString();
                CurrentLog.Tozihat = dgvlogs.CurrentRow.Cells["tozihat"].Value.ToString();
                frm_ShowLog frm_ShowLog_i = new frm_ShowLog(CurrentLog);

                frm_ShowLog_i.ShowDialog();
            }
        }

        private void dGAttachments_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            btnViewAttachments.Enabled = true;
            btnSaveAttachments.Enabled = true;
        }

        private void dGAttachments_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            if (dGAttachments.RowCount <= 0)
            {
                btnViewAttachments.Enabled = false;
                btnSaveAttachments.Enabled = false;
            }
        }

        private void dgvamanat_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        } 
    }
}
