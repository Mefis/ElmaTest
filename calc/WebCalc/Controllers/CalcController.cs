using Calc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebCalc.Models;

namespace WebCalc.Controllers
{
    public class CalcController : Controller
    {
        // GET: Calc
        public ActionResult Index(CalcModel data)
        {
            var model = data ?? new CalcModel();

            if (ModelState.IsValid)
            {
                var calcHelper = new Helper();
                model.Result = calcHelper.Sum(model.X, model.Y);
            }

            ViewData.Model = model;

            return View();
        }
    }
}