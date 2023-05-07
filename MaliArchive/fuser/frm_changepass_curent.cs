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
    public partial class frm_changepass_curent : Form
    {
       
        public frm_changepass_curent()
        {
            InitializeComponent();

           
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
                        string q = "select password from users where uid='" + cUser.uid + "'";
                        mycommand.CommandText = q;
                        SqlDataReader myreader = mycommand.ExecuteReader();
                        myreader.Read();
                        if (myreader.HasRows)
                            if (myreader["password"].ToString() == common.GetHashedPassword(txtOldpass.Text))
                            {
                                myreader.Close();
                                q = "update users set password='" + common.GetHashedPassword(txtNewpass.Text) + "' where uid='" + cUser.uid + "'";
                                mycommand.CommandText = q;
                                mycommand.ExecuteNonQuery();
                                common.writelog(6, "تغيير رمز عبور كاربر جاري", cUser.uid + " # " + cUser.username + " *** " + cUser.name + " " + cUser.family , cUser.uid,"");
                                MessageBox.Show("رمز عبور با موفقيت تغيير يافت", "تغيير رمز عبور", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.Close();
                            }
                            else
                            {
                                common.writelog(7, "تغيير ناموفق رمز عبور كاربر جاري - ورود رمز اشتباه", cUser.uid + " # " + cUser.username + " *** " + cUser.name + " " + cUser.family, cUser.uid, "");
                                MessageBox.Show("رمز عبور قبلي صحيح نمي باشد", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        else
                        {
                            myreader.Close();
                            MessageBox.Show("خطا در تغيير رمز عبور", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        }

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
