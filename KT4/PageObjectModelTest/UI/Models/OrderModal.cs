using KT4PageObjectModelTest.Core;
using KT4PageObjectModelTest.Locators;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace KT4PageObjectModelTest.UI.Modals
{
    public class OrderModal : WebDriverHelper
    {
        public OrderModal(IWebDriver driver) : base(driver) { }
        public bool CompleteOrder(string name, string country, string city, string card, string month, string year)
        {
            WaitForTheElement("orderModal");
            driver.FindElement(OrderModalLocators.NameField).SendKeys(name);
            driver.FindElement(OrderModalLocators.CountryField).SendKeys(country);
            driver.FindElement(OrderModalLocators.CityField).SendKeys(city);
            driver.FindElement(OrderModalLocators.CardField).SendKeys(card);
            driver.FindElement(OrderModalLocators.MonthField).SendKeys(month);
            driver.FindElement(OrderModalLocators.YearField).SendKeys(year);
            Click(OrderModalLocators.PurchaseButton);

            try
            {
                Click(OrderModalLocators.OkButton);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}