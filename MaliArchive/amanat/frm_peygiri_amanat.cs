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
    public partial class frm_peygiri_amanat : Form
    {
        public frm_peygiri_amanat()
        {
            InitializeComponent();
        }

        private void doc_Log_amanat_Load()
        {
            using (SqlConnection myconnection = new SqlConnection(DA.ConnectionString))
            {
                using (SqlCommand mycommand = new SqlCommand())
                {
                    myconnection.Open();
                    mycommand.Connection = myconnection;
                    SqlDataReader myreader; 

                    //load amanat gridview
                    mycommand.CommandText =
                    @"select 
                    amanat.parvandeh_id,
                    n1.name amanat_girandeh,
                    amanat.formdate,
                    amanat.todate,
                    DATEDIFF(DAY, amanat.todate, GETDATE()) takhir,
                    n2.name+' '+n2.family tah_dahandeh,
                    amanat.tozihat_amanat
                    from amanat
                    join ashkas n1 on amanat.personid=n1.pid
                    join users n2 on amanat.uid_dahandeh=n2.uid
                    where amanat.tahvil='false'
                    order by amanatid DESC";

                    myreader = mycommand.ExecuteReader();
                    dgvamanat.Rows.Clear();
                    if (myreader.HasRows)
                    {
                        //int takhir = 0;
                        while (myreader.Read())
                        {
                           // takhir=Convert.ToInt32(myreader["takhir"]);
                            //if (takhir<0)
                            //    takhir=0;
                            dgvamanat.Rows.Add(myreader["parvandeh_id"].ToString(), myreader["amanat_girandeh"].ToString(),
                                common.persian_date((DateTime)myreader["formdate"]).ToString(),
                                common.persian_date((DateTime)myreader["todate"]).ToString(),
                                myreader["takhir"].ToString(),
                                myreader["tah_dahandeh"].ToString(),
                                myreader["tozihat_amanat"].ToString());

                        }
                        foreach (DataGridViewRow row in dgvamanat.Rows)
                        {
                            if (Convert.ToInt32(row.Cells["takhir"].Value) > 0)
                                row.DefaultCellStyle.BackColor = Color.Pink;
                            if (Convert.ToInt32(row.Cells["takhir"].Value) < 0)
                                row.DefaultCellStyle.BackColor = Color.OrangeRed;
                        }

                    }

                }
                myconnection.Close();
            }
        }        

        private void frm_peygiri_amanat_Load(object sender, EventArgs e)
        {
            doc_Log_amanat_Load();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvamanat_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvamanat.RowCount >= 0)
            {
                txtResultTozihat.Text = dgvamanat.CurrentRow.Cells["tozihat_amanat"].Value.ToString();
            }
        }
    }
}
