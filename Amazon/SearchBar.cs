using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Amazon
{
    public class SearchBar
    {
        private IWebDriver driver;
        public string Text
        {
            get
            {
                var serchvar = driver.FindElement(By.Id("twotabsearchtextbox"));
                return serchvar.GetAttribute("value");

            }
            set
            {
                
                var serchvar = driver.FindElement(By.Id("twotabsearchtextbox"));
                serchvar.Clear();
                serchvar.SendKeys(value);
            }
        }
        public SearchBar(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void click()
        {
            var clikvar = driver.FindElement(By.Id("nav-search-submit-button"));
            clikvar.Click();
        }
    }
}
