using KT4PageObjectModelTest.Core;
using KT4PageObjectModelTest.UI.Models;
using KT4PageObjectModelTest.UI.Pages;
using OpenQA.Selenium;

namespace KT4PageObjectModelTest.Tests
{
    public class LoginTests
    {
        [Fact]
        [Trait("Category", "SuccessfulLogin")]
        public void SuccessfulLogin()
        {
            using IWebDriver driver = WebDriverFactory.CreateDriver();
            driver.Navigate().GoToUrl("https://www.demoblaze.com/");
            MainPage mainPage = new MainPage(driver);
            LoginModal loginModal = new LoginModal(driver);

            mainPage.ClickLogin();
            Assert.Null(loginModal.Login("haiwaer", "123321"));
        }

        [Fact]
        [Trait("Category", "FailedLogin")]
        public void FailedLogin_WrongPassword()
        {
            using IWebDriver driver = WebDriverFactory.CreateDriver();
            driver.Navigate().GoToUrl("https://www.demoblaze.com/");
            MainPage mainPage = new MainPage(driver);
            LoginModal loginModal = new LoginModal(driver);

            mainPage.ClickLogin();
            Assert.Contains("Wrong password.", loginModal.Login("haiwaer", "parolcotorinevozmojnovzlomat14!z"));
        }
    }
}