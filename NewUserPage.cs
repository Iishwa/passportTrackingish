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
    public partial class NewUserPage : Form
    {
        public NewUserPage()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection(@"Data Source=ANIKET ; Integrated security=true ; Initial catalog=PassportProject");
        private void button1_Click(object sender, EventArgs e)
        {
            conn.Open();
            string dob = Wikitechy.UserDetails.GetDate(dateTimePicker1.Value);
            SqlCommand cmd = new SqlCommand("insert into loginTable values('" + txt_Name.Text + "','" + txt_UserName.Text + "','" + txt_pwd.Text + "','" + dob + "','" + cmb_SecurityQuestion.SelectedItem.ToString() + "','" + txt_SecAns.Text + "')", conn);
            int status = cmd.ExecuteNonQuery(); //this line will return whether the above code returns success 1 or failure 0
            if(status>0)
            {
                MessageBox.Show("User Added Successfuly");
            }
            else
            {
                MessageBox.Show("Problem in data insertion");
            }
            conn.Close();
              

        }

        private void button2_Click(object sender, EventArgs e)
        {
            LoginPage loginpg = new LoginPage();
            loginpg.Show();
            this.Hide();
        }
    }
}
