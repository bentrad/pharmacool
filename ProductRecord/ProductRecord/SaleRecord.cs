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
    public class SaleRecord : DatabaseConnection
    {

        //----------------------Fields--------------------
        private string _id;
        private string _date;
        private ProdRecord _product;
        private int _quantitySold;
        private double _price;

        //----------------------Constructors--------------------

        public SaleRecord(string database, string tableName, int quantitySold, ProdRecord product, string id, double price, string date) : base(database, tableName)
        {

        }
        //Sets up default database and table. For more information look at portal.azure.com
        public SaleRecord(int quantitySold, ProdRecord product, string id, double price, string date) : base("pcdb", "SALES")
        {
            _quantitySold = quantitySold;
            _product = product;
            _id = id;
            _price = price;
            _date = date;
        }

        //-------------------Methods--------------------

        public override void Create(string[] values) //may not need these parameters. String only needs to be 3 elements in size(Name, Quantity & Stock)
        {
            base.Create(values);

            try
            {
                Command = Connection.CreateCommand();
                /*
                Command.CommandText = "INSERT INTO(saledate, productid, qtysold, saleprice)VALUES(@saledate, @productid, @qtysold, @saleprice)";
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

        public override void Edit(string[] values) //may not need these parameters. String only needs to be 3 elements in size(Name, Quantity & Stock)
        {
            base.Edit(values);


        }

        public override void Delete(string id)
        {
            base.Delete(id);
        }

        public void LoadData()
        {
            base.LoadData(TableName);
        }

        //--------------------Get Properties--------------------- 
        public string ID
        {
            get { return _id; }
        }
        public int Quantity
        {
            get { return _quantitySold; }
        }

        public ProdRecord Product
        {
            get {return _product; }
        }

        public string Date
        {
            get { return _date; }
        }

        public double Price
        {
            get { return _price; }
        }
    }
}
