using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace cerinfo.Models
{
    public class usuario

    {
        
        public int UsuarioID { get; set; }
        public string nombre_usuario { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "El nombre de usuario debe contener de 3 a 50 caracteres")]
        public string paterno_usuario { get; set; }
        [StringLength(50,ErrorMessage ="El apellido paterno no puede ser mas de 50 caracter")]
        public string materno_usuario { get; set; }
        [StringLength(50, ErrorMessage = "El apellido materno no puede ser mas de 50 caracter")]
        public string tipo_usuario { get; set; }
        public string correo { get; set; }
        public string contrasena { get; set; }

    }
}
