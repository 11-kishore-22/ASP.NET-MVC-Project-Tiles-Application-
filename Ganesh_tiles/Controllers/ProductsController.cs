using Ganesh_tiles.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.WebSockets;

namespace Ganesh_tiles.Controllers
{
    public class ProductsController : Controller
    {
        // GET: Products 
        string db = @"data source=DESKTOP-GF0PAV6\SQLEXPRESS;initial catalog=GT_MVC;integrated security=True";

        public ActionResult Index()
        {

            List<Products> pdt = new List<Products>();
            using(SqlConnection con = new SqlConnection(db))
            {
                SqlCommand cmd = new SqlCommand("sp_show_pdt", con);
                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    pdt.Add(new Products
                    {
                        Id = Convert.ToInt32(sdr["Id"]),
                        cus_Name = sdr["cus_Name"].ToString(),
                        pdt_Brand = sdr["pdt_Brand"].ToString(),
                        pdt_Type = sdr["pdt_Type"].ToString(),
                        pdt_Qty = Convert.ToInt32(sdr["pdt_Qty"]),
                        pdt_Perbox = sdr["pdt_Perbox"].ToString(),
                        total_Cost = sdr["total_Cost"].ToString()
                    });
                }
                con.Close();
            }
            return View(pdt);
        }

        // GET: Products/Details/5
        public ActionResult Details(int id)
        {
            Products pdtdetails = new Products();
            using(SqlConnection con = new SqlConnection(db))
            {
                SqlCommand cmd = new SqlCommand("sp_search_pdt " + id,con);
                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    pdtdetails = new Products
                    {
                        Id = Convert.ToInt32(sdr["Id"]),
                        cus_Name = sdr["cus_Name"].ToString(),
                        pdt_Brand = sdr["pdt_Brand"].ToString(),
                        pdt_Type = sdr["pdt_Type"].ToString(),
                        pdt_Qty = Convert.ToInt32(sdr["pdt_Qty"]),
                        pdt_Perbox = sdr["pdt_Perbox"].ToString(),
                        total_Cost = sdr["total_Cost"].ToString()
                    };
                }
                con.Close();
            }
            return View(pdtdetails);
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        [HttpPost]
        public ActionResult Create(Products pdt)
        {

            if (pdt.pdt_Qty.ToString().Length > 0)
            {
                pdt.total_Cost = (Convert.ToInt32(pdt.pdt_Qty) * (Convert.ToInt32(pdt.pdt_Perbox))).ToString();
            }
            try
            {
                if (ModelState.IsValid)
                {
                    using(SqlConnection con = new SqlConnection(db))
                    {
                        string str = "sp_ins_pdt '"+pdt.cus_Name+"','"+pdt.pdt_Brand+"','"+pdt.pdt_Type+"',"+pdt.pdt_Qty+",'"+pdt.pdt_Perbox+"','"+pdt.total_Cost+"'";
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

        // GET: Products/Edit/5
        public ActionResult Edit(int id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            else
            {
                Products pdt = new Products();
                using (SqlConnection con = new SqlConnection(db))
                {
                    SqlCommand cmd = new SqlCommand("sp_search_pdt "+id, con);
                    con.Open();
                    SqlDataReader sdr = cmd.ExecuteReader();
                    while (sdr.Read())
                    {
                        pdt = new Products
                        {
                            Id = Convert.ToInt32(sdr["Id"]),
                            cus_Name = sdr["cus_Name"].ToString(),
                            pdt_Brand = sdr["pdt_Brand"].ToString(),
                            pdt_Type = sdr["pdt_Type"].ToString(),
                            pdt_Qty = Convert.ToInt32(sdr["pdt_Qty"]),
                            pdt_Perbox = sdr["pdt_Perbox"].ToString(),
                            total_Cost = sdr["total_Cost"].ToString()
                        };
                    }

                    con.Close();
                }
                return View(pdt);
            }
            
        }

        // POST: Products/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Products pdt)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using(SqlConnection con = new SqlConnection(db))
                    {
                        string editquery = "sp_upd_pdt "+pdt.Id+",'"+pdt.cus_Name+"',"+
                            "'"+pdt.pdt_Brand+"','"+pdt.pdt_Type+"',"+
                            ""+pdt.pdt_Qty+",'"+pdt.pdt_Perbox+"',"+
                            "'"+pdt.total_Cost+"' ";
                        SqlCommand cmd = new SqlCommand(editquery,con);
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

        // GET: Products/Delete/5
        public ActionResult Delete(int id)
        {

            Products pdtdelete = new Products();
            using (SqlConnection con = new SqlConnection(db))
            {
                SqlCommand cmd = new SqlCommand("sp_search_pdt "+ id, con);
                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    pdtdelete = new Products
                    {
                        Id = Convert.ToInt32(sdr["Id"]),
                        cus_Name = sdr["cus_Name"].ToString(),
                        pdt_Brand = sdr["pdt_Brand"].ToString(),
                        pdt_Type = sdr["pdt_Type"].ToString(),
                        pdt_Qty = Convert.ToInt32(sdr["pdt_Qty"]),
                        pdt_Perbox = sdr["pdt_Perbox"].ToString(),
                        total_Cost = sdr["total_Cost"].ToString()
                    };
                }
                con.Close();
            }
            return View(pdtdelete);
        }

        // POST: Products/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using(SqlConnection con = new SqlConnection(db))
                    {
                        string query2 = "sp_del_pdt " +id;
                        SqlCommand cmd = new SqlCommand(query2,con);
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
