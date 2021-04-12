using Luisde_Prestamos_Cd.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Luisde_Prestamos_Cd.ViewModels
{
    public class DetalleAlquileresViewModels
    {
        public int Id { get; set; }
        public string Item { get; set; }
        public int CodigoTitulo { get; set; }
        public string DiasPrestamo { get; set; }
        public DateTime FechaDevolucion { get; set; }
        public int AlquilerId { get; set; }
        public Alquileres Alquiler { get; set; }
        public int CdId { get; set; }
        public Cds Cd { get; set; }
    }
}
