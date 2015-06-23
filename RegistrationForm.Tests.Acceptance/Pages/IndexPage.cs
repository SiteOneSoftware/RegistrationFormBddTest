using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace RegistrationForm.Tests.Acceptance.Pages
{
    public class IndexPage : BasePage
    {
        public static string Url = "/";

        [FindsBy(How = How.Id, Using = "loginLink")]
        public IWebElement LoginButton;

        [FindsBy(How = How.Id, Using = "registerLink")]
        public IWebElement RegisterButton;

        [FindsBy(How = How.LinkText, Using = "Log off")]
        public IWebElement LogoutButton;

        public override string DefaultTitle
        {
            get { return "Home Page - My ASP.NET Application"; }
        }

        internal void IsLoginButtonAvaliable()
        {
            if (LoginButton == null)
            {
                throw new Exception("Unable to find the login button on the page");
            }

            AssertElementText(LoginButton, "Log in", "login button");
        }

        internal BasePage ClickRegisterButton()
        {
            RegisterButton.Click();
            return GetInstance<RegistrationPage>(Driver);
        }

        internal void IsLogoutButtonAvailable()
        {
            if (LogoutButton == null)
            {
                throw new Exception("Unable to find the logout button on the page");
            }

            Assert.AreEqual("Log off", LogoutButton.Text);  
        }
    }
}