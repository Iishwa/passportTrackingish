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
    public partial class ChangeStatusPage : Form
    {
        public ChangeStatusPage()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // ChangeStatusPage
            // 
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Name = "ChangeStatusPage";
            this.Load += new System.EventHandler(this.ChangeStatusPage_Load);
            this.ResumeLayout(false);

        }

        private void ChangeStatusPage_Load(object sender, EventArgs e)
        {

        }
    }
}
