using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebApiFinalDiNezioCamilettiAgustin.Data;
using WebApiFinalDiNezioCamilettiAgustin.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace WebApiFinalDiNezioCamilettiAgustin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        public DBHospitalContext context { get; set; }

        public DoctorController(DBHospitalContext context)
        {
            this.context = context;
        }

        //GET-api/Doctor
        [HttpGet]
        public List<Doctor> Get() => (from a in context.Doctores select a).ToList();

        //GET-api/Doctor/id
        [HttpGet("{id}")]
        public ActionResult<Doctor> Get(int id)
        {
            var doctor = (from a in context.Doctores where a.DoctorId == id select a).SingleOrDefault();
            if (doctor == null) return NotFound();
            return doctor;
        }

        //GET-api/Doctor/especialidad/especialidad
        [HttpGet("especialidad/{especialidad}")]
        public List<Doctor> Get(string especialidad) => (from a in context.Doctores where a.Especialidad.ToUpper() == especialidad.ToUpper() select a).ToList();
        

        //POST-api/Doctor
        [HttpPost]
        public ActionResult Post([FromBody] Doctor doctor)
        {
            context.Doctores.Add(doctor);
            context.SaveChanges();
            return Ok();
        }

        //DELETE-api/Doctor
        [HttpDelete("{id}")]
        public ActionResult<Doctor> Delete(int id)
        {
            var aEliminar = context.Doctores.Find(id);
            if (aEliminar == null) return NotFound();
            context.Remove(aEliminar);
            context.SaveChanges();
            return aEliminar;
        }

        //PUT-api/Doctor
        [HttpPut("{id}")]
        public ActionResult<Doctor> Put(int id, [FromBody] Doctor doctor)
        {
            if (id != doctor.DoctorId) return BadRequest();
            context.Entry(doctor).State = EntityState.Modified;
            context.SaveChanges();
            return NoContent();
        }
    }
}
