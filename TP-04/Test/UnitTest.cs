using System;
using Entidades;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void ListaInstanciada()
        {
            Correo correo = new Correo();

            Assert.IsNotNull(correo.Paquetes);
        }

        [TestMethod]
        [ExpectedException(typeof(TrackingIdRepetidoException))]
        public void PaqueteRepetido()
        {
            Correo correo = new Correo();
            Paquete paq1 = new Paquete("Chile 757", "147-258-685");
            Paquete paq2 = new Paquete("Austria 1589", "147-258-685");

            correo += paq1;
            correo += paq2;

            Assert.Fail();
        }

    }
}
