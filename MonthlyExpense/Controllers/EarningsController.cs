using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MonthlyExpense.Models;

namespace MonthlyExpense.Controllers
{
    public class EarningsController : Controller
    {
        EarningsModel aEarningsModel=new EarningsModel();
        // GET: Earnings
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult PrcSaveEarnignsData(EarningsModel bEarningsModel)
        {
            int result = aEarningsModel.PrcSaveEarnings(bEarningsModel);
            return Json(result);
        }

        public ActionResult PrcUpdateEarnignsData(EarningsModel bEarningsModel)
        {
            int result = aEarningsModel.PrcUpdateEarnings(bEarningsModel);
            return Json(result);
        }

        public ActionResult PrcDeleteEarnignsData(int id)
        {
            int result = aEarningsModel.PrcDeleteEarnings(id);
            return Json(result);
        }

        public ActionResult PrcGetEarningsList(string date)
        {
            ViewBag.EarningsList = aEarningsModel.PrcGetEarningsList(date);
            return PartialView("_gridEarnings", new EarningsModel());
        }

    }
}