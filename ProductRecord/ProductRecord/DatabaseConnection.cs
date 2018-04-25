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

namespace Pharmacool
{
     public class DatabaseConnection
    {
        //----------------------Fields--------------------
        private SqlConnectionStringBuilder _builder;
        private SqlConnection _connection;
        private SqlCommand _cmd;
        private string _tableName;

        //----------------------Constructor/s--------------------
        public DatabaseConnection(string database, string tableName)
        {
            _builder = new SqlConnectionStringBuilder();
            _builder.DataSource = "pharmacool.database.windows.net"; //BRADLEY CHICK: DELETE THIS IF YOU DID NOT WRITE THIS: //ERROR:Server Name cannot be found
            _builder.UserID = "pharma@pharmacool";
            _builder.Password = "pineapplepizza1!";
            _builder.InitialCatalog = database;     //Product database is 'pcdb'. Refer to portal.azure.com for more details
            _tableName = tableName;
            _connection = new SqlConnection(_builder.ConnectionString);
        }



        //----------------------Methods--------------------

        //Add row to database
        public virtual void Create(string[] values)
        {
            ConnectionCommandStartUp();
            //Connection must be closed in child class
        }

        //Edit database row
        public virtual void Edit(string[] values)
        {
            ConnectionCommandStartUp();
            try
            {
                Command = Connection.CreateCommand();
                //Command.CommandText = "INSERT INTO("+ ", " + ", " + ", " + ", )VALUES(" + ;
                Command.CommandText = "INSERT INTO(saledate, productid, qtysold, saleprice)VALUES(@saledate, @productid, @qtysold, @saleprice)";
                /*
                Command.Parameters.AddWithValue("@saledate", txtDate.Text);         // These 4 variables are from the frontend. 
                Command.Parameters.AddWithValue("@saleprive", sPrice);              // We must add the front end to get this working
                Command.Parameters.AddWithValue("@qtysold", sQtySold);
                Command.Parameters.AddWithValue("@productid", int.Parse(txtId.Text));
                //*/
                Command.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                CloseConnectionAndLoad();
            }

        }
        //Remove row from database
        public virtual void Delete(string id)
        {
            ConnectionCommandStartUp();
            //Connection must be closed in child class
        }

        //--------------TODO: Fix code so it can read all fields from Columns of selected table----------------------
        public SqlCommand SQLCommandBuilder ()
        {

            //Read number of columns in table
            //Put each column into an element of a string array(EXCLUDE ID!!!!)
            //Assign each column the appropriate value/s from the UX
            SqlCommand cmd;
            DataTable schemaTable;
            SqlDataReader myReader;

            ConnectionCommandStartUp();

            cmd = Connection.CreateCommand();
            cmd.CommandText = "SELECT * FROM " + TableName; //TODO: Set SQL to get all Column Names
            myReader = cmd.ExecuteReader(CommandBehavior.KeyInfo);
            
            //Retrieve column schema into Datatable
            schemaTable = myReader.GetSchemaTable();

            Console.WriteLine(schemaTable.Columns[0] + " = " +  schemaTable.Rows[0][schemaTable.Columns[0]].ToString());

            foreach (DataRow myField in schemaTable.Rows)
            {

                //For each property of the field...
                foreach (DataColumn myProperty in schemaTable.Columns)
                {
                    //Display the field name and value.
                    Console.WriteLine(myProperty.ColumnName + " = " + myField[myProperty].ToString());
                }
                Console.WriteLine();

                //Pause.
                Console.ReadLine();
            }

            //Always close the DataReader and connection.
            myReader.Close();
            Connection.Close();


            //Command.CommandText = "INSERT INTO(saledate, productid, qtysold, saleprice)VALUES(@saledate, @productid, @qtysold, @saleprice)";
            //Command.Parameters.AddWithValue("@saledate", txtDate.Text);         // These 4 variables are from the frontend. 
            //Command.Parameters.AddWithValue("@saleprive", sPrice);              // We must add the front end to get this working
            //Command.Parameters.AddWithValue("@qtysold", sQtySold);
            //Command.Parameters.AddWithValue("@productid", int.Parse(txtId.Text));

            return cmd;
        }


        // Loads data to the database
        public void LoadData(string tableName)
        {
            _connection.Open();
            try
            {
                SqlCommand _cmd = _connection.CreateCommand();
                _cmd.CommandText = "SELECT * FROM " + tableName;
                SqlDataAdapter adap = new SqlDataAdapter(_cmd);
                DataSet ds = new DataSet();
                adap.Fill(ds);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (_connection.State == ConnectionState.Open)
                {
                    _connection.Close();
                }
            }
        }



        public void OpenConnection()
        {
            if (!(_connection.State == ConnectionState.Open))
                _connection.Open();
        }

        //Closes connection to the database
        public void CloseConnectionAndLoad()
        {
            if (_connection.State == ConnectionState.Open)
            {
                _connection.Close();
                LoadData(_tableName);
            }
        }

        public void ConnectionCommandStartUp()
        {
            OpenConnection();
            _cmd = _connection.CreateCommand();
        }

        //----------------------Properties--------------------
        protected SqlConnectionStringBuilder Builder{ 
            get { return _builder; }
            set { _builder = value; }
        }
        public SqlConnection Connection {
            get { return _connection; }
            set { _connection = value; }
        }
        public SqlCommand Command{
            get { return _cmd; }
            set { _cmd = value; }
        }
        public string TableName
        {
            get { return _tableName; }
            set { _tableName = value; }
        }
    }
}
