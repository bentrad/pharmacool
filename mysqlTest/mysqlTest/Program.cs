using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;



namespace mysqlTest
{

    public class mysqlTest
    {
        static void Main(string[] args)
        {
            /* my first program in C# */
            Application.Run(new SqlTest());
            //public static void mySqlTest.Run(new Form1());
            //MySqlCommand cmd;
            //try
            //{
            //    SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            //    builder.DataSource = "pharmacool.database.windows.net";
            //    builder.UserID = "pharma";
            //    builder.Password = "pineapplepizza1!";
            //    builder.InitialCatalog = "pcdb";

            //    using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
            //    {
            //        Console.WriteLine("\nQuery data example:");
            //        Console.WriteLine("=========================================\n");

            //        connection.Open();

            //        //cmd = connection.CreateCommand();
            //        //cmd.CommandText = "INSERT INTO PRODUCTS(productid, pname, pcost, pstock)VALUES(@productid, @pname, @pcost, @pstock)";
            //        //cmd.Parameters.AddWithValue("@productid", int.Parse(txtId.Text));
            //        //cmd.Parameters.AddWithValue("@pname", txtName.Text);
            //        //cmd.Parameters.AddWithValue("@pcost", pCost);
            //        //cmd.Parameters.AddWithValue("@pstock", pStock);
            //        //cmd.ExecuteNonQuery();

            //        StringBuilder sb = new StringBuilder();
            //        sb.Append("INSERT INTO PRODUCTS(pname, pcost, pstock)VALUES('apple', 0.4, 300)");//, pname, pcost, pstock)VALUES(5, testConnName, 5, 5)");
            //        //sb.Append("FROM [SalesLT].[ProductCategory] pc ");
            //        //sb.Append("JOIN [SalesLT].[Product] p ");
            //        //sb.Append("ON pc.productcategoryid = p.productcategoryid;");

            //        String sql = sb.ToString();

            //        using (SqlCommand command = new SqlCommand(sql, connection))
            //        {
            //            //command = connection.CreateCommand();
            //            using (SqlDataReader reader = command.ExecuteReader())
            //            {
            //                while (reader.Read())
            //                {
            //                    Console.WriteLine("{0} {1}", reader.GetString(0), reader.GetString(1));
            //                }
            //            }
            //        }
            //    }
            //}
            //catch (SqlException e)
            //{
            //    Console.WriteLine(e.ToString());
            //}
            //Console.ReadLine();
        


            Console.WriteLine("Hello World");
            //Console.ReadKey();
        }
    }
};
    
