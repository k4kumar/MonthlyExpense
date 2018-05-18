using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MonthlyExpense.Models
{
    public class EarningsModel:Gateway
    {
        public int ID { get; set; }
        public string Source { get; set; }
        public int Amount { get; set; }

        [DisplayName("Date Earned")]
        public string DtEarn { get; set; }
        [DisplayName("Remainder Amount")]
        public int OutstandingAmount { get; set; }
        public string Comment { get; set; }

        public int PrcSaveEarnings(EarningsModel bEarningsModel)
        {
            int newId = 0;
            Query = "Select IsNull(max(Id),0)+1 as Id from tblEarnings";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            while (Reader.Read())
            {
                newId = Convert.ToInt32(Reader["Id"]);
            }
            Reader.Close();
            Query = "Insert into tblEarnings Values('" + newId + "','" + bEarningsModel.Amount + "','" + bEarningsModel.Source + "','" + bEarningsModel.DtEarn + "'" +
                    ",'" + bEarningsModel.OutstandingAmount + "','" + bEarningsModel.Comment + "')";
            Command = new SqlCommand(Query, Connection);
            int rowAffected = Command.ExecuteNonQuery();
            Connection.Close();
            return rowAffected;
        }

        public int PrcUpdateEarnings(EarningsModel bEarningsModel)
        {
            
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Query = "Update tblEarnings set Amount='"+bEarningsModel.Amount+"',Comments='"+bEarningsModel.Comment+"',Source='"+bEarningsModel.Source+"'," +
                    "dtEarn='"+bEarningsModel.DtEarn+"',OutstandingAmount='"+bEarningsModel.OutstandingAmount+"' where Id='"+bEarningsModel.ID+"'";
            Command = new SqlCommand(Query, Connection);
            int rowAffected = Command.ExecuteNonQuery();
            Connection.Close();
            return rowAffected;
        }

        public int PrcDeleteEarnings(int id)
        {
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Query = "Delete tblEarnings where Id='"+id+"'";
            Command = new SqlCommand(Query, Connection);
            int rowAffected = Command.ExecuteNonQuery();
            Connection.Close();
            return rowAffected;
        }


        public List<EarningsModel> PrcGetEarningsList(string date)
        {
            List<EarningsModel> earningList = new List<EarningsModel>();
            Query = "Exec prcGetEarningsDetails '" + date + "'";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            while (Reader.Read())
            {
                EarningsModel bEarningsModel = new EarningsModel();
                bEarningsModel.ID = Convert.ToInt32(Reader["Id"]);
                bEarningsModel.Source = Reader["Source"].ToString();
                bEarningsModel.DtEarn = Reader["DtEarn"].ToString();
                bEarningsModel.OutstandingAmount = Convert.ToInt32(Reader["OutstandingAmount"]);
                bEarningsModel.Amount = Convert.ToInt32(Reader["Amount"]);
                bEarningsModel.Comment = Reader["Comments"].ToString();
                earningList.Add(bEarningsModel);
            }
            Reader.Close();
            Connection.Close();
            return earningList;
        }
    }
}