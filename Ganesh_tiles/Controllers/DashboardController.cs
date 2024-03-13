using Ganesh_tiles.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ganesh_tiles.Controllers
{
    public class DashboardController : Controller
    {
        string db = ConfigurationManager.ConnectionStrings["pdt"].ConnectionString;
        // GET: Dashboard
        public ActionResult Dashboard()
        {
            return View();
        }
        [HttpGet]
        public ActionResult EmployeeDetails()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EmployeeDetails(Employee emp)
        {
            if (ModelState.IsValid)
            {
                using (SqlConnection con = new SqlConnection(db))
                {

                    string str = "sp_tbl_emp_ins '"+emp.emp_Name+"','"+emp.emp_Email+"','"+emp.emp_Age+"','"+emp.emp_Dsgn+"','"+emp.emp_Location+"','"+emp.emp_Salary+"'";
                    SqlCommand cmd = new SqlCommand(str, con);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    return RedirectToAction("Dashboard","Dashboard");
                }
            }
            return View();
        }



    }
}