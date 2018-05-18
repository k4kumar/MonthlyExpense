using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls.WebParts;

namespace MonthlyExpense.Models
{
    public class ExpenseModel:Gateway
    {
        public int ExpenseId { get; set; }
        [DisplayName("Expense Date")]
        public string DtExpense { get; set; }
        [DisplayName("Expense Type")]
        public string ExpenseType { get; set; }
        [DisplayName("Amount")]
        public int Amount { get; set; }
        [DisplayName("Expense Name")]
        public string ExpenseName { get; set; }
        [DisplayName("Comment")]
        public string Comment { get; set; }

        public List<ExpenseModel> PrcGetExpenseTypes()
        {
            List<ExpenseModel> expenseTypeList = new List<ExpenseModel>();
            Query = "Select varName from tblCat_Variable where varType='Expense'";
            Command=new SqlCommand(Query,Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            while (Reader.Read()) {
                ExpenseModel aExpenseModel=new ExpenseModel();
                aExpenseModel.ExpenseType = Reader["varName"].ToString();
                expenseTypeList.Add(aExpenseModel);
            }
            Reader.Close();
            Connection.Close();
            return expenseTypeList;
        }

        public int PrcSaveExpense(ExpenseModel aExpenseModel)
        {
            int newId = 0;
            Query = "Select IsNull(max(Id),0)+1 as Id from tblExpense";
            Command=new SqlCommand(Query,Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            while (Reader.Read())
            {
                newId = Convert.ToInt32(Reader["Id"]);
            }
            Reader.Close();
            Query = "Insert into tblExpense Values('" + newId + "','" + aExpenseModel.ExpenseName + "','" + aExpenseModel.DtExpense + "','"+aExpenseModel.ExpenseType+"'" +
                    ",'"+aExpenseModel.Comment+"','"+aExpenseModel.Amount+"')";
            Command=new SqlCommand(Query,Connection);
            int rowAffected = Command.ExecuteNonQuery();
            Connection.Close();
            return rowAffected;
        }

        public List<ExpenseModel> PrcGetExpenseList(string date)
        {
            List<ExpenseModel> expenseList = new List<ExpenseModel>();
            Query = "Exec prcGetExpenseDetails '" +date+"'";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            while (Reader.Read())
            {
                ExpenseModel bExpenseModel = new ExpenseModel();
                bExpenseModel.ExpenseId = Convert.ToInt32(Reader["Id"]);
                bExpenseModel.ExpenseType = Reader["ExpenseType"].ToString();
                bExpenseModel.ExpenseName = Reader["ExpenseName"].ToString();
                bExpenseModel.Amount = Convert.ToInt32(Reader["Amount"]);
                bExpenseModel.DtExpense = Reader["DtExpense"].ToString();
                bExpenseModel.Comment = Reader["Comments"].ToString();
                expenseList.Add(bExpenseModel);
            }
            Reader.Close();
            Connection.Close();
            return expenseList;
        }

        public int PrcUpdateEarnings(ExpenseModel bExpenseModel)
        {

            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Query = "Update tblExpense set Amount='" + bExpenseModel.Amount + "',Comments='" + bExpenseModel.Comment + "',ExpenseType='" + bExpenseModel.ExpenseType + "'," +
                    "ExpenseName='" + bExpenseModel.ExpenseName + "',DtExpense='" + bExpenseModel.DtExpense + "' where Id='" + bExpenseModel.ExpenseId + "'";
            Command = new SqlCommand(Query, Connection);
            int rowAffected = Command.ExecuteNonQuery();
            Connection.Close();
            return rowAffected;
        }

        public int PrcDeleteEarnings(int id)
        {
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Query = "Delete tblExpense where Id='" + id + "'";
            Command = new SqlCommand(Query, Connection);
            int rowAffected = Command.ExecuteNonQuery();
            Connection.Close();
            return rowAffected;
        }


    }
}