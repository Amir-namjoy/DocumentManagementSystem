using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Windows.Forms.VisualStyles;

namespace MaliArchive
{
    public partial class frm_viewlogs : Form
    {

        bool frmload = false;
        int curuid = -1;
        string CurrentUsername = "";

        class userDTO 
        {
          
            public int uid { get; set; }
            public string username { get; set; }
            public string name { get; set; }
            public string family { get; set; }

            
        }

        List<userDTO> users = new List<userDTO>();

        public frm_viewlogs()
        {
            InitializeComponent();
            

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frm_viewlogs_Load(object sender, EventArgs e)
        {

            

            //comblogs.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            //comblogs.AutoCompleteSource = AutoCompleteSource.CustomSource;
            //comblogs.AutoCompleteCustomSource = new AutoCompleteStringCollection();
            
            using (SqlConnection myconnection = new SqlConnection(DA.ConnectionString))
            {
                using (SqlCommand mycommand = new SqlCommand())
                {
                    myconnection.Open();
                    mycommand.Connection = myconnection;
                    mycommand.CommandText = "select * from users";
                    SqlDataReader myreader = mycommand.ExecuteReader();
                    //userDTO tempuser = new userDTO();
                    users.Add(new userDTO()
                    {
                        uid = -1,
                        username = "",
                        name = "",
                        family = "",
                    }
                        );                    
                    while (myreader.Read())
                    {
                       /* tempuser.uid = (int)myreader["uid"];
                        tempuser.username = myreader["username"].ToString();
                        tempuser.name = myreader["name"].ToString();
                        tempuser.family = myreader["family"].ToString();*/
                        users.Add(new userDTO()
                        {
                            uid = (int)myreader["uid"],
                            username = myreader["username"].ToString(),
                            name = myreader["name"].ToString(),
                            family = myreader["family"].ToString(),
                        }
                            );
                        // if (myreader[13].ToString()=="true")
                        //  dataGridView1.CurrentRow.
                        //comblogs.AutoCompleteCustomSource.Add(myreader["username"].ToString());
                    }


                }
            }
           frmload=true;

            comblogs.ValueMember = null;
            comblogs.DisplayMember = "username";
            comblogs.DataSource = users;

            combroydad.SelectedIndex = 0;
                      
        }


        private void comblogs_SelectedValueChanged(object sender, EventArgs e)
        {
            if (frmload && comblogs.SelectedValue != null)
            {

                userDTO current = (userDTO)comblogs.SelectedValue;

                lblfamily.Text = current.family.ToString();
                lblname.Text = current.name.ToString();
                curuid = current.uid;
                CurrentUsername = current.username;
                
            }
        }

        private void btnshowlog_Click(object sender, EventArgs e)
        {
            if (curuid == -1)
            {
                MessageBox.Show("لطفاً يك كاربر را انتخاب كنيد", "رويدادنگاري", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                string user = curuid.ToString();
                string logDate = "";

                using (SqlConnection myconnection = new SqlConnection(DA.ConnectionString))
                {
                    using (SqlCommand mycommand = new SqlCommand())
                    {
                        myconnection.Open();
                        mycommand.Connection = myconnection;
                        string royadad_query = "";
                        string date_query = "";

                        /*
                        *  1 ورود كاربر به سيستم
                        *  2 ورود رمز اشتباه 
                        *  3 افزودن كاربر جديد
                        *  4 ويرايش اطلاعات و دسترسي هاي كاربر
                        *  5 تغيير رمز عبور كاربر
                        *  6 تغيير رمز عبور كاربر جاري
                        *  7  تغيير رمز عبور كاربر جاري - ورود رمز اشتباه 
                        *  8 تهيه گزارش
                        *  9 افزودن پرونده جديد
                        *  10 ويرايش پرونده
                        *  11 خروج كاربر از سيستم
                        *  12 مشاهده پرونده
                        *  13 مشاهده پرونده از طريق ويرايش
                        *  14 افزودن شخص جديد
                        *  15 تغيير مشخصات شخص
                        *  16 گزارش رويدادنگاري
                        *  17 عدم اجازه ورود به سيستم
                        *  18 تبت امانت
                        *  19 تحويل امانت
                        */

                        if (combroydad.SelectedIndex == 0)
                            royadad_query = "";
                        else
                            royadad_query = " and code=" + combroydad.SelectedIndex;

                        if ((!fastartdate.IsNull && !faenddate.IsNull) &&
                            (fastartdate.SelectedDateTime.ToString("yyyy/MM/dd") == faenddate.SelectedDateTime.ToString("yyyy/MM/dd")))
                        {
                            date_query = " and CONVERT(varchar(10), logdate, 102) = '" + fastartdate.SelectedDateTime.ToString("yyyy.MM.dd") + "'";
                            logDate = string.Format(" در تاريخ {0}", fastartdate.Text);
                        }
                        else
                        {
                            if (!fastartdate.IsNull)
                            {
                                date_query = " and CONVERT(varchar(10), logdate, 102) >= '" + fastartdate.SelectedDateTime.ToString("yyyy/MM/dd") + "'";
                                logDate = string.Format(" باز زماني از: {0} ", fastartdate.Text);
                            }
                            if (!faenddate.IsNull)
                            {
                                date_query += " and CONVERT(varchar(10), logdate, 102) <= '" + faenddate.SelectedDateTime.ToString("yyyy/MM/dd") + "'";
                                logDate = string.Format(" تا: {0} ", faenddate.Text);
                            }
                        }
                        
                        if (combroydad.SelectedIndex == 2)
                            user = CurrentUsername;

                        mycommand.CommandText = @"select  userslog.*,n2.name+' '+n2.family username 
                                            from userslog 
                                            join users n2 on userslog.userid=n2.uid
                                            where userid=" + user + royadad_query + date_query + " order by logdate DESC";
                        
                        SqlDataReader myreader = mycommand.ExecuteReader();
                        dgvlogs.Rows.Clear();
                        if (myreader.HasRows)
                        {
                            while (myreader.Read())
                            {
                                dgvlogs.Rows.Add(dgvlogs.RowCount + 1,myreader["logdate"],
                                    myreader["username"].ToString(), myreader["roydad"].ToString(), myreader["tozihat"].ToString());
                                // if (myreader[13].ToString()=="true")
                                //  dataGridView1.CurrentRow.

                            }

                        }
                    }
                    string log = string.Format(" نام كاربري: {0}   رويداد: {1}   ",
                        user, combroydad.Text);
                    log += logDate;
                    common.writelog(16, "گزارش رويدادنگاري", log, cUser.uid, "");
                    myconnection.Close();
                }
            }
        }

        private void dgvlogs_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                ClassLog CurrentLog = new ClassLog();
                CurrentLog.LogTime =  dgvlogs.CurrentRow.Cells["logdate"].Value.ToString();
                CurrentLog.UserName = dgvlogs.CurrentRow.Cells["username"].Value.ToString();
                CurrentLog.Subject = dgvlogs.CurrentRow.Cells["roydad"].Value.ToString();
                CurrentLog.Tozihat = dgvlogs.CurrentRow.Cells["tozihat"].Value.ToString();
                frm_ShowLog frm_ShowLog_i = new frm_ShowLog(CurrentLog);

                frm_ShowLog_i.ShowDialog();
            }
        }

                                   
    }
}
