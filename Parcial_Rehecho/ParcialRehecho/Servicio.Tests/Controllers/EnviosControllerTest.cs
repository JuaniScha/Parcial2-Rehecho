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

namespace Servicio.Tests.Controllers
{
    [TestClass]
    public class EnviosControllerTest
    {
        [TestMethod]
        public void Put()
        {
            // Disponer
            EnviosController controller = new EnviosController();
            var mock = new Mock<Principal>();
            mock.Setup(x => x.ActualizarEnvio("5555", 3)).Returns(new Resultado(true, "Error"));

            // Actuar
            controller.Put("5555",3);

            // Declarar
            //Assert.AreEqual()                     No se como hacer la comprobacion, porque el servicio devuelve los HttsStatusCode.
        }
    }
}
