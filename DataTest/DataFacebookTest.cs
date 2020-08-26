using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
//Paquete Excel de interoperabilidad de Microsoft Office
using excel = Microsoft.Office.Interop.Excel;

namespace DataTest
{
    [TestClass]
    public class DataFacebookTest
    {
        [TestMethod]
        public void LoginDataTest()
        {
            //Objeto para clase de excel
            excel.Application x = new excel.Application();
            //Objeto para la clase Libro de trabajo y ruta de la hoja de calculo
            excel.Workbook y = x.Workbooks.Open(@"D:\data_login.xlsx");
            //Var par ala hoja de trabajo de donde obtendremos datos
            excel._Worksheet x1WorkSheet = y.Sheets[1];
            //Var range para obtener el rango de la hoja de trabajo
            excel.Range valueRange = x1WorkSheet.UsedRange;
            //Recuento del rango
            int totalCount = valueRange.Count;
            

            //Inicializamos el driver
            IWebDriver driver = new FirefoxDriver();
            driver.Navigate().GoToUrl("https://www.facebook.com/");
            //Ampliamos toda la ventana
            driver.Manage().Window.Maximize();

        
            //Accedemos a filas y columnas de las celdas en hoja de calculo
            for (int i = 2; i <= valueRange.Count; i++)
            {
                //Params
                string userName = valueRange.Cells[1][i].value2;
                string userPassword = valueRange.Cells[2][i].value2;

                //Enviamos los parametros
                driver.FindElement(By.Name("email")).SendKeys(userName);
                driver.FindElement(By.Name("pass")).SendKeys(userPassword);
                //Submit
                driver.FindElement(By.Name("login")).Submit();
                //Go to profile
                driver.Navigate().GoToUrl("UserProfile");
                //Read data
               
                //Assert.AreEqual(esperado, dado);
                driver.Quit();

            }
        }
    }
}
