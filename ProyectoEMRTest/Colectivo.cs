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
