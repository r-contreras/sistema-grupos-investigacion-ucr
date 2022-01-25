using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System.Threading;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;

namespace UITestsSelenium.WebDriver.PeopleContext
{
    [TestClass]
    public class ProfilePage
    {
        IWebDriver _driver;
        [TestCleanup]
        public void TearDown()
        {
            if (_driver!=null)
                _driver.Quit();
        }

        [TestMethod]
        public void ProfilePageAccessTests()
        {
            _driver = new ChromeDriver();
            _driver.Manage().Window.Maximize();
            //Tests
            AccessDirectlyAndRefresh();
        }

        public void AccessDirectlyAndRefresh()
        {
            //arrange
            //This is Alexandra Martinez specific address.
            _driver.Url = "https://localhost:44331/Perfil/CfDJ8Fw9qBVsGeNEgmw7pQH2FvAmLz7rAMhOoQWK2zFIWV4KvF0" +
                "A_AwQa7URX7jDicQLUS4EThxoS8kyvYTWo7bKJQuT7vwkS81jEgJ64aPdU5WZyt8A2uKAnraeEd3KkqGro3fsQ8KbkaskWIUDUBPS7hgD_cBZ30XYcQBbup2WROYt/1";
            _driver.Navigate().Refresh();
            //action
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
            
            //assert
            _driver.FindElement(By.Id("PresentationCard"));
            _driver.FindElement(By.Id("AsociatedProjects"));
            _driver.FindElement(By.Id("AsociatedThesis"));
            _driver.FindElement(By.Id("AsociatedPublications"));
            
        }

        [TestMethod]
        public void ProfileExternalLinksTest()
        {
            //arrange
            _driver = new ChromeDriver();
            TryFacebookIconTest();
            TryGithubIconTest();
            TryLinkedInIconTest();

        }
        private void TryFacebookIconTest()
        {
            //arrange
            _driver.Url = "https://localhost:44331/Perfil/CfDJ8AtT1hRXRmdJsmPYbdr_mK4_SnaKRwB9oGLAaOiHwxNN0FU-RpE01Svxj3W2Y2l-Dn85DCa5guMcy-akD-BJmgNMZQZTgL3A-r77c0ad4Zzs27s2RYRzTvf8-fpDfLKGnDsVYGlhDnKYa6jN6uqqQz4/1";
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
            IWebElement iconLink = _driver.FindElement(By.Id("facebookIcon"));
            
            //act
            iconLink.Click();

            //assert
            _driver.Url.Contains("facebook");

        }
        private void TryGithubIconTest()
        {
            //arrange
            _driver.Url = "https://localhost:44331/Perfil/CfDJ8AtT1hRXRmdJsmPYbdr_mK4_SnaKRwB9oGLAaOiHwxNN0FU-RpE01Svxj3W2Y2l-Dn85DCa5guMcy-akD-BJmgNMZQZTgL3A-r77c0ad4Zzs27s2RYRzTvf8-fpDfLKGnDsVYGlhDnKYa6jN6uqqQz4/1";
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);
            IWebElement iconLink = _driver.FindElement(By.Id("githubIcon"));
            
            //act
            iconLink.Click();


            //assert
            _driver.Url.Contains("github");
        }
        private void TryLinkedInIconTest()
        {
            //arrange
            _driver.Url = "https://localhost:44331/Perfil/CfDJ8AtT1hRXRmdJsmPYbdr_mK4_SnaKRwB9oGLAaOiHwxNN0FU-RpE01Svxj3W2Y2l-Dn85DCa5guMcy-akD-BJmgNMZQZTgL3A-r77c0ad4Zzs27s2RYRzTvf8-fpDfLKGnDsVYGlhDnKYa6jN6uqqQz4/1";
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);
            IWebElement iconLink = _driver.FindElement(By.Id("linkedinIcon"));

            //act
            iconLink.Click();

            //assert
            _driver.Url.Contains("linkedin");

        }

        [TestMethod]
        public void BreadListTest()
        {
            //arrange
            _driver = new ChromeDriver();
            _driver.Url = "https://localhost:44331/Perfil/CfDJ8AtT1hRXRmdJsmPYbdr_mK4_SnaKRwB9oGLAaOiHwxNN0FU-RpE01Svxj3W2Y2l-Dn85DCa5guMcy-akD-BJmgNMZQZTgL3A-r77c0ad4Zzs27s2RYRzTvf8-fpDfLKGnDsVYGlhDnKYa6jN6uqqQz4/1";
            string url = _driver.Url;
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);
            
            //act
            _driver.FindElement(By.Id("pagepath")).Click();
            string ur2 = _driver.Url;
            _driver.FindElement(By.Id("pagepath")).Click();

            //assert
            _driver.Navigate().Back();
            _driver.Url.Equals(ur2);
            _driver.Navigate().Back();
            _driver.Url.Equals(url);

        }
        [TestMethod]
        public void PaginationTest()
        {
            //arrange 
            _driver = new ChromeDriver();
            _driver.Url = "https://localhost:44331/Perfil/CfDJ8Fw9qBVsGeNEgmw7pQH2FvAmLz7rAMhOoQWK2zFIWV4KvF0" +
                "A_AwQa7URX7jDicQLUS4EThxoS8kyvYTWo7bKJQuT7vwkS81jEgJ64aPdU5WZyt8A2uKAnraeEd3KkqGro3fsQ8KbkaskWIUDUBPS7hgD_cBZ30XYcQBbup2WROYt/1";
            _driver.Manage().Window.Maximize();
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);

            IReadOnlyList<IWebElement> showMore_Buttons = _driver.FindElements(By.CssSelector(".mud-button-root.mud-button.mud-button-filled.mud-button-filled-secondary.mud-button-filled-size-medium.mud-ripple"));
            int cant = showMore_Buttons.Count;

            //act
            IWebElement pagination = _driver.FindElement(By.CssSelector(".mud-button-root.mud-button.mud-button-text.mud-button-text-default.mud-button-text-size-medium"));
            pagination.Click();
            showMore_Buttons = _driver.FindElements(By.CssSelector(".mud-button-root.mud-button.mud-button-filled.mud-button-filled-secondary.mud-button-filled-size-medium.mud-ripple"));
            showMore_Buttons[0].Click();
            
            //assert
            _driver.Url.Equals("https://localhost:44331/PublicationDetailed/10.1007/978-3-030-01171-0_15");


        }
    }
}
