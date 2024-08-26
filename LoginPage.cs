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
    public partial class LoginPage : Form
    {
        public LoginPage()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection(@"Data Source=ANIKET ; Integrated security=true ; Initial catalog=PassportProject");

        private void textBox3_Textchanged(object sender, EventArgs e)
        {

           



        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            conn.Open();

            SqlCommand cmd = new SqlCommand("select count(1) from [dbo].[loginTable] where [username]='" + txt_admin_username.Text + "' and [pwd]='" + txt_admin_pwd.Text + "'", conn);
            cmd.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            int val = Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString());

            if (val > 0)
            {
                MessageBox.Show("Valid Login");
                OptionPage optpage = new OptionPage();
                optpage.Show();
                this.Hide();

            }
            else
            {
                MessageBox.Show("Invalid login");
            }
           
            conn.Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            conn.Open();
            string query = "select id from [dbo].passport_logindetalis where username='" + txt_username.Text + "' and pwd='" + txt_pwd.Text + "'";

            SqlCommand cmd = new SqlCommand("select id from [dbo].passport_logindetalis where username = '" + txt_username.Text+"' and pwd = '" + txt_pwd.Text +"'", conn);
            cmd.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            int val = Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString());
            Wikitechy.UserDetails.Username = val.ToString();

            if (val > 0)
            {
                MessageBox.Show("Valid Passport User Login");
                ShowStatus vsp = new ShowStatus();
                vsp.Show();
                this.Hide();

            }
            else
            {
                MessageBox.Show("Invalid login");
            }
            conn.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            NewUserPage newlogin = new NewUserPage();
            newlogin.Show();
            this.Hide();
        }
    }
}
