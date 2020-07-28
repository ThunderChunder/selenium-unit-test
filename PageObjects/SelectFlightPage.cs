using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChromeUnitTest.PageObjects
{
    class SelectFlightPage
    {
        public IWebDriver driver;
        public IWebElement continueButton;

        public SelectFlightPage(IWebDriver driver)
        {
            this.driver = driver;
        }
        //Finds webpage form elements and binds each to a IWebElement object in the array
        public void findFormElements(List<PageElement> homePageElements)
        {
            foreach(PageElement ele in homePageElements)
            {
                if(ele.type =='b')
                {
                    continueButton = driver.FindElement(By.Name(ele.key));
                }
            }
        }
        //Performs Click() operation of continue button Element present on the page
        public BookAFlightPage clickContinue()
        {
            continueButton.Click();

            return new BookAFlightPage(driver);
        }
    }
}
