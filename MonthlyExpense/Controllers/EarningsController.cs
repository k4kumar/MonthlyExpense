using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MonthlyExpense.Controllers
{
    public class EarningsController : Controller
    {
        // GET: Earnings
        public ActionResult Index()
        {
            return View();
        }
    }
}