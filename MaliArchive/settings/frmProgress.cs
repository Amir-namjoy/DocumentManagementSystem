using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MaliArchive.settings
{
    public partial class frmProgress : Form
    {


        public frmProgress()
        {
            InitializeComponent();
            
            this.TopLevel = true;
            label_stat.Show();
           


        }

        public string lbl_statValue
        {
            get { return label_stat.Text; }
            set { label_stat.Text = value; }
        }    


    }
}
