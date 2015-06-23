﻿using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace RegistrationForm.Tests.Acceptance
{
    public abstract partial class BasePage : CommonBase
    {
        public string BaseURL { get; set; }

        public virtual string DefaultTitle { get { return ""; } }

        /// <summary>
        /// Asserts that the current page is of the given type
        /// </summary>
        public void Is<TPage>() where TPage : BasePage, new()
        {
            if (!(this is TPage))
            {
                throw new AssertionException(String.Format("Page Type Mismatch: Current page is not a '{0}'", typeof(TPage).Name));
            }
        }

        /// <summary>
        /// Inline cast to the given page type
        /// </summary>
        /// <typeparam name="TPage">The page to cast.</typeparam>
        /// <returns>The cast page.</returns>
        public TPage As<TPage>() where TPage : BasePage, new()
        {
            return (TPage)this;
        }

        protected static TPage GetInstance<TPage>(IWebDriver driver, string baseUrl, string expectedTitle = "")
            where TPage : BasePage, new()
        {
            TPage pageInstance = new TPage() { Driver = driver, BaseURL = baseUrl };
            PageFactory.InitElements(driver, pageInstance);

            if (string.IsNullOrWhiteSpace(expectedTitle))
            {
                expectedTitle = pageInstance.DefaultTitle;
            }

            new OpenQA.Selenium.Support.UI.WebDriverWait(driver, TimeSpan.FromSeconds(5)).Until<OpenQA.Selenium.IWebElement>(
                (d) =>
                {
                    return d.FindElement(ByChained.TagName("body"));
                });

            AssertIsEqual(expectedTitle, driver.Title, "Page Title");

            return pageInstance;
        }

        protected TPage GetInstance<TPage>(IWebDriver driver = null, string expectedTitle = "")
            where TPage : BasePage, new()
        {
            return GetInstance<TPage>(driver ?? Driver, BaseURL, expectedTitle);
        }
    }
}