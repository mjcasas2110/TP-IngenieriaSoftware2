using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProyectoEMR
{
    public class Colectivo
    {
        public string Linea { get; set; }
        public string Empresa { get; set; }
        public int NumeroInterno { get; set; }

        public Colectivo(string Linea, string Empresa, int NumeroInterno)
        {
            this.Linea = Linea;
            this.Empresa = Empresa;
            this.NumeroInterno = NumeroInterno;
        }
    }
}
