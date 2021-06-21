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
        public double Costo { get; set; }

        //Usar nombres de variables descriptivos (puede ser "descripcion"
        public Envio(int dni, string descrip, DateTime fechaEstimada)
        {
            Random random = new Random();
            int nro = random.Next(1, 10000);

            this.NroEnvio = Convert.ToString(nro);
            //No esta bueno esto, si el cliente no existe, seguirias construyendo el objeto Envio.
            //En vez de tenerlo aca, podrias tener un metodo "CrearEnvio" en principal, que valide el destinatario y luego cree
            //la instancia Envio
            this.Destinatario = Principal.Instancia.ObtenerClientePorDNI(dni);
            this.Estado = Estados.Pendiente;
            this.FechaEstimada = fechaEstimada;
            this.Descripcion = descrip;
        }

        //Se puede usar el enum como parametro y no un entero, es mas facil la validacion
        //Falta validar que si el estado actual es 1, el nuevo solo puede ser 2, si es 2, solo puede ser 3 y asi.
        public bool ActualizarEstado(int estado)
        {
            if (this.Estado == (Estados)estado - 1)
            {
                this.Estado = (Estados)estado;
                if (estado == (int)Estados.Entregado)
                {
                    this.FechaEntrega = DateTime.Now;
                    //La comision puede ser un dato del envio, no del repartidor, porq depende del porcentaje del repartidor, y del costo del envio.
                    this.Repartidor.ComisionGanada = this.Costo * this.Repartidor.PorcentajeComision;
                }
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
