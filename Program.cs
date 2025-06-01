using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

class CloudQAAutomation
{
    static void Main(string[] args)
    {
        IWebDriver driver = new ChromeDriver();
        driver.Navigate().GoToUrl("https://app.cloudqa.io/home/AutomationPracticeForm");
        driver.Manage().Window.Maximize();

        WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));

        try
        {
            IWebElement firstName = wait.Until(d => d.FindElement(By.Id("fname")));
            firstName.Clear();
            firstName.SendKeys("Kiran");

            IWebElement maleRadio = wait.Until(d => d.FindElement(By.Id("male")));
            maleRadio.Click();

            IWebElement dob = wait.Until(d => d.FindElement(By.Id("dob")));
            dob.Clear();
            dob.SendKeys("2003-11-12"); // YYYY-MM-DD format

            Console.WriteLine("✅ Test passed: All fields filled successfully.");
            Thread.Sleep(3000);
        }
        catch (Exception ex)
        {
            Console.WriteLine("❌ Test failed: " + ex.Message);
        }
        finally
        {
            //driver.Quit();
            Console.WriteLine("Press any key to close the browser...");
            Console.ReadKey();
            driver.Quit();
        }
    }
}
