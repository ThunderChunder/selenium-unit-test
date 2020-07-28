using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChromeUnitTest
{
    class PageElement
    {
        //Stores HTML Element name attribute to identify specific webpage element
        public string key;
        //Stores value to be passed to HTML element e.g. value for textbox, option in select one drop down menu, radio button to select...
        public string value;
        //Defines what type of HTML Element the object is to interact with e.g. t == TextBox, s == SelectOne, c == CheckBox, r == RadioButton
        public char type;

        public PageElement(string key, string value, char type)
        {
            this.key = key;
            this.value = value;
            this.type = type;
        }
    }
}
