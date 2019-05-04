using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace TestClass
{
    public class HouseDetailsPage
    {
        private IWebDriver driver;

        [FindsBy(How = How.Id, Using = "comments")]
        public IWebElement comments;

        [FindsBy(How = How.Id, Using = "likes")]
        public IWebElement likes;

        [FindsBy(How = How.XPath, Using = "//*[@id='peopleComments']/div[2]/input")]
        public IWebElement sendButton;

        public HouseDetailsPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void AddComment(String sComment)
        {
            comments.SendKeys(sComment);
            sendButton.Click();
        }
    }
}
