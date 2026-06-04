using KT4PageObjectModelTest.Core;
using KT4PageObjectModelTest.Locators;
using OpenQA.Selenium;

namespace KT4PageObjectModelTest.UI.Pages
{
    public class CartPage : WebDriverHelper
    {
        public CartPage(IWebDriver driver) : base(driver) { }
        public void ClickPlaceOrder() => Click(CartLocators.PlaceOrderButton);
    }
}