using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace RegistrationForm.Tests.Acceptance.Pages
{
    public class RegistrationPage : BasePage
    {
        [FindsBy(How = How.Id, Using = "Email")]
        public IWebElement EmailTextBox;

        [FindsBy(How = How.Id, Using = "Password")]
        public IWebElement PasswordTextBox;

        [FindsBy(How = How.Id, Using = "ConfirmPassword")]
        public IWebElement ConfirmPasswordTextBox;

        [FindsBy(How = How.XPath, Using = "//input[@type='submit']")]
        public IWebElement SubmitButton;

        public override string DefaultTitle
        {
            get { return "Register - My ASP.NET Application"; }
        }

        internal void PopulateEmailTextBox(string email)
        {
            EmailTextBox.SendKeys(email);
        }

        internal void PopulatePasswordTextBox(string password)
        {
            PasswordTextBox.SendKeys(password);
        }

        internal void PopulateConfirmPasswordTextBox(string confirmPassword)
        {
            ConfirmPasswordTextBox.SendKeys(confirmPassword);
        }

        internal BasePage SubmitForm()
        {
            SubmitButton.Click();
            return GetInstance<IndexPage>(Driver);
        }
    }
}
