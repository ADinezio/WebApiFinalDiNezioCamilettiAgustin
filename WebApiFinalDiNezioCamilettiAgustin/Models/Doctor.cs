using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiFinalDiNezioCamilettiAgustin.Models
{
    public class Doctor
    {

        #region propiedades
        public int DoctorId { get; set; }
        public string Apellido { get; set; }
        public string Especialidad { get; set; }

        [Required]
        public int HospitalCo { get; set; }
        #endregion

        #region propiedades Navegacion
        [ForeignKey("HospitalCo")]
        public Hospital Hospital { get; set; }
        #endregion
    }
}
