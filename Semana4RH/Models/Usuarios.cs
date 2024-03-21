using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

//herramienta para validaciones
using System.ComponentModel.DataAnnotations;

namespace Semana4RH.Models
{
    public class Usuarios
    {
        //atributos para cada campo de la tabla
        [Required(ErrorMessage ="El campo esta vacio, No Puede Estar Vacio")]
        public int userid { get; set; }
        [Required]

        public string username { get; set; }
        [Required]

        public string pass { get; set; }
        [Required]

        public string nivel { get; set; }
        // contructore
        public Usuarios()
        {

        }
        public Usuarios (int id, string us, string pa, string ni)
        {
            this.userid = id;
            this.username = us;
            this.pass = pa;
            this.nivel = ni;
        }
    }
}