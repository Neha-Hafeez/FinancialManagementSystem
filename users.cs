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

namespace FinanceManagementSystem
{
    public partial class users : Form
    {
        public users()
        {
            InitializeComponent();
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Zain Mughal\Documents\financeDB.mdf;Integrated Security=True;Connect Timeout=30");

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void users_Load(object sender, EventArgs e)
        {

        }
        private void Clear()
        {
            UnameTB.Text = "";
            PasswordTb.Text = "";
            PhoneTB.Text = "";
            AddressTB.Text = "";
        }
        private void AddButton_Click(object sender, EventArgs e)
        {
            if (UnameTB.Text == "" || PhoneTB.Text == "" || PasswordTb.Text == "" || AddressTB.Text == "")
            {
                MessageBox.Show("Missing Infromation");
            }
            else 
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("insert into UserTb1(Uname,UDOB,Uphone,UPass,UAddress)values(@UN,@UD,@UP,@UPA,@UA)", Con);
                    cmd.Parameters.AddWithValue("@UN", UnameTB.Text);
                    cmd.Parameters.AddWithValue("@UD", DOB.Value.Date);
                    cmd.Parameters.AddWithValue("@UP", PhoneTB.Text);
                    cmd.Parameters.AddWithValue("@UPA",PasswordTb.Text);
                    cmd.Parameters.AddWithValue("@UA", AddressTB.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("User Added !!!");
                    Con.Close();
                    Clear();
                }
                catch(Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void UnameTB_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {
            login Obj = new login();
            Obj.Show();
            this.Hide();
        }
    }
}
