using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CL2Abanto.Database
{
    public class AlumnosEntity
    {
        [Key]
        public int IdAlumno { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int DNI { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public List<NotasEntity> Notas { get; set; }
    }
}