using KT4PageObjectModelTest.Core;
using KT4PageObjectModelTest.Locators;
using OpenQA.Selenium;

namespace KT4PageObjectModelTest.UI.Models
{
    public class LoginModal : WebDriverHelper
    {
        public LoginModal(IWebDriver driver) : base(driver) { }
        public string? Login(string username, string password)
        {
            WaitForTheElement("logInModalLabel");
            driver.FindElement(LoginModalLocators.UsernameField).SendKeys(username);
            driver.FindElement(LoginModalLocators.PasswordField).SendKeys(password);
            Click(LoginModalLocators.SubmitButton);
            return GetAlertIfExists();
        }
    }
}
