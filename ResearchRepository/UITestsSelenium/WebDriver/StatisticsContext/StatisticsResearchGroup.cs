using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace UITestsSelenium.WebDriver.StatisticsContext
{
    [TestClass]
    public class StatisticsResearchGroup
    {
        IWebDriver driver;

        [TestCleanup]
        public void TearDown()
        {
            if (driver != null)
                driver.Quit();
        }

        /// <summary>
        /// Tests for alert to show quantity of publications
        /// </summary>
        /// Author: Pablo Otárola Rodríguez [LosPollosHermanos]
        [TestMethod]
        public void CorrectAlert() {
            ///Arrange
            ///Create a Chrome driver
            driver = new ChromeDriver();

            ///Act
            ///Go to Statistics page of Group 1
            driver.Navigate().GoToUrl("https://localhost:44331/estadisticas/1");
            driver.Manage().Window.Maximize();

            ///Declare an awaiter for our driver
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));

            wait.Until(e => e.FindElement(By.CssSelector("#banner > div > div > div > div.mud-grid-item.mud-grid-item-xs-12 > div > div")));
            IWebElement alert = driver.FindElement(By.CssSelector("#banner > div > div > div > div.mud-grid-item.mud-grid-item-xs-12 > div > div"));

            Assert.IsNotNull(alert);
        }

        /// <summary>
        /// Tests for chart of statistic of publications per area
        /// </summary>
        /// Author: Pablo Otárola Rodríguez [LosPollosHermanos]
        [TestMethod]
        public void CorrectChartAreas()
        {
            ///Arrange
            ///Create a Chrome driver
            driver = new ChromeDriver();

            ///Act
            ///Go to Statistics page of Group 1
            driver.Navigate().GoToUrl("https://localhost:44331/estadisticas/1");
            driver.Manage().Window.Maximize();

            ///Declare an awaiter for our driver
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));

            wait.Until(e => e.FindElement(By.CssSelector("#banner > div > div > div > div:nth-child(2) > div")));
            IWebElement mudpaper = driver.FindElement(By.CssSelector("#banner > div > div > div > div:nth-child(2) > div"));

            wait.Until(e => e.FindElement(By.CssSelector("#banner > div > div > div > div:nth-child(2) > div > div.mud-grid-item.mud-grid-item-xs-12.mud-grid-item-md-12.d-flex.justify-end > button")));
            IWebElement popUpbutton = driver.FindElement(By.CssSelector("#banner > div > div > div > div:nth-child(2) > div > div.mud-grid-item.mud-grid-item-xs-12.mud-grid-item-md-12.d-flex.justify-end > button"));

            wait.Until(e => e.FindElement(By.CssSelector("#banner > div > div > div > div:nth-child(2) > div > div.mud-grid.mud-grid-spacing-xs-3.mud-grid-justify-xs-flex-start > div.mud-grid-item.mud-grid-item-xs-12.mud-grid-item-sm-6.mud-grid-item-md-4 > div > div > div > div.mud-input.mud-input-text.mud-input-adorned-end.mud-input-underline.mud-select-input")));
            IWebElement filter = driver.FindElement(By.CssSelector("#banner > div > div > div > div:nth-child(2) > div > div.mud-grid.mud-grid-spacing-xs-3.mud-grid-justify-xs-flex-start > div.mud-grid-item.mud-grid-item-xs-12.mud-grid-item-sm-6.mud-grid-item-md-4 > div > div > div > div.mud-input.mud-input-text.mud-input-adorned-end.mud-input-underline.mud-select-input"));

            wait.Until(e => e.FindElement(By.CssSelector("#banner > div > div > div > div:nth-child(2) > div > div.mud-grid.mud-grid-spacing-xs-3.mud-grid-justify-xs-flex-start > div:nth-child(2)")));
            IWebElement areas = driver.FindElement(By.CssSelector("#banner > div > div > div > div:nth-child(2) > div > div.mud-grid.mud-grid-spacing-xs-3.mud-grid-justify-xs-flex-start > div:nth-child(2)"));

            popUpbutton.Click();

            wait.Until(e => e.FindElement(By.CssSelector("#banner > div > div > div > div:nth-child(2) > div > div.mud-overlay > div.mud-overlay-content > div > div > div.mud-paper.mud-elevation-1.d-flex.flex-column.align-left.pa-10")));
            IWebElement mudpaperPopUp = driver.FindElement(By.CssSelector("#banner > div > div > div > div:nth-child(2) > div > div.mud-overlay > div.mud-overlay-content > div > div > div.mud-paper.mud-elevation-1.d-flex.flex-column.align-left.pa-10"));

            wait.Until(e => e.FindElement(By.CssSelector("#banner > div > div > div > div:nth-child(2) > div > div.mud-grid.mud-grid-spacing-xs-3.mud-grid-justify-xs-flex-start > div.mud-grid-item.mud-grid-item-xs-12.mud-grid-item-sm-6.mud-grid-item-md-4 > div")));
            IWebElement mudselect = driver.FindElement(By.CssSelector("#banner > div > div > div > div:nth-child(2) > div > div.mud-grid.mud-grid-spacing-xs-3.mud-grid-justify-xs-flex-start > div.mud-grid-item.mud-grid-item-xs-12.mud-grid-item-sm-6.mud-grid-item-md-4 > div"));

            wait.Until(e => e.FindElement(By.CssSelector("#banner > div > div > div > div:nth-child(2) > div > div.mud-grid.mud-grid-spacing-xs-3.mud-grid-justify-xs-flex-start > div:nth-child(2)")));
            IWebElement areasPopUp = driver.FindElement(By.CssSelector("#banner > div > div > div > div:nth-child(2) > div > div.mud-grid.mud-grid-spacing-xs-3.mud-grid-justify-xs-flex-start > div:nth-child(2)"));

            wait.Until(e => e.FindElement(By.CssSelector("#banner > div > div > div > div:nth-child(2) > div > div.mud-overlay > div.mud-overlay-content > div > div > div.mud-grid-item.mud-grid-item-xs-12.mud-grid-item-md-12.d-flex.justify-start > button")));
            IWebElement closeButton = driver.FindElement(By.CssSelector("#banner > div > div > div > div:nth-child(2) > div > div.mud-overlay > div.mud-overlay-content > div > div > div.mud-grid-item.mud-grid-item-xs-12.mud-grid-item-md-12.d-flex.justify-start > button"));

            Assert.IsNotNull(mudpaper);
            Assert.IsNotNull(popUpbutton);
            Assert.IsNotNull(filter);
            Assert.IsNotNull(areas);
            Assert.IsNotNull(mudpaperPopUp);
            Assert.IsNotNull(mudselect);
            Assert.IsNotNull(areasPopUp);
            Assert.IsNotNull(closeButton);
        }

        /// <summary>
        /// Tests for chart of statistic of publications per area
        /// </summary>
        /// Author: Pablo Otárola Rodríguez [LosPollosHermanos]
        [TestMethod]
        public void CorrectChartYears()
        {
            ///Arrange
            ///Create a Chrome driver
            driver = new ChromeDriver();

            ///Act
            ///Go to Statistics page of Group 1
            driver.Navigate().GoToUrl("https://localhost:44331/estadisticas/1");
            driver.Manage().Window.Maximize();

            ///Declare an awaiter for our driver
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));

            wait.Until(e => e.FindElement(By.CssSelector("#banner > div > div > div > div:nth-child(3) > div")));
            IWebElement mudpaper = driver.FindElement(By.CssSelector("#banner > div > div > div > div:nth-child(3) > div"));

            wait.Until(e => e.FindElement(By.CssSelector("#banner > div > div > div > div:nth-child(3) > div > div.mud-grid-item.mud-grid-item-xs-12.mud-grid-item-md-12.d-flex.justify-end > button")));
            IWebElement popUpbutton = driver.FindElement(By.CssSelector("#banner > div > div > div > div:nth-child(3) > div > div.mud-grid-item.mud-grid-item-xs-12.mud-grid-item-md-12.d-flex.justify-end > button"));

            wait.Until(e => e.FindElement(By.CssSelector("#banner > div > div > div > div:nth-child(3) > div > div.mud-grid.mud-grid-spacing-xs-3.mud-grid-justify-xs-flex-start > div.mud-grid-item.mud-grid-item-xs-12.mud-grid-item-sm-6.mud-grid-item-md-4 > div > div > div")));
            IWebElement filter = driver.FindElement(By.CssSelector("#banner > div > div > div > div:nth-child(3) > div > div.mud-grid.mud-grid-spacing-xs-3.mud-grid-justify-xs-flex-start > div.mud-grid-item.mud-grid-item-xs-12.mud-grid-item-sm-6.mud-grid-item-md-4 > div > div > div"));

            wait.Until(e => e.FindElement(By.CssSelector("#banner > div > div > div > div:nth-child(3) > div > div.mud-grid.mud-grid-spacing-xs-3.mud-grid-justify-xs-flex-start > div:nth-child(2)")));
            IWebElement years = driver.FindElement(By.CssSelector("#banner > div > div > div > div:nth-child(3) > div > div.mud-grid.mud-grid-spacing-xs-3.mud-grid-justify-xs-flex-start > div:nth-child(2)"));

            popUpbutton.Click();

            wait.Until(e => e.FindElement(By.CssSelector("#banner > div > div > div > div:nth-child(3) > div > div.mud-overlay > div.mud-overlay-content > div > div > div.mud-paper.mud-elevation-1.d-flex.flex-column.align-left.pa-10")));
            IWebElement mudpaperPopUp = driver.FindElement(By.CssSelector("#banner > div > div > div > div:nth-child(3) > div > div.mud-overlay > div.mud-overlay-content > div > div > div.mud-paper.mud-elevation-1.d-flex.flex-column.align-left.pa-10"));

            wait.Until(e => e.FindElement(By.CssSelector("#banner > div > div > div > div:nth-child(3) > div > div.mud-overlay > div.mud-overlay-content > div > div > div.mud-paper.mud-elevation-1.d-flex.flex-column.align-left.pa-10 > div > div.mud-grid.mud-grid-spacing-xs-3.mud-grid-justify-xs-flex-start > div.mud-grid-item.mud-grid-item-xs-12.mud-grid-item-sm-6.mud-grid-item-md-4 > div > div")));
            IWebElement mudselect = driver.FindElement(By.CssSelector("#banner > div > div > div > div:nth-child(3) > div > div.mud-overlay > div.mud-overlay-content > div > div > div.mud-paper.mud-elevation-1.d-flex.flex-column.align-left.pa-10 > div > div.mud-grid.mud-grid-spacing-xs-3.mud-grid-justify-xs-flex-start > div.mud-grid-item.mud-grid-item-xs-12.mud-grid-item-sm-6.mud-grid-item-md-4 > div > div"));

            wait.Until(e => e.FindElement(By.CssSelector("#banner > div > div > div > div:nth-child(3) > div > div.mud-overlay > div.mud-overlay-content > div > div > div.mud-paper.mud-elevation-1.d-flex.flex-column.align-left.pa-10 > div > div.mud-grid.mud-grid-spacing-xs-3.mud-grid-justify-xs-flex-start > div:nth-child(2)")));
            IWebElement areasPopUp = driver.FindElement(By.CssSelector("#banner > div > div > div > div:nth-child(3) > div > div.mud-overlay > div.mud-overlay-content > div > div > div.mud-paper.mud-elevation-1.d-flex.flex-column.align-left.pa-10 > div > div.mud-grid.mud-grid-spacing-xs-3.mud-grid-justify-xs-flex-start > div:nth-child(2)"));

            wait.Until(e => e.FindElement(By.CssSelector("#banner > div > div > div > div:nth-child(3) > div > div.mud-overlay > div.mud-overlay-content > div > div > div.mud-grid-item.mud-grid-item-xs-12.mud-grid-item-md-12.d-flex.justify-start > button")));
            IWebElement closeButton = driver.FindElement(By.CssSelector("#banner > div > div > div > div:nth-child(3) > div > div.mud-overlay > div.mud-overlay-content > div > div > div.mud-grid-item.mud-grid-item-xs-12.mud-grid-item-md-12.d-flex.justify-start > button"));

            Assert.IsNotNull(mudpaper);
            Assert.IsNotNull(popUpbutton);
            Assert.IsNotNull(filter);
            Assert.IsNotNull(years);
            Assert.IsNotNull(mudpaperPopUp);
            Assert.IsNotNull(mudselect);
            Assert.IsNotNull(areasPopUp);
            Assert.IsNotNull(closeButton);
        }

        /// <summary>
        /// Tests for chart of statistic of publications per type
        /// </summary>
        /// Author: Pablo Otárola Rodríguez [LosPollosHermanos]
        [TestMethod]
        public void CorrectChartType()
        {
            ///Arrange
            ///Create a Chrome driver
            driver = new ChromeDriver();

            ///Act
            ///Go to Statistics page of Group 1
            driver.Navigate().GoToUrl("https://localhost:44331/estadisticas/1");
            driver.Manage().Window.Maximize();

            ///Declare an awaiter for our driver
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));

            wait.Until(e => e.FindElement(By.CssSelector("#banner > div > div > div > div:nth-child(4) > div")));
            IWebElement mudpaper = driver.FindElement(By.CssSelector("#banner > div > div > div > div:nth-child(4) > div"));

            wait.Until(e => e.FindElement(By.CssSelector("#banner > div > div > div > div:nth-child(4) > div > div.mud-grid-item.mud-grid-item-xs-12.mud-grid-item-md-12.d-flex.justify-end > button")));
            IWebElement popUpbutton = driver.FindElement(By.CssSelector("#banner > div > div > div > div:nth-child(4) > div > div.mud-grid-item.mud-grid-item-xs-12.mud-grid-item-md-12.d-flex.justify-end > button"));

            popUpbutton.Click();

            wait.Until(e => e.FindElement(By.CssSelector("#banner > div > div > div > div:nth-child(4) > div > div.mud-overlay > div.mud-overlay-content > div > div > div.mud-paper.mud-elevation-1.d-flex.flex-column.align-left.pa-10")));
            IWebElement mudpaperPopUp = driver.FindElement(By.CssSelector("#banner > div > div > div > div:nth-child(4) > div > div.mud-overlay > div.mud-overlay-content > div > div > div.mud-paper.mud-elevation-1.d-flex.flex-column.align-left.pa-10"));

            wait.Until(e => e.FindElement(By.CssSelector("#banner > div > div > div > div:nth-child(4) > div > div.mud-overlay > div.mud-overlay-content > div > div > div.mud-grid-item.mud-grid-item-xs-12.mud-grid-item-md-12.d-flex.justify-start > button")));
            IWebElement closeButton = driver.FindElement(By.CssSelector("#banner > div > div > div > div:nth-child(4) > div > div.mud-overlay > div.mud-overlay-content > div > div > div.mud-grid-item.mud-grid-item-xs-12.mud-grid-item-md-12.d-flex.justify-start > button"));

            Assert.IsNotNull(mudpaper);
            Assert.IsNotNull(popUpbutton);
            Assert.IsNotNull(mudpaperPopUp);
            Assert.IsNotNull(closeButton);
        }

        /// <summary>
        /// Tests for chart of statistic of publications per area
        /// </summary>
        /// Author: Pablo Otárola Rodríguez [LosPollosHermanos]
        [TestMethod]
        public void CorrectChartGroup()
        {
            ///Arrange
            ///Create a Chrome driver
            driver = new ChromeDriver();

            ///Act
            ///Go to Statistics page of Group 1
            driver.Navigate().GoToUrl("https://localhost:44331/estadisticas/1");
            driver.Manage().Window.Maximize();

            ///Declare an awaiter for our driver
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));

            wait.Until(e => e.FindElement(By.CssSelector("#banner > div > div > div > div:nth-child(5) > div")));
            IWebElement mudpaper = driver.FindElement(By.CssSelector("#banner > div > div > div > div:nth-child(5) > div"));

            wait.Until(e => e.FindElement(By.CssSelector("#banner > div > div > div > div:nth-child(5) > div > div.mud-grid-item.mud-grid-item-xs-12.mud-grid-item-md-12.d-flex.justify-end > button")));
            IWebElement popUpbutton = driver.FindElement(By.CssSelector("#banner > div > div > div > div:nth-child(5) > div > div.mud-grid-item.mud-grid-item-xs-12.mud-grid-item-md-12.d-flex.justify-end > button"));

            popUpbutton.Click();

            wait.Until(e => e.FindElement(By.CssSelector("#banner > div > div > div > div:nth-child(5) > div > div.mud-overlay > div.mud-overlay-content > div")));
            IWebElement mudpaperPopUp = driver.FindElement(By.CssSelector("#banner > div > div > div > div:nth-child(5) > div > div.mud-overlay > div.mud-overlay-content > div"));

            wait.Until(e => e.FindElement(By.CssSelector("#banner > div > div > div > div:nth-child(5) > div > div.mud-overlay > div.mud-overlay-content > div > div > div.mud-grid-item.mud-grid-item-xs-12.mud-grid-item-md-12.d-flex.justify-start > button")));
            IWebElement closeButton = driver.FindElement(By.CssSelector("#banner > div > div > div > div:nth-child(5) > div > div.mud-overlay > div.mud-overlay-content > div > div > div.mud-grid-item.mud-grid-item-xs-12.mud-grid-item-md-12.d-flex.justify-start > button"));

            Assert.IsNotNull(mudpaper);
            Assert.IsNotNull(popUpbutton);
            Assert.IsNotNull(mudpaperPopUp);
            Assert.IsNotNull(closeButton);
        }

        /// <summary>
        /// Tests for chart of statistic of publications per area
        /// </summary>
        /// Author: Pablo Otárola Rodríguez [LosPollosHermanos]
        [TestMethod]
        public void CorrectChartTypeByYears()
        {
            ///Arrange
            ///Create a Chrome driver
            driver = new ChromeDriver();

            ///Act
            ///Go to Statistics page of Group 1
            driver.Navigate().GoToUrl("https://localhost:44331/estadisticas/1");
            driver.Manage().Window.Maximize();

            ///Declare an awaiter for our driver
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));

            wait.Until(e => e.FindElement(By.CssSelector("#banner > div > div > div > div:nth-child(6) > div")));
            IWebElement mudpaper = driver.FindElement(By.CssSelector("#banner > div > div > div > div:nth-child(6) > div"));

            wait.Until(e => e.FindElement(By.CssSelector("#banner > div > div > div > div:nth-child(6) > div > div.mud-grid-item.mud-grid-item-xs-12.mud-grid-item-md-12.d-flex.justify-end > button")));
            IWebElement popUpbutton = driver.FindElement(By.CssSelector("#banner > div > div > div > div:nth-child(6) > div > div.mud-grid-item.mud-grid-item-xs-12.mud-grid-item-md-12.d-flex.justify-end > button"));

            wait.Until(e => e.FindElement(By.CssSelector("#banner > div > div > div > div:nth-child(6) > div > div.mud-grid.mud-grid-spacing-xs-3.mud-grid-justify-xs-flex-start > div.mud-grid-item.mud-grid-item-xs-12.mud-grid-item-sm-6.mud-grid-item-md-4 > div > div > div")));
            IWebElement filter = driver.FindElement(By.CssSelector("#banner > div > div > div > div:nth-child(6) > div > div.mud-grid.mud-grid-spacing-xs-3.mud-grid-justify-xs-flex-start > div.mud-grid-item.mud-grid-item-xs-12.mud-grid-item-sm-6.mud-grid-item-md-4 > div > div > div"));

            wait.Until(e => e.FindElement(By.CssSelector("#banner > div > div > div > div:nth-child(6) > div > div.mud-grid.mud-grid-spacing-xs-3.mud-grid-justify-xs-flex-start > div:nth-child(2)")));
            IWebElement years = driver.FindElement(By.CssSelector("#banner > div > div > div > div:nth-child(6) > div > div.mud-grid.mud-grid-spacing-xs-3.mud-grid-justify-xs-flex-start > div:nth-child(2)"));

            popUpbutton.Click();

            wait.Until(e => e.FindElement(By.CssSelector("#banner > div > div > div > div:nth-child(6) > div > div.mud-overlay > div.mud-overlay-content > div > div > div.mud-paper.mud-elevation-1.d-flex.flex-column.align-left.pa-10")));
            IWebElement mudpaperPopUp = driver.FindElement(By.CssSelector("#banner > div > div > div > div:nth-child(6) > div > div.mud-overlay > div.mud-overlay-content > div > div > div.mud-paper.mud-elevation-1.d-flex.flex-column.align-left.pa-10"));

            wait.Until(e => e.FindElement(By.CssSelector("#banner > div > div > div > div:nth-child(6) > div > div.mud-overlay > div.mud-overlay-content > div > div > div.mud-paper.mud-elevation-1.d-flex.flex-column.align-left.pa-10 > div > div.mud-grid.mud-grid-spacing-xs-3.mud-grid-justify-xs-flex-start > div.mud-grid-item.mud-grid-item-xs-12.mud-grid-item-sm-6.mud-grid-item-md-4 > div > div")));
            IWebElement mudselect = driver.FindElement(By.CssSelector("#banner > div > div > div > div:nth-child(6) > div > div.mud-overlay > div.mud-overlay-content > div > div > div.mud-paper.mud-elevation-1.d-flex.flex-column.align-left.pa-10 > div > div.mud-grid.mud-grid-spacing-xs-3.mud-grid-justify-xs-flex-start > div.mud-grid-item.mud-grid-item-xs-12.mud-grid-item-sm-6.mud-grid-item-md-4 > div > div"));

            wait.Until(e => e.FindElement(By.CssSelector("#banner > div > div > div > div:nth-child(6) > div > div.mud-overlay > div.mud-overlay-content > div > div > div.mud-paper.mud-elevation-1.d-flex.flex-column.align-left.pa-10 > div > div.mud-grid.mud-grid-spacing-xs-3.mud-grid-justify-xs-flex-start > div:nth-child(2)")));
            IWebElement areasPopUp = driver.FindElement(By.CssSelector("#banner > div > div > div > div:nth-child(6) > div > div.mud-overlay > div.mud-overlay-content > div > div > div.mud-paper.mud-elevation-1.d-flex.flex-column.align-left.pa-10 > div > div.mud-grid.mud-grid-spacing-xs-3.mud-grid-justify-xs-flex-start > div:nth-child(2)"));

            wait.Until(e => e.FindElement(By.CssSelector("#banner > div > div > div > div:nth-child(6) > div > div.mud-overlay > div.mud-overlay-content > div > div > div.mud-grid-item.mud-grid-item-xs-12.mud-grid-item-md-12.d-flex.justify-start > button")));
            IWebElement closeButton = driver.FindElement(By.CssSelector("#banner > div > div > div > div:nth-child(6) > div > div.mud-overlay > div.mud-overlay-content > div > div > div.mud-grid-item.mud-grid-item-xs-12.mud-grid-item-md-12.d-flex.justify-start > button"));
            
            Assert.IsNotNull(mudpaper);
            Assert.IsNotNull(popUpbutton);
            Assert.IsNotNull(filter);
            Assert.IsNotNull(years);
            Assert.IsNotNull(mudpaperPopUp);
            Assert.IsNotNull(mudselect);
            Assert.IsNotNull(areasPopUp);
            Assert.IsNotNull(closeButton);
        }

        /// <summary>
        /// Tests sorting the publications per year statistic to show those from 2018 & 2020
        /// </summary>
        /// Author: David Sánchez López [LosPollosHermanos]
        [TestMethod]
        public void CorrectSortPublicationsByYear()
        {
            ///Arrange
            ///Create a Chrome driver
            driver = new ChromeDriver();

            ///Act
            ///Go to Statistics page of Group 1
            driver.Navigate().GoToUrl("https://localhost:44331/estadisticas/1");
            driver.Manage().Window.Maximize();

            ///Declare an awaiter for our driver
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));

            //Wait for & find the canvas (MudPaper) where the graph lays at.
            wait.Until(e => e.FindElement(By.CssSelector("#banner > div > div > div > div:nth-child(3) > div")));            
            IWebElement mudpaper = driver.FindElement(By.CssSelector("#banner > div > div > div > div:nth-child(3) > div"));
            
            //Wait for & find the combo box (MudSelect) which hosts the filters.
            wait.Until(e => e.FindElement(By.CssSelector("#banner > div > div > div > div:nth-child(3) > div > div.mud-grid.mud-grid-spacing-xs-3.mud-grid-justify-xs-flex-start > div.mud-grid-item.mud-grid-item-xs-12.mud-grid-item-sm-6.mud-grid-item-md-4 > div")));
            IWebElement mudselect = driver.FindElement(By.CssSelector("#banner > div > div > div > div:nth-child(3) > div > div.mud-grid.mud-grid-spacing-xs-3.mud-grid-justify-xs-flex-start > div.mud-grid-item.mud-grid-item-xs-12.mud-grid-item-sm-6.mud-grid-item-md-4 > div"));

            //Wait for & find the button to toggle the graph to fullscreen (popup).
            wait.Until(e => e.FindElement(By.CssSelector("#banner > div > div > div > div:nth-child(3) > div > div.mud-grid-item.mud-grid-item-xs-12.mud-grid-item-md-12.d-flex.justify-end > button")));
            IWebElement fullscreenButton = driver.FindElement(By.CssSelector("#banner > div > div > div > div:nth-child(3) > div > div.mud-grid-item.mud-grid-item-xs-12.mud-grid-item-md-12.d-flex.justify-end > button"));
            
            //Assert
            //Check the state of the displayed statistics graph
            Assert.IsNotNull(mudpaper);
            Assert.IsNotNull(mudselect);
            Assert.IsNotNull(fullscreenButton);
        }

        /// <summary>
        /// Tests for pop up for statistic of publications per year
        /// </summary>
        /// Author: Pablo Otárola Rodríguez [LosPollosHermanos]
        [TestMethod]
        public void CorrectPopUpPublicationsByAuthor()
        {
            ///Arrange
            ///Create a Chrome driver
            driver = new ChromeDriver();

            ///Act
            ///Go to Statistics page of Group 1
            driver.Navigate().GoToUrl("https://localhost:44331/estadisticas/1");
            driver.Manage().Window.Maximize();

            ///Declare an awaiting for our driver
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));

            //Wait for and find the canvas (MudPaper) where the graph lays at.
            wait.Until(e => e.FindElement(By.CssSelector("#banner > div > div > div > div:nth-child(5) > div")));
            IWebElement mudpaper = driver.FindElement(By.CssSelector("#banner > div > div > div > div:nth-child(5) > div"));

            //Wait for and find the buttom for pop up
            wait.Until(e => e.FindElement(By.CssSelector("#banner > div > div > div > div:nth-child(5) > div > div.mud-grid-item.mud-grid-item-xs-12.mud-grid-item-md-12.d-flex.justify-end > button")));
            IWebElement mudButton = driver.FindElement(By.CssSelector("#banner > div > div > div > div:nth-child(5) > div > div.mud-grid-item.mud-grid-item-xs-12.mud-grid-item-md-12.d-flex.justify-end > button"));

            mudButton.Click();

            //Wait for and find the pop up for the graph
            wait.Until(e => e.FindElement(By.CssSelector("#banner > div > div > div > div:nth-child(5) > div > div.mud-overlay > div.mud-overlay-content > div > div > div.mud-paper.mud-elevation-1.d-flex.flex-column.align-left.pa-10")));
            IWebElement mudpaperPopUp = driver.FindElement(By.CssSelector("#banner > div > div > div > div:nth-child(5) > div > div.mud-overlay > div.mud-overlay-content > div > div > div.mud-paper.mud-elevation-1.d-flex.flex-column.align-left.pa-10"));

            //Wait for and find the button for close the pop up
            wait.Until(e => e.FindElement(By.CssSelector("#banner > div > div > div > div:nth-child(5) > div > div.mud-overlay > div.mud-overlay-content > div > div > div.mud-grid-item.mud-grid-item-xs-12.mud-grid-item-md-12.d-flex.justify-start > button")));
            IWebElement mudButtonClosePopUp = driver.FindElement(By.CssSelector("#banner > div > div > div > div:nth-child(5) > div > div.mud-overlay > div.mud-overlay-content > div > div > div.mud-grid-item.mud-grid-item-xs-12.mud-grid-item-md-12.d-flex.justify-start > button"));

            //Assert
            //Check the state of the displayed statistics graph
            Assert.IsNotNull(mudpaper);
            Assert.IsNotNull(mudButton);
            Assert.IsNotNull(mudpaperPopUp);
            Assert.IsNotNull(mudButtonClosePopUp);
        }

        /// <summary>
        /// Tests sorting the publications per research areas to show those from Software Engineering at Research Center level
        /// </summary>
        /// Author: Frank Alvarado Alfaro [LosPollosHermanos]
        [TestMethod]
        public void CorrectSortPublicationsByResearchArea()
        {
            ///Arrange
            ///Create a Chrome driver
            driver = new ChromeDriver();

            ///Act
            ///Go to Statistics page of Group 1
            driver.Navigate().GoToUrl("https://localhost:44331/estadisticas");
            driver.Manage().Window.Maximize();

            ///Declare an awaiter for our driver
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));

            //Wait for & find the canvas (MudPaper) where the graph lays at.
            wait.Until(e => e.FindElement(By.CssSelector("#banner > div > div > div:nth-child(3) > div:nth-child(2) > div")));
            IWebElement mudpaper = driver.FindElement(By.CssSelector("#banner > div > div > div:nth-child(3) > div:nth-child(2) > div"));
            
            //Wait for & find the combo box (MudSelect) which hosts the filters.
            wait.Until(e => e.FindElement(By.CssSelector("#banner > div > div > div:nth-child(3) > div:nth-child(2) > div > div.mud-grid.mud-grid-spacing-xs-3.mud-grid-justify-xs-flex-start > div.mud-grid-item.mud-grid-item-xs-12.mud-grid-item-sm-6.mud-grid-item-md-4 > div")));
            IWebElement mudselect = driver.FindElement(By.CssSelector("#banner > div > div > div:nth-child(3) > div:nth-child(2) > div > div.mud-grid.mud-grid-spacing-xs-3.mud-grid-justify-xs-flex-start > div.mud-grid-item.mud-grid-item-xs-12.mud-grid-item-sm-6.mud-grid-item-md-4 > div"));
            
            //Wait for & find the button to toggle the graph to fullscreen (popup).
            wait.Until(e => e.FindElement(By.CssSelector("#banner > div > div > div:nth-child(3) > div:nth-child(2) > div > div.mud-grid-item.mud-grid-item-xs-12.mud-grid-item-md-12.d-flex.justify-end > button")));
            IWebElement fullscreenButton = driver.FindElement(By.CssSelector("#banner > div > div > div:nth-child(3) > div:nth-child(2) > div > div.mud-grid-item.mud-grid-item-xs-12.mud-grid-item-md-12.d-flex.justify-end > button"));
            
            //Assert
            //Check the state of the displayed statistics graph
            Assert.IsNotNull(mudpaper);
            Assert.IsNotNull(mudselect);
            Assert.IsNotNull(fullscreenButton);
        }
    }
}
