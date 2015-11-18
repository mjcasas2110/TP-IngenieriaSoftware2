using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProyectoEMR
{
    public class Viaje
    {
        public DateTime Fecha { get; set; }
        public string ColectivoLinea { get; set; }
        public string ColectivoEmpresa { get; set; }
        public double Monto { get; set; }

        public Viaje(DateTime Fecha, string ColectivoLinea, string ColectivoEmpresa, double Monto)
        {
            this.Fecha = Fecha;
            this.ColectivoLinea = ColectivoLinea;
            this.ColectivoEmpresa = ColectivoEmpresa;
            this.Monto = Monto;
        }
    }
}
