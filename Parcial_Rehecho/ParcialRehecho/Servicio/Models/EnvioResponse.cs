using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Logica;

namespace Servicio.Models
{
    public class EnvioResponse
    {
        public string Respuesta { get; set; }

        public EnvioResponse(Envio envio)
        {
            this.Respuesta = $"Nro. envío: {envio.NroEnvio}";
        }
    }
}