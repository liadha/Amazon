using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amazon
{
    public class Amazon
    {
        private Pages pages;
        public Pages Pages
        {
            get { return this.pages; }
        }


        public Amazon(IWebDriver driver, string url)
        {
            driver.Url = url;
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            this.pages = new Pages(driver);

        }
    }
}
