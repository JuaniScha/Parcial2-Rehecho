using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Logica;

namespace Servicio.Models
{
    public class EnvioRequest
    {
        public int DNI_Destinatario { get; set; }
        public DateTime FechaEstimada { get; set; }
        public string DescripcionPaquete { get; set; }

        public Envio GenerarEnvio()
        {
            Envio nuevoEnvio = new Envio(this.DNI_Destinatario, this.DescripcionPaquete, this.FechaEstimada);

            return nuevoEnvio;
        }
    }
}