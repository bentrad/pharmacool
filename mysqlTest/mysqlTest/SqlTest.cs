using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
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

        //static void Main(string[] args)
        //{
        //    /* my first program in C# */

        //    Application.Run(new SqlTest());

        //    Console.WriteLine("Hello World");
        //    Console.ReadKey();
        //}

        // "Server=localhost;Database=testdb;Uid=root;Pwd=YES;";

        //Azure server: pharmacool.database.windows.net ; Database: pcdb ; User: pharma ; password: pinapplepizza1!
        string myConnectionString = "Server= pharmacool.database.windows.net;Database=pcdb;Uid=pharma@pharmacool;Pwd=pineapplepizza1!;";

        public SqlTest()
        {
            InitializeComponent();
        }


        private void button1_Click_1(object sender, EventArgs e)
        {
            int pStock;
            float pCost;
            string cost = txtCost.Text;
            string stock = txtStock.Text;
            float.TryParse(cost, out pCost);
            int.TryParse(stock, out pStock);
            //MySqlConnection connection = new MySqlConnection(myConnectionString);

            MySqlCommand cmd;
            //connection.Open();
            try
            {

                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                builder.DataSource = "pharmacool.database.windows.net"; //ERROR:Server Name cannot be found
                builder.UserID = "pharma@pharmacool";
                builder.Password = "pineapplepizza1!";
                builder.InitialCatalog = "pcdb";
                MySqlConnection connection = new MySqlConnection(builder.ConnectionString);

                Console.WriteLine("\nQuery data\n");
                Console.WriteLine(builder.ConnectionString);

                connection.Open();
                cmd = connection.CreateCommand();
                cmd.CommandText = "INSERT INTO phonebook(productid, pname, pcost, pstock)VALUES(@productid, @pname, @pcost, @pstock)";
                cmd.Parameters.AddWithValue("@productid", int.Parse(txtId.Text));
                cmd.Parameters.AddWithValue("@pname", txtName.Text);
                cmd.Parameters.AddWithValue("@pcost", pCost);
                cmd.Parameters.AddWithValue("@pstock", pStock);
                cmd.ExecuteNonQuery();
                
            }
            catch (Exception)
            {
                throw;
            }
            //finally
            //{

            //    if (connection.State == ConnectionState.Open)
            //    {
            //        connection.Close();
            //        LoadData();
            //    }

            //}
        }
        private void LoadData()
        {
            MySqlConnection connection = new MySqlConnection(myConnectionString);
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

        private void SqlTest_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}