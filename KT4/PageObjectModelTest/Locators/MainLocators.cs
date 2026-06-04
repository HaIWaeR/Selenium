using OpenQA.Selenium;

namespace KT4PageObjectModelTest.Locators
{
    public static class MainLocators
    {
        public static readonly By CartButton = By.Id("cartur");
        public static readonly By LoginButton = By.Id("login2");
        public static readonly By SignUpButton = By.Id("signin2");
        public static readonly By LogoutButton = By.Id("logout2");
        public static readonly By WelcomeUser = By.Id("nameofuser");
        public static readonly By SamsungGalaxyS6 = By.XPath("//a[text()='Samsung galaxy s6']");
    }
}
