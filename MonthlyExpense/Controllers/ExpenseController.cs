using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MonthlyExpense.Models;

namespace MonthlyExpense.Controllers
{
    public class ExpenseController : Controller
    {
        ExpenseModel aExpenseModel = new ExpenseModel();
        // GET: Expense
        public ActionResult Index()
        {
            ViewBag.ExpenseTypes = PrcGetExpenseTypes();
            return View();
        }

       
        public List<ExpenseModel> PrcGetExpenseTypes()
        {    
            return aExpenseModel.PrcGetExpenseTypes();
        }



        public ActionResult PrcSaveExpenseData(ExpenseModel bExpenseModel)
        {
            int result = aExpenseModel.PrcSaveExpense(bExpenseModel);
            return Json(result);
        }

        public ActionResult PrcUpdateExpenseData(ExpenseModel bExpenseModel)
        {
            int result = aExpenseModel.PrcUpdateEarnings(bExpenseModel);
            return Json(result);
        }

        public ActionResult PrcDeleteExpenseData(int id)
        {
            int result = aExpenseModel.PrcDeleteEarnings(id);
            return Json(result);
        }

        public ActionResult PrcGetExpenseList(string date)
        {
            ViewBag.ExpenseList = aExpenseModel.PrcGetExpenseList(date);
            return PartialView("_gridExpense", new ExpenseModel());
        }

    }
}