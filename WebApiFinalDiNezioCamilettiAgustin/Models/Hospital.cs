using System.Collections.Generic;

namespace WebApiFinalDiNezioCamilettiAgustin.Models
{
    public class Hospital
    {
        #region propiedades
        public int HospitalId { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public int NumeroCama { get; set; }
        #endregion

        #region propiedades Navegacion
        public List<Doctor> Doctores { get; set; }
        #endregion
    }
}
