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
using MaliArchive.fdoc;
//using Microsoft. Office.Interop.Excel;

namespace MaliArchive
{
    public partial class FrmGozaresh : Form
    {

        private const string Raked_MESSAGEBOX = "RakedMsgcBox";
        private const string NoRaked_MESSAGEBOX = "NoRakedMsgcBox";
        private const string Result_MESSAGEBOX = "ResultMsgcBox";
        //frm_edit frm_edit_i;
        public FrmGozaresh()
        {
            InitializeComponent();
            common.setLanguageToFarsi();
            numericUD_parvandeh.Text = "";
            numericUpDownIdQuickReport.Text = "";
        }

        Doc selected_doc = new Doc();
        private const string MessageBoxQuickSearch="btnQuickSearch";

        private void set_doc_object_values()
        {
            selected_doc.id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["id"].Value); 
            selected_doc.tariktashkil= (DateTime) dataGridView1.CurrentRow.Cells["tariktashkil"].Value;
            selected_doc.personalid= dataGridView1.CurrentRow.Cells["personalid"].Value.ToString(); 
            selected_doc.daftarkol = dataGridView1.CurrentRow.Cells["daftarkol"].Value.ToString(); 
            selected_doc.name = dataGridView1.CurrentRow.Cells["name"].Value.ToString(); 
            selected_doc.family= dataGridView1.CurrentRow.Cells["family"].Value.ToString(); 
            selected_doc.passid= dataGridView1.CurrentRow.Cells["passid"].Value.ToString(); 
            selected_doc.nationalcode= dataGridView1.CurrentRow.Cells["nationalcode"].Value.ToString(); 
            selected_doc.father= dataGridView1.CurrentRow.Cells["father"].Value.ToString(); 
            selected_doc.eshteghal= dataGridView1.CurrentRow.Cells["eshteghal"].Value.ToString(); 
            selected_doc.tedadbarg= Convert.ToInt32(dataGridView1.CurrentRow.Cells["tedadbarg"].Value); 
            selected_doc.estekdam= dataGridView1.CurrentRow.Cells["estekdam"].Value.ToString();
            selected_doc.tozihat= dataGridView1.CurrentRow.Cells["tozihat"].Value.ToString();
            selected_doc.raked= Convert.ToBoolean(dataGridView1.CurrentRow.Cells["raked"].Value.ToString());
            selected_doc.amanat= Convert.ToBoolean(dataGridView1.CurrentRow.Cells["amanat"].Value.ToString()); 
            
        }

        private void جديدToolStripMenuItem_Click(object sender, EventArgs e)
        {
            numericUD_parvandeh.Value = 0;
           // txtb_tarikTaskil.Clear();
            txtb_personalid.Clear();
            txtb_daftarkol.Clear();
            comb_eshteghal.SelectedIndex = -1;
            txtb_name.Clear();
            txtb_family.Clear();
            txtb_fathername.Clear();
            txtb_passid.Clear();
            txtb_nationalCode.Clear();
            txtb_tozihat.Clear();
            radio_noRaked.Checked = true;
            radio_showAmanat.Checked = true;
            tabCresult.SelectedTab = tabPage1;
        }

        private void RunReport(bool QuickReport)
        {
            bool whereNist = true;

            string q = "select * from parvandeh";
            string logq = "";

            if (!QuickReport)
            {
                #region Make Query

                ///<summary>
                ///ایجاد کوئری 
                ///</summary>
                if ((numericUD_parvandeh.Value != 0) && (numericUD_parvandeh.Text != ""))
                {
                    if (whereNist)
                    {
                        q += " where ";
                        whereNist = false;
                    }
                    q += "id=" + numericUD_parvandeh.Value;
                    logq += "شماره پرونده: " + numericUD_parvandeh.Text;
                    logq += "       ";
                }
                
                if (!fdate_tarikTaskil_from.IsNull)
                {
                    if (whereNist)
                    {
                        q += " where ";
                        whereNist = false;
                    }
                    else
                        q += " and ";
                    q += "tarikTashkil >= '" + fdate_tarikTaskil_from.SelectedDateTime.ToString("yyyy/MM/dd") + "'";
                    logq += "تاريخ تشكيل پرونده از: " + fdate_tarikTaskil_from.Text;
                    logq += "       ";
                }

                if (!fdate_tarikTaskil_to.IsNull)
                {
                    if (whereNist)
                    {
                        q += " where ";
                        whereNist = false;
                    }
                    else
                        q += " and ";
                    q += "tarikTashkil <= '" + fdate_tarikTaskil_to.SelectedDateTime.ToString("yyyy/MM/dd") + "'";
                    logq += "شماره پرونده تا: " + fdate_tarikTaskil_to.Text;
                    logq += "       ";
                }

                if (comb_eshteghal.Text.Trim() != "")
                {
                    if (whereNist)
                    {
                        q += " where ";
                        whereNist = false;
                    }
                    else
                        q += " and ";
                    q += "eshteghal like '%" + comb_eshteghal.Text + "%' ";
                    logq += "وضعيت اشتغال: " + comb_eshteghal.Text;
                    logq += "       ";
                }
                if (txtb_personalid.Text.Trim() != "")
                {
                    if (whereNist)
                    {
                        q += " where ";
                        whereNist = false;
                    }
                    else
                        q += " and ";
                    q += "personalid like '%" + txtb_personalid.Text + "%' ";
                    logq += "شماره پرسنلي: " + txtb_personalid.Text;
                    logq += "       ";
                }
                if (txtb_daftarkol.Text.Trim() != "")
                {
                    if (whereNist)
                    {
                        q += " where ";
                        whereNist = false;
                    }
                    else
                        q += " and ";
                    q += "daftarkol like '%" + txtb_daftarkol.Text + "%' ";
                    logq += "شماره دفتركل: " + txtb_daftarkol.Text;
                    logq += "       ";
                }
                if (txtb_name.Text.Trim() != "")
                {
                    if (whereNist)
                    {
                        q += " where ";
                        whereNist = false;
                    }
                    else
                        q += " and ";
                    q += "name like '%" + txtb_name.Text + "%' ";
                    logq += "نام: " + txtb_name.Text;
                    logq += "       ";
                }
                if (txtb_family.Text.Trim() != "")
                {
                    if (whereNist)
                    {
                        q += " where ";
                        whereNist = false;
                    }
                    else
                        q += " and ";
                    q += "family like '%" + txtb_family.Text + "%' ";
                    logq += "نام خانوادگي: " + txtb_family.Text;
                    logq += "       ";
                }
                if (txtb_fathername.Text.Trim() != "")
                {
                    if (whereNist)
                    {
                        q += " where ";
                        whereNist = false;
                    }
                    else
                        q += " and ";
                    q += "father like '%" + txtb_fathername.Text + "%' ";
                    logq += "نام پدر: " + txtb_fathername.Text;
                    logq += "       ";
                }
                if (txtb_passid.Text.Trim() != "")
                {
                    if (whereNist)
                    {
                        q += " where ";
                        whereNist = false;
                    }
                    else
                        q += " and ";
                    q += "passid like '%" + txtb_passid.Text + "%' ";
                    logq += "شماره شناسنامه: " + txtb_passid.Text;
                    logq += "       ";
                }
                if (txtb_nationalCode.Text.Trim() != "")
                {
                    if (whereNist)
                    {
                        q += " where ";
                        whereNist = false;
                    }
                    else
                        q += " and ";
                    q += "nationalcode like '%" + txtb_nationalCode.Text + "%' ";
                    logq += "كدملي: " + txtb_nationalCode.Text;
                    logq += "       ";
                }
                if (!checkBox2.Checked)
                {
                    if (whereNist)
                    {
                        q += " where ";
                        whereNist = false;
                    }
                    else
                        q += " and ";
                    q += "tedadbarg =" + numericUpDownTedadBarg.Value;
                    logq += "تعداد برگ: " + numericUpDownTedadBarg.Text;
                    logq += "       ";
                }
                if (comb_estekdam.Text.Trim() != "")
                {
                    if (whereNist)
                    {
                        q += " where ";
                        whereNist = false;
                    }
                    else
                        q += " and ";
                    q += "estekdam like '%" + comb_estekdam.Text + "%' ";
                    logq += "نوع استخدام: " + comb_estekdam.Text;
                    logq += "       ";
                }
                if (txtb_tozihat.Text.Trim() != "")
                {
                    if (whereNist)
                    {
                        q += " where ";
                        whereNist = false;
                    }
                    else
                        q += " and ";
                    q += "tozihat like '%" + txtb_tozihat.Text + "%' ";
                    logq += "توضيحات: " + txtb_tozihat.Text;
                    logq += "       ";
                }

                if ((radio_noRaked.Checked) || (radio_onlyRaked.Checked))
                {
                    if (whereNist)
                    {
                        q += " where ";
                        whereNist = false;
                    }
                    else
                        q += " and ";
                    q += "raked =" + Convert.ToInt32(radio_onlyRaked.Checked);
                    logq += "فقط نمايش پرونده هاي راكد: " + radio_onlyRaked.Checked;
                    logq += "       ";
                }

                if ((radio_onlyAmanat.Checked) || (radio_noAmanat.Checked))
                {
                    if (whereNist)
                    {
                        q += " where ";
                        whereNist = false;
                    }
                    else
                        q += " and ";
                    q += "amanat =" + Convert.ToInt32(radio_onlyAmanat.Checked);
                    logq += "فقط نمايش پرونده هاي امانت داده شده: " + radio_onlyAmanat.Checked;
                    logq += "       ";
                }

                #endregion make Query
            }
            else
            {
                q += " Where id=" + numericUpDownIdQuickReport.Value;
                logq += "جستجوي سريع --- شماره پرونده: " + numericUpDownIdQuickReport.Value;
                logq += "       ";
            }

            #region Run Query
            using (SqlConnection myconnection = new SqlConnection(DA.ConnectionString))
            {
                using (SqlCommand mycommand = new SqlCommand())
                {
                    myconnection.Open();
                    mycommand.Connection = myconnection;

                    mycommand.CommandText = q;
                    SqlDataReader myreader = mycommand.ExecuteReader();
             
                    dataGridView1.Rows.Clear();
                    if (myreader.HasRows)
                    {
                        while (myreader.Read())
                        {
                            dataGridView1.Rows.Add(dataGridView1.RowCount + 1, myreader["id"].ToString(), myreader["tarikTashkil"],
                                myreader["personalid"].ToString(), myreader["daftarkol"].ToString(), myreader["name"].ToString(), myreader["family"].ToString(),
                                myreader["passid"].ToString(), myreader["nationalcode"].ToString(), myreader["father"].ToString(), myreader["eshteghal"].ToString(),
                                myreader["tedadbarg"].ToString(), myreader["estekdam"].ToString(), myreader["tozihat"].ToString(), myreader["raked"].ToString(),
                                myreader["amanat"].ToString(), myreader["amanatid"].ToString());
                            //radGridView1.Rows.Add(myreader["tarikTashkil"]);
                        }

                        if (checkBox_amanatColor.Checked || checkBoxRakedColor.Checked)
                            foreach (DataGridViewRow row in dataGridView1.Rows)
                            {
                                if (Convert.ToBoolean(row.Cells["amanat"].Value) && checkBox_amanatColor.Checked)
                                    row.DefaultCellStyle.BackColor = btnAmanatColor.BackColor;
                                if (Convert.ToBoolean(row.Cells["raked"].Value) && checkBoxRakedColor.Checked)
                                    row.DefaultCellStyle.BackColor = btnRakedColor.BackColor;
                            }

                        lblResultTedad.Text = dataGridView1.RowCount.ToString() + " پرونده";
                        string ResultPages = string.Format("صفحه 1 از 1 [ 1 تا {0}]", dataGridView1.RowCount.ToString());
                        combResultPages.Items.Clear();
                        combResultPages.Items.Add(ResultPages);
                        combResultPages.SelectedIndex = 0;

                    }
                    
                    if (logq.Trim().Equals(""))
                        logq = "همه پرونده ها";
                    logq += " نتيجه: " + lblResultTedad.Text;
                    common.writelog(8, "تهيه گزارش", logq, cUser.uid, "");

                }
                myconnection.Close();
            }
            #endregion
        }
        
        private void اجرايگزارشToolStripMenuItem_Click(object sender, EventArgs e)
        {
            اجرايگزارشToolStripMenuItem.Image = MaliArchive.Properties.Resources.stop;

            RunReport(false);
             
            tabCresult.SelectedTab = tabPage2;
            اجرايگزارشToolStripMenuItem.Image = MaliArchive.Properties.Resources.run;
            if (dataGridView1.Rows.Count == 0)
            {
                خروجیبهاکسلToolStripMenuItem.Enabled = false;
                //راكدكردنپروندهToolStripMenuItem.Enabled = false;
                مشاهدهپروندهToolStripMenuItem.Enabled = false;
                ويرايشپروندهToolStripMenuItem.Enabled = false;
                
                ثبتامانتToolStripMenuItem.Enabled = false;
                تحويلامانتToolStripMenuItem.Enabled = false;
                راکدکردنپروندهToolStripMenuItem.Enabled = false;
                فعالکردنپروندهToolStripMenuItem.Enabled = false;
            }
            else
            {
                خروجیبهاکسلToolStripMenuItem.Enabled = true;
                //راكدكردنپروندهToolStripMenuItem.Enabled = true;
                مشاهدهپروندهToolStripMenuItem.Enabled = cUser.showdoc;
                ويرايشپروندهToolStripMenuItem.Enabled = cUser.editdoc;

                if (Convert.ToBoolean(dataGridView1.CurrentRow.Cells["amanat"].Value))
                {
                    ثبتامانتToolStripMenuItem.Enabled = false;
                    تحويلامانتToolStripMenuItem.Enabled = true;
                }
                else
                {
                    ثبتامانتToolStripMenuItem.Enabled = true;
                    تحويلامانتToolStripMenuItem.Enabled = false;
                }

                if (Convert.ToBoolean(dataGridView1.CurrentRow.Cells["raked"].Value))
                {
                    راکدکردنپروندهToolStripMenuItem.Enabled = false;
                    فعالکردنپروندهToolStripMenuItem.Enabled = true;
                }
                else
                {
                    راکدکردنپروندهToolStripMenuItem.Enabled = true;
                    فعالکردنپروندهToolStripMenuItem.Enabled = false;
                }
            }

        }
        
        private void ويرايشپروندهToolStripMenuItem_Click(object sender, EventArgs e)
        {

            set_doc_object_values();
            FrmEdit frm_edit_i = new FrmEdit(selected_doc);
            common.TempDoc.personalid = null;
            frm_edit_i.ShowDialog();

            if (common.TempDoc.personalid != null)
            {
                dataGridView1.CurrentRow.Cells["tarikTashkil"].Value = common.TempDoc.tariktashkil;
                dataGridView1.CurrentRow.Cells["personalid"].Value = common.TempDoc.personalid;
                dataGridView1.CurrentRow.Cells["daftarkol"].Value = common.TempDoc.daftarkol;
                dataGridView1.CurrentRow.Cells["name"].Value = common.TempDoc.name;
                dataGridView1.CurrentRow.Cells["family"].Value = common.TempDoc.family;
                dataGridView1.CurrentRow.Cells["passid"].Value = common.TempDoc.passid;
                dataGridView1.CurrentRow.Cells["nationalcode"].Value = common.TempDoc.nationalcode;
                dataGridView1.CurrentRow.Cells["father"].Value = common.TempDoc.father;
                dataGridView1.CurrentRow.Cells["eshteghal"].Value = common.TempDoc.eshteghal;
                dataGridView1.CurrentRow.Cells["tedadbarg"].Value = common.TempDoc.tedadbarg;
                dataGridView1.CurrentRow.Cells["estekdam"].Value = common.TempDoc.estekdam;
                dataGridView1.CurrentRow.Cells["tozihat"].Value = common.TempDoc.tozihat;
                txtResultTozihat.Text = common.TempDoc.tozihat;
            }
           // اجرايگزارشToolStripMenuItem_Click(null,null);
          /*  if (frm_edit_i != null)
            {
                frm_edit_i.Show();

            }  
            else
            {
                frm_edit_i = new frm_edit(Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value), dataGridView1.CurrentRow.Cells[1].Value.ToString(), dataGridView1.CurrentRow.Cells[3].Value.ToString(), dataGridView1.CurrentRow.Cells[4].Value.ToString(), dataGridView1.CurrentRow.Cells[5].Value.ToString(), dataGridView1.CurrentRow.Cells[6].Value.ToString(), dataGridView1.CurrentRow.Cells[7].Value.ToString(), dataGridView1.CurrentRow.Cells[8].Value.ToString(), dataGridView1.CurrentRow.Cells[9].Value.ToString(), dataGridView1.CurrentRow.Cells[2].Value.ToString(), dataGridView1.CurrentRow.Cells[10].Value.ToString());
                //frm_edit_i.MdiParent = ;
                frm_edit_i.Show();
                frm_edit_i.FormClosing +=frm_edit_i_FormClosing;
            }*/
        }

    /*   private void frm_edit_i_FormClosing(object sender, FormClosingEventArgs e)
        {
            frm_edit_i = null;
        }*/

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            numericUpDownTedadBarg.Enabled = !numericUpDownTedadBarg.Enabled;
        }

        private void مشاهدهپروندهToolStripMenuItem_Click(object sender, EventArgs e)
        {

            set_doc_object_values();
            frm_viewdoc frm_viewdoc_i = new frm_viewdoc(selected_doc);

            frm_viewdoc_i.Show();
        }

        private void txtb_parvandeh_TextChanged(object sender, EventArgs e)
        {

        }

        private void خروجیبهاکسلToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

      /*  private void btn_clearfromd_Click(object sender, EventArgs e)
        {
            fdate_tarikTaskil_from.yy.Text = "";
            fdate_tarikTaskil_from.mm.Text = "";
            fdate_tarikTaskil_from.dd.Text = "";
        }

        private void btn_cleartod_Click(object sender, EventArgs e)
        {
            fdate_tarikTaskil_to.yy.Text = "";
            fdate_tarikTaskil_to.mm.Text = "";
            fdate_tarikTaskil_to.dd.Text = "";
        }*/

 
        private void checkBox2_CheckedChanged_1(object sender, EventArgs e)
        {
            numericUpDownTedadBarg.Enabled = !numericUpDownTedadBarg.Enabled;
        }

        private void ثبتامانتToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //set_doc_object_values();
            DataGridViewRow clonedRow = (DataGridViewRow) dataGridView1.CurrentRow.Clone();
            for (Int32 index = 0; index < dataGridView1.CurrentRow.Cells.Count; index++)
            {
                clonedRow.Cells[index].Value = dataGridView1.CurrentRow.Cells[index].Value;
            }
            frm_amanat frm_amanat_i = new frm_amanat(clonedRow);
            common.TempDoc.amanat = false;
            frm_amanat_i.ShowDialog();
            dataGridView1.CurrentRow.Cells["amanat"].Value = common.TempDoc.amanat;
            if (Convert.ToBoolean(dataGridView1.CurrentRow.Cells["amanat"].Value) && checkBox_amanatColor.Checked)
                dataGridView1.CurrentRow.DefaultCellStyle.BackColor = btnAmanatColor.BackColor;
            
            if (dataGridView1.RowCount >= 0)
            {
                if (Convert.ToBoolean(dataGridView1.CurrentRow.Cells["amanat"].Value))
                {
                    ثبتامانتToolStripMenuItem.Enabled = false;
                    تحويلامانتToolStripMenuItem.Enabled = true;
                }
                else
                {
                    ثبتامانتToolStripMenuItem.Enabled = true;
                    تحويلامانتToolStripMenuItem.Enabled = false;
                }

            }
           // اجرايگزارشToolStripMenuItem_Click(null, null);
        }

        private void تحويلامانتToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataGridViewRow clonedRow = (DataGridViewRow)dataGridView1.CurrentRow.Clone();
            for (Int32 index = 0; index < dataGridView1.CurrentRow.Cells.Count; index++)
            {
                clonedRow.Cells[index].Value = dataGridView1.CurrentRow.Cells[index].Value;
            }
            frm_tahvil_amanat frm_tahvil_amanat_i = new frm_tahvil_amanat(clonedRow);
            common.TempDoc.amanat = true;
            frm_tahvil_amanat_i.ShowDialog();
            dataGridView1.CurrentRow.Cells["amanat"].Value = common.TempDoc.amanat;
            if (!Convert.ToBoolean(dataGridView1.CurrentRow.Cells["amanat"].Value))
                dataGridView1.CurrentRow.DefaultCellStyle.BackColor = dataGridView1.BackgroundColor;
            if (dataGridView1.RowCount >= 0)
            {
                if (Convert.ToBoolean(dataGridView1.CurrentRow.Cells["amanat"].Value))
                {
                    ثبتامانتToolStripMenuItem.Enabled = false;
                    تحويلامانتToolStripMenuItem.Enabled = true;
                }
                else
                {
                    ثبتامانتToolStripMenuItem.Enabled = true;
                    تحويلامانتToolStripMenuItem.Enabled = false;
                }

            }
            //اجرايگزارشToolStripMenuItem_Click(null, null);
        }

 
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                set_doc_object_values();
                frm_viewdoc frm_viewdoc_i = new frm_viewdoc(selected_doc);

                frm_viewdoc_i.Show();
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {

            if (dataGridView1.RowCount >= 0)
            {
                if (Convert.ToBoolean(dataGridView1.CurrentRow.Cells["amanat"].Value))
                {
                    ثبتامانتToolStripMenuItem.Enabled = false;
                    تحويلامانتToolStripMenuItem.Enabled = true;
                }
                else
                {
                    ثبتامانتToolStripMenuItem.Enabled = true;
                    تحويلامانتToolStripMenuItem.Enabled = false;
                }

                if (Convert.ToBoolean(dataGridView1.CurrentRow.Cells["raked"].Value))
                {
                    راکدکردنپروندهToolStripMenuItem.Enabled = false;
                    فعالکردنپروندهToolStripMenuItem.Enabled = true;
                }
                else
                {
                    راکدکردنپروندهToolStripMenuItem.Enabled = true;
                    فعالکردنپروندهToolStripMenuItem.Enabled = false;
                }

                txtResultTozihat.Text = dataGridView1.CurrentRow.Cells["tozihat"].Value.ToString();
            }

        }

        private void راکدکردنپروندهToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FAMessageBox msgRaked;
            msgRaked = FAMessageBoxManager.GetMessageBox(Raked_MESSAGEBOX);
            if (FAMessageBoxManager.GetMessageBox(Raked_MESSAGEBOX) == null)
            {
                msgRaked = FAMessageBoxManager.CreateMessageBox(Raked_MESSAGEBOX, true);
                // msg.AllowSaveResponse = true;
                //msg.SaveResponseText = "سوال را تکرار نکن";
                msgRaked.Caption = "راكد كردن پرونده";
                msgRaked.Icon = FarsiMessageBoxExIcon.Warning;
                msgRaked.PlaySound = true;
                msgRaked.Text = " آيا مايل به راكد كردن پرونده شماره " + dataGridView1.CurrentRow.Cells["id"].Value.ToString() + " هستيد؟ ";
                msgRaked.AddButton("خير", "No");
                msgRaked.AddButton("بله", "Yes");
            }

            if (msgRaked.Show(this) == "Yes")
            {
                int raked = 200; 
                raked =  Convert.ToInt32(DA.raked_doc(dataGridView1.CurrentRow.Cells["id"].Value.ToString()));
                

                FAMessageBox msgResult;
                msgResult = FAMessageBoxManager.GetMessageBox(Result_MESSAGEBOX);
                if (FAMessageBoxManager.GetMessageBox(Result_MESSAGEBOX) == null)
                {
                    msgResult = FAMessageBoxManager.CreateMessageBox(Result_MESSAGEBOX, true);
                    msgResult.AddButtons(MessageBoxButtons.OK);
                }
                // msg.AllowSaveResponse = true;
                //msg.SaveResponseText = "سوال را تکرار نکن";
                msgResult.Caption = "راكد كردن پرونده";
                msgResult.Icon = FarsiMessageBoxExIcon.Information;
                msgResult.PlaySound = true;
                msgResult.Text = " پرونده شماره " + dataGridView1.CurrentRow.Cells["id"].Value.ToString() + " راكد شد ";

                msgResult.Show(this);

                dataGridView1.CurrentRow.Cells["raked"].Value = true;
                if (checkBoxRakedColor.Checked)
                    dataGridView1.CurrentRow.DefaultCellStyle.BackColor = btnRakedColor.BackColor;

                راکدکردنپروندهToolStripMenuItem.Enabled = false;
                فعالکردنپروندهToolStripMenuItem.Enabled = true;
                //اجرايگزارشToolStripMenuItem_Click(null, null);
            }

        }

        private void فعالکردنپروندهToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FAMessageBox msgNoRaked;
            msgNoRaked = FAMessageBoxManager.GetMessageBox(NoRaked_MESSAGEBOX);
            if (FAMessageBoxManager.GetMessageBox(NoRaked_MESSAGEBOX) == null)
            {
                msgNoRaked = FAMessageBoxManager.CreateMessageBox(NoRaked_MESSAGEBOX, true);
                // msg.AllowSaveResponse = true;
                //msg.SaveResponseText = "سوال را تکرار نکن";
                msgNoRaked.Caption = "فعال كردن پرونده";
                msgNoRaked.Icon = FarsiMessageBoxExIcon.Warning;
                msgNoRaked.PlaySound = true;
                msgNoRaked.Text = " آيا مايل به فعال كردن پرونده شماره " + dataGridView1.CurrentRow.Cells["id"].Value.ToString() + " هستيد؟ ";
                msgNoRaked.AddButton("خير", "No");
                msgNoRaked.AddButton("بله", "Yes");
            }

            if (msgNoRaked.Show(this) == "Yes")
             {
                string q = "update parvandeh set raked=0 where id=" + dataGridView1.CurrentRow.Cells["id"].Value.ToString();
                DA.run_Query(q);
                
                FAMessageBox msgResult;
                msgResult = FAMessageBoxManager.GetMessageBox(Result_MESSAGEBOX);
                if (FAMessageBoxManager.GetMessageBox(Result_MESSAGEBOX) == null)
                {
                    msgResult = FAMessageBoxManager.CreateMessageBox(Result_MESSAGEBOX, true);
                    msgResult.AddButtons(MessageBoxButtons.OK);

                }
                // msg.AllowSaveResponse = true;
                //msg.SaveResponseText = "سوال را تکرار نکن";
                msgResult.Caption = "فعال كردن پرونده";
                msgResult.Icon = FarsiMessageBoxExIcon.Information;
                msgResult.PlaySound = true;
                msgResult.Text = " پرونده شماره " + dataGridView1.CurrentRow.Cells["id"].Value.ToString() + " فعال شد ";
                msgResult.Show(this);

                dataGridView1.CurrentRow.Cells["raked"].Value = false;
                dataGridView1.CurrentRow.DefaultCellStyle.BackColor = dataGridView1.BackgroundColor;

                راکدکردنپروندهToolStripMenuItem.Enabled = true;
                فعالکردنپروندهToolStripMenuItem.Enabled = false;
                // اجرايگزارشToolStripMenuItem_Click(null, null);
            }
        }

        private void numericUD_KeyUp(object sender, KeyEventArgs e)
        {
            if (numericUD_parvandeh.Text == "")
                numericUD_parvandeh.Value = 0;
            if (numericUD_parvandeh.Value == 0)
                numericUD_parvandeh.Text = "";
        }

        private void txtb_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!((int)e.KeyChar >= 48 && (int)e.KeyChar <= 58 || (int)e.KeyChar == (int)Keys.Back))
                e.KeyChar = (char)27;
        }

 
        private void frm_gozaresh_Load(object sender, EventArgs e)
        {
            foreach (DataGridViewColumn col in dataGridView1.Columns)
                if (col.ToolTipText.Length > 0)
                    checkedListBoxCloumnSelection.Items.Add(col.HeaderText, col.Visible);

            
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            
            for (int i = 0; i < checkedListBoxCloumnSelection.Items.Count; i++)
                dataGridView1.Columns[i].Visible = checkedListBoxCloumnSelection.GetItemChecked(i);
           
            tabCresult.SelectedTab = tabPage2;
            
        }

        private void btnSetDefCloumns_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewColumn col in dataGridView1.Columns)
                if (col.ToolTipText.Length > 0)
                    col.Visible=true;
            checkedListBoxCloumnSelection.Items.Clear();
            foreach (DataGridViewColumn col in dataGridView1.Columns)
                if (col.ToolTipText.Length > 0)
                    checkedListBoxCloumnSelection.Items.Add(col.HeaderText, col.Visible);
        }

        private void radio_noAmanat_CheckedChanged(object sender, EventArgs e)
        {
            checkBox_amanatColor.Enabled = !radio_noAmanat.Enabled;
        }
        private void radio_showAmanat_CheckedChanged(object sender, EventArgs e)
        {
            checkBox_amanatColor.Enabled = radio_showAmanat.Enabled;
        }
        private void radio_onlyAmanat_CheckedChanged(object sender, EventArgs e)
        {
            checkBox_amanatColor.Enabled = radio_onlyAmanat.Enabled;
        }

        private void radio_noRaked_CheckedChanged(object sender, EventArgs e)
        {
            checkBoxRakedColor.Enabled = !radio_noRaked.Enabled;
        }

        private void radio_showRaked_CheckedChanged(object sender, EventArgs e)
        {
            checkBoxRakedColor.Enabled = radio_showRaked.Enabled;
        }

        private void radio_onlyRaked_CheckedChanged(object sender, EventArgs e)
        {
            checkBoxRakedColor.Enabled = !radio_onlyRaked.Enabled;
        }

        private void btnAmanatColor_Click(object sender, EventArgs e)
        {
            // Update the btnAmanatColor color if the user clicks OK  
            if (colorDialog1.ShowDialog() == DialogResult.OK)
                btnAmanatColor.BackColor = colorDialog1.Color;
        }

        private void btnRakedColor_Click(object sender, EventArgs e)
        {
            // Update the btnRakedColor color if the user clicks OK  
            if (colorDialog1.ShowDialog() == DialogResult.OK)
                btnRakedColor.BackColor = colorDialog1.Color;
        }

        private void btnQuickSearch_Click(object sender, EventArgs e)
        {
            FAMessageBox msg;
            msg = FAMessageBoxManager.GetMessageBox(MessageBoxQuickSearch);
            if (FAMessageBoxManager.GetMessageBox(MessageBoxQuickSearch) == null)
            {
                msg = FAMessageBoxManager.CreateMessageBox(MessageBoxQuickSearch, true);
                msg.AddButtons(MessageBoxButtons.OK);
            }
            if ((numericUpDownIdQuickReport.Value == 0) || (numericUpDownIdQuickReport.Text.Trim() == ""))
            {


                msg.Caption = "گزارش سريع";
                msg.Icon = FarsiMessageBoxExIcon.Warning;
                msg.PlaySound = true;
                msg.Text = "*شماره پرونده را مشخص كنيد\n";
                msg.Show(this);
                FAMessageBoxManager.DeleteMessageBox(MessageBoxQuickSearch);
                return;
            }

            اجرايگزارشToolStripMenuItem.Image = MaliArchive.Properties.Resources.stop;

            RunReport(true);

            tabCresult.SelectedTab = tabPage2;
            اجرايگزارشToolStripMenuItem.Image = MaliArchive.Properties.Resources.run;
            if (dataGridView1.Rows.Count == 0)
            {
                خروجیبهاکسلToolStripMenuItem.Enabled = false;
                //راكدكردنپروندهToolStripMenuItem.Enabled = false;
                مشاهدهپروندهToolStripMenuItem.Enabled = false;
                ويرايشپروندهToolStripMenuItem.Enabled = false;

                ثبتامانتToolStripMenuItem.Enabled = false;
                تحويلامانتToolStripMenuItem.Enabled = false;
                راکدکردنپروندهToolStripMenuItem.Enabled = false;
                فعالکردنپروندهToolStripMenuItem.Enabled = false;
            }
            else
            {
                خروجیبهاکسلToolStripMenuItem.Enabled = true;
                //راكدكردنپروندهToolStripMenuItem.Enabled = true;
                مشاهدهپروندهToolStripMenuItem.Enabled = cUser.showdoc;
                ويرايشپروندهToolStripMenuItem.Enabled = cUser.editdoc;

                if (Convert.ToBoolean(dataGridView1.CurrentRow.Cells["amanat"].Value))
                {
                    ثبتامانتToolStripMenuItem.Enabled = false;
                    تحويلامانتToolStripMenuItem.Enabled = true;
                }
                else
                {
                    ثبتامانتToolStripMenuItem.Enabled = true;
                    تحويلامانتToolStripMenuItem.Enabled = false;
                }

                if (Convert.ToBoolean(dataGridView1.CurrentRow.Cells["raked"].Value))
                {
                    راکدکردنپروندهToolStripMenuItem.Enabled = false;
                    فعالکردنپروندهToolStripMenuItem.Enabled = true;
                }
                else
                {
                    راکدکردنپروندهToolStripMenuItem.Enabled = true;
                    فعالکردنپروندهToolStripMenuItem.Enabled = false;
                }
            }
        }

        private void numericUpDownIdQuickReport_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Keys)e.KeyChar == Keys.Enter)
                btnQuickSearch_Click(null, null);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void FrmGozaresh_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Properties.Settings.Default.Save();
        }





 
    }
}
