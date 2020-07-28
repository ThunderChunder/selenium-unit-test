/*
 The purpose of this class is to store all form inputs in one location making it slightly easier to test different form inputs
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChromeUnitTest
{
    class DriverVariables
    {
        public string destURL = "http://newtours.demoaut.com/mercurywelcome.php";

        //##################### HOMEPAGE VARIABLES ######################################
        public List<PageElement> homePageElements = new List<PageElement>() 
        { 
            new PageElement("userName", "mercury", 't' ), 
            new PageElement("password", "mercury", 't'),
            new PageElement("login", "", 'b')
        };
        //Used in assert of Homepage
        public string homePageTitle = "Welcome: Mercury Tours";
        public string homePageSourceString = "login";

        //##################### FLIGHTFINDER VARIABLES ######################################
        //Used in assert of FlightFinder page
        public string flightFinderSourceString = "/images/masts/mast_flightfinder.gif";
        public string flightFinderTitle = "Find a Flight: Mercury Tours:";

        public List<PageElement> flightFinderElements = new List<PageElement>()
        {
            new PageElement("tripType", "oneway", 'r'),
            new PageElement("fromPort", "Sydney", 's'),
            new PageElement("toPort", "London", 's'),
            new PageElement("servClass", "First", 'r'),
            new PageElement("findFlights", "", 'b')
        };

        //##################### SELECTFLIGHT VARIABLES ######################################
        //Used in assert of SelectFlight page
        public string selectFlightTitle = "Select a Flight: Mercury Tours";
        public string selectFlightSourceString = "/images/masts/mast_selectflight.gif";

        public List<PageElement> selectFlightElements = new List<PageElement>()
        {
            new PageElement("reserveFlights", "", 'b')
        };

        //##################### BOOKAFLIGHT VARIABLES ######################################
        //Used in assert of BookAFlight page
        public string bookAFlightTitle = "Book a Flight: Mercury Tours";
        public string bookAFlightSourceString = "/images/masts/mast_book.gif";

        public List<PageElement> bookAFlightElements = new List<PageElement>()
        {
            new PageElement("passFirst0", "Brian", 't'),
            new PageElement("passLast0", "Valenzi", 't'),
            new PageElement("creditnumber", "0100111001", 't'),
            new PageElement("ticketLess", "1", 'c'),
            new PageElement("buyFlights", "", 'b')
        };
    }
}
