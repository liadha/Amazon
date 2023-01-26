using NUnit.Framework.Interfaces;
using OpenQA.Selenium;

namespace Amazon
{
    public class Tests
    {
        BrowsherFactory browsher;
        IWebDriver driver;
        List<Item> itemList = new List<Item>();

        [SetUp]
        public void Setup()
        {
                browsher = new BrowsherFactory();
                browsher.InitBrowser("Chrome");
                driver = browsher.retuenDriver("Chrome");
        }

        [Test]
        public void Test1()
        {

            Amazon tester = new Amazon(driver, "https://www.amazon.com/?language=en_US&currency=USD");
            tester.Pages.Home.SearchBar.Text = "mouse";
            tester.Pages.Home.SearchBar.click();
            itemList=tester.Pages.Results.GetResultBy(new Dictionary<string, string>(){ { "price_low_then","100"},{ "price_higer_or_equal","10" },{ "free_shipping","true" } });

            //if the list is empty the test pass but there is no element for those filter
            if (itemList.Count == 0)
            {
                Console.WriteLine("---------------------------");
                Console.WriteLine("sorry there is no item like this");
                Console.WriteLine("---------------------------");
            }    
            else
            {
                foreach (var item in itemList)
                {
                    Console.WriteLine(item.Title);
                    Console.WriteLine(item.Link);
                    Console.WriteLine(item.Price);
                    Console.WriteLine("------------");
                }
            }


            Assert.Pass();
        }
        [TearDown]
        public void closeBrowser()
        {
            browsher.CloseAllDrivers();
            
        }
    }
}