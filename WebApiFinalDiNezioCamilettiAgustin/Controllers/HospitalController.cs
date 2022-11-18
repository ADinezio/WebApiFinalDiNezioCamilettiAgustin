using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebApiFinalDiNezioCamilettiAgustin.Data;
using WebApiFinalDiNezioCamilettiAgustin.Models;
using System.Linq;

namespace WebApiFinalDiNezioCamilettiAgustin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HospitalController : ControllerBase
    {
        public DBHospitalContext context { get; set; }

        public HospitalController(DBHospitalContext context)
        {
            this.context = context;
        }

        //GET-api/Hospital
        [HttpGet]
        public dynamic Get() => (from h in context.Hospitales select new {h.Nombre,h.Telefono,h.NumeroCama});

        //GET-api/Hospital/NumeroCamas
        [HttpGet("{NumeroCamas}")]
        public dynamic Get(int numeroCamas) => (from h in context.Hospitales where h.NumeroCama > numeroCamas select new { h.Nombre, h.Telefono, h.NumeroCama });
    }
}
