using Calc;
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

                var oper = string.Format("{0} {1} {2} = {3}", model.X, ActiveOperation, model.Y, model.Result);

                AddOperation(oper);
            }

            ViewData.Model = model;

            return View();
        }

        public ActionResult History()
        {
            return View(GetOperation());
        }

        #region Работа с БД

        private void AddOperation(string oper)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["ElmaCon"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                var queryString = string.Format("INSERT INTO [dbo].[History] ([Operation]) VALUES (N'{0}')", oper);

                SqlCommand command = new SqlCommand(queryString, connection);
                command.Connection.Open();
                command.ExecuteNonQuery();
            }
        }

        private void DeleteHistory()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["ElmaCon"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                var queryString = "DELETE FROM [dbo].[History]";

                SqlCommand command = new SqlCommand(queryString, connection);
                command.Connection.Open();
                command.ExecuteNonQuery();
            }
        }

        private IEnumerable<string> GetOperation()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["ElmaCon"].ConnectionString;

            var result = new List<string>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                var queryString = "SELECT [Operation] FROM [dbo].[History]";

                SqlCommand command = new SqlCommand(queryString, connection);
                command.Connection.Open();

                var reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        result.Add(reader.GetString(0));
                    }
                }
                reader.Close();
            }
            return result;
        }

        #endregion
    }
}