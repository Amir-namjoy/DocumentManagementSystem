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
    public partial class frm_usersmanagement : Form
    {
        public frm_usersmanagement()
        {
            InitializeComponent();
            كاربرجديدToolStripMenuItem.Enabled = cUser.addUser;
            مشخصاتToolStripMenuItem.Enabled = cUser.editUser;

        }
        
        User seluser = new User();

        private void Set_user()
        {
            seluser.name = dgv1.CurrentRow.Cells["name"].Value.ToString();
            seluser.family = dgv1.CurrentRow.Cells["family"].Value.ToString(); 
            seluser.username = dgv1.CurrentRow.Cells["username"].Value.ToString();
            seluser.personalid = dgv1.CurrentRow.Cells["personalid"].Value.ToString(); 
            seluser.semat = dgv1.CurrentRow.Cells["semat"].Value.ToString();
            seluser.allowLogin = (bool) dgv1.CurrentRow.Cells["allowLogin"].Value; 
            seluser.gender = dgv1.CurrentRow.Cells["gender"].Value.ToString();
            seluser.addNew = (bool)dgv1.CurrentRow.Cells["addnew"].Value; 
            seluser.editdoc = (bool) dgv1.CurrentRow.Cells["editdoc"].Value;
            seluser.showdoc = (bool)dgv1.CurrentRow.Cells["showdoc"].Value; 
            seluser.gozaresh = (bool) dgv1.CurrentRow.Cells["gozaresh"].Value;
            seluser.manageUsers = (bool)dgv1.CurrentRow.Cells["manageUsers"].Value;
            seluser.addUser = (bool)dgv1.CurrentRow.Cells["addUser"].Value;
            seluser.editUser = (bool) dgv1.CurrentRow.Cells["editUser"].Value;
            seluser.manageAshkas = (bool)dgv1.CurrentRow.Cells["manageAshkas"].Value;
            seluser.viewLog = (bool)dgv1.CurrentRow.Cells["viewlog"].Value;
            seluser.uid = dgv1.CurrentRow.Cells["uid"].Value.ToString();
        }
        private void load_user()
        {
            using (SqlConnection myconnection = new SqlConnection(DA.ConnectionString))
            {
                using (SqlCommand mycommand = new SqlCommand())
                {
                    myconnection.Open();
                    mycommand.Connection = myconnection;

                    string q = "select * from users";

                    mycommand.CommandText = q;

                    SqlDataReader myreader = mycommand.ExecuteReader();
                    dgv1.Rows.Clear();
                    if (myreader.HasRows)
                    {
                        while (myreader.Read())
                        {
                            dgv1.Rows.Add(myreader[0].ToString(), myreader[1].ToString(), myreader[3].ToString(), myreader[4].ToString(), 
                                myreader[5].ToString(), myreader[6].ToString(), myreader[7], myreader[8], myreader[9], myreader[10], 
                                myreader[11], myreader[12], myreader[13], myreader[14], myreader[15], myreader[15], myreader[17], myreader[16]);
                            // if (myreader[13].ToString()=="true")
                            //  dataGridView1.CurrentRow.

                        }

                    }
                }
                myconnection.Close();

                if (dgv1.Rows.Count == 0)
                {

                  //  كاربرجديدToolStripMenuItem.Enabled = false;
                    مشخصاتToolStripMenuItem.Enabled = false;
                    تغييررمزعبورToolStripMenuItem.Enabled = false;
                    جستجوToolStripMenuItem.Enabled = false;
                   // بازآوريToolStripMenuItem.Enabled = false;
                }
                else
                {
                   // كاربرجديدToolStripMenuItem.Enabled = true;
                    مشخصاتToolStripMenuItem.Enabled = true;
                    تغييررمزعبورToolStripMenuItem.Enabled = true;
                    جستجوToolStripMenuItem.Enabled = true;
                   // بازآوريToolStripMenuItem.Enabled = true;
                }

            }
        }

        private void frm_usersmanagement_Load(object sender, EventArgs e)
        {
            load_user();
        }

        private void بازآوريToolStripMenuItem_Click(object sender, EventArgs e)
        {
            load_user();
        }

        private void كاربرجديدToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_addUser frm_adduser_i = new frm_addUser();
            frm_adduser_i.ShowDialog();
            load_user();
        }

        private void تغييررمزعبورToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_changepass frm_changepass_i = new frm_changepass(dgv1.CurrentRow.Cells["uid"].Value.ToString(), 
                dgv1.CurrentRow.Cells["username"].Value.ToString(), dgv1.CurrentRow.Cells["name"].Value.ToString(),
                dgv1.CurrentRow.Cells["family"].Value.ToString());
            frm_changepass_i.ShowDialog();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void مشخصاتToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Set_user();
            common.TempUser.username = "";
            frm_edit_user feui = new frm_edit_user(seluser);
            feui.ShowDialog();
            if (common.TempUser.username != "")
            {
                dgv1.CurrentRow.Cells["username"].Value = common.TempUser.username;
                dgv1.CurrentRow.Cells["name"].Value = common.TempUser.name;
                dgv1.CurrentRow.Cells["family"].Value = common.TempUser.family;
                dgv1.CurrentRow.Cells["personalid"].Value = common.TempUser.personalid;
                dgv1.CurrentRow.Cells["semat"].Value = common.TempUser.semat;
                dgv1.CurrentRow.Cells["gender"].Value = common.TempUser.gender;
                dgv1.CurrentRow.Cells["addnew"].Value = common.TempUser.addNew;
                dgv1.CurrentRow.Cells["showdoc"].Value = common.TempUser.showdoc;
                dgv1.CurrentRow.Cells["editdoc"].Value = common.TempUser.editdoc;
                dgv1.CurrentRow.Cells["gozaresh"].Value = common.TempUser.gozaresh;
                dgv1.CurrentRow.Cells["manageusers"].Value = common.TempUser.manageUsers;
                dgv1.CurrentRow.Cells["adduser"].Value = common.TempUser.addUser;
                dgv1.CurrentRow.Cells["edituser"].Value = common.TempUser.editUser;
                dgv1.CurrentRow.Cells["manageashkas"].Value = common.TempUser.manageAshkas;
                dgv1.CurrentRow.Cells["viewlog"].Value = common.TempUser.viewLog;
                dgv1.CurrentRow.Cells["allowlogin"].Value = common.TempUser.allowLogin;
            }
        }

        private void dgv1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                Set_user();
                common.TempUser.username = "";
                frm_edit_user feui = new frm_edit_user(seluser);
                feui.ShowDialog();
                if (common.TempUser.username != "")
                {
                    dgv1.CurrentRow.Cells["username"].Value = common.TempUser.username;
                    dgv1.CurrentRow.Cells["name"].Value = common.TempUser.name;
                    dgv1.CurrentRow.Cells["family"].Value = common.TempUser.family;
                    dgv1.CurrentRow.Cells["personalid"].Value = common.TempUser.personalid;
                    dgv1.CurrentRow.Cells["semat"].Value = common.TempUser.semat;
                    dgv1.CurrentRow.Cells["gender"].Value = common.TempUser.gender;
                    dgv1.CurrentRow.Cells["addnew"].Value = common.TempUser.addNew;
                    dgv1.CurrentRow.Cells["showdoc"].Value = common.TempUser.showdoc;
                    dgv1.CurrentRow.Cells["editdoc"].Value = common.TempUser.editdoc;
                    dgv1.CurrentRow.Cells["gozaresh"].Value = common.TempUser.gozaresh;
                    dgv1.CurrentRow.Cells["manageusers"].Value = common.TempUser.manageUsers;
                    dgv1.CurrentRow.Cells["adduser"].Value = common.TempUser.addUser;
                    dgv1.CurrentRow.Cells["edituser"].Value = common.TempUser.editUser;
                    dgv1.CurrentRow.Cells["manageashkas"].Value = common.TempUser.manageAshkas;
                    dgv1.CurrentRow.Cells["viewlog"].Value = common.TempUser.viewLog;
                    dgv1.CurrentRow.Cells["allowlogin"].Value = common.TempUser.allowLogin;
                }
            }
        }
    }
}
