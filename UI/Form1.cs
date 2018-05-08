using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using MaterialSkin;
using MaterialSkin.Controls;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace PharmaCool
{

    public partial class Form1 : MaterialForm
    {
        string myConnectionString = "Server= pharmacool.database.windows.net;Database=pcdb;Uid=pharma@pharmacool;Pwd=pineapplepizza1!;";
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'pcdbDataSet.SALES' table. You can move, or remove it, as needed.
            this.sALESTableAdapter.Fill(this.pcdbDataSet.SALES);
            // TODO: This line of code loads data into the 'pcdbDataSet.PRODUCTS' table. You can move, or remove it, as needed.
            this.pRODUCTSTableAdapter.Fill(this.pcdbDataSet.PRODUCTS);

        }
        
        //Check if text box is empty
        public bool isEmpty(TextBox txtBoxObject)
        {
            if (string.IsNullOrWhiteSpace(txtBoxObject.Text))
            {
                txtBoxObject.Focus();
                errorProvider1.SetError(txtBoxObject, "Please fill in the blank");
                return true;
            }
            errorProvider1.SetError(txtBoxObject, "");
            return false;
        }
        
        //Check if text box is numeric
        public bool isNotNumeric(TextBox txtBoxObject)
        {
            int number = 0;
            if (int.TryParse(txtBoxObject.Text, out number))
            {
                errorProvider2.SetError(txtBoxObject, "");
                return false;
            }
            errorProvider2.SetError(txtBoxObject, "Please enter numbers only");
            return true;
        }

        //Check if text box contains maximum 2 decimal points
        public bool isDecimalNumber(TextBox txtBoxObject)
        {
            decimal number;

            if (Decimal.TryParse(txtBoxObject.Text, out number))
            {
                errorProvider3.SetError(txtBoxObject, "");
                return true;
            }
            errorProvider3.SetError(txtBoxObject, "Please enter a decimal number");
            return false;
        }

        //Validate function for all text box controls
        public bool isValidated(TextBox txtId, TextBox txtName, TextBox txtCost, TextBox txtStock)
        {
            if (isEmpty(txtId) || isEmpty(txtName) || isEmpty(txtCost) || isEmpty(txtStock))
                return false;
            else if (isNotNumeric(txtId) || isNotNumeric(txtStock))
                return false;
            else if (!isDecimalNumber(txtCost))
                return false;
            return true;
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            int pStock;
            float pCost;
            string cost = txtCost.Text;
            string stock = txtStock.Text;
            float.TryParse(cost, out pCost);
            int.TryParse(stock, out pStock);
            //MySqlConnection connection = new MySqlConnection(myConnectionString);
            SqlConnectionStringBuilder builder;
            SqlConnection connection;
            SqlCommand cmd;

            //connection.Open();

            builder = new SqlConnectionStringBuilder();
            builder.DataSource = "pharmacool.database.windows.net"; //ERROR:Server Name cannot be found
            builder.UserID = "pharma@pharmacool";
            builder.Password = "pineapplepizza1!";
            builder.InitialCatalog = "pcdb";

            connection = new SqlConnection(builder.ConnectionString);

            Console.WriteLine("\nQuery data example:");
            Console.WriteLine(builder.ConnectionString);
            Console.WriteLine("=========================================\n");

            connection.Open();

            try
            {

                //    //MySqlConnection connection = new MySqlConnection(builder.ConnectionString);

                //    connection.Open();
                if (isValidated(txtId, txtName, txtCost, txtStock))
                {
                    cmd = connection.CreateCommand();
                    cmd.CommandText = "INSERT INTO PRODUCTS(pname, pcost, pstock)VALUES(@pname, @pcost, @pstock)";
                    cmd.Parameters.AddWithValue("@productid", int.Parse(txtId.Text));
                    cmd.Parameters.AddWithValue("@pname", txtName.Text);
                    cmd.Parameters.AddWithValue("@pcost", pCost);
                    cmd.Parameters.AddWithValue("@pstock", pStock);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception)
            {
                //throw;
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

        private void LoadData()
        {
            SqlConnection connection = new SqlConnection(myConnectionString);
            connection.Open();
            try
            {
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "SELECT * FROM PRODUCTS";
                SqlDataAdapter adap = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adap.Fill(ds);

                dataGridView.DataSource = ds.Tables[0].DefaultView;
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

        private void pRODUCTSBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }
    }
}
