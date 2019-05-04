using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.PageObjects;

namespace TestClass
{
    public class MainTest
    {
        private static IWebDriver driver;
        private HomePage Home = new HomePage(driver);
        private HouseDetailsPage House = new HouseDetailsPage(driver);
        private RegistrationPage Registration = new RegistrationPage(driver);
        private ResultsPage Results = new ResultsPage(driver);
        private LoginPage Login = new LoginPage(driver);

        [SetUp]
        public void LoadDriver()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("--start-maximized");
            driver = new ChromeDriver(@"C:\ChromeDriver", options);
            driver.Navigate().GoToUrl("https://grup5web.firebaseapp.com");
            PageFactory.InitElements(driver, Home);
            PageFactory.InitElements(driver, House);
            PageFactory.InitElements(driver, Registration);
            PageFactory.InitElements(driver, Results);
            PageFactory.InitElements(driver, Login);
        }

        [Test]
        public void VerifyLikes()
        {
            Home.ClickRegister();
            Registration.FillForm("John", "Johnson", "04671633B", "04041983", "Calle feran", "Barcelona", "66078", "Spain", "545481970", "mail@gmail.com", "haimi1", "ITaly1900", "ITaly1900");
            Login.FillDetails("haimi", "Italy1900");
            driver.Navigate().GoToUrl("https://grup5web.firebaseapp.com/properties/properties.html?region=Navarra");
            Results.SelectMostExpensive();
            Results.SelectHouse();
            House.AddComment("Some comment");
            driver.Navigate().Back();
            Results.UpdatedLikes();
            int updatedLikes = Results.UpdatedLikes();
            Assert.AreEqual(1, updatedLikes);
        }

        [TearDown]
        public void UnloadDriver()
        {
            driver.Quit();
        }
    }
}
