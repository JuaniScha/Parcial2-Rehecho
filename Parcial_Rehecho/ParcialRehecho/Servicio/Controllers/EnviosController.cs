using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Logica;
using Servicio.Models;

namespace Servicio.Controllers
{
    public class EnviosController : ApiController
    {
        public IPrincipal principal { get; set; }

        public EnviosController(IPrincipal principal)
        {
            this.principal = principal ?? Principal.Instancia;
        }       

        // GET: api/Envios/5
        public IHttpActionResult Get(string idEnvio)
        {
            //Esto es un PUT no un Get, no deberia estar esta logica aca, sino en la actualizacion de envío
            Resultado resultado = principal.AsignarRepartidorEnvio(idEnvio);

            if (resultado.Ok)
            {
                Envio envio = principal.ObtenerEnvioPorID(resultado.Codigo);
                Repartidor repartidorAsignado = envio.Repartidor;

                return Content(HttpStatusCode.OK, repartidorAsignado);
            }

            return Content(HttpStatusCode.NotFound, resultado.Error);
        }

        // POST: api/Envios
        public IHttpActionResult Post([FromBody]EnvioRequest request)
        {
            Envio envio = request.GenerarEnvio();
            Resultado resultado = principal.CargarNuevoEnvio(envio);
            if (resultado.Ok)
            {
                Envio envioCreado = principal.ObtenerEnvioPorID(resultado.Codigo);
                EnvioResponse response = new EnvioResponse(envioCreado);

                return Content(HttpStatusCode.Created, response.Respuesta);
            }

            return Content(HttpStatusCode.BadRequest, resultado.Error);
        }

        // PUT: api/Envios/5
        public IHttpActionResult Put(string id, [FromBody]int estado)
        {
            Resultado resultado = principal.ActualizarEnvio(id, estado);

            if (resultado.Ok)
                return Content(HttpStatusCode.OK, "Actualizado");

            return Content(HttpStatusCode.NotFound, resultado.Error);
        }
    }
}
