using Luisde_Prestamos_Cd.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Luisde_Prestamos_Cd.ViewModels
{
    public class AlquileresViewModels
    {
        public int Id { get; set; }
        public int noAlquiler { get; set; }
        public int codigoCliente { get; set; }
        public DateTime fechaAlquiler { get; set; }
        public double valorAlquiler { get; set; }
        public int ClienteId { get; set; }
        public Clientes Cliente { get; set; }

    }
}
