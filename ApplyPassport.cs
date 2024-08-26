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
    public partial class ApplyPassport : Form
    {
        public ApplyPassport()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection(@"Data Source=ANIKET ; Integrated security=true ; Initial catalog=PassportProject");
        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Random r = new Random();
            
           int PassportRefNumber=r.Next(1,3000);
            string PPStatus = "pending";
            string dob = Wikitechy.UserDetails.GetDate(dateTimePicker1.Value);
            conn.Open();
            SqlCommand cmd = new SqlCommand("insert into passport_details(FirstName,Lastname,Email,DOB,[Address],District,[State],Gender,ContactNo,Photo,AadharNo,PassportRefNumber,PPStatus) values('" + txt_FirstName.Text + "','" + txt_LastName.Text + "','" + txt_Email.Text + "','" + dob + "', '" + txt_Address.Text + "', '" + txt_District.Text + "','" + cmb_State.Text + "','" + cmb_Gender.Text + "','" + txt_ContactNo.Text + "','" + txt_PhotoName.Text + "','" + txt_AadharNo.Text + "'," + PassportRefNumber.ToString()+ ",'" + PPStatus + "')", conn);
            int status =cmd.ExecuteNonQuery();

            if (status==1)
            {
                MessageBox.Show("Passport Details updated successfully");
            }
            else
            {
                MessageBox.Show("Issues in updating");

            }
            //passport user login detail
            SqlCommand cmd1 = new SqlCommand("select id from passport_details order by id desc", conn);
            cmd1.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(cmd1);
            DataSet ds = new DataSet();
            da.Fill(ds);
            int id=Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString());
            MessageBox.Show("The refrence Number for your passport is:" + PassportRefNumber.ToString());

            SqlCommand cmd2 = new SqlCommand("insert into passport_logindetalis(Id,username,pwd,Security_Question,Security_Answer) values(" + id + ",'" + txt_UserName.Text + "','" + txt_Password.Text + "','" + cmb_SecQuestion.SelectedItem.ToString() + "','" + txt_SecAnswer.Text + "')",conn);
            int val2 = cmd2.ExecuteNonQuery();
            if(val2>0)
            {
                MessageBox.Show("Passport user login details added successfully");


            }
            else
            {

                MessageBox.Show("Data insertion failed");
            }



            conn.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp) |*.jpg; *.jpeg; *.gif; *.bmp";
            if(openFileDialog1.ShowDialog()==DialogResult.OK)
            {
                //display image in the picturebox
                pictureBox1.Image = new Bitmap(openFileDialog1.FileName);
                //image path
                txt_PhotoName.Text = openFileDialog1.FileName;
                Image img = pictureBox1.Image;
                img.Save(txt_FirstName.Text + "-" + txt_LastName.Text + ".jpg");


            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            LoginPage loginpg = new LoginPage();
            loginpg.Show();
            this.Hide();
        }

        private void cmb_State_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
