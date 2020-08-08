using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.CommonModels;

namespace SpecFlowProject1.Steps
{
    [Binding]
    public class BuscaminasJuegoSteps
    {
        //Implementacion del webdriver para firefox
        IWebDriver driver = new FirefoxDriver();


        [Given(@"que ingreso al sitio web")]
        public void DadoQueIngresoAlSitioWeb()
        {

            FirefoxDriverService service = FirefoxDriverService.CreateDefaultService(@"C:\Selenium", "geckodriver.exe");
            service.FirefoxBinaryPath = @"C:\Program Files\Mozilla Firefox\firefox.exe";
            driver = new FirefoxDriver(service);

            //App route
            driver.Url = "https://localhost:8081/";
            //Ampliamos la venta del navegador
            driver.Manage().Window.Maximize();
            driver.Navigate();
        }
        
        [When(@"escribo mi nombre de usuario ""(.*)""")]
        public void CuandoRegistroMi(string nombre)
        {
            driver.Url = "https://localhost:8081/login/index";
            //Ampliamos la venta del navegador
            driver.Manage().Window.Maximize();
            driver.Navigate();
            driver.FindElement(By.Name("username")).SendKeys(nombre);
            driver.FindElement(By.Name("username")).SendKeys(nombre + Keys.Enter);
            //driver.FindElement(By.Name("aceptar")).Click();
        }
        
        [Then(@"el juego empieza")]
        public void EntoncesElJuegoEmpieza()
        {
            var dato = driver.FindElement(By.Name("empezar")).GetAttribute("username");
            var esperado = driver.FindElement(By.Name("empezar")).GetAttribute("username").Equals("Pepito");

            //Assert.AreEqual(dato, esperado);
            bool result = dato.Equals(esperado);

            if (result){
                Console.Out.Write("Test aprobado");
                driver.Close();
            }
            else {
                Console.Out.Write("El test ha fallado");
                driver.Close();
            }
        }
    }
}
