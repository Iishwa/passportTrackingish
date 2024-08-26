using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Wikitechy;

namespace PassportStatusTrackingApplication
{
    public partial class ShowStatus : Form
    {
        public ShowStatus()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection(@"Data Source=ANIKET ; Integrated security=true ; Initial catalog=PassportProject");

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LoginPage d = new LoginPage();
            this.Hide();
            d.Show();
        }

        private void ShowStatus_Load(object sender, EventArgs e)
        {
            conn.Open();
            int id = Convert.ToInt32(Wikitechy.UserDetails.Username);
            MessageBox.Show(id.ToString());
            string query= "select * from passport_details a inner join passport_logindetalis b on a.id=b.id where a.id =" + id.ToString();

            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            dataGridView1.DataSource = ds.Tables[0];
            conn.Close();
        }
    }
}
