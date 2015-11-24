using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoEMR
{
    class Program
    {
        static void Main(string[] args)
        {
            Colectivo colectivo1 = new Colectivo("142", "Semtur", 1);
            Colectivo colectivo2 = new Colectivo("143", "Mixta", 1);
            Colectivo colectivo3 = new Colectivo("144", "Mixta", 1);

            Tarjeta tarjeta1 = new Tarjeta(false);
            Tarjeta tarjeta2 = new Tarjeta(true);

            Console.WriteLine("---------TARJETA 1---------");
            tarjeta1.RecargarSaldo(368);
            Console.WriteLine("Saldo: " + tarjeta1.Saldo);
            tarjeta1.RecargarSaldo(196);
            Console.WriteLine("Saldo: " + tarjeta1.Saldo);
            tarjeta1.RecargarSaldo(5);
            Console.WriteLine("Saldo: " + tarjeta1.Saldo);
            Console.WriteLine(": " + tarjeta1.PagarBoleto(colectivo1, DateTime.Now.AddHours(-8)));
            Console.WriteLine(": " + tarjeta1.PagarBoleto(colectivo1, DateTime.Now.AddHours(-2)));
            Console.WriteLine(": " + tarjeta1.PagarBoleto(colectivo2, DateTime.Now.AddMinutes(-30)));
            Console.WriteLine(": " + tarjeta1.PagarBoleto(colectivo3, DateTime.Now.AddMinutes(-10)));
            Console.WriteLine(": " + tarjeta1.PagarBoleto(colectivo1, DateTime.Now));
            Console.WriteLine(tarjeta1.ViajesDetalle());
            Console.WriteLine(tarjeta1.ViajesTotal());
            Console.WriteLine("Saldo: " + tarjeta1.Saldo);

            Console.WriteLine("---------TARJETA 2---------");
            tarjeta2.RecargarSaldo(368);
            Console.WriteLine("Saldo: " + tarjeta2.Saldo);
            tarjeta2.RecargarSaldo(196);
            Console.WriteLine("Saldo: " + tarjeta2.Saldo);
            tarjeta2.RecargarSaldo(5);
            Console.WriteLine("Saldo: " + tarjeta2.Saldo);
            Console.WriteLine(": " + tarjeta2.PagarBoleto(colectivo1, DateTime.Now.AddHours(-8)));
            Console.WriteLine(": " + tarjeta2.PagarBoleto(colectivo1, DateTime.Now.AddHours(-2)));
            Console.WriteLine(": " + tarjeta2.PagarBoleto(colectivo2, DateTime.Now.AddMinutes(-30)));
            Console.WriteLine(": " + tarjeta2.PagarBoleto(colectivo3, DateTime.Now.AddMinutes(-10)));
            Console.WriteLine(": " + tarjeta2.PagarBoleto(colectivo1, DateTime.Now));
            Console.WriteLine(tarjeta2.ViajesDetalle());
            Console.WriteLine(tarjeta1.ViajesTotal());
            Console.WriteLine("Saldo: " + tarjeta2.Saldo);

            Console.ReadKey();
        }
    }
}
