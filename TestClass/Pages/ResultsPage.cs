using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support.PageObjects;


namespace TestClass
{
    public class ResultsPage
    {
        private IWebDriver driver;

        [FindsBy(How = How.Id, Using = "filter")]
        public IWebElement filter;

        [FindsBy(How = How.Id, Using = "innerDiv-9")]
        public IWebElement mostExpensiveHouse;

        [FindsBy(How = How.Id, Using = "likes-9")]
        public IWebElement updatedLikes;

        public int UpdatedLikes()
        {
            string numOfUpdatedLikes = updatedLikes.Text;
            numOfUpdatedLikes = numOfUpdatedLikes.Substring(0,1);
            int result = Int32.Parse(numOfUpdatedLikes);
            return result;
        }

        public ResultsPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void SelectMostExpensive()
        {
            SelectElement dropdown = new SelectElement(filter);
            dropdown.SelectByValue("mostExpensive");
        }

        public void SelectHouse()
        {
            mostExpensiveHouse.Click();
        }

    }
}
