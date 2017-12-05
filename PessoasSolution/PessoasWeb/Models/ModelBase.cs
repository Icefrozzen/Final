using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace PessoasWeb.Models
{
    public class ModelBase : IDisposable
    {
        protected SqlConnection connection;
        public ModelBase()
        {
            string strConn = @"Data Source = localhost;  
                               Initial Catalog = vidnu;
                               Integrated Security = true";
            //USer Id = sa; Password = dba;

            connection = new SqlConnection(strConn);
            connection.Open();
        }

        public void Dispose()
        {
            connection.Close();
        }
    }
}
