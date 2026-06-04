using KT4PageObjectModelTest.Core;
using KT4PageObjectModelTest.Locators;
using OpenQA.Selenium;

namespace KT4PageObjectModelTest.UI.Pages
{
    public class ProductPage : WebDriverHelper
    {
        public ProductPage(IWebDriver driver) : base(driver) { }

        public void AddToCart() => Click(ProductLocators.AddToCartButton);
        public string? AddToCartAndGetAlert()
        {
            Click(ProductLocators.AddToCartButton);
            return GetAlertIfExists();
        }
    }
}
