using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Data.SqlClient;

//using MySql.Data.MySqlClient;

namespace ProductRecord
{
    interface IHaveDatabase
    {
        //delete
        Boolean Remove(string[] value);

        //edit
        Boolean Edit(string[] value);

        //create
        Boolean Create(string[] value);
    }
}
