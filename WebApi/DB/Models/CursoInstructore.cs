using System;
using System.Collections.Generic;

#nullable disable

namespace WebApi.DB.Models
{
    public partial class CursoInstructore
    {
        public int Id { get; set; }
        public short IdCurso { get; set; }
        public short IdInstructor { get; set; }
        public DateTime? FechaContratacion { get; set; }

        public virtual Curso IdCursoNavigation { get; set; }
        public virtual Instructore IdInstructorNavigation { get; set; }
    }
}
