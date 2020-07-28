using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace ChromeUnitTest.PageObjects
{
    class HomePage
    {
        public IWebDriver driver;
        //Used to store test credentials
        private string userName, password;
        //Each object binds to respected HTML page element
        private IWebElement userNameTextbox, passwordTextbox, submitButton;

        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
        }
        //Navigates to destination URL passed
        public void navToURL(string destURL)
        {
            driver.Navigate().GoToUrl(destURL);
        }
        //Stores username and password as global attribute
        public void storeCredentials(List<PageElement> homePageElements)
        {
            userName = homePageElements[0].value;
            password = homePageElements[1].value;
        }
        //Finds and binds username, password, submitButton HTML elements to global attributes
        public void findLoginElements(List<PageElement> homePageElements)
        {
            userNameTextbox = driver.FindElement(By.Name(homePageElements[0].key));
            passwordTextbox = driver.FindElement(By.Name(homePageElements[1].key));
            submitButton = driver.FindElement(By.Name(homePageElements[2].key));
        }
        //Passes global username and password attributes to bound HTML elements username/password and clicks submits
        //Returns FlightFinderPage object
        public FlightFinderPage login()
        {
            userNameTextbox.Clear();
            passwordTextbox.Clear();
            userNameTextbox.SendKeys(userName);
            passwordTextbox.SendKeys(password);
            submitButton.Click();

            return new FlightFinderPage(driver);
        }

    }
}
