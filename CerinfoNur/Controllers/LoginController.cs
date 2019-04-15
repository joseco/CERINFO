using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CerinfoNur.Models;
using System.Data.SqlClient;

namespace CerinfoNur.Controllers
{
    public class LoginController : Controller
    {

        SqlConnection con = new SqlConnection("Data Source=DESKTOP-RM8UAH3;Initial Catalog=cerinfo;Integrated Security=True");
        SqlCommand com = new SqlCommand();
        SqlDataReader dr;
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        
        //[HttpPost]

        // POST: Login
        public ActionResult Auth(Login L)
        {
            con.Open();
            com.Connection = con;
            com.CommandText = "SELECT * FROM tbl_usuario WHERE nombre_usuario='"+L.username+"' AND password='"+L.password+"'";
            dr = com.ExecuteReader();
            if (dr.Read())
            {
                con.Close();
                return View();
            }
            else
            {
                con.Close();
                return View();
            }
            
            
        }
        
        
    }
}
