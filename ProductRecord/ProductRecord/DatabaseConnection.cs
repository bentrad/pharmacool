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
        //Variables required for database connection
        private SqlConnectionStringBuilder _builder;
        private SqlConnection _connection;
        private SqlCommand _cmd;
        private string _tableName;

        //Constructor - declare appropriate variables
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

        //Opens connection to the database
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

        // Loads data to the database
        public void LoadData(string tableName)
        {
            _connection.Open();
            try
            {
                SqlCommand _cmd = _connection.CreateCommand();
                _cmd.CommandText = "SELECT * FROM " +  tableName;
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


        public void ConnectionCommandStartUp()
        {
            OpenConnection();
            _cmd = _connection.CreateCommand();
        }
        //Remove row from databse
        public virtual void Delete(string id)
        {
            ConnectionCommandStartUp();
            //Connection must be closed in child class
        }

        //Edit database row
        public virtual void Edit(string[] values) {
            ConnectionCommandStartUp();
            //Connection must be closed in child class

        }

        //Add row to database
        public virtual void Create(string[] values) {
            ConnectionCommandStartUp();
            //Connection must be closed in child class
        }

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
