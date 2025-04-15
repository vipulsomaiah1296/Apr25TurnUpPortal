using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using System.Threading; // Added for Thread.Sleep

namespace Apr25TurnUpPortal
{
    public class TMPage
    {
        public static void CreateTimeRecord(IWebDriver driver)
        {
            //Click on Create New button
            IWebElement createNewButton = driver.FindElement(By.XPath("//*[@id=\"container\"]/p/a"));
            createNewButton.Click();

            //Select time from dropdown
            IWebElement typeCodeDropdown = driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[1]/div/span[1]/span/span[2]/span"));
            typeCodeDropdown.Click();

            IWebElement timeOption = driver.FindElement(By.XPath("//*[@id=\"TypeCode_listbox\"]/li[2]"));
            Thread.Sleep(2000);
            timeOption.Click();

            //Type code into code textbox 
            IWebElement codeTextBox = driver.FindElement(By.Id("Code"));
            codeTextBox.SendKeys("TA Programme");

            //Type description into description textbox 
            IWebElement descriptionTextBox = driver.FindElement(By.Id("Description"));
            descriptionTextBox.SendKeys("This is a description");

            //Type price into price textbox 
            IWebElement priceTagOverlap = driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[1]/div/span[2]/span/input[1]"));
            priceTagOverlap.Click();

            IWebElement priceTextBox = driver.FindElement(By.Id("Price"));
            priceTextBox.SendKeys("12");

            //Click on save button
            IWebElement saveButton = driver.FindElement(By.Id("SaveButton"));
            saveButton.Click();
            Thread.Sleep(2000);

            //Check if the Time record is created successfully
            IWebElement goToLastPageButton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span"));
            goToLastPageButton.Click();

            IWebElement newCode = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));

            if (newCode.Text == "TA Programme")
            {
                Console.WriteLine("Time record created successfully");
            }
            else
            {
                Console.WriteLine("Time record not created");
            }
        }

        public static void EditTimeRecord(IWebDriver driver)
        {
            //Click on Edit button
            IWebElement editButton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[5]/a[1]"));
            editButton.Click();
            //Edit description
            IWebElement descriptionTextBox = driver.FindElement(By.Id("Description"));
            descriptionTextBox.Clear();
            descriptionTextBox.SendKeys("This is an edited description");
            //Click on save button
            IWebElement saveButton = driver.FindElement(By.Id("SaveButton"));
            saveButton.Click();
            Thread.Sleep(2000);
            //Check if the Time record is edited successfully
            IWebElement newDescription = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[2]"));
            if (newDescription.Text == "This is an edited description")
            {
                Console.WriteLine("Time record edited successfully");
            }
            else
            {
                Console.WriteLine("Time record not edited");
            }
        }

        public static void DeleteTimeRecord(IWebDriver driver)
        {
            //Click on Delete button
            IWebElement deleteButton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[5]/a[2]"));
            deleteButton.Click();
            Thread.Sleep(2000);
            //Click on Yes button
            IWebElement yesButton = driver.FindElement(By.XPath("/html/body/div[6]/div[7]/div/button[1]"));
            yesButton.Click();
            Thread.Sleep(2000);
            //Check if the Time record is deleted successfully
        }
    }
}