using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amazon
{
    public class Item
    {
        private IWebDriver driver;
        private string title;
        private string price;
        private string link;
        public string Title
        {
            get { return this.title; }
            set { this.title = value;}
        }

        public string Price
        {
            get { return this.price; }
            set { this.price = value; }
        }
        public string Link
        {
            get { return this.link; }
            set { this.link = value; }
        }

        public Item(IWebDriver driver)
        {
            this.driver = driver;
        }
        //public Item(IWebDriver driver, IWebElement title, IWebElement link, IWebElement price)
        //{
        //    this.driver = driver;
        //    this.price = price.Text;
        //    this.link = link.Text;
        //    this.title = title.Text;




    }
}
