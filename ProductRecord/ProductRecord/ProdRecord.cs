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


/*
 * https://www.c-sharpcorner.com/UploadFile/9582c9/insert-update-delete-display-data-in-mysql-using-C-Sharp/
 * */


namespace Pharmacool
{
    public class ProdRecord : DatabaseConnection
    {
        //----------------------Fields--------------------
        private int _quantity;
        private string _name;
        private string _id;
        private List<string> _tags;
        private double _cost;

        //----------------------Constructors--------------------

        public ProdRecord(string database, string tableName, int quantity, string name, string id, double cost) : base(database, tableName)
        {
            _quantity = quantity;
            _name = name;
            _id = id;
            _cost = cost;
        }

        //Sets up default database and table. For more information look at portal.azure.com
        public ProdRecord(int quantity, string name, string id, double cost) : base("pcdb", "PRODUCTS")
        {
            _quantity = quantity;
            _name = name;
            _id = id;
            _cost = cost;
        }



        //-------------------Methods--------------------

        public override void Create(string[] values) //may not need these parameters. String only needs to be 3 elements in size(Name, Quantity & Stock)
        {
            base.Create(values);

            try
            {
                Command = Connection.CreateCommand();
                /*
                Command.CommandText = "INSERT INTO(pname, pcost, pstock)VALUES(@pname, @pcost, @pstock)";
                Command.Parameters.AddWithValue("@productid", int.Parse(txtId.Text)); // These 4 variables are from the frontend. 
                Command.Parameters.AddWithValue("@pname", txtName.Text);              // We must add the front end to get this working
                Command.Parameters.AddWithValue("@pcost", pCost);
                Command.Parameters.AddWithValue("@pstock", pStock);
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

        public override void Edit(string[] values) //may not need these parameters. String only needs to be 3 elements in size(Name, Quantity & Stock)
        {
            base.Edit(values);

            //create SQL command
            /*
            Command.CommandText = "UPDATE" + TableName + "SET (pname, pcost, pstock)VALUES(@pname, @pcost, @pstock) WHERE pname=" + values[2];
            //Command.Parameters.AddWithValue("@productid", int.Parse(txtId.Text));
            Command.Parameters.AddWithValue("@pname", txtName.Text);
            Command.Parameters.AddWithValue("@pcost", pCost);
            Command.Parameters.AddWithValue("@pstock", pStock);
            Command.ExecuteNonQuery();
            //*/

            //Check if Product exists
            //IF does edit Product with new values
            //else return errormessage
        }

        //Remove row from table
        public override void Delete(string id)
        {
            base.Delete(id);

            Command.CommandText = "DELETE FROM " + TableName + " WHERE productid = @productid";
            Command.Parameters.AddWithValue("@productid", int.Parse(id));

            //Connection must be closed in child class
        }


        public void LoadData()
        {
            base.LoadData(TableName);
        }

        //---------------ATTENTION: BRADLEY, please review old code ------------------------------------------
        [Obsolete("Old code that has to be reviewed", true)]
        public void CreateRecord()
        {
            //address path to database file
            //string myConnection = "Add path here";

            //Query to insert into database
            string query = "insert into example.example(Quantity,Name,ID,Tags,Cost) values('"
                + _quantity + "','" + _name + "','" + _id + "','" + _tags + "','" + _cost + "');";
            /*
        //Connection to mySQL
        mySqlConnection myConn = new mySqlConnection(myConnection);

        //Command class that handles query and connection object
        MySqlCommand myCommand = new MySqlCommand(query, MyConn2);

        MySqlDataReader MyReader;
        myConn.Open();

        //Query will be executed and data is saved to database
        MyReader = myCommand.ExecuteReader(); 
        while (MyReader.Read())
        */
        }
        //Edit Record Method


        //Removes a record
        [Obsolete("Old code that has to be reviewed", true)]
        public void RemoveRecord()
        {
            /*
             string MyConnection2 = "datasource=localhost;port=3307;username=root;password=root";  
            string Query = "delete from student.studentinfo where idStudentInfo='" + this.IdTextBox.Text + "';";  
            MySqlConnection MyConn2 = new MySqlConnection(MyConnection2);  
            MySqlCommand MyCommand2 = new MySqlCommand(Query, MyConn2);  
            MySqlDataReader MyReader2;  
            MyConn2.Open();  
             MyReader2 = MyCommand2.ExecuteReader();  
             MessageBox.Show("Data Deleted");  
             while (MyReader2.Read())  
             {  
             }  
             MyConn2.Close(); 
             * /}

            //Edit record elements
            /*
            //This is my connection string i have assigned the database file address path
            string MyConnection2 = "datasource=localhost;port=3307;username=root;password=root";  
            //This is my update query in which i am taking input from the user through windows forms and update the record.  
            string Query = "update student.studentinfo set idStudentInfo='" + this.IdTextBox.Text + "',Name='" + this.NameTextBox.Text + "',Father_Name='" + this.FnameTextBox.Text + "',Age='" + this.AgeTextBox.Text + "',Semester='" + this.SemesterTextBox.Text + "' where idStudentInfo='" + this.IdTextBox.Text + "';";  
            //This is  MySqlConnection here i have created the object and pass my connection string.  
            MySqlConnection MyConn2 = new MySqlConnection(MyConnection2);  
            MySqlCommand MyCommand2 = new MySqlCommand(Query, MyConn2);  
            MySqlDataReader MyReader2;  
            MyConn2.Open();  
            MyReader2 = MyCommand2.ExecuteReader();  
            MessageBox.Show("Data Updated");  
            while (MyReader2.Read())
            {  
            }  
            MyConn2.Close();//Connection closed here
             */

            /*

            Display Data


            string MyConnection2 = "datasource=localhost;port=3307;username=root;password=root";  
            string Query = "delete from student.studentinfo where idStudentInfo='" + this.IdTextBox.Text + "';";  
            MySqlConnection MyConn2 = new MySqlConnection(MyConnection2);  
            MySqlCommand MyCommand2 = new MySqlCommand(Query, MyConn2);  
            MySqlDataReader MyReader2;  
            MyConn2.Open();  
             MyReader2 = MyCommand2.ExecuteReader();  
             MessageBox.Show("Data Deleted");  
             while (MyReader2.Read())  
             {  
             }  
             MyConn2.Close(); 
            */
        }


        //--------------------Get Properties--------------------- 
        public int Quantity {
            get {return _quantity;}
        }

        public string Name { 
            get {return _name;}
        }

        public string ID {
            get { return _id; }
        }

        public List<string> Tags
        {
            get{return _tags;}
        }

        public double Cost { 
            get {return _cost;}
        }
            
    }
}
