using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Luisde_Prestamos_Cd.ViewModels
{
    public class CdViewModels
    {
        public int Id { get; set; }
        public int CodigoTitulo { get; set; }
        public int NoCd { get; set; }
        public string Condicion { get; set; }
        public string Ubicacion { get; set; }
        public bool Estado { get; set; }
    }
}
