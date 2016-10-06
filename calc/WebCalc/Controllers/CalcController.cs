using Calc;
using Domain.Managers;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using WebCalc.Models;

namespace WebCalc.Controllers
{
    public class CalcController : Controller
    {
        private IHistoryManager Manager { get; set; }

        public CalcController()
        {
            Manager = new HistoryManager();
        }

        private Helper Calc { get; set; }

        private string ActiveOperation { get; set; }

        public ActionResult Index(CalcModel data)
        {
            var model = data ?? new CalcModel();

            Calc = new Helper();

            var methods = Calc.GetType().GetMethods(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public);

            var operations = new List<SelectListItem>();

            foreach (var m in methods)
            {
                operations.Add(new SelectListItem
                {
                    Text = m.Name,
                    Value = m.Name
                });
            }
            ViewBag.operations = operations;

            if (ModelState.IsValid)
            {
                ActiveOperation = model.Operation;

                var calcType = Calc.GetType();
                var method = Calc.GetType().GetMethod(ActiveOperation);

                var result = method.Invoke(Calc, new object[] { model.X, model.Y });
                model.Result = Double.Parse(result.ToString());

                AddOperation(model.X,model.Y,model.Result);
            }

            ViewData.Model = model;

            return View();
        }

        public ActionResult History()
        {
            return View(GetOperation());
        }

        #region Работа с БД

        private void AddOperation(int x, int y, double result)
        {
            var history = new HistoryDomain();

            history.X = x;
            history.Y = y;
            history.Result = result;
            history.CreationDate = DateTime.Now;
            history.Operation = ActiveOperation;

            Manager.Add(history);
        }

        private IEnumerable<HistoryDomain> GetOperation()
        {
            return Manager.List();
        }

        #endregion
    }
}