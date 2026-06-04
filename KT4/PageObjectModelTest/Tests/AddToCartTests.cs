using KT4PageObjectModelTest.Core;
using KT4PageObjectModelTest.UI.Pages;
using OpenQA.Selenium;

namespace KT4PageObjectModelTest.Tests
{
    public class AddToCartTests
    {
        [Fact]
        [Trait("Category", "AddToCart")]
        public void AddSamsungGalaxyS6ToCart()
        {
            using IWebDriver driver = WebDriverFactory.CreateDriver();
            driver.Navigate().GoToUrl("https://www.demoblaze.com/");

            MainPage mainPage = new MainPage(driver);
            ProductPage productPage = new ProductPage(driver);

            mainPage.ClickSamsungGalaxyS6();
            string? result = productPage.AddToCartAndGetAlert();

            Assert.Contains("Product added", result);
        }
    }
}