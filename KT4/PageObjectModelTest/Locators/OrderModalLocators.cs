using OpenQA.Selenium;

namespace KT4PageObjectModelTest.Locators
{
    public static class OrderModalLocators
    {
        public static readonly By NameField = By.Id("name");
        public static readonly By CountryField = By.Id("country");
        public static readonly By CityField = By.Id("city");
        public static readonly By CardField = By.Id("card");
        public static readonly By MonthField = By.Id("month");
        public static readonly By YearField = By.Id("year");
        public static readonly By PurchaseButton = By.XPath("//button[text()='Purchase']");
        public static readonly By OkButton = By.XPath("//button[text()='OK']");
    }
}
