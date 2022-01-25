using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System.Threading;
using OpenQA.Selenium.Support.UI;
using System;


namespace UITestSelenium.WebDriver.PeopleContext
{
    [TestClass]
    public class Selenium
    {
        IWebDriver driver;

        [TestCleanup]
        public void TearDown()
        {
            if (driver != null)
                driver.Quit();
        }

        [TestMethod]
        public void PruebaIngresoChrome()
        {
            ///Arrange
            /// Crea el driver de Chrome
            driver = new ChromeDriver();
            PruebaIngreso();
        }

        [TestMethod]
        public void PruebaIngresoFirefox()
        {
            ///Arrange
            /// Crea el driver de Firefox
            var options = new FirefoxOptions
            {
                AcceptInsecureCertificates = true
            };
            driver = new FirefoxDriver(options);
            PruebaIngreso();
        }
        private void PruebaIngreso()
        {
            ///Arrange
            /// Pone la pantalla en full screen
            driver.Manage().Window.Maximize();
            ///Act
            /// Se va a la URL de la aplicacion
            driver.Url = "https://localhost:44331/";
            ///Assert
            ///Assert.AreEqual(driver.FindElement(By.XPath("//")).Text, "ASP.NET");
        }

      
        [TestMethod]
        public void CheckIfRegisterButtonIsDisabled()
        {
            //arrange
            driver = new ChromeDriver();
            driver.Url = "https://localhost:44331/register";
            IWebElement registerButton = driver.FindElement(By.Id("registerButton"));
            //act
            var en = registerButton.Enabled;
            //assert
            Assert.AreEqual(en, false);
        }

        [TestMethod]
        public void CheckIfRegisterButtonIsEnabled()
        {
            //arrange
            driver = new ChromeDriver();
            driver.Url = "https://localhost:44331/register";
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(3));
            IWebElement Name = wait.Until(e => e.FindElement(By.Id("Nombre")));
            IWebElement FirstLastName = wait.Until(e => e.FindElement(By.Id("Primer Apellido")));
            IWebElement SecondLastName = wait.Until(e => e.FindElement(By.Id("Segundo Apellido")));
            IWebElement Desc = wait.Until(e => e.FindElement(By.Id("Descripción")));
            IWebElement Title = wait.Until(e => e.FindElement(By.Id("Titular")));
            IWebElement Grade = wait.Until(e => e.FindElement(By.Id("Grado Académico")));
            IWebElement Country = wait.Until(e => e.FindElement(By.Id("País")));
            IWebElement Uni = wait.Until(e => e.FindElement(By.Id("Universidad Principal")));
            IWebElement Email = wait.Until(e => e.FindElement(By.Id("Email")));
            IWebElement Password = wait.Until(e => e.FindElement(By.Id("Contraseña")));
            IWebElement ConfirmedPass = wait.Until(e => e.FindElement(By.Id("Contraseña2")));
            //act
            Name.SendKeys("Nombre");
            FirstLastName.SendKeys("Apellido1");
            SecondLastName.SendKeys("Apellido2");
            Desc.SendKeys("Biografia");
            Title.SendKeys("Titulo");
            Grade.SendKeys("Grado");
            Country.SendKeys("CR");
            Uni.SendKeys("UCR");
            Email.SendKeys("test@gmail.com");
            Password.SendKeys("Contrasena12.");
            ConfirmedPass.SendKeys("Contrasena12.");
            Thread.Sleep(350);
            IWebElement registerButton = driver.FindElement(By.Id("registerButton"));
            var en = registerButton.Enabled;
            //assert
            Assert.AreEqual(en, true);
        }

        [TestMethod]
        public void IncorrectLoginTest() {
            //arrange
            var options = new FirefoxOptions
            {
                AcceptInsecureCertificates = true
            };
            driver = new FirefoxDriver(options);
            driver.Url = "https://localhost:44331/signin";
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(3));
            IWebElement emailEntry = wait.Until(e => e.FindElement(By.Id("EmailField")));
            IWebElement passwordEntry = wait.Until(e => e.FindElement(By.Id("PasswordField")));
            IWebElement loginButton = wait.Until(e => e.FindElement(By.Id("Login")));
            
            //act
            emailEntry.SendKeys("abc@gmail.com");
            passwordEntry.SendKeys("Contrasena12.");
            Thread.Sleep(350);
            loginButton.Click();

            //assert
            driver.Url.Contains("signin");

        }

        [TestMethod]
        public void SeeAllPeopleFromGroupButtonWorking()
        {
            driver = new FirefoxDriver();
            driver.Url = "https://localhost:44331/grupos/1";
            IWebElement viewPeopleButton = driver.FindElement(By.Name("VER TODAS LAS PERSONAS"));
            //act
            viewPeopleButton.Click();
            //assert
            driver.Url.Contains("personas");
        }

        [TestMethod]
        public void GotoInAcademicProfile()
        {
            //arrange
            driver = new ChromeDriver();
            driver.Url = "https://localhost:44331/signin";
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(3));
            IWebElement Email = wait.Until(e => e.FindElement(By.Id("EmailField")));
            IWebElement Password = wait.Until(e => e.FindElement(By.Id("PasswordField")));
            Email.SendKeys("carlos.moramembreno@ucr.ac.cr");
            Password.SendKeys("Cmm.1997");
            IWebElement logIn = driver.FindElement(By.Id("Login"));
            logIn.Click();      
            Thread.Sleep(1000);

            //act
            driver.Url = "https://localhost:44331/EditProfile/CfDJ8MeHLRdeuQlCn0YJYWKAOQZDyf8hi7l8K4E810w8HiF5MBgKAxx_wxj2V7YXWWi0ikinRHj2YaU10iGnq23AgQVGseSwE1hgEXYCLrJRDZEGPZmLdg5XGCxXpuaeBNpACdwoljT_p_8TmOKAxMpT92g";

            //assert
            driver.Url.Contains("EditProfile");
        }



    }
} 
        
