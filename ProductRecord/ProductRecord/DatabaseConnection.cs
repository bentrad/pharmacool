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
//using MySql.Data.MySqlClient;

namespace ProductRecord
{
    class DatabaseConnection
    {
        //Variables required for database connection
        SqlConnectionStringBuilder builder;
        SqlConnection connection;
        SqlCommand cmd;

        //Constructor - declare appropriate variables
        public DatabaseConnection(string database)
        {
            builder = new SqlConnectionStringBuilder();
            builder.DataSource = "pharmacool.database.windows.net"; //ERROR:Server Name cannot be found
            builder.UserID = "pharma@pharmacool";
            builder.Password = "pineapplepizza1!";
            builder.InitialCatalog = database;
            connection = new SqlConnection(builder.ConnectionString);
        }

        //Opens connection to the database
        public void OpenConnection()
        {
            if (!(connection.State == ConnectionState.Open))
            connection.Open();
        }

        //Closes connection to the database
        public void CloseConnection()
        {
            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
                LoadData();
            }
        }

        // Loads data to the database
        private void LoadData()
        {
            connection.Open();
            try
            {
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "SELECT * FROM PRODUCTS";
                SqlDataAdapter adap = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adap.Fill(ds);
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

        //Remove row from databse
        public virtual void Delete(string id, string tableName) {
            OpenConnection();

            cmd = connection.CreateCommand();
            cmd.CommandText = "DELETE FROM " + tableName + " WHERE productid = @productid";
            cmd.Parameters.AddWithValue("@productid", int.Parse(id));

            //Connection must be closed in child class
        }

        //Edit database row
        public virtual void Edit(string[] value) {
            OpenConnection();

            //Connection must be closed in child class

        }

        //Add row to database
        public virtual void Create(string[] value) {
            OpenConnection();


           //Connection must be closed in child class
        }
    }
}
