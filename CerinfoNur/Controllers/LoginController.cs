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
    public class LoginController : Controller
    {

        SqlConnection con = new SqlConnection("Data Source=DESKTOP-DPN7855;Initial Catalog=cerinfo;Integrated Security=True");
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
           

            string usuario = L.username;
            string contrasena = L.password;
            cerinfoEntities DB = new cerinfoEntities();

            // var persona = DB.tbl_usuario.Where(x => x.nombre_usuario == usuario).FirstOrDefault();
            //Generar algoritmo de encryptacion
            // String salt = cryptoService.GenerateSalt();
            //String contrasenaencryptada = cryptoService.Compute(L.password);
            //com.CommandText = "SELECT * FROM tbl_usuario WHERE nombre_usuario='"+L.username+"' AND contrasena='"+L.password+"'";
            // Con password encryptado
            //com.CommandText = "SELECT * FROM tbl_usuario WHERE nombre_usuario='" + L.username + "' AND contrasena='" + contrasenaencryptada + "'";
            //ICryptoService cryptoService = new PBKDF2();
            //string contrasenaEncryptada = cryptoService.Compute(contrasena,persona.salt);
            string pcontrasena = GetSHA1(contrasena);
            com.CommandText = "SELECT * FROM tbl_usuario WHERE nombre_usuario='" + usuario + "' AND contrasena='" + pcontrasena + "'";


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