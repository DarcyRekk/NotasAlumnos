using CL2Abanto.Database;
using System;
using System.Collections.Generic;
namespace CL2Abanto.Models
{
    public class AlumnosListResponse
    {
        public List<AlumnosResponse> List { get; set; }
        public AlumnosListResponse()
        {
            List = new List<AlumnosResponse>();
        }
    }
    public class AlumnosResponse
    {
        public int IdAlumno { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int DNI { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public List<NotasEntity> Notas { get; set; }
    }
}