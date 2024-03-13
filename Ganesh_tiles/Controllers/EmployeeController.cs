using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Configuration;
using Ganesh_tiles.Model;
using System.Data.SqlClient;

namespace Ganesh_tiles.Controllers
{
    public class EmployeeController : Controller
    {
        string db = ConfigurationManager.ConnectionStrings["pdt"].ConnectionString;

        // GET: Employee
        public ActionResult Index()
        {
            List<Employee> emp = new List<Employee>();
            using(SqlConnection con = new SqlConnection(db))
            {
                SqlCommand cmd = new SqlCommand("sp_tbl_emp_show", con);
                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    emp.Add(new Employee
                    {
                        Id = Convert.ToInt32(sdr["id"]),
                        emp_Name = sdr["emp_Name"].ToString(),
                        emp_Email = sdr["emp_Email"].ToString(),
                        emp_Age = sdr["emp_Age"].ToString(),
                        emp_Dsgn = sdr["emp_Dsgn"].ToString(),
                        emp_Location = sdr["emp_Location"].ToString(),
                        emp_Salary = sdr["emp_Salary"].ToString()
                    });
                }
                con.Close();
            }
            return View(emp);
        }

        // GET: Employee/Details/5
        public ActionResult Details(int id)
        {
            Employee emp = new Employee();
            using(SqlConnection con = new SqlConnection(db))
            {
                SqlCommand cmd = new SqlCommand("sp_tbl_emp_id "+id, con);
                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    emp = new Employee
                    {
                        Id = Convert.ToInt32(sdr["id"]),
                        emp_Name = sdr["emp_Name"].ToString(),
                        emp_Email = sdr["emp_Email"].ToString(),
                        emp_Age = sdr["emp_Age"].ToString(),
                        emp_Dsgn = sdr["emp_Dsgn"].ToString(),
                        emp_Location = sdr["emp_Location"].ToString(),
                        emp_Salary = sdr["emp_Salary"].ToString()
                    };
                }
                con.Close();
            }
            return View(emp);
        }

        // GET: Employee/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Employee/Create
        [HttpPost]
        public ActionResult Create(Employee emp)
        {
            try
            {
                if (ModelState.IsValid)
                {

                }
                using(SqlConnection con = new SqlConnection(db))
                {
                    string str = "sp_tbl_emp_ins '"+emp.emp_Name+"','"+emp.emp_Email+"','"+emp.emp_Age+"','"+emp.emp_Dsgn+"','"+emp.emp_Location+"','"+emp.emp_Salary+"'";
                    SqlCommand cmd = new SqlCommand(str, con);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }        
                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Index");
            }
        }

        // GET: Employee/Edit/5
        public ActionResult Edit(int id)
        {
            Employee emp = new Employee();
            using (SqlConnection con = new SqlConnection(db))
            {
                SqlCommand cmd = new SqlCommand("sp_tbl_emp_id "+ id, con);
                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    emp = new Employee
                    {
                        Id = Convert.ToInt32(sdr["id"]),
                        emp_Name = sdr["emp_Name"].ToString(),
                        emp_Email = sdr["emp_Email"].ToString(),
                        emp_Age = sdr["emp_Age"].ToString(),
                        emp_Dsgn = sdr["emp_Dsgn"].ToString(),
                        emp_Location = sdr["emp_Location"].ToString(),
                        emp_Salary = sdr["emp_Salary"].ToString()
                    };
                }
                con.Close();
            }
            return View(emp);

        }

        // POST: Employee/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Employee emp)
        {
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
                }
                else
                {
                    using(SqlConnection con = new SqlConnection(db))
                    {
                        string str = "sp_tbl_emp_up "+emp.Id+",'"+emp.emp_Name+"','"+emp.emp_Email+"','"+emp.emp_Age+"','"+emp.emp_Dsgn+"','"+emp.emp_Location+"','"+emp.emp_Salary+"'";
                        SqlCommand cmd = new SqlCommand(str, con);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Index");
            }
        }

        // GET: Employee/Delete/5
        public ActionResult Delete(int id)
        {
            Employee emp = new Employee();
            using (SqlConnection con = new SqlConnection(db))
            {
                SqlCommand cmd = new SqlCommand("sp_tbl_emp_id "+ id, con);
                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    emp = new Employee
                    {
                        Id = Convert.ToInt32(sdr["id"]),
                        emp_Name = sdr["emp_Name"].ToString(),
                        emp_Email = sdr["emp_Email"].ToString(),
                        emp_Age = sdr["emp_Age"].ToString(),
                        emp_Dsgn = sdr["emp_Dsgn"].ToString(),
                        emp_Location = sdr["emp_Location"].ToString(),
                        emp_Salary = sdr["emp_Salary"].ToString()
                    };
                }
                con.Close();
            }
            return View(emp);
        }

        // POST: Employee/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (SqlConnection con = new SqlConnection(db))
                    {
                        string str = "sp_tbl_emp_del " + id;
                        SqlCommand cmd = new SqlCommand(str, con);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }         
                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Index");
            }
        }
    }
}
