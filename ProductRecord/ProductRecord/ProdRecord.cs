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
            base.Delete(id); // Open Connection

            Command.CommandText = "DELETE FROM " + TableName + " WHERE productid = @productid";
            Command.Parameters.AddWithValue("@productid", int.Parse(id));

            base.CloseConnectionAndLoad(); // Close Connection
        }


        public void LoadData()
        {
            base.LoadData(TableName);
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

        /* Not Required ATM
         * 
         * public List<string> Tags
        {
            get{return _tags;}
        }*/

        public double Cost { 
            get {return _cost;}
        }
            
    }
}
