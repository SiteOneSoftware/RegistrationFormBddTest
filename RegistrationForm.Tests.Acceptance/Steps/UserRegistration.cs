using System;
using RegistrationForm.Tests.Acceptance.Pages;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace RegistrationForm.Tests.Acceptance.Steps
{
    [Binding]
    public sealed class UserRegistration : BaseSteps
    {
        [Given(@"I am on the home page")]
        public void GivenIAmOnTheHomePage()
        {
            CurrentPage = (BasePage)BasePage.LoadIndexPage(CurrentDriver, BasePage.BaseUrl);
        }

        [Given(@"I am not logged in")]
        public void GivenIAmNotLoggedIn()
        {
            CurrentPage.As<IndexPage>().IsLoginButtonAvaliable();
        }

        [When(@"I click the register button")]
        public void WhenIClickTheRegisterButton()
        {
            NextPage = CurrentPage.As<IndexPage>().ClickRegisterButton();
        }

        [When(@"fill in the registration form with the following details")]
        public void WhenFillInTheRegistrationFormWithTheFollowingDetails(Table table)
        {
            dynamic form = table.CreateDynamicInstance();
            var emailArr = form.Email.Split('@');
            var email = string.Format("{0}{1}@{2}", emailArr[0], RandomNumber(), emailArr[1]);
            CurrentPage.As<RegistrationPage>().PopulateEmailTextBox(email);
            CurrentPage.As<RegistrationPage>().PopulatePasswordTextBox(form.Password);
            CurrentPage.As<RegistrationPage>().PopulateConfirmPasswordTextBox(form.ConfirmPassword);
        }

        [When(@"I submit the form")]
        public void WhenISubmitTheForm()
        {
            NextPage = CurrentPage.As<RegistrationPage>().SubmitForm();
        }

        [Then(@"I redirected to the home page")]
        public void ThenIRedirectedToTheHomePage()
        {
            CurrentPage.Is<IndexPage>();
        }

        [Then(@"I will be logged in")]
        public void ThenIWillBeLoggedIn()
        {
            CurrentPage.As<IndexPage>().IsLogoutButtonAvailable();
        }
    }
}