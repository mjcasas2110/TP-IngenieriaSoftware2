#if NUNIT
using TestClass = NUnit.Framework.TestFixtureAttribute;
using TestMethod = NUnit.Framework.TestAttribute;
using TestCleanup = NUnit.Framework.TearDownAttribute;
using TestInitialize = NUnit.Framework.SetUpAttribute;
using ClassCleanup = NUnit.Framework.TestFixtureTearDownAttribute;
using ClassInitialize = NUnit.Framework.TestFixtureSetUpAttribute;
#else
using Microsoft.VisualStudio.TestTools.UnitTesting;
#endif
using MsAssert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProyectoEMRTest
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
