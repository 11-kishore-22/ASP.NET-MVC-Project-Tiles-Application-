using Ganesh_tiles.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Ganesh_tiles.Controllers
{
    public class RegisterLoginController : Controller
    {

        string db = @"data source=DESKTOP-GF0PAV6\SQLEXPRESS;initial catalog=GT_MVC;integrated security=True";

        // GET: RegisterLogin
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Register(Register rg)
        {
           using(SqlConnection con = new SqlConnection(db))
            {
                string query = "[sp_tbl_user_ins] '"+rg.Name+"','"+rg.Username+"','"+rg.Email+"','"+rg.Password+"','"+rg.Location+"'";
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script> alert('Registered Successfully')</script>");
                return RedirectToAction("Index","Home");
            }
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Register rgr)
        {

            return View();
        }
    }
}