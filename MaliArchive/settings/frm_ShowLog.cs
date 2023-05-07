using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MaliArchive
{
    public partial class frm_ShowLog : Form
    {
        public frm_ShowLog(ClassLog CurrentLog)
        {
            InitializeComponent();

            lbl_TimeRoydad.Text = CurrentLog.LogTime;
            lblSunjectRoydad.Text = CurrentLog.Subject;
            lblUserRoydad.Text = CurrentLog.UserName;
            txtTozihat.Text = CurrentLog.Tozihat;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
