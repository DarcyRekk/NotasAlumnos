using System.ComponentModel.DataAnnotations;

namespace CL2Abanto.Database
{
    public class NotasEntity
    {
        [Key]
        public int IdNota { get; set; }
        public int IdAlumno { get; set; }
        public string NombreCurso { get; set; }
        public double Nota { get; set; }
        public AlumnosEntity Alumnos { get; set; }
    }
}