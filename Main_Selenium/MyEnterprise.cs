using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager.DriverConfigs.Impl;

namespace SeleniumMyEnterprise.Main_Selenium
{
    internal class MyEnterprise
    {
        IWebDriver driver;
        [SetUp]

        public void startBrowser()
        {
            new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();

        }
        [Test]

        public void MySelenium()
        {
            driver.Url = "https://www.w3schools.com/html/html_tables.asp";

            driver.FindElement(By.XPath("//div[@id='accept-choices']")).Click();


            IWebElement tableElem =  driver.FindElement(By.XPath("//table[@id='customers']"));

            List<IWebElement> tableRawElem = new List<IWebElement>(tableElem.FindElements(By.TagName("tr")));

            String strRowData = "";

            foreach (IWebElement rowElem in tableRawElem)
            {

                List<IWebElement> listtdElem = new List<IWebElement> (rowElem.FindElements(By.TagName("td")));

                foreach(IWebElement tdElem in listtdElem)
                {
                    strRowData = strRowData + tdElem.Text + "\t\t";
                }

            }

            Console.WriteLine(strRowData);


                   }

        [TearDown]

        public void closeBrowser()
        {
               driver.Close();
        }

    }
}
