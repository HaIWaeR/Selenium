using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace KT2Registration
{
    public class Program
    {
        static void Main(string[] args)
        {
            TestSuccessfulRegistration();
            TestFailedRegistration();
            TestSuccessfulLogin();
            TestFailedLogin();
            TestAddToCart();
        }

        static void TestSuccessfulRegistration()
        {
            IWebDriver driver = new ChromeDriver();
            try
            {
                driver.Navigate().GoToUrl("https://www.demoblaze.com/");
                string user = "user_" + Guid.NewGuid().ToString().Substring(0, 8);

                driver.FindElement(By.Id("signin2")).Click();

                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
                wait.Until(d => d.FindElement(By.Id("sign-username")).Displayed);

                driver.FindElement(By.Id("sign-username")).SendKeys(user);
                driver.FindElement(By.Id("sign-password")).SendKeys("password123");
                driver.FindElement(By.XPath("//button[contains(text(),'Sign up')]")).Click();

                Console.WriteLine("Тест регистрации пройден успешно.");
            }
            catch (Exception ex) { Console.WriteLine("Ошибка в регистрации: " + ex.Message); }
            finally
            {
                driver.Quit();
            }
        }
        static void TestFailedRegistration()
        {
            IWebDriver driver = new ChromeDriver();
            try
            {
                driver.Navigate().GoToUrl("https://www.demoblaze.com/");
                driver.FindElement(By.Id("signin2")).Click();

                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
                wait.Until(d => d.FindElement(By.Id("sign-username")).Displayed);

                driver.FindElement(By.Id("sign-username")).SendKeys("existing_user");
                driver.FindElement(By.Id("sign-password")).SendKeys("password123");
                driver.FindElement(By.XPath("//button[contains(text(),'Sign up')]")).Click();

                Console.WriteLine("Тест неуспешной регистрации выполнен.");
            }
            catch (Exception ex) { Console.WriteLine("Ошибка в неуспешной регистрации: " + ex.Message); }
            finally
            {
                driver.Quit();
            }
        }
        static void TestSuccessfulLogin()
        {
            IWebDriver driver = new ChromeDriver();
            try
            {
                driver.Navigate().GoToUrl("https://www.demoblaze.com/");
                driver.FindElement(By.Id("login2")).Click();

                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
                wait.Until(d => d.FindElement(By.Id("loginusername")).Displayed);

                driver.FindElement(By.Id("loginusername")).SendKeys("testuser");
                driver.FindElement(By.Id("loginpassword")).SendKeys("password123");
                driver.FindElement(By.XPath("//button[contains(text(),'Log in')]")).Click();

                Console.WriteLine("Тест успешного входа пройден.");
            }
            catch (Exception ex) { Console.WriteLine("Ошибка в успешном входе: " + ex.Message); }
            finally
            {
                driver.Quit();
            }
        }
        static void TestFailedLogin()
        {
            IWebDriver driver = new ChromeDriver();
            try
            {
                driver.Navigate().GoToUrl("https://www.demoblaze.com/");
                driver.FindElement(By.Id("login2")).Click();

                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
                wait.Until(d => d.FindElement(By.Id("loginusername")).Displayed);

                driver.FindElement(By.Id("loginusername")).SendKeys("wrong_user");
                driver.FindElement(By.Id("loginpassword")).SendKeys("wrong_pass");
                driver.FindElement(By.XPath("//button[contains(text(),'Log in')]")).Click();

                Console.WriteLine("Тест неуспешного входа выполнен.");
            }
            catch (Exception ex) { Console.WriteLine("Ошибка в неуспешном входе: " + ex.Message); }
            finally
            {
                driver.Quit();
            }
        }
        static void TestAddToCart()
        {
            IWebDriver driver = new ChromeDriver();
            try
            {
                driver.Navigate().GoToUrl("https://www.demoblaze.com/");
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));

                IWebElement product = wait.Until(d => d.FindElement(By.XPath("//a[@class='hrefch' and text()='Samsung galaxy s6']")));
                product.Click();

                var addToCartButton = wait.Until(d =>
                {
                    var element = d.FindElement(By.LinkText("Add to cart"));
                    return element.Displayed ? element : null;
                });

                addToCartButton.Click();

                wait.Until(d =>
                {
                    d.SwitchTo().Alert().Accept();
                    return true;
                });

                driver.FindElement(By.Id("cartur")).Click();

                wait.Until(d => d.FindElement(By.XPath("//button[text()='Place Order']")).Displayed);
                driver.FindElement(By.XPath("//button[text()='Place Order']")).Click();

                wait.Until(d => d.FindElement(By.Id("name")).Displayed);
                driver.FindElement(By.Id("name")).SendKeys("TestUser");
                driver.FindElement(By.Id("country")).SendKeys("1");
                driver.FindElement(By.Id("city")).SendKeys("spb");
                driver.FindElement(By.Id("card")).SendKeys("2202202");
                driver.FindElement(By.Id("month")).SendKeys("05.08");
                driver.FindElement(By.Id("year")).SendKeys("2027");
                driver.FindElement(By.XPath("//button[text()='Purchase']")).Click();

                wait.Until(d => d.FindElement(By.XPath("//button[text()='OK']")).Displayed);
                driver.FindElement(By.XPath("//button[text()='OK']")).Click();

                Console.WriteLine("Тест добавления в корзину пройден.");
            }
            catch (Exception ex) { Console.WriteLine("Ошибка в корзине: " + ex.Message); }
            finally
            {
                driver.Quit();
            }
        }
    }
}