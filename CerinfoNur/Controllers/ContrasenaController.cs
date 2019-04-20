using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CerinfoNur.Models;
using System.Data.SqlClient;
using SimpleCrypto;
using System.Security.Cryptography;
using System.Text;

namespace CerinfoNur.Controllers
{
    public class ContrasenaController : Controller
    {

        SqlConnection con = new SqlConnection("Data Source=DESKTOP-DPN7855;Initial Catalog=cerinfo;Integrated Security=True");
        SqlCommand com = new SqlCommand();
        SqlDataReader dr;
        // GET: Contrasena
        public ActionResult Index()
        {
            ViewBag.showSuccessAlert = false;
            return View();
        }

        [HttpPost]
        public ActionResult Auth(Contrasena C)
        {
            con.Open();
            com.Connection = con;
           

            string usuario = C.username;
            string contrasena = C.antiguaContrasena;
            string newContrasena = C.nuevaContrasena;
            string confirmContrasena = C.confirmarContrasena;
            cerinfoEntities DB = new cerinfoEntities();

            if (newContrasena.Equals(confirmContrasena) && newContrasena.Length > 6)
            {
                ViewBag.showSuccessAlert = true;
                string pcontrasena = GetSHA1(newContrasena);
                string pcontrasenaOld = GetSHA1(contrasena);
                try
                {
                    com.CommandText = "UPDATE tbl_usuario SET contrasena='" + pcontrasena + "' WHERE nombre_usuario='" + usuario + "' AND contrasena = '" + pcontrasenaOld + "'";

                    com.ExecuteReader();
                    con.Close();
                    return View("~/Views/Home/Index.cshtml");
                }
                catch (Exception)
                {
                    return View("Error");
                    throw;
                }
               
                
            }
            else {
                
                return View("Error");
            }    
        }
        public static string GetSHA1(string str)
        {
            SHA1 sha1 = SHA1Managed.Create();
            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] stream = null;
            StringBuilder sb = new StringBuilder();
            stream = sha1.ComputeHash(encoding.GetBytes(str));
            for (int i = 0; i < stream.Length; i++) sb.AppendFormat("{0:x2}", stream[i]);
            return sb.ToString();
        }


    }
}