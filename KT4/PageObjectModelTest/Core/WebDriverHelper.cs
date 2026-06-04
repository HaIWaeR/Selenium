using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace KT4PageObjectModelTest.Core
{
    public class WebDriverHelper
    {
        protected IWebDriver driver;
        protected WebDriverWait wait;
        public WebDriverHelper(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
        }
        public void WaitForTheElement(string nameUnit)
        {
            if (nameUnit.Contains("//"))
                wait.Until(d => d.FindElement(By.XPath(nameUnit)).Displayed);
            else
                wait.Until(d => d.FindElement(By.Id(nameUnit)).Displayed);
        }
        public void Click(By locator)
        {
            wait.Until(d => d.FindElement(locator).Displayed);
            driver.FindElement(locator).Click();
        }
        public string? GetAlertIfExists()
        {
            try
            {
                var alert = new WebDriverWait(driver, TimeSpan.FromSeconds(2))
                    .Until(d => d.SwitchTo().Alert());
                string? text = alert.Text;
                alert.Accept();
                return text;
            }
            catch (WebDriverTimeoutException)
            {
                return null;
            }
        }
    }
}