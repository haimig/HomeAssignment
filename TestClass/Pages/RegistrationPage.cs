using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace TestClass
{
    public class RegistrationPage
    {
        private IWebDriver driver;

        [FindsBy(How = How.Id, Using = "name")]
        public IWebElement name;

        [FindsBy(How = How.Id, Using = "lastname")]
        public IWebElement lastName;

        [FindsBy(How = How.Id, Using = "dni")]
        public IWebElement dni;

        [FindsBy(How = How.Id, Using = "birthdate")]
        public IWebElement birthDate;

        [FindsBy(How = How.Id, Using = "address")]
        public IWebElement address;

        [FindsBy(How = How.Id, Using = "city")]
        public IWebElement city;

        [FindsBy(How = How.Id, Using = "zipcode")]
        public IWebElement zipCode;

        [FindsBy(How = How.Id, Using = "country")]
        public IWebElement country;

        [FindsBy(How = How.Id, Using = "phone")]
        public IWebElement phone;

        [FindsBy(How = How.Id, Using = "email")]
        public IWebElement email;

        [FindsBy(How = How.Id, Using = "username")]
        public IWebElement userName;

        [FindsBy(How = How.Id, Using = "password")]
        public IWebElement password;

        [FindsBy(How = How.Id, Using = "verifyPassword")]
        public IWebElement verifyPassword;

        [FindsBy(How = How.XPath, Using = "//*[@id='registerForm']/div[14]/input")]
        public IWebElement submitButton;

        [FindsBy(How = How.Id, Using = "errorMessage")]
        public IWebElement errorMessage;

        public RegistrationPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void FillForm(string sName, string sLastName, string sDni,string sBirthDate, string sAddress, string sCity, string sZipCode, string sCountry, string sPhone, string sEmail, string sUserName, string sPassword, string sConfirmPassword)
        {
            name.SendKeys(sName);
            lastName.SendKeys(sLastName);
            dni.SendKeys(sDni);
            birthDate.SendKeys(sBirthDate);
            address.SendKeys(sAddress);
            city.SendKeys(sCity);
            zipCode.SendKeys(sZipCode);
            country.SendKeys(sCountry);
            phone.SendKeys(sPhone);
            email.SendKeys(sEmail);
            userName.SendKeys(sUserName);
            password.SendKeys(sPassword);
            verifyPassword.SendKeys(sConfirmPassword);
            submitButton.Click();
        }

        public string ErrorMessage()
        {
            string errorMessageText = errorMessage.Text;
            return errorMessageText;
        }

    }
}
