using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CerinfoNur.Models;
using System.Data.SqlClient;
using SimpleCrypto;

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



        [HttpPost]
        public ActionResult Auth(Login L)
        {
            con.Open();
            com.Connection = con;
            ICryptoService cryptoService = new PBKDF2();
            //Generar algoritmo de encryptacion
            String salt = cryptoService.GenerateSalt();
            String contrasenaencryptada = cryptoService.Compute(L.password);
            com.CommandText = "SELECT * FROM tbl_usuario WHERE nombre_usuario='"+L.username+"' AND contrasena='"+L.password+"'";
            // Con password encryptado
            //com.CommandText = "SELECT * FROM tbl_usuario WHERE nombre_usuario='" + L.username + "' AND contrasena='" + contrasenaencryptada + "'";
            dr = com.ExecuteReader();
            if (dr.Read())
            {
                con.Close();
                return View("~/Views/Home/Index.cshtml");
            }
            else
            {
                con.Close();
                return View("Error");
            }
            
            
        }
        
        
    }
}
