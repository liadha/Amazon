using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using System;
using System.Collections.Generic;

namespace Amazon
{
    class BrowsherFactory
    {
        private Dictionary<string, IWebDriver> drivers = new Dictionary<string, IWebDriver>();
        public Dictionary<string, IWebDriver> Drivers
        {
            get
            {

                return this.drivers;
            }
            set
            {
                this.drivers = value;
            }

        }
        public void InitBrowser(string browserName)
        {
            switch (browserName.ToUpper())
            {
                case "FIREFOX":
                    if (!(drivers.ContainsKey("Firefox")))
                    {
                        FirefoxOptions options = new FirefoxOptions();
                        options.AddArguments("--start-maximized");
                        IWebDriver driver1 = new FirefoxDriver();
                        Drivers.Add("Firefox", driver1);
                        break;
                    }
                    break;


                case "EDGE":
                    if (!(drivers.ContainsKey("Edge")))
                    {
                        EdgeOptions options = new EdgeOptions();
                        options.AddArguments("--start-maximized");
                        IWebDriver driver2 = new EdgeDriver();
                        Drivers.Add("Edge", driver2);
                        break;
                    }
                    break;


                case "CHROME":
                    if (!(drivers.ContainsKey("Chrome")))
                    {
                        ChromeOptions options = new ChromeOptions();
                        options.AddArguments("--start-maximized");
                        IWebDriver driver3 = new ChromeDriver(options);
                        Drivers.Add("Chrome", driver3);
                        break;
                    }
                    break;

            }
        }

        public IWebDriver retuenDriver(string browserName)
        {
            return this.drivers[browserName];
        }

        public void CloseAllDrivers()
        {
            foreach (var key in drivers.Keys)
            {
                drivers[key].Close();
                drivers[key].Quit();
            }
        }
    }
}
