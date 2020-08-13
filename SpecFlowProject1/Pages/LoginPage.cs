using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace SpecFlowProject1.Pages
{
    public class LoginPage
    {
        public IWebDriver WebDriver { get; }

        //Inicializamos el constructor
        public LoginPage(IWebDriver webDriver)
        {
            WebDriver = webDriver;
        }

        /** Elementos de la pagina inicial **/
        //Campos del formulario de login
        public IWebElement inputUserName => WebDriver.FindElement(By.Name("email"));
        public IWebElement inputUserPassword => WebDriver.FindElement(By.Name("pass"));
        //Btn login
        public IWebElement buttonLogin => WebDriver.FindElement(By.Name("login"));
        //Nombre del perfil
        public IWebElement ProfileNameText => WebDriver.FindElement(By.LinkText("ProfileName"));


        //Metodo para login username and password
        public void Login(string userName, string userPassword)
        {
            //Enviamos los parametros
            inputUserName.SendKeys(userName);
            inputUserPassword.SendKeys(userPassword);
        }

        //Hacemos un submit de los datos ingresados
        public void LoginClickButton() => buttonLogin.Submit();

        //Verificamos si el texto Panel central existe
        public bool IsProfileNameExist() => ProfileNameText.Displayed;

    }
}
