//Inside SeleniumTest.cs

using NUnit.Framework;

using OpenQA.Selenium;

using OpenQA.Selenium.Chrome;

using OpenQA.Selenium.Firefox;

using System;

using System.Collections.ObjectModel;

using System.IO;

namespace SeleniumCsharp

{

    public class Tests

    {

        IWebDriver driver;

        [OneTimeSetUp]

        public void Setup()

        {

            //Below code is to get the drivers folder path dynamically.

            string path = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;

            //Creates the ChomeDriver object, Executes tests on Google Chrome

            driver = new ChromeDriver(path + @"\drivers\");

           

        }

        [Test]

        public void verifyLogo()

        {

            driver.Navigate().GoToUrl("https://www.browserstack.com/");

            Assert.IsTrue(driver.FindElement(By.Id("logo")).Displayed);

        }

        [Test]

        public void verifyMenuItemcount()

        {

            ReadOnlyCollection<IWebElement> menuItem = driver.FindElements(By.XPath("//ul[contains(@class,'horizontal-list product-menu')]/li"));

            Assert.AreEqual(menuItem.Count, 4);

        }

        [Test]

        public void verifyPricingPage()

        {

            driver.Navigate().GoToUrl("https://browserstack.com/pricing");

            IWebElement contactUsPageHeader = driver.FindElement(By.TagName("h1"));

            Assert.IsTrue(contactUsPageHeader.Text.Contains("Replace your device lab and VMs with any of these plans"));

        }




        [OneTimeTearDown]

        public void TearDown()

        {

            driver.Quit();

        }

    }

}