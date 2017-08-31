using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Usuarios
    {
        [Key]
        public int IdUsuarios { get; set; }
        public string NombreUsuarios { get; set; }
        public string Nombres { get; set; }
        public string FechaCreacion { get; set; }
        public string Contrasena { get; set; }
    }
}
