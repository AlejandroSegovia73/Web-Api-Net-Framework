using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TECNM.Models;

namespace TECNM.Controllers
{
    [Authorize]
    public class UsersController : ApiController
    {
        //Obtener a todos los estudiantes
        public IHttpActionResult GetAllStudents()
        {
            List<Estudiante> estudiantes = null;

            using (var user = new TECNMEntities())
            {
                estudiantes = user.Estudiantes
                    .Select(e => new Estudiante()
                    {
                        id = e.id,
                        nombre = e.nombre,
                        apellidoP = e.apellidoP,
                        apellidoM = e.apellidoM,
                        matricula = e.matricula,
                    }).ToList<Estudiante>();
            }

            if (estudiantes == null || estudiantes.Count == 0)
            {
                return NotFound();
            }

            return Ok(estudiantes);
        }

        //Obtener estudiante por medio del id
        public IHttpActionResult GetStudentById(int id)
        {
            Estudiante estudiante = null;

            using (var user = new TECNMEntities())
            {
                estudiante = user.Estudiantes
                    .Where(e => e.id == id)
                    .Select(e => new Estudiante()
                    {
                        id = e.id,
                        nombre = e.nombre,
                        apellidoP = e.apellidoP,
                        apellidoM = e.apellidoM,
                        matricula = e.matricula,
                    }).FirstOrDefault<Estudiante>();
            }

            if (estudiante == null)
            {
                return NotFound();
            }

            return Ok(estudiante);
        }

        //Agregar un nuevo estudiante
        public IHttpActionResult PostNewStudent(Estudiante estudiante)
        {
            using (var user = new TECNMEntities())
            {
                user.Estudiantes.Add(new Estudiantes()
                {
                    id = estudiante.id,
                    nombre = estudiante.nombre,
                    apellidoP = estudiante.apellidoP,
                    apellidoM = estudiante.apellidoM,
                    matricula = estudiante.matricula,
                });

                user.SaveChanges();
            }

            return Ok();
        }

        public IHttpActionResult Put(Estudiante estudiante)
        {
            using (var user = new TECNMEntities())
            {
                var existingUser = user.Estudiantes.Where(e => e.id == estudiante.id)
                                                        .FirstOrDefault<Estudiantes>();

                if (existingUser != null)
                {
                    existingUser.id = estudiante.id;
                    existingUser.nombre = estudiante.nombre;
                    existingUser.apellidoP = estudiante.apellidoP;
                    existingUser.apellidoM = estudiante.apellidoM;
                    existingUser.matricula = estudiante.matricula;

                    user.SaveChanges();
                }
                else
                {
                    return NotFound();
                }
            }

            return Ok();
        }
        public IHttpActionResult Delete(int id)
        {
            using (var user = new TECNMEntities())
            {
                var estudiante = user.Estudiantes
                    .Where(e => e.id == id)
                    .FirstOrDefault();

                user.Entry(estudiante).State = System.Data.Entity.EntityState.Deleted;
                user.SaveChanges();
            }

            return Ok();
        }
    }
}
