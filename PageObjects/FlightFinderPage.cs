using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChromeUnitTest.PageObjects
{
    class FlightFinderPage
    {
        public IWebDriver driver;
        //Stores all bound webpage elements in array
        private IWebElement[] pageElementObj;
        //Stores all relevant webpage element attribute, element type and test data for that element
        List<PageElement> homePageElements;

        public FlightFinderPage(IWebDriver driver)
        {
            this.driver = driver;
        }
        //Takes List<PageElement> and writes data into object global attribute
        //Instantiates array size to accomodate all HTML elements that will be interacted with
        public void storeFormValues(List<PageElement> homePageElements)
        {
            this.homePageElements = new List<PageElement>(homePageElements);
            pageElementObj = new IWebElement[this.homePageElements.Count];
        }
        //Finds webpage form elements and binds each to a IWebElement object in the array
        public void findFormElements()
        {
            for (int i = 0; i < homePageElements.Count; i++)
            {
                switch (homePageElements[i].type)
                {
                    case 'r':
                        pageElementObj[i] = driver.FindElement(By.XPath("//input[@name='" + homePageElements[i].key + "' and @value='" + homePageElements[i].value + "']"));
                        break;
                    case 's':
                    case 'b':
                        pageElementObj[i] = driver.FindElement(By.Name(homePageElements[i].key));
                        break;
                }
            }
        }
        //Inputs all form values using the switch case to determine correct element type
        public SelectFlightPage inputFormValues()
        {
            SelectElement selector;
            for (int i = 0; i < homePageElements.Count; i++)
            {
                switch (homePageElements[i].type)
                {
                    case 'r':
                        pageElementObj[i].Click();
                        break;
                    case 's':
                        selector = new SelectElement(pageElementObj[i]);
                        selector.SelectByValue(homePageElements[i].value);
                        break;
                    case 'b':
                        System.Threading.Thread.Sleep(2000);
                        pageElementObj[i].Click();
                        break;
                }
            }
            return new SelectFlightPage(driver);
        }
    }
}
