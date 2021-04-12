using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Luisde_Prestamos_Cd.ViewModels
{
    public class ClientesViewModels
    {
        public int Id { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Nombre { get; set; }
        public string Correo { get; set; }
        public int NroDNI { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public DateTime FechaInscripcion { get; set; }
        public string TemaInteres { get; set; }
        public bool Estado { get; set; }

    }
}
