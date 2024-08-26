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
    public partial class ChangeStatus : Form
    {
        public ChangeStatus()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection(@"Data Source=ANIKET ; Integrated security=true ; Initial catalog=PassportProject");
        private void button2_Click(object sender, EventArgs e)
            


        {
            conn.Open();
            string query = ("update [dbo].[passport_details] set [PPStatus]='" + cmb_Status.SelectedItem.ToString() + "'  where [PassportRefNumber] = ' "+ cmb_RefNumber.SelectedItem.ToString()+"' ")  ;
       SqlCommand cmd2 = new SqlCommand(query, conn);
           int status = cmd2.ExecuteNonQuery();
            if (status > 0)
            {
                MessageBox.Show("Passport details updated succesfully");
            }
            else
            {
                MessageBox.Show("Updation Failed");
            }
            conn.Close();


        }
        private void button1_Click(object sender,EventArgs e)
        {
            OptionPage op = new OptionPage();
            op.Show();
            this.Hide();

        }

        private void ChangeStatus_Load(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand cmd1 = new SqlCommand("select [PassportRefNumber] from[dbo].[passport_details] where [PPStatus]='pending'", conn);
            cmd1.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(cmd1);
            DataSet ds = new DataSet();
            da.Fill(ds);
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                cmb_RefNumber.Items.Add(dr[0].ToString());

            }
            conn.Close();

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

            LoginPage s = new LoginPage();
            this.Hide();
            s.Show();
            //this.Close();
        }
    }
    }

