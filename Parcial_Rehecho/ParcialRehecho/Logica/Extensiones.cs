using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public static class Extensiones
    {
        public static double ObtenerDistanciaEntrePuntos(this Envio envio, Repartidor repartidor)
        {
            Persona destinatario = envio.Destinatario;
            double EarthRadius = 6371;
            double distance = 0;
            double Lat = (repartidor.Latitud - destinatario.Latitud) * (Math.PI / 180);
            double Lon = (repartidor.Longitud - destinatario.Longitud) * (Math.PI / 180);
            double a = Math.Sin(Lat / 2) * Math.Sin(Lat / 2) + Math.Cos(destinatario.Latitud * (Math.PI / 180)) * Math.Cos(repartidor.Latitud * (Math.PI / 180)) * Math.Sin(Lon / 2) * Math.Sin(Lon / 2);
            double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
            distance = EarthRadius * c;

            return distance;
        }
    }
}
