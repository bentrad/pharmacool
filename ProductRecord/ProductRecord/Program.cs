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
    public class Program
    {
        static void Main(string[] args)
        {
            //Test SALES database connection
            DatabaseConnection testConnection = new DatabaseConnection("pcdb", "SALES");

            testConnection.SQLCommandBuilder();
            Console.WriteLine("Hello World");
            //Console.ReadKey();
        }
    }
}
