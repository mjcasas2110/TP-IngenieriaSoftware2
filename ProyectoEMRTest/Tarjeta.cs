using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProyectoEMRTest
{
    public class Tarjeta
    {
        public bool MedioBoleto { get; set; }
        public double Saldo { get; set; }
        public static bool Transbordo { get; set; }

        public List<Viaje> viajes { get; set; }

        public Tarjeta(bool MedioBoleto)
        {
            this.MedioBoleto = MedioBoleto;
            Transbordo = true;
            viajes = new List<Viaje>();
        }

        public bool PagarBoleto(Colectivo Colectivo, DateTime FechaHoraViaje)
        {
            if (viajes != null && viajes.Count() > 0)
            {
                var ultimoViaje = viajes.OrderBy(v => v.Fecha.Date).Last();
                TimeSpan diferenciaViajes = FechaHoraViaje - ultimoViaje.Fecha;
                if (ultimoViaje.ColectivoLinea != Colectivo.Linea && diferenciaViajes.TotalMinutes <= 60 && Transbordo)
                {
                    if (MedioBoleto && 6 <= FechaHoraViaje.Hour && FechaHoraViaje.Hour <= 24)
                    {
                        /*Transbordo Medio Boleto*/
                        if (Saldo >= 0.96)
                        {
                            Saldo -= 0.96;
                            Transbordo = false;
                            Viaje viaje = new Viaje(FechaHoraViaje, Colectivo.Linea, Colectivo.Empresa, 0.96);
                            viajes.Add(viaje);
                            return true;
                        }
                        else { return false; }
                    }
                    else
                    {
                        /*Transbordo Comun*/
                        if (Saldo >= 1.90)
                        {
                            Saldo -= 1.90;
                            Transbordo = false;
                            Viaje viaje = new Viaje(FechaHoraViaje, Colectivo.Linea, Colectivo.Empresa, 1.90);
                            viajes.Add(viaje);
                            return true;
                        }
                        else { return false; }
                    }
                }
            }
            if (MedioBoleto && 6 <= FechaHoraViaje.Hour && FechaHoraViaje.Hour <= 24)
            {
                /*Medio Boleto*/
                if (Saldo >= 1.90)
                {
                    Saldo -= 1.90;
                    Transbordo = true;
                    Viaje viaje = new Viaje(FechaHoraViaje, Colectivo.Linea, Colectivo.Empresa, 1.90);
                    viajes.Add(viaje);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                /*Boleto Comun*/
                if (Saldo >= 5.75)
                {
                    Saldo -= 5.75;
                    Transbordo = true;
                    Viaje viaje = new Viaje(FechaHoraViaje, Colectivo.Linea, Colectivo.Empresa, 5.75);
                    viajes.Add(viaje);
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public string ViajesDetalle()
        {
            string lista = "";
            foreach (var viaje in viajes)
            {
                lista += viaje.Fecha.ToString() + " " + viaje.ColectivoLinea + " " + viaje.Monto.ToString() + "\n";
            }
            return lista;
        }

        public int ViajesTotal()
        {
            return viajes.Count();
        }

        public void RecargarSaldo(double Monto)
        {
            if (Monto >= 368)
            {
                Saldo += Monto + 92;
            }
            else
            {
                if (Monto >= 196)
                {
                    Saldo += Monto + 34;
                }
                else
                {
                    Saldo += Monto;
                }
            }
        }
    }
}
