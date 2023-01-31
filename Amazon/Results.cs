using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V109.Page;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Amazon
{
    public class Results
    {


        private IWebDriver driver;
        private List<Item> items = new List<Item>();


        public Results(IWebDriver driver)
        {

            this.driver = driver;


        }
        /*
         * A function that receives a dictionary of filters
         * and returns a list of products that meet the criteria requested in the dictionary
         */
        public List<Item> GetResultBy(Dictionary<string, string> filters)
        {
            //root of xpath
            string xp = "//*[@data-component-type='s-search-result'";
            foreach (KeyValuePair<string, string> filter in filters)
            {
                switch (filter.Key)
                {
                    case "price_low_then":
                        string price = filters["price_low_then"];
                        xp += string.Format("and translate(descendant::span[@class = 'a-offscreen']//.,'$', '') < {0} ", price);
                        break;
                    case "price_higer_or_equal":
                        string price1 = filters["price_higer_or_equal"];
                        xp += string.Format("and translate(descendant::span[@class = 'a-offscreen']//.,'$', '')>={0} ", price1);
                        break;
                    case "free_shipping":
                        if (filters["free_shipping"].ToLower()=="true")
                        {
                            xp += "and descendant::span[@class='a-color-base a-text-bold']//text() ='FREE Shipping '";
                        }
                        else
                        {
                            xp += "and not (descendant::span[@class='a-color-base a-text-bold']//text() ='FREE Shipping ')";
                        }
                        break;
                    default:
                        Console.WriteLine("There is no option like this : " + filter.Key.ToString());
                        break;

                }
            }
            //close the xpath string
            xp += "]";
            //get list of filter elements
            var products = driver.FindElements(By.XPath(xp));
            //in this loop i create instance of item object , set her properties add the item into list
            foreach (var product in products)
            {
                Item item = new Item(this.driver);
                item.Title = product.FindElement(By.TagName("h2")).Text;
                item.Link = product.FindElement(By.TagName("a")).GetAttribute("href");
                item.Price = product.FindElement(By.ClassName("a-offscreen")).GetAttribute("textContent");



                items.Add(item);
            }
            //return the list of item
            return items;
        }
    }
 }


