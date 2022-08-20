using DocumentFormat.OpenXml.Drawing;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using TechTalk.SpecFlow;
using WebDriverManager.DriverConfigs.Impl;

namespace SeleniumMyEnterprise.StepDefinitions
{
    [Binding]
    public class PrintAllTableValueForW3SchoolPortalStepDef
    {

        public IWebDriver driver;
        String strRowData = "";

        [Given(@"User is on the given URL page")]
        public void GivenUserIsOnTheGivenURLPage()
        {

            
            ChromeOptions option = new ChromeOptions();
            option.AddArguments("--headless");
            new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
            
            driver = new ChromeDriver(option);
            driver.Url = "https://www.w3schools.com/html/html_tables.asp";
            driver.Manage().Window.Maximize();

            driver.FindElement(By.XPath("//div[@id='accept-choices']")).Click();

            
            
            
        }

        [When(@"User get table data from given page")]
        public void WhenUserGetTableDataFromGivenPage()
        {

            IWebElement tableElem = driver.FindElement(By.XPath("//table[@id='customers']"));

            List<IWebElement> tableRawElem = new List<IWebElement>(tableElem.FindElements(By.TagName("tr")));

            

            foreach (IWebElement rowElem in tableRawElem)
            {

                List<IWebElement> listtdElem = new List<IWebElement>(rowElem.FindElements(By.TagName("td")));

                foreach (IWebElement tdElem in listtdElem)
                {
                    strRowData = strRowData + tdElem.Text + "\t\t";
                }

            }

            Console.WriteLine(strRowData);

            //  tableElem.Text(FirstRow.Equals(strRowData.Contains("Alfreds")));

           

        }

        [Then(@"User is able to print all the table data")]
        public void ThenUserIsAbleToPrintAllTheTableData()
        {
            Boolean strData = strRowData.Contains("Alfreds");

            Console.WriteLine(strData);
            Assert.IsTrue(strData);
        }


    }
}
