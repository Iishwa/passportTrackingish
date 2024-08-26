using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PassportStatusTrackingApplication
{
    public partial class OptionPage : Form
    {
        public OptionPage()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ApplyPassport apply = new ApplyPassport();
            apply.Show();
            this.Hide();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            ChangeStatus CSP = new ChangeStatus();
            CSP.Show();
            this.Hide();
        }

        private void OptionPage_Load(object sender, EventArgs e)
        {

        }
    }
}
