using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CerinfoNur.Models;
using System.Text.RegularExpressions;
using System.Data.SqlClient;
using SimpleCrypto;
using System.Security.Cryptography;
using System.Text;

namespace CerinfoNur.Controllers
{
    public class tbl_usuarioController : Controller
    {
        private CerinfoNurContext db = new CerinfoNurContext();
        SqlConnection conexion = new SqlConnection("Data Source=DESKTOP-DPN7855;Initial Catalog=cerinfo;Integrated Security=True");

        // GET: tbl_usuario
        public ActionResult Index()
        {

            cerinfoEntities DB = new cerinfoEntities();
            List<tbl_usuario> user = DB.tbl_usuario.ToList();
                return View(user);
        }

        // GET: tbl_usuario/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_usuario tbl_usuario = db.tbl_usuario.Find(id);
            if (tbl_usuario == null)
            {
                return HttpNotFound();
            }
            return View(tbl_usuario);
        }

        // GET: tbl_usuario/Create
        public ActionResult Create()
        {
            return View();
        }
  
        [HttpPost]
        public ActionResult create(tbl_usuario usuario)
        {
            //LLAMO AL METODO Y HASHEO LA CONTRASEÑA
            string co = GetSHA1(usuario.contrasena);
           
            ICryptoService cryptoService = new PBKDF2();
            //Generar algoritmo de encryptacion
            string salt = cryptoService.GenerateSalt();
            string contrasenaencryptada = cryptoService.Compute(usuario.contrasena);
            conexion.Open();
            SqlCommand query = new SqlCommand("insertarusuario", conexion);
            query.CommandType = CommandType.StoredProcedure;
            query.Parameters.Add("@pid_usuario", SqlDbType.VarChar).Value = usuario.id_usuario;
            query.Parameters.Add("@pcontrasena", SqlDbType.VarChar).Value = co;
            query.Parameters.Add("@pnombre_usuario", SqlDbType.VarChar).Value = usuario.nombre_usuario;
            query.Parameters.Add("@ppaterno_usuario", SqlDbType.VarChar).Value = usuario.paterno_usuario;
            query.Parameters.Add("@pmaterno_usuario", SqlDbType.VarChar).Value = usuario.materno_usuario;
            query.Parameters.Add("@ptipo_usuario", SqlDbType.VarChar).Value = usuario.tipo_usuario;
            query.Parameters.Add("@pcorreo", SqlDbType.VarChar).Value = usuario.correo;
            query.ExecuteNonQuery();
            conexion.Close();
            return RedirectToAction("Index");
        }

        // GET: tbl_usuario/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_usuario tbl_usuario = db.tbl_usuario.Find(id);
            if (tbl_usuario == null)
            {
                return HttpNotFound();
            }
            return View(tbl_usuario);
        }

        // POST: tbl_usuario/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_usuario,contrasena,nombre_usuario,paterno_usuario,materno_usuario,tipo_usuario,correo")] tbl_usuario tbl_usuario)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_usuario).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbl_usuario);
        }

        // GET: tbl_usuario/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_usuario tbl_usuario = db.tbl_usuario.Find(id);
            if (tbl_usuario == null)
            {
                return HttpNotFound();
            }
            return View(tbl_usuario);
        }

        // POST: tbl_usuario/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            tbl_usuario tbl_usuario = db.tbl_usuario.Find(id);
            db.tbl_usuario.Remove(tbl_usuario);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        //METODO DE HASH ENCRYPTACION DE CONTRASEÑA
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

