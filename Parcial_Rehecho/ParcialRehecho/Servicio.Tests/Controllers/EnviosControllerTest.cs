using Microsoft.VisualStudio.TestTools.UnitTesting;
using Servicio;
using Servicio.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using Logica;
using Moq;
using System.Web.Http.Results;

namespace Servicio.Tests.Controllers
{
    [TestClass]
    public class EnviosControllerTest
    {
        [TestMethod]
        public void Put()
        {
            // Disponer            
            var mock = new Mock<IPrincipal>(); //USar la interface para mockear
            EnviosController controller = new EnviosController(mock.Object); //crear el controller pasando el Object mockeado para que tome la logica que queres.
            mock.Setup(x => x.ActualizarEnvio("5555", 3)).Returns(new Resultado(true, "Error"));

            // Actuar
            //Fijate  el tipo de datos que retorna el metodo "Content", y asi podes parsear la respuesta de interface en un objeto y validar la respuesta final.
            NegotiatedContentResult<string> httpActionResult = (NegotiatedContentResult<string>)controller.Put("5555",3);

            // Declarar
            Assert.AreEqual(httpActionResult.StatusCode, System.Net.HttpStatusCode.OK);

            //ESTE ES EL TEST QUE DEBERIA ESTAR, PERO FALLA, PORQ TENES MAL EL MOCK (RETORNAS TRUE, Y ESO HACE QUE CAMBIE EL MENSAJE)
            //ACA PODES VER SI REALMENTE ESTA MAL EL MOCK O EL CODIGO. EN ESTE CASO EL MOCK (SI ES TRUE, NO IMPORTA EL 2DO PARAM DE RESULTADO, 
            //HAY QUE VALIDAR QUE CONTENT == "Actualizado"
            //Assert.AreEqual(httpActionResult.Content, "Error");            
        }
    }
}
