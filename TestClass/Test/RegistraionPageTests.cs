using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.PageObjects;

namespace TestClass.Test
{
    class RegistraionPageTests
    {
        private static IWebDriver driver;
        private RegistrationPage Registration = new RegistrationPage(driver);
        private string invalidZipCodeMessage = "El código postal tiene que tener una longitud de 5 números";
        private string invalidDNIMessage = "Debe introducir un DNI válido.";
        private string mismatchPasswordsMessage = "No coinciden las contraseñas.";

        [SetUp]
        public void LoadDriver()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("--start-maximized");
            driver = new ChromeDriver(@"C:\ChromeDriver", options);
            driver.Navigate().GoToUrl("https://grup5web.firebaseapp.com/register/register.html");
            PageFactory.InitElements(driver, Registration);
        }

        [Test]
        public void InvalidZipCodeLength()
        {
            Registration.FillForm("John", "Johnson", "04671633B", "04041983", "Calle feran", "Barcelona", "6607897", "Spain", "545481970", "mail@gmail.com", "haimi1", "ITaly1900", "ITaly1900");
            Assert.IsTrue((Registration.ErrorMessage()).Contains(invalidZipCodeMessage));
        }

        [Test]
        public void InvalidDNI()
        {
            Registration.FillForm("John", "Johnson", "12345677A", "04041983", "Calle feran", "Barcelona", "66078", "Spain", "545481970", "mail@gmail.com", "haimi1", "ITaly1900", "ITaly1900");
            Assert.IsTrue((Registration.ErrorMessage()).Contains(invalidDNIMessage));
        }

        [Test]
        public void InvalidEmail()
        {
            Registration.FillForm("John", "Johnson", "04671633B", "04041983", "Calle feran", "Barcelona", "66078", "Spain", "545481970", "mail@gmail", "haimi1", "ITaly1900", "ITaly1900");
            Assert.IsTrue((Registration.email).Equals(driver.SwitchTo().ActiveElement()));
        }

        [Test]
        public void EmptyNameField()
        {
            Registration.FillForm("", "Johnson", "04671633B", "04041983", "Calle feran", "Barcelona", "66078", "Spain", "545481970", "mail@gmail.com", "haimi1", "ITaly1900", "ITaly1900");
            Assert.IsTrue((Registration.name).Equals(driver.SwitchTo().ActiveElement()));
        }

        [Test]
        public void MismatchPasswords()
        {
            Registration.FillForm("John", "Johnson", "04671633B", "04041983", "Calle feran", "Barcelona", "66078", "Spain", "545481970", "mail@gmail.com", "haimi1", "ITaly1900", "ITaly190");
            Assert.IsTrue((Registration.ErrorMessage()).Contains(mismatchPasswordsMessage));
        }

        [TearDown]
        public void UnloadDriver()
        {
            driver.Quit();
        }
    }
}
