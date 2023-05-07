using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace MaliArchive
{
    public partial class frm_amanatgirandegan : Form
    {
        public frm_amanatgirandegan()
        {
            InitializeComponent();
        }

        shaks selected_shaks = new shaks();

        private void set_shaks_obj_valuse()
        {
            selected_shaks.pid = Convert.ToInt32(dgv1.CurrentRow.Cells["person_id"].Value);
            selected_shaks.name = dgv1.CurrentRow.Cells["name"].Value.ToString();
            selected_shaks.personid = dgv1.CurrentRow.Cells["personalid"].Value.ToString();
            selected_shaks.semat = dgv1.CurrentRow.Cells["semat"].Value.ToString();
            selected_shaks.mahalkar = dgv1.CurrentRow.Cells["mahalkar"].Value.ToString();
            selected_shaks.tel = dgv1.CurrentRow.Cells["tel"].Value.ToString();
            selected_shaks.mobile = dgv1.CurrentRow.Cells["mobile"].Value.ToString();
            selected_shaks.gender = dgv1.CurrentRow.Cells["gender"].Value.ToString();
            selected_shaks.tozihat = dgv1.CurrentRow.Cells["tozihat"].Value.ToString();
        }

        private void load_user()
        {
            using (SqlConnection myconnection = new SqlConnection(DA.ConnectionString))
            {
                using (SqlCommand mycommand = new SqlCommand())
                {
                    myconnection.Open();
                    mycommand.Connection = myconnection;

                    string q = "select * from ashkas";

                    mycommand.CommandText = q;

                    SqlDataReader myreader = mycommand.ExecuteReader();
                    dgv1.Rows.Clear();
                    if (myreader.HasRows)
                    {
                        while (myreader.Read())
                        {
                            dgv1.Rows.Add(myreader["pid"].ToString(), myreader["name"].ToString(), myreader["personalid"].ToString(), 
                                myreader["semat"].ToString(), myreader["tozihat"].ToString(),
                                myreader["mahalkar"].ToString(), myreader["tel"].ToString(),
                                myreader["mobile"].ToString(), myreader["gender"].ToString());
                        }

                    }
                }
                myconnection.Close();

                if (dgv1.Rows.Count == 0)
                {
                    مشخصاتToolStripMenuItem.Enabled = false;
                    جستجوToolStripMenuItem.Enabled = false;
                }
                else
                {
                    مشخصاتToolStripMenuItem.Enabled = true;
                    جستجوToolStripMenuItem.Enabled = true;
                }

            }
        }

        private void بازآوريToolStripMenuItem_Click(object sender, EventArgs e)
        {
            load_user();
        }

        private void frm_amanatgirandegan_Load(object sender, EventArgs e)
        {
            load_user();
        }

        private void كاربرجديدToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_add_ashkas frm_add_ashkas_i = new frm_add_ashkas();
            frm_add_ashkas_i.ShowDialog();
            load_user();
        }

        private void مشخصاتToolStripMenuItem_Click(object sender, EventArgs e)
        {
            set_shaks_obj_valuse();
            common.TempShaks.name = "";
            frm_edit_ashkas frm_edit_ashkas_i = new frm_edit_ashkas(selected_shaks);
            frm_edit_ashkas_i.ShowDialog();
            if (common.TempShaks.name != "")
            {
                dgv1.CurrentRow.Cells["name"].Value = common.TempShaks.name;
                dgv1.CurrentRow.Cells["personalid"].Value = common.TempShaks.personid;
                dgv1.CurrentRow.Cells["semat"].Value = common.TempShaks.semat;
                dgv1.CurrentRow.Cells["tozihat"].Value = common.TempShaks.tozihat;
                dgv1.CurrentRow.Cells["mahalkar"].Value = common.TempShaks.mahalkar;
                dgv1.CurrentRow.Cells["tel"].Value = common.TempShaks.tel;
                dgv1.CurrentRow.Cells["mobile"].Value = common.TempShaks.mobile;
                dgv1.CurrentRow.Cells["gender"].Value = common.TempShaks.gender;
            }
        }

        private void dgv1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                set_shaks_obj_valuse();
                common.TempShaks.name = "";
                frm_edit_ashkas frm_edit_ashkas_i = new frm_edit_ashkas(selected_shaks);
                frm_edit_ashkas_i.ShowDialog();
                if (common.TempShaks.name != "")
                {
                    dgv1.CurrentRow.Cells["name"].Value = common.TempShaks.name;
                    dgv1.CurrentRow.Cells["personalid"].Value = common.TempShaks.personid;
                    dgv1.CurrentRow.Cells["semat"].Value = common.TempShaks.semat;
                    dgv1.CurrentRow.Cells["tozihat"].Value = common.TempShaks.tozihat;
                    dgv1.CurrentRow.Cells["mahalkar"].Value = common.TempShaks.mahalkar;
                    dgv1.CurrentRow.Cells["tel"].Value = common.TempShaks.tel;
                    dgv1.CurrentRow.Cells["mobile"].Value = common.TempShaks.mobile;
                    dgv1.CurrentRow.Cells["gender"].Value = common.TempShaks.gender;
                }
            }
            
        }
    }
}
