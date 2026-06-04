using KT4PageObjectModelTest.Core;
using KT4PageObjectModelTest.UI.Modals;
using KT4PageObjectModelTest.UI.Pages;
using OpenQA.Selenium;

namespace KT4PageObjectModelTest.Tests
{
    public class PurchaseTests
    {
        [Fact]
        [Trait("Category", "Purchase")]
        public void CompletePurchaseOrder()
        {
            using IWebDriver driver = WebDriverFactory.CreateDriver();
            driver.Navigate().GoToUrl("https://www.demoblaze.com/");
            MainPage mainPage = new MainPage(driver);
            ProductPage productPage = new ProductPage(driver);
            CartPage cartPage = new CartPage(driver);
            OrderModal orderModal = new OrderModal(driver);

            mainPage.ClickSamsungGalaxyS6();
            productPage.AddToCart();
            mainPage.ClickCart();
            cartPage.ClickPlaceOrder();

            bool isOrderCreated = orderModal.CompleteOrder(
                "Test User",
                "USA",
                "New York",
                "1234567890123456",
                "12",
                "2025"
            );

            Assert.True(isOrderCreated);
        }
    }
}