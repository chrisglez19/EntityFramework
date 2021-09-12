using System;
using System.Collections.Generic;

#nullable disable

namespace WebApi.DB.Models
{
    public partial class EstatusAlumno
    {
        public EstatusAlumno()
        {
            Alumnos = new HashSet<Alumno>();
        }

        public short Id { get; set; }
        public string Clave { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<Alumno> Alumnos { get; set; }
    }
}
