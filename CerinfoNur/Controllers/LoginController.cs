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
using System.Net.Mail;
using System.Data;

namespace CerinfoNur.Controllers
{
    public class LoginController : Controller
    {

        SqlConnection con = new SqlConnection("Data Source=HP;Initial Catalog=cerinfo;Integrated Security=True");
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

        public ActionResult Step1_email()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Enviar(tbl_usuario usuario)
        {
            if (usuario.correo != "" && usuario.correo != null)
            {
                try
                {

                    SqlConnection conexion = new SqlConnection("Data Source=HP;Initial Catalog=cerinfo;Integrated Security=True");
                    SqlCommand com = new SqlCommand();
                    SqlDataReader dr;
                    conexion.Open();
                    com.Connection = conexion;

                    com.CommandText = "select * from tbl_usuario where correo ='" + usuario.correo + "'";


                    dr = com.ExecuteReader();
                    if (dr.Read())
                    {
                        string user = dr.GetString(0);
                        conexion.Close();

                        //Envia el mensaje al correo electronico con un codigo encriptado.
                        var seed = Environment.TickCount;
                        var random = new Random(seed);
                        int value = random.Next(0, 100);
                        String sha1 = GetSHA1(value + "asd");
                        enviarCorreo(usuario.correo, sha1);

                        agregarCambioContrasenaPendiente(user, sha1);


                        return RedirectToAction("Step2_encriptado");
                    }
                    else
                    {
                        conexion.Close();
                        return RedirectToAction("Step1_email");
                    }
                }
                catch (Exception ex)
                {
                    return View("Error");

                }

            }
            else
            {
                return RedirectToAction("Step1_email");
            }

        }
        public ActionResult Step2_encriptado()
        {
            return View();
        }




        [HttpPost]
        public ActionResult Step3_info(string sha1)
        {
            try
            {
                SqlCommand com = new SqlCommand();
                SqlDataReader dr;
                con.Open();
                com.Connection = con;

                com.CommandText = "select * from tbl_recuperarContrasena where sha1 = '" + sha1 + "'";
                dr = com.ExecuteReader();
                if (dr.Read())
                {
                    tbl_usuario user = new tbl_usuario();

                    com.CommandText = "select usuario_id from tbl_recuperarContrasena where sha1 = '" + sha1 + "'";
                    string user_id = dr.GetString(0);

                    com.CommandText = "select * from fn_getUserPass ('" + user_id + "')";
                    user.id_usuario = dr.GetString(0);
                    user.contrasena = dr.GetString(1);

                    return View(user);
                }
                else
                {

                    return RedirectToAction("Step2_encriptado");
                }
            }
            catch (Exception ex)
            {
                return View("Error");

            }
        }




        private void enviarCorreo(string para, string mensaje)
        {
            try
            {
                string email = "cerinfo.nur@gmail.com";
                string pass = "yo12345678";
                MailMessage correo = new MailMessage();
                correo.From = new MailAddress(email);
                correo.To.Add(para);
                correo.Subject = "Solicitud para cambio de contraseña";
                correo.Body = "Copie el codigo y peguelo en la pagina para poder cambiar su contraseña " + mensaje;
                correo.IsBodyHtml = true;
                correo.Priority = MailPriority.Normal;

                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 25;
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = true;

                smtp.Credentials = new System.Net.NetworkCredential(email, pass);

                smtp.Send(correo);
            }
            catch (Exception ex)
            {

            }
        }

        private void agregarCambioContrasenaPendiente(string usuario_id, string sha1)
        {
            con.Open();
            SqlCommand query = new SqlCommand("sp_insert_RecuperarPassPendiente", con);
            query.CommandType = CommandType.StoredProcedure;
            query.Parameters.Add("@user_id", SqlDbType.VarChar).Value = usuario_id;
            query.Parameters.Add("@sha", SqlDbType.VarChar).Value = sha1;

            query.ExecuteNonQuery();
            con.Close();
        }

    }

}