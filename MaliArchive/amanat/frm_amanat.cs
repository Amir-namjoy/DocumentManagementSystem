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
    public partial class frm_amanat : Form
    {

        bool frmload = false;
        int curpid = -1;
        class personDTO
        {

            public int sid { get; set; }
            public string name { get; set; }
            public string semat { get; set; }
            public string mahalkar { get; set; }
            public string tel { get; set; }
        }

        public frm_amanat(DataGridViewRow Row)
        {
            InitializeComponent();
            common.setLanguageToFarsi();
            this.Text += Row.Cells[0].Value.ToString();
            dgvpi.Rows.Add(Row);

        }

        private void loadcomb()
        {
             List<personDTO> users = new List<personDTO>();

             comblpersons.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
             comblpersons.AutoCompleteSource = AutoCompleteSource.ListItems;
           
            
            using (SqlConnection myconnection = new SqlConnection(DA.ConnectionString))
            {
                using (SqlCommand mycommand = new SqlCommand())
                {
                    myconnection.Open();
                    mycommand.Connection = myconnection;
                    mycommand.CommandText = "select * from ashkas";
                    SqlDataReader myreader = mycommand.ExecuteReader();
                    personDTO tempuser = new personDTO();
                    users.Add(new personDTO()
                    {
                        sid = -1,
                        name = "",
                        semat = "",
                        mahalkar = "",
                        tel = ""
                    });                    
                    while (myreader.Read())
                    {

                        users.Add(new personDTO()
                        {
                            sid = (int)myreader["pid"],
                            name = myreader["name"].ToString(),
                            semat = myreader["semat"].ToString(),
                            mahalkar = myreader["mahalkar"].ToString(),
                            tel = myreader["tel"].ToString()
                        });

                    }

                }
            }
           frmload=true;

            comblpersons.ValueMember = null;
            comblpersons.DisplayMember = "name";
            comblpersons.DataSource = users;

            comblpersons.SelectedIndex = 0;
        }

        private void fdate_tarikTaskil_from_DateChanged(object sender, EventArgs e)
        {

        }

        private void frm_amanat_Load(object sender, EventArgs e)
        {
            loadcomb();
            fdate_amanat_from.SelectedDateTime = DateTime.Now;
            fdate_amanat_to.SelectedDateTime = DateTime.Now;
        }

        private void fdate_amanat_to_DateChanged(object sender, EventArgs e)
        {

        }

        private void comblpersons_SelectedValueChanged(object sender, EventArgs e)
        {
            if (frmload && comblpersons.SelectedValue != null)
            {

                personDTO current = (personDTO)comblpersons.SelectedValue;

                lblname.Text = current.name.ToString();
                lblsemat.Text = current.semat.ToString();
                lblmahalkar.Text = current.mahalkar.ToString();
                lbltel.Text = current.tel.ToString();
                curpid = current.sid;

            }
        }



        private void btn_closefrm_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnamanat_Click(object sender, EventArgs e)
        {
            string errtext = "";

            if (curpid==-1)
                errtext += "لطفاً شخص امانت گيرنده را مشخص فرمائيد*\n";

            if (fdate_amanat_from.IsNull)
                errtext += "تاريخ شروع امانت را مشخص نمائيد*\n";
            if (fdate_amanat_to.IsNull)
                errtext += "تاريخ پايان امانت را مشخص نمائيد*\n";
            if (!fdate_amanat_from.IsNull && !fdate_amanat_to.IsNull && (fdate_amanat_from.SelectedDateTime > fdate_amanat_to.SelectedDateTime))
                errtext += "تاريخ پايان امانت نمي تواند از تاريخ شروع كوچكتر باشد*\n";
            if (errtext.Trim() != "")
            {
                MessageBox.Show(errtext, "خطا در ثبت امانت", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                return;
            }

            using (SqlConnection myconnection = new SqlConnection(DA.ConnectionString))
            {
                using (SqlCommand mycommand = new SqlCommand())
                {
                    myconnection.Open();
                    mycommand.Connection = myconnection;
                   // SqlParameter[] myparametrs = new SqlParameter[10];
                    mycommand.Parameters.AddWithValue("@pid", Convert.ToInt32(dgvpi.CurrentRow.Cells["id"].Value));
                    mycommand.Parameters.AddWithValue("@personid", curpid);
                    mycommand.Parameters.AddWithValue("@fromdate", fdate_amanat_from.SelectedDateTime.ToString("yyyy/MM/dd"));
                    mycommand.Parameters.AddWithValue("@todate", fdate_amanat_to.SelectedDateTime.ToString("yyyy/MM/dd"));
                   // mycommand.Parameters.AddWithValue("@tahvildate", null);
                    mycommand.Parameters.AddWithValue("@uid_dahandeh", Convert.ToInt32(cUser.uid));
                  //  mycommand.Parameters.AddWithValue("@uid_girandeh", null);
                    mycommand.Parameters.AddWithValue("@tozihat_amanat", txtb_tozihat.Text);
                 //   mycommand.Parameters.AddWithValue("@tozihat_tahvil", null);
                    mycommand.Parameters.AddWithValue("@tahvil", false);

                    string query = @"DECLARE @iid INT
                                     insert into amanat(parvandeh_id, personid, formdate, todate, uid_dahandeh, 
                                     tozihat_amanat, tahvil) values(@pid, @personid, @fromdate, @todate, @uid_dahandeh, 
                                     @tozihat_amanat, @tahvil)
                                     set @iid = SCOPE_IDENTITY()
                                     update parvandeh set amanat=1, amanatid=@iid where id=@pid
                                     ";
                    mycommand.CommandText = query;
                    mycommand.ExecuteNonQuery();

                    string log = string.Format("پرونده {0} از تاريخ {1} تا {2} به شخص {3} امانت داده شد- توضيحات {4} *** كاربر امانت دهنده {5}"
                        , dgvpi.CurrentRow.Cells["id"].Value.ToString(), fdate_amanat_from.Text
                        , fdate_amanat_to.Text , lblname.Text
                        , txtb_tozihat.Text, cUser.name + cUser.family );
                    
                    common.writelog(18, "ثبت امانت پرونده", log, cUser.uid, dgvpi.CurrentRow.Cells["id"].Value.ToString());
                    common.TempDoc.amanat = true;
                    MessageBox.Show("امانت پرونده با موفقیت ثبت شد", "ثبت امانت پرونده", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                myconnection.Close();
            }
            this.Close();                    
        }
    }
}
