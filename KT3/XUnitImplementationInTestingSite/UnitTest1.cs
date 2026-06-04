using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Runtime.InteropServices;

namespace KT3xUnitImplementationInTestingSite
{
    public class WebShopScenarios : IDisposable
    {
        private readonly IWebDriver driver;
        private readonly WebDriverWait wait;

        public WebShopScenarios()
        {
            driver = new ChromeDriver();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
        }

        public void Dispose() { driver.Quit(); }

        [Fact]
        [Trait("Category", "Registration")]
        public void TestSuccessfulRegistration()
        {
            driver.Navigate().GoToUrl("https://www.demoblaze.com/");
            string user = "user_" + Guid.NewGuid().ToString().Substring(0, 8);

            driver.FindElement(By.Id("signin2")).Click();
            wait.Until(d => d.FindElement(By.Id("sign-username")).Displayed);

            driver.FindElement(By.Id("sign-username")).SendKeys(user);
            driver.FindElement(By.Id("sign-password")).SendKeys("password123");
            driver.FindElement(By.XPath("//button[contains(text(),'Sign up')]")).Click();

            var alert = wait.Until(d =>
            {
                try { return d.SwitchTo().Alert(); }
                catch { return null; }
            });

            Assert.NotNull(alert);
            Console.WriteLine(alert.Text);
            Assert.Contains("Sign up successful.", alert.Text);
        }

        [Fact]
        [Trait("Category", "FailedRegistration")]
        public void TestFailedRegistration()
        {
            driver.Navigate().GoToUrl("https://www.demoblaze.com/");
            driver.FindElement(By.Id("signin2")).Click();

            wait.Until(d => d.FindElement(By.Id("sign-username")).Displayed);
            driver.FindElement(By.Id("sign-username")).SendKeys("existing_user");
            driver.FindElement(By.Id("sign-password")).SendKeys("password123");
            driver.FindElement(By.XPath("//button[contains(text(),'Sign up')]")).Click();

            var alert = wait.Until(d =>
            {
                try { return d.SwitchTo().Alert(); }
                catch { return null; }
            });

            Assert.NotNull(alert);
            Assert.Contains("This user already exist.", alert.Text);
        }

        [Fact]
        [Trait("Category", "Login")]
        public void TestSuccessfulLogin()
        {
            driver.Navigate().GoToUrl("https://www.demoblaze.com/");
            driver.FindElement(By.Id("login2")).Click();
            wait.Until(d => d.FindElement(By.Id("loginusername")).Displayed);

            driver.FindElement(By.Id("loginusername")).SendKeys("haiwaer");
            driver.FindElement(By.Id("loginpassword")).SendKeys("123321");
            driver.FindElement(By.XPath("//button[contains(text(),'Log in')]")).Click();

            wait.Until(d => d.FindElement(By.Id("nameofuser")).Displayed);
            var userNameElement = driver.FindElement(By.Id("nameofuser"));

            Assert.Contains("Welcome haiwaer", userNameElement.Text);

        }

        [Fact]
        [Trait("Category", "FailedLogin")]
        public void TestFailedLogin()
        {
            driver.Navigate().GoToUrl("https://www.demoblaze.com/");
            driver.FindElement(By.Id("login2")).Click();
            wait.Until(d => d.FindElement(By.Id("loginusername")).Displayed);

            driver.FindElement(By.Id("loginusername")).SendKeys("wrong_user");
            driver.FindElement(By.Id("loginpassword")).SendKeys("wrong_pass");
            driver.FindElement(By.XPath("//button[contains(text(),'Log in')]")).Click();
            Assert.True(true);


            var alert = wait.Until(d =>
            {
                try { return d.SwitchTo().Alert(); }
                catch { return null; }
            });

            Assert.NotNull(alert);
            Assert.Contains("Wrong password.", alert.Text);
        }

        [Fact]
        [Trait("Category", "AddToCart")]
        public void TestAddToCart()
        {
            driver.Navigate().GoToUrl("https://www.demoblaze.com/");

            var product = wait.Until(d => d.FindElement(By.LinkText("Samsung galaxy s6")));
            product.Click();

            wait.Until(d => d.FindElement(By.LinkText("Add to cart"))).Click();

            var alert = wait.Until(d =>
            {
                try { return d.SwitchTo().Alert(); }
                catch { return null; }
            });
            alert.Accept();

            wait.Until(d => d.FindElement(By.Id("cartur")).Enabled);
            driver.FindElement(By.Id("cartur")).Click();

            wait.Until(d => d.FindElement(By.XPath("//tbody[@id='tbodyid']/tr[td[text()='Samsung galaxy s6']]")));
            wait.Until(d => d.FindElement(By.XPath("//button[text()='Place Order']"))).Click();
            wait.Until(d => d.FindElement(By.Id("orderModal")).Displayed);

            wait.Until(d => d.FindElement(By.Id("name"))).SendKeys("TestUser");
            driver.FindElement(By.Id("country")).SendKeys("1");
            driver.FindElement(By.Id("city")).SendKeys("spb");
            driver.FindElement(By.Id("card")).SendKeys("2202202");
            driver.FindElement(By.Id("month")).SendKeys("05.08");
            driver.FindElement(By.Id("year")).SendKeys("2027");

            driver.FindElement(By.XPath("//button[text()='Purchase']")).Click();


            wait.Until(d => d.FindElement(By.XPath("//button[text()='OK']")).Displayed);
            var userNameElement = driver.FindElement(By.XPath("//button[text()='OK']"));
            Assert.Contains("OK", userNameElement.Text);

        }
    }
}