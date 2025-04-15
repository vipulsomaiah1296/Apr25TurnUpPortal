using System;
using OpenQA.Selenium;
using System.Threading;
using OpenQA.Selenium.Support.UI;

namespace Apr25TurnUpPortal
{
    public class LoginPage
    {
        // Functions that allow us to login to Turnup portal
        public static void LoginActions(IWebDriver driver)
        {
            try
            {
                // Launch Turnup portal
                driver.Navigate().GoToUrl("http://horse.industryconnect.io/");
                driver.Manage().Window.Maximize();

                // Wait for page to load 
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementsVisble(By.Id("UserName")));

                // Identify username textbox and enter valid username
                IWebElement usernameTextbox = wait.Until(d => d.FindElement(By.Id("UserName")));
                usernameTextbox.Clear();
                usernameTextbox.SendKeys("hari");
                WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementsVisible(By.Id("Username")));


                // Identify password textbox and enter valid password
                IWebElement passwordTextbox = driver.FindElement(By.Id("Password"));
                passwordTextbox.Clear();
                passwordTextbox.SendKeys("123123");

                // Identify login button and click on it
                IWebElement loginButton = driver.FindElement(By.XPath("//*[@id=\"loginForm\"]/form/div[3]/input[1]"));
                loginButton.Click();

                // Wait for login to complete
                wait.Until(d => d.FindElement(By.Id("logoutForm")));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Login failed: {ex.Message}");
                throw;
            }
        }
    }
}