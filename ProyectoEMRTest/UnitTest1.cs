using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ProyectoEMRTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void MedioBoleto()
        {
            Colectivo colectivo1 = new Colectivo("142", "Semtur", 1);
            Colectivo colectivo2 = new Colectivo("143", "Mixta", 1);
            Colectivo colectivo3 = new Colectivo("144", "Mixta", 1);

            Tarjeta tarjeta1 = new Tarjeta(false);
            Tarjeta tarjeta2 = new Tarjeta(true);

            Assert.AreEqual(false, tarjeta1.MedioBoleto);
            Assert.AreEqual(true, tarjeta2.MedioBoleto);
        }

        [TestMethod]
        public void Recarga()
        {
            Tarjeta tarjeta1 = new Tarjeta(true);

            tarjeta1.RecargarSaldo(5);
            Assert.AreEqual(5, tarjeta1.Saldo);

            tarjeta1.Saldo = 0;
            tarjeta1.RecargarSaldo(196);
            Assert.AreEqual(230, tarjeta1.Saldo);

            tarjeta1.Saldo = 0;
            tarjeta1.RecargarSaldo(368);
            Assert.AreEqual(460, tarjeta1.Saldo);
        }

        [TestMethod]
        public void PagarBoletoComun()
        {
            Colectivo colectivo1 = new Colectivo("142", "Semtur", 1);
            Colectivo colectivo2 = new Colectivo("143", "Mixta", 1);
            Colectivo colectivo3 = new Colectivo("144", "Mixta", 1);

            Tarjeta tarjeta1 = new Tarjeta(false);
            Tarjeta tarjeta2 = new Tarjeta(true);
            
            //Tarjeta 1
            //Viaje no concretado por falta de fondos
            Assert.AreEqual(false, tarjeta1.PagarBoleto(colectivo1, DateTime.Now.AddHours(-8)));
            tarjeta1.RecargarSaldo(200);
            //Boleto comun
            Assert.AreEqual(true,tarjeta1.PagarBoleto(colectivo1, DateTime.Now.AddHours(-2)));
            Assert.AreEqual(228.25, tarjeta1.Saldo);
            //Boleto comun
            Assert.AreEqual(true,tarjeta1.PagarBoleto(colectivo2, DateTime.Now.AddMinutes(-30)));
            Assert.AreEqual(222.5, tarjeta1.Saldo);
            //Transbordo comun (diferente colectivo en menos de una hora)
            Assert.AreEqual(true,tarjeta1.PagarBoleto(colectivo3, DateTime.Now.AddMinutes(-10)));
            Assert.AreEqual(220.6, tarjeta1.Saldo);
            //Boleto comun (diferente colectivo en menos de una hora pero con transbordo ya usado)
            Assert.AreEqual(true,tarjeta1.PagarBoleto(colectivo1, DateTime.Now.AddMinutes(-1)));
            Assert.AreEqual(214.85, tarjeta1.Saldo);
            //Boleto comun (mismo colectivo en menos de una hora)
            Assert.AreEqual(true,tarjeta1.PagarBoleto(colectivo1, DateTime.Now));
            Assert.AreEqual(209.1, tarjeta1.Saldo);

            Assert.AreEqual(5, tarjeta1.ViajesTotal());
        }

        [TestMethod]
        public void PagarMedioBoleto()
        {
            Colectivo colectivo1 = new Colectivo("142", "Semtur", 1);
            Colectivo colectivo2 = new Colectivo("143", "Mixta", 1);
            Colectivo colectivo3 = new Colectivo("144", "Mixta", 1);

            Tarjeta tarjeta1 = new Tarjeta(false);
            Tarjeta tarjeta2 = new Tarjeta(true);

            var temprano = new DateTime(2015, 11, 24, 3, 0, 0);

            //Tarjeta 2
            //Viaje no concretado por falta de fondos
            Assert.AreEqual(false, tarjeta2.PagarBoleto(colectivo1, DateTime.Now.AddHours(-8)));
            //
            tarjeta2.RecargarSaldo(200);
            //Medio Boleto
            Assert.AreEqual(true, tarjeta2.PagarBoleto(colectivo1, temprano));
            Assert.AreEqual(228.25, tarjeta2.Saldo);
            //Medio Boleto
            Assert.AreEqual(true, tarjeta2.PagarBoleto(colectivo1, DateTime.Now.AddHours(-2)));
            Assert.AreEqual(226.35, tarjeta2.Saldo);
            //Transbordo medio boleto
            Assert.AreEqual(true, tarjeta2.PagarBoleto(colectivo2, DateTime.Now.AddHours(-2)));
            Assert.AreEqual(225.39, tarjeta2.Saldo);
            //Medio Boleto (diferente colectivo en menos de una hora pero con transbordo ya usado)
            Assert.AreEqual(true, tarjeta2.PagarBoleto(colectivo3, DateTime.Now.AddHours(-1).AddMinutes(-30)));
            Assert.AreEqual((decimal)223.49, (decimal)tarjeta2.Saldo);
            //Medio Boleto (mismo colectivo en menos de una hora)
            Assert.AreEqual(true, tarjeta2.PagarBoleto(colectivo3, DateTime.Now.AddHours(-1)));
            Assert.AreEqual((decimal)221.59, (decimal)tarjeta2.Saldo);

            Assert.AreEqual(5, tarjeta2.ViajesTotal());
        }
    }
}
