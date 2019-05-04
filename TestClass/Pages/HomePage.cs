using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace TestClass
{
    public class HomePage
    {
        private IWebDriver driver;

        [FindsBy(How = How.ClassName, Using = "ion-person-add")]
        public IWebElement registerButton;

        [FindsBy(How = How.ClassName, Using = "ion-log-in")]
        public IWebElement loginButton;

        public HomePage (IWebDriver driver)
        {
            this.driver = driver;
        }

        public void ClickRegister()
        {
            registerButton.Click();
        }
    }
}
