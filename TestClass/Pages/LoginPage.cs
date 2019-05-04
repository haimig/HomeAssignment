using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace TestClass
{
    public class LoginPage
    {
        private IWebDriver driver;

        [FindsBy(How = How.Id, Using = "username")]
        public IWebElement username;

        [FindsBy(How = How.Id, Using = "password")]
        public IWebElement password;

        [FindsBy(How = How.XPath, Using = "//*[@id='loginForm']/div[3]/input")]
        public IWebElement loginButton;

        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void FillDetails(String sUsername, String sPassword)
        {
            username.SendKeys(sUsername);
            password.SendKeys(sPassword);
            loginButton.Click();
        }
    }
}
