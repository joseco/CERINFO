using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cerinfo.Models;

namespace cerinfo.Data
{
    public class dbinicializador
    {
        public static void Inicializador (cerinfoContext context)
        {
            context.Database.EnsureCreated();

            //buscar si existen registros en la tabla categoria

            if (context.usuario.Any())
            {
                return;
            }
           // var usuarios = new usuario[]
            {
               // new usuario{nombre_usuario="Angel",paterno_usuario="Chavez",materno_usuario="valverde"
                //,tipo_usuario="Administrador",correo="anderzonmc@gmail.com",contrasena="123123"}
            }
        }
    }
}
