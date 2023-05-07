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
    public partial class frm_changepass : Form
    {
        string username1,  name1, family1, uid;
        public frm_changepass(string uid1, string username, string name, string family)
        {
            InitializeComponent();

            uid = uid1;
            username1=username;
            name1 = name; 
            family1 = family;
            lblname.Text = name + " " + family;
            lbluser.Text = username;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtNewpass.Text != txtNewpassr.Text)
                {
                    MessageBox.Show("كلمه هاي عبور جديد يكي نيستند", "تغيير كلمه عبور", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }

                using (SqlConnection myconnection = new SqlConnection(DA.ConnectionString))
                {
                    using (SqlCommand mycommand = new SqlCommand())
                    {
                        myconnection.Open();
                        mycommand.Connection = myconnection;
                        string q = "update users set password='" + common.GetHashedPassword(txtNewpass.Text) + "' where uid='" + uid + "'";
                        mycommand.CommandText = q;
                        mycommand.ExecuteNonQuery();
                        common.writelog(5, "تغيير رمز عبور", uid +" # "+ username1 + " *** " + name1+" "+family1, cUser.uid,"");
                        MessageBox.Show("رمز عبور با موفقيت تغيير يافت", "تغيير رمز عبور", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
 
                    }
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.ToString(), "بروز خطا", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }

        }
    }
}
