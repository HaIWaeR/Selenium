using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace KT4PageObjectModelTest.Core
{
    public class WebDriverFactory
    {
        public static IWebDriver CreateDriver()
        {
            var driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(5);
            return driver;
        }
    }
}
