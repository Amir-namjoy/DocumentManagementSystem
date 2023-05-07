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
    public partial class frm_savabeg_amanat : Form
    {
        public frm_savabeg_amanat()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvamanat_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void frm_savabeg_amanat_Load(object sender, EventArgs e)
        {
            faenddate.SelectedDateTime = DateTime.Today;
            fastartdate.SelectedDateTime = DateTime.Today.AddMonths(-Convert.ToInt16(numericUpDown1.Value));

            faenddate2.SelectedDateTime = DateTime.Today;
            fastartdate2.SelectedDateTime = DateTime.Today.AddMonths(-Convert.ToInt16(numericUpDown2.Value));


            using (SqlConnection myconnection = new SqlConnection(DA.ConnectionString))
            {
                using (SqlCommand mycommand = new SqlCommand())
                {
                    myconnection.Open();
                    mycommand.Connection = myconnection;
                    
                    #region  load amanat gridview
                    mycommand.CommandText =
                    @"select 
                    parvandeh_id,
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
                             order by amanatid DESC";

                    SqlDataReader myreader = mycommand.ExecuteReader();
                    dgvamanat.Rows.Clear();
                    if (myreader.HasRows)
                    {
                        while (myreader.Read())
                        {
                            dgvamanat.Rows.Add(
                                myreader["parvandeh_id"].ToString(),
                                myreader["amanat_girandeh"].ToString(),
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
                    
                }
            }

            //dgvamanat.Sort(dgvamanat.Columns["fromdate"], ListSortDirection.Ascending);

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            fastartdate.SelectedDateTime = DateTime.Today.AddMonths(-Convert.ToInt16(numericUpDown1.Value));
            
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            fastartdate2.SelectedDateTime = DateTime.Today.AddMonths(-Convert.ToInt16(numericUpDown2.Value));
        }
    }
}
