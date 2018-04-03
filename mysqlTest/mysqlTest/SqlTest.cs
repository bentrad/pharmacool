using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;


namespace mysqlTest
{
    public partial class SqlTest : Form
    {

        static void Main(string[] args)
        {
            /* my first program in C# */

            Application.Run(new SqlTest());

            Console.WriteLine("Hello World");
            Console.ReadKey();
        }

        // "Server=localhost;Database=testdb;Uid=root;Pwd=YES;";

        //Azure server: pharmacool.database.windows.net ; Database: pcdb ; User: pharma ; password: pinapplepizza1!
        string MyConnectionString = "Server=pharmacool.database.windows.net;Database=pcdb;Uid=pharma;Pwd=pineapplepizza1!;";

        public SqlTest()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {



            /*private*/
            //void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
            //{

            //}

            //private void SqlTest_Load(object sender, EventArgs e)
            //{
            //}


            private void LoadData()
            {
                MySqlConnection connection = new MySqlConnection(MyConnectionString);
                connection.Open();
                try
                {
                    MySqlCommand cmd = connection.CreateCommand();
                    cmd.CommandText = "SELECT * FROM phonebook";
                    MySqlDataAdapter adap = new MySqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    adap.Fill(ds);

                    dataGridView1.DataSource = ds.Tables[0].DefaultView;
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    if (connection.State == ConnectionState.Open)
                    {
                        connection.Close();
                    }
                }
            }

            private void button1_Click(object sender, EventArgs e)
            {
                int MobileNo;
                string Mobile = txtMobile.Text;
                int.TryParse(Mobile, out MobileNo);

                MySqlConnection connection = new MySqlConnection(MyConnectionString);
                MySqlCommand cmd;
                connection.Open();
                try
                {
                    cmd = connection.CreateCommand();
                    cmd.CommandText = "INSERT INTO phonebook(Id,Name, MobileNo)VALUES(@Id,@Name,@MobileNo)";
                    cmd.Parameters.AddWithValue("@Id", int.Parse(txtId.Text)); //TODO: add ID and Name(Maybe add via windows Forms?)
                    cmd.Parameters.AddWithValue("@Name", txtName.Text);
                    cmd.Parameters.AddWithValue("@MobileNo", Mobile);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {

                    if (connection.State == ConnectionState.Open)
                    {
                        connection.Close();
                        LoadData();
                    }

                }
            }
        }

    }
}