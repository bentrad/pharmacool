using System.Collections.Generic;
using System.Data;


/*
 * https://www.c-sharpcorner.com/UploadFile/9582c9/insert-update-delete-display-data-in-mysql-using-C-Sharp/
 * */


namespace ProductRecord
{
public class ProdRecord
{
    //Variables Used by Product Records
    private int _quantity;
    private string _name;
    private string _id;
    private List<string> _tags;
    private double _cost;
    
    //Constructor (if required)
    public ProdRecord(int quantity, string name, string id, double cost)
    {
            _quantity = quantity;
            _name = name;
            _id = id;
            //_tags;
            _cost = cost;
        }

    //Functions
    //Just set up for now, may not return a value in the future
    
    //Creates a new record
    //Need variable inputs?
    public void CreateRecord() {
        //address path to database file
        string myConnection = "Add path here";

        //Query to insert into database
        string query = "insert into example.example(Quantity,Name,ID,Tags,Cost) values('"
            +_quantity+"','"+_name+"','"+_id+"','"+_tags+"','"+_cost+"');";
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
public void RemoveRecord() {
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

        //Just use Set and get properies for this
        public void EditQuantity() { }
        public void EditName() { }
        public void EditID() { }
        public void EditTags() { }
        public void EditCost() { }

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



        //Access to variables
        /*
        //Get quantity of product
        public int Quantity {
            get {
                return _quantity;
            }
        }
        
        //Get name of product
        public string Name { 
            get {
                return _name;
            }
        }
        
        //Get ID of product
        public string ID {
            get {
                return _id;
            }
        }

        //Retrieve list of all tags
        public List<string> Tags
        {
            get
            {
                return _tags;
            }
        }

        //Get cost of product
        public double Cost {
            get {
                return _cost;
            }
        }
        */
    }
}
