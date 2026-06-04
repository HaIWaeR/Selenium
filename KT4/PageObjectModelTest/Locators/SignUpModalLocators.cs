using OpenQA.Selenium;

namespace KT4PageObjectModelTest.Locators
{
    public static class SignUpModalLocators
    {
        public static readonly By ModalLabel = By.Id("signInModalLabel");
        public static readonly By UsernameField = By.Id("sign-username");
        public static readonly By PasswordField = By.Id("sign-password");
        public static readonly By SignUpButton = By.XPath("//button[contains(text(),'Sign up')]");
    }
}
