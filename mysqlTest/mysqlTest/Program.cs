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
         
            Console.WriteLine("Hello World");
            //Console.ReadKey();
        }
    }
};