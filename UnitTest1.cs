using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Assert = NUnit.Framework.Assert;

namespace ChromeUnitTest.PageObjects
{
    [TestClass]
    public class UnitTest1
    {
        private IWebDriver driver;
  
        [SetUp]
        public void initUnitTest()
        {
            this.driver = new ChromeDriver();
            //driver.Manage().Window.Maximize();
        }

        [Test]
        public void testMethod()
        {
            DriverVariables dVar = new DriverVariables();

            HomePage homePage = new HomePage(driver);
            homePage.navToURL(dVar.destURL);
            validateURL(dVar.destURL, homePage.driver);
            validatePage(dVar.homePageTitle, homePage.driver, dVar.homePageSourceString);
            homePage.findLoginElements(dVar.homePageElements);
            homePage.storeCredentials(dVar.homePageElements);

            System.Threading.Thread.Sleep(1000);

            FlightFinderPage flightFinderPage = homePage.login();
            validatePage(dVar.flightFinderTitle, flightFinderPage.driver, dVar.flightFinderSourceString);
            flightFinderPage.storeFormValues(dVar.flightFinderElements);
            flightFinderPage.findFormElements();

            SelectFlightPage selectFlightPage = flightFinderPage.inputFormValues();
            validatePage(dVar.selectFlightTitle, selectFlightPage.driver, dVar.selectFlightSourceString);
            selectFlightPage.findFormElements(dVar.selectFlightElements);

            System.Threading.Thread.Sleep(2000);

            BookAFlightPage bookAFlightPage = selectFlightPage.clickContinue();
            validatePage(dVar.bookAFlightTitle, bookAFlightPage.driver, dVar.bookAFlightSourceString);
            bookAFlightPage.storeFormValues(dVar.bookAFlightElements);
            bookAFlightPage.findFormElements();
            bookAFlightPage.inputFormValues();

            System.Threading.Thread.Sleep(2000);
        }

        //Asserts whether expectedUrl and driver.Url are equal
        public void validateURL(string expectedUrl, IWebDriver driver)
        {
            Assert.AreEqual(expectedUrl, driver.Url, driver.Url + " URL does not match " + expectedUrl);
        }
        //Asserts whether specific page title is correct and whether the page contains correct image
        public void validatePage(string expectedTitle, IWebDriver driver, string expectedPageSource)
        {   
            Assert.AreEqual(expectedTitle, driver.Title, driver.Title+" title does not match "+expectedTitle);
            Assert.IsTrue(driver.PageSource.Contains(expectedPageSource), expectedPageSource+" is not in the page source.");
        }


        [TearDown]
        public void closeConn()
        {
            driver.Close();
            driver.Quit();
        }
    }
}
