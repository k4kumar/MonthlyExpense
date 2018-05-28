using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MonthlyExpense.Models
{
    public class BudgetModel
    {
        public int Id { get; set; }
        public string ExpenseType { get; set; }
        public int Amount { get; set; }
        public string Comment { get; set; }

        public string BudgetMonth { get; set; }
    }
}