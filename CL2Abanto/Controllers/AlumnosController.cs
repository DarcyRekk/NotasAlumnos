using CL2Abanto.Database;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using CL2Abanto.Models;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
namespace CL2Abanto.Controllers
{
    public class AlumnosController : Controller
    {
        private readonly AlumnosContext _alumnosContext;
        public AlumnosController(AlumnosContext alumnosContext)
        {
            this._alumnosContext = alumnosContext;
        }
        public IActionResult List()
        {
            var listado = _alumnosContext.Alumnos
                .Include(e => e.Notas)
                .ToList();
            AlumnosListResponse model = new AlumnosListResponse();
            model.List = (from a in listado
                          select new AlumnosResponse()
                          {
                              IdAlumno = a.IdAlumno,
                              Nombre = a.Nombre,
                              Apellido = a.Apellido,
                              DNI = a.DNI,
                              Notas = a.Notas
                          }).ToList();

            return View(model);
        }
        public IActionResult Add()
        {
            var model = new AlumnosResponse();
            model.Notas = new List<NotasEntity>();
            return View(model);
        }
        [HttpPost]
        public IActionResult Add(AlumnosResponse model)
        {
            if (ModelState.IsValid)
            {
                _alumnosContext.Alumnos.Add(new AlumnosEntity
                {
                    Nombre = model.Nombre,
                    Apellido = model.Apellido,
                    DNI = model.DNI,
                });
                _alumnosContext.SaveChanges();
                var AlumnoId = _alumnosContext.Alumnos
                    .OrderByDescending(e => e.IdAlumno)
                    .FirstOrDefault().IdAlumno;
                foreach (var notas in model.Notas)
                {
                    _alumnosContext.Notas.Add(new NotasEntity
                    {
                        IdAlumno = AlumnoId,
                        NombreCurso = notas.NombreCurso,
                        Nota = notas.Nota
                    });
                }
                _alumnosContext.SaveChanges();
                return RedirectToAction("List");
            }
            return View(model);
        }
    }
}