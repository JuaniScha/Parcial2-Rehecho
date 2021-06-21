using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class Envio
    {
        public string NroEnvio { get; set; }
        public Persona Destinatario { get; set; }
        public Repartidor Repartidor { get; set; }
        public Estados Estado { get; set; }
        public DateTime FechaEstimada { get; set; }
        public DateTime FechaEntrega { get; set; }
        public string Descripcion { get; set; }

        public Envio(int dni, string descrip, DateTime fechaEstimada)
        {
            Random random = new Random();
            int nro = random.Next(1, 10000);

            this.NroEnvio = Convert.ToString(nro);
            this.Destinatario = Principal.Instancia.ObtenerClientePorDNI(dni);
            this.Estado = Estados.Pendiente;
            this.FechaEstimada = fechaEstimada;
            this.Descripcion = descrip;
        }

        public bool ActualizarEstado(int estado)
        {
            if (this.Estado == (Estados)estado - 1)
            {
                this.Estado = (Estados)estado;
                return true;
            }

            return false;
        }

        public enum Estados
        {
            Pendiente,
            AsignadoRepartidor,
            EnCamino,
            Entregado
        }
    }

}
