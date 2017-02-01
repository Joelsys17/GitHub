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

namespace WindowsFormsApplication3
{
        public partial class Form1 : Form
        {
            private string conn;
            private MySqlConnection connect;
            public Form1()
            {
                InitializeComponent();
            }

            private void db_connection()
            {
                try
                {
                    conn = "Server=localhost;Database=sys17;Uid=root;Pwd=;";
                    connect = new MySqlConnection(conn);
                    connect.Open();
                }
                catch (MySqlException e)
                {
                    throw;
                }
            }

            private bool validate_login(string user, string pass)
            {
                db_connection();
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = "Select * from members where username=@user and password=@pass";
                cmd.Parameters.AddWithValue("@user", user);
                cmd.Parameters.AddWithValue("@pass", pass);
                cmd.Connection = connect;
                MySqlDataReader login = cmd.ExecuteReader();
                if (login.Read())
                {
                    connect.Close();
                    return true;
                }
                else
                {
                    connect.Close();
                    return false;
                }
            }

            private void button1_Click(object sender, EventArgs e)
        {
            {
                string user = username.Text;
                string pass = password.Text;
                if (user == "" || pass == "")
                {
                    MessageBox.Show("Tom fält, var snäll och fyll i båda.");
                    return;
                }
                bool r = validate_login(user, pass);
                if (r)
                    MessageBox.Show("Välkommen");
                else
                    MessageBox.Show("Fel användarinformation");
            }
        }
    }