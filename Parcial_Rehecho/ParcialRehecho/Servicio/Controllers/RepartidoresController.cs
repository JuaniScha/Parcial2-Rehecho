using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Logica;

namespace Servicio.Controllers
{
    public class RepartidoresController : ApiController
    {
        public IHttpActionResult Get(DateTime desde, DateTime hasta)
        {
            List<RepartidorLista> lista = Principal.Instancia.ObtenerListaEntreFechas(desde, hasta);

            return Content(HttpStatusCode.OK, lista);
        }
    }
}
