using KT4PageObjectModelTest.Core;
using KT4PageObjectModelTest.UI.Pages;
using OpenQA.Selenium;

namespace KT4PageObjectModelTest.Tests
{
    public class SignUpTests
    {
        [Fact]
        [Trait("Category", "SuccessfulSignUp")]
        public void SuccessfulSignUp()
        {
            using IWebDriver driver = WebDriverFactory.CreateDriver();
            driver.Navigate().GoToUrl("https://www.demoblaze.com/");
            MainPage mainPage = new MainPage(driver);
            SignUpModal signUpModal = new SignUpModal(driver);

            mainPage.ClickSignUp();
            string randomUser = "user_" + Guid.NewGuid().ToString().Substring(0, 8);
            Assert.Contains("Sign up successful.", signUpModal.SignUp(randomUser, "123321"));
        }

        [Fact]
        [Trait("Category", "FailedSignUp")]
        public void FailedSignUp_UserAlreadyExists()
        {
            using IWebDriver driver = WebDriverFactory.CreateDriver();
            driver.Navigate().GoToUrl("https://www.demoblaze.com/");
            MainPage mainPage = new MainPage(driver);
            SignUpModal signUpModal = new SignUpModal(driver);

            mainPage.ClickSignUp();
            Assert.Contains("This user already exist.", signUpModal.SignUp("haiwaer", "123321"));
        }
    }
}