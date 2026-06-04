using KT4PageObjectModelTest.Core;
using KT4PageObjectModelTest.Locators;
using OpenQA.Selenium;

namespace KT4PageObjectModelTest.UI.Pages
{
    public class MainPage : WebDriverHelper
    {
        public MainPage(IWebDriver driver) : base(driver) { }

        public void ClickLogin() => Click(MainLocators.LoginButton);
        public void ClickSignUp() => Click(MainLocators.SignUpButton);
        public void ClickCart() => Click(MainLocators.CartButton);
        public void ClickSamsungGalaxyS6() => Click(MainLocators.SamsungGalaxyS6);
    }
}