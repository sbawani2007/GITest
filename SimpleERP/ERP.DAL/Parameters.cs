using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace ERP.DAL
{
    public class Parameters
    {
        public System.Collections.Hashtable collection = new System.Collections.Hashtable();

        public void Add(MySql.Data.MySqlClient.MySqlParameter param)
        {
            collection.Add(param.ParameterName, param);
        }

        public MySqlParameter Get(string paramName)
        {
            return (MySqlParameter)collection[paramName];
        }

    }
}
