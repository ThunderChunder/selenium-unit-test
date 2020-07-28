using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChromeUnitTest.PageObjects
{
    class BookAFlightPage
    {
        public IWebDriver driver;

        private IWebElement[] pageElementObj;

        List<PageElement> homePageElements;

        public BookAFlightPage(IWebDriver driver)
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
                //I still used switch case if radio button type is ever required. case 'r': can be defined
                switch(homePageElements[i].type)
                {
                    case 't':
                    case 's':
                    case 'c':
                    case 'b':
                        pageElementObj[i] = driver.FindElement(By.Name(homePageElements[i].key));
                        break;
                }
            }
        }
        //Inputs all form values using the switch case to determine correct element type
        public HomePage inputFormValues()
        {
            SelectElement selector;
            for (int i = 0; i < homePageElements.Count; i++)
            {
                switch (homePageElements[i].type)
                {
                    case 't':
                        pageElementObj[i].Clear();
                        pageElementObj[i].SendKeys(homePageElements[i].value);
                        break;
                    case 's':
                        selector = new SelectElement(pageElementObj[i]);
                        selector.SelectByValue(homePageElements[i].value);
                        break;
                    case 'c':
                        pageElementObj[i].Click();
                        break;
                    case 'b':
                        System.Threading.Thread.Sleep(2000);
                        pageElementObj[i].Click();
                        break;
                }
            }
            return new HomePage(driver);
        }
    }
}
