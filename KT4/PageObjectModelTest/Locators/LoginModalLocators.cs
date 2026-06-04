using OpenQA.Selenium;

namespace KT4PageObjectModelTest.Locators
{
    public static class LoginModalLocators
    {
        public static readonly By ModalLabel = By.Id("logInModalLabel");
        public static readonly By UsernameField = By.Id("loginusername");
        public static readonly By PasswordField = By.Id("loginpassword");
        public static readonly By SubmitButton = By.XPath("//button[contains(text(),'Log in')]");
    }
}
