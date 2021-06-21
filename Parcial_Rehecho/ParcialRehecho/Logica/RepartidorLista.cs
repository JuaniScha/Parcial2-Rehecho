using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class RepartidorLista
    {
        public string NombreApellido { get; set; }
        public double TotalGanadoComisiones { get; set; } //solamente sumo los porcentajes xq nunca se recibe un costo de envío
        public int EnviosRealizados { get; set; }
    }
}
