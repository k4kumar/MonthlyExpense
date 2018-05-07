using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace MonthlyExpense.Models
{
    public class Gateway
    {
        public SqlCommand Command { get; set; }
        public SqlDataReader Reader { get; set; }
        public SqlConnection Connection { get; set; }
        public string Query { get; set; }

        public string connectionString = WebConfigurationManager.ConnectionStrings["expenseDBCon"].ConnectionString;
        public Gateway()
        {
            Connection=new SqlConnection(connectionString);
        }
    }
}