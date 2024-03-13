using Ganesh_tiles.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using Microsoft.Ajax.Utilities;

namespace Ganesh_tiles.Controllers
{
    public class HomeController : Controller
    {
        string d = @"data source=DESKTOP-GF0PAV6\SQLEXPRESS;initial catalog=GT_MVC;integrated security=True";

        public ActionResult Index()
        {
            return View();
        }


       
        GT_MVCEntities1 db = new GT_MVCEntities1();
        [HttpGet]
        public ActionResult About()
        {
            return View();
        }


        [HttpPost]
        public ActionResult About(tbl_Contact contact)
        {
            db.tbl_Contact.Add(contact);
            db.SaveChanges();
            Response.Write("<script>alert('Enter successfully')</script>");
            return View();
        }



        //Product pd = new Product();
        [HttpGet]
        public ActionResult Product()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Product(Products pdt)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (SqlConnection con = new SqlConnection(d))
                    {
                        string str = "sp_ins_pdt '" + pdt.cus_Name + "','" + pdt.pdt_Brand + "','" + pdt.pdt_Type + "'," + pdt.pdt_Qty + ",'" + pdt.pdt_Perbox + "','" + pdt.total_Cost + "'";
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
            //pd.tbl_Productbill.Add(pdt);
            //pd.SaveChanges();
            //Response.Write("<script>alert('Product Ordered Successfully')</script>");

        }
       
    }
        
}