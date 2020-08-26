using OpenQA.Selenium;
using NUnit.Framework;
using OpenQA.Selenium.Firefox;
using SpecFlowProject1.Pages;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace SpecFlowProject1.Steps
{
    [Binding]
    public class InicioDeSesionSteps
    {
        //Utilizamos los elementos de la clase LoginPage
        LoginPage loginPage = null;

        //Inicializamos el servicio de navegacion web
        IWebDriver webDriver = new FirefoxDriver();

        [Given(@"que ingreso al sitio web de Facebook")]
        public void DadoQueIngresoAlSitioWebDeFacebook()
        {
            webDriver.Navigate().GoToUrl("https://www.facebook.com/");
            //Ampliamos toda la ventana
            webDriver.Manage().Window.Maximize();

            loginPage = new LoginPage(webDriver);

        }
        
        [Given(@"pongo los siguientes detalles")]
        public void DadoPongoLosSiguientesDetalles(Table table)
        {
            /**Creamos una instancia de objecto dinamico 
             * para leer el dato recibido**/
            dynamic values = table.CreateDynamicInstance();

            //Llamamos al metodo de login pasando los parametros
            loginPage.Login((string)values.username, (string)values.password); //Casteamos los datos a string
        }
        
        [Given(@"le doy click en el botón Entrar")]
        public void DadoLeDoyClickEnElBotonIniciarSesion()
        {
            //Llamado a la funcion para iniciar sesion
            loginPage.LoginClickButton();
        }
        
        [Then(@"podré ver mi nombre de perfil")]
        public void EntoncesPodreVerDatosDeMiPerfil()
        {
            webDriver.Navigate().GoToUrl("https://www.facebook.com/Parter28");
            loginPage = new LoginPage(webDriver);

            //Assert
            Assert.That(loginPage.IsProfileNameExist(), Is.True);
        }
    }
}
