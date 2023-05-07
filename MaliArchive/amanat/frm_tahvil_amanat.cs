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
    public partial class frm_tahvil_amanat : Form
    {
        public frm_tahvil_amanat(DataGridViewRow Row)
        {
            InitializeComponent();
            this.Text += Row.Cells[0].Value.ToString();
            dgvpi.Rows.Add(Row);
        }
        DateTime todate;
        private void loadtxts()
        {

            using (SqlConnection myconnection = new SqlConnection(DA.ConnectionString))
            {
                using (SqlCommand mycommand = new SqlCommand())
                {
                    myconnection.Open();
                    mycommand.Connection = myconnection;
                    SqlParameter[] myparametrs = new SqlParameter[1];
                    mycommand.Parameters.AddWithValue("@amanatid", Convert.ToInt32(dgvpi.CurrentRow.Cells["amanat_id"].Value));
                    mycommand.CommandText = @"select formdate,todate,n1.name girandeh,n2.name+' '+n2.family dahandeh,tozihat_amanat, 
                                            DATEDIFF(DAY, amanat.todate, GETDATE()) takhir                                            
                                            from amanat 
                                            join ashkas n1 on amanat.personid=n1.pid
                                            join users n2 on amanat.uid_dahandeh=n2.uid
                                            where amanatid=@amanatid";
                    SqlDataReader myreader = mycommand.ExecuteReader();
                    int takhir = 0;
                    while (myreader.Read())
                    {
                        lblfromdate.Text = common.persian_date((DateTime)myreader["formdate"]).ToString();
                        lbltodate.Text = common.persian_date((DateTime)myreader["todate"]).ToString();
                        lblamanatgirandeh.Text = myreader["girandeh"].ToString();
                        lbldahandeh.Text = myreader["dahandeh"].ToString();
                        txtbTozihatAmanat.Text = myreader["tozihat_amanat"].ToString();

                        todate = DateTime.Parse(myreader["todate"].ToString());
                        takhir = Convert.ToInt32(myreader["takhir"]);
                        if (takhir > 0)
                        {
                            lbltakhir.Text = "تعداد" + takhir + "روز تاخير در تحويل پرونده تا امروز";
                            lbltakhir.ForeColor = Color.Red;
                        }
                        if (takhir < 0)
                        {
                            lbltakhir.Text = "تعداد" + Math.Abs(takhir) + "روز باقي مانده به موعد تحويل پرونده تا امروز";
                            lbltakhir.ForeColor = Color.BlueViolet;
                        }
                    }

                }

            }
        }
        private void frm_tahvil_amanat_Load(object sender, EventArgs e)
        {
            fdate_tahvil.SelectedDateTime = DateTime.Now;
            loadtxts();
        }

        private void btn_closefrm_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string errtext = "";

            if (fdate_tahvil.IsNull)
                errtext += "تاريخ تحويل امانت را مشخص نمائيد*\n";

            if (errtext.Trim() != "")
            {
                MessageBox.Show(errtext, "خطا در ثبت تحويل امانت", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                return;
            }

            using (SqlConnection myconnection = new SqlConnection(DA.ConnectionString))
            {
                using (SqlCommand mycommand = new SqlCommand())
                {
                    myconnection.Open();
                    mycommand.Connection = myconnection;
                    SqlParameter[] myparametrs = new SqlParameter[10];
                    mycommand.Parameters.AddWithValue("@pid", Convert.ToInt32(dgvpi.CurrentRow.Cells["id"].Value));
                    //mycommand.Parameters.AddWithValue("@personid", curpid);
                    //mycommand.Parameters.AddWithValue("@fromdate", fdate_amanat_from.GetDate().ToString("yyyy/MM/dd"));
                    //mycommand.Parameters.AddWithValue("@todate", fdate_amanat_to.GetDate().ToString("yyyy/MM/dd"));
                    mycommand.Parameters.AddWithValue("@tahvildate",  fdate_tahvil.SelectedDateTime.ToString("yyyy/MM/dd"));
                    //mycommand.Parameters.AddWithValue("@uid_dahandeh", Convert.ToInt32(cUser.uid));
                    mycommand.Parameters.AddWithValue("@uid_girandeh", Convert.ToInt32(cUser.uid));
                    //mycommand.Parameters.AddWithValue("@tozihat_amanat", txtb_tozihat.Text);
                    mycommand.Parameters.AddWithValue("@tozihat_tahvil", txtbTozihatTahvil.Text);
                    mycommand.Parameters.AddWithValue("@tahvil", true);
                    mycommand.Parameters.AddWithValue("@amant", false);
                    mycommand.Parameters.AddWithValue("@amanatid", Convert.ToInt32(dgvpi.CurrentRow.Cells["amanat_id"].Value));
                    string query = @"update amanat set tahvildate= @tahvildate, uid_girandeh=@uid_girandeh, 
                                        tozihat_tahvil=@tozihat_tahvil, tahvil=@tahvil  where amanatid=@amanatid
                                     update parvandeh set amanat=@amant, amanatid=-1 where id=@pid
                                     ";
                    mycommand.CommandText = query;
                    mycommand.ExecuteNonQuery();

                    string log = string.Format("پرونده {0}  از تاريخ {1} تا {2} به شخص {3} توسط {4} امانت داده شده بود در تاريخ {5} تحويل شد- توضيحات {6} ***  كاربر تحويل گيرنده {7}"
                    , dgvpi.CurrentRow.Cells[0].Value.ToString(), lblfromdate.Text
                    , lbltodate.Text, lblamanatgirandeh.Text, lbldahandeh.Text, fdate_tahvil.Text
                    , txtbTozihatTahvil.Text, cUser.name + cUser.family);

                    common.writelog(19, "تحويل امانت پرونده", log, cUser.uid, dgvpi.CurrentRow.Cells["id"].Value.ToString());
                    common.TempDoc.amanat = false;
                    MessageBox.Show("تحويل امانت پرونده با موفقیت ثبت شد", "تحويل امانت پرونده", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                myconnection.Close();
            }
            this.Close();                
        }

        private void fdate_tahvil_DateChanged(object sender, EventArgs e)
        {
            /*
            TimeSpan remaindate = fdate_tahvil.GetDate().Subtract(todate.Date);
            if (remaindate != null)
            {
                double takhir = remaindate.Days; ;
                if (takhir > 0)
                {
                    lbltakhirta.Text = "تعداد" + takhir + " روز تاخير در تحويل پرونده تا " + common.persian_date(fdate_tahvil.GetDate());
                    lbltakhirta.ForeColor = Color.Red;
                }
                if (takhir < 0)
                {
                    lbltakhirta.Text = "تعداد" + Math.Abs(takhir) + " روز تعجيل در تحويل پرونده تا " + common.persian_date(fdate_tahvil.GetDate());
                    lbltakhirta.ForeColor = Color.BlueViolet;
                }
                if (takhir == 0)
                {
                    lbltakhirta.Text =  " تحويل پرونده در موعد مقرر  " + common.persian_date(fdate_tahvil.GetDate());
                    lbltakhirta.ForeColor = Color.Blue;
                }
            }
            else
            {
                lbltakhirta.Text = "!";
            }  
            */
        }
    }
}
