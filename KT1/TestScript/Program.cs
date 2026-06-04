using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Collections.ObjectModel;

namespace TestScript
{
    public class Program
    {
        static void Main(string[] args)
        {
            IWebDriver driver = new ChromeDriver();

            try
            {
                string url = "https://suninjuly.github.io/redirect_accept";
                driver.Navigate().GoToUrl(url);

                driver.FindElement(By.TagName("button")).Click();

                ReadOnlyCollection<string> allTabs = driver.WindowHandles;
                driver.SwitchTo().Window(allTabs[1]);

                string textValue = driver.FindElement(By.Id("input_value")).Text;
                int x = int.Parse(textValue);

                double result = Math.Log(Math.Abs(12 * Math.Sin(x)));

                IWebElement inputEl = driver.FindElement(By.Id("answer"));
                inputEl.SendKeys(result.ToString());

                driver.FindElement(By.TagName("button")).Click();
            }
            finally
            {
                driver.Quit();
            }
        }
    }
}