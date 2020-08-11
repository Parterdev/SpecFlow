using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PruebaUnitariaBuscaminas
{
    [TestClass]
    public class MinesweeperTest
    {
        [TestMethod]
        public void RetornaNombreJugador()
        {
            //Arrange
            var jugador = new GamerName();
            //Act
            var resultado = jugador.Add("Pepito");
            //Assert
            Assert.AreEqual("Pepito", resultado);

        }
    }
}
