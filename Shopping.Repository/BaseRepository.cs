using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Shopping.DAL.Implement
{
    public class BaseRepository
    {
        private readonly IConfiguration _config;
        protected IDbConnection connection;
        public BaseRepository(IConfiguration config)
        {
            _config = config;
            connection = new SqlConnection(_config.GetConnectionString("ShoppingDbConnection"));
            //connection = new SqlConnection(@"Data Source=DESKTOP-1AHHKMF\SQLEXPRESS;Initial Catalog=DB_Shopping_CG;Persist Security Info=True;User ID=nhattan; password=Lovelykid1@");
        }
    }
}
