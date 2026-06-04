using KT4PageObjectModelTest.Core;
using KT4PageObjectModelTest.Locators;
using OpenQA.Selenium;

namespace KT4PageObjectModelTest
{
    public class SignUpModal : WebDriverHelper
    {
        public SignUpModal(IWebDriver driver) : base(driver) { }
        public string? SignUp(string username, string password)
        {
            WaitForTheElement("signInModalLabel");
            driver.FindElement(SignUpModalLocators.UsernameField).SendKeys(username);
            driver.FindElement(SignUpModalLocators.PasswordField).SendKeys(password);
            Click(SignUpModalLocators.SignUpButton);
            return GetAlertIfExists();
        }
    }
}