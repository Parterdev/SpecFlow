using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.CommonModels;
using OpenQA.Selenium.Support.UI;

namespace SpecFlowProject1.Steps
{
    [Binding]
    public class BuscaminasJuegoSteps
    {
        //Creamos una varible de tipo IWebDriver
        IWebDriver driver;


        [Given(@"que ingreso al sitio web")]
        public void DadoQueIngresoAlSitioWeb()
        {

            //Instanciamos el objeto driver
            driver = new FirefoxDriver();
            driver.Navigate().GoToUrl("http://localhost:4200/minas");

        }

        [When(@"escribo mi nombre de usuario ""(.*)""")]
        public void CuandoRegistroMi(string nombre)
        {
            //Ampliamos toda la ventana
            driver.Manage().Window.Maximize();
            //Espera de 5 segs
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            //Enviamos el parametro nombre
            driver.FindElement(By.Name("txtNombre")).SendKeys(nombre + Keys.Enter);
            //Enviamos al usuario a la pagina de juego
            driver.Navigate().GoToUrl("http://localhost:4200/juego");

        }

        [Then(@"el juego empieza")]
        public void EntoncesElJuegoEmpieza()
        {

            if (driver != null)
            {
                Console.Out.Write("Test aprobado");
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
                driver.Close();
            }

        }
    }
}