using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MonthlyExpense.Models
{
    public class EarningsModel
    {
        public int ID { get; set; }
        public string Source { get; set; }
        public int Amount { get; set; }
        public string DtEarn { get; set; }
        public int OutstandingAmount { get; set; }
        public string Comment { get; set; }
    }
}