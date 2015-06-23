using System.Configuration;
using Baseclass.Contrib.SpecFlow.Selenium.NUnit.Bindings;
using OpenQA.Selenium;
using RegistrationForm.Tests.Acceptance.Pages;
using Baseclass.Contrib;

namespace RegistrationForm.Tests.Acceptance
{
    public abstract partial class BasePage
    {
        public static string BaseUrl
        {
            get { return ConfigurationManager.AppSettings["seleniumBaseUrl"]; }
        }

        public static IndexPage LoadIndexPage(IWebDriver driver, string baseURL)
        {
            if (driver == null)
            {
                driver = Browser.Current;
            }

            driver.Navigate().GoToUrl(baseURL.TrimEnd(new char[] { '/' }) + IndexPage.Url);

            return GetInstance<IndexPage>(driver, baseURL, "");
        }
    }
}