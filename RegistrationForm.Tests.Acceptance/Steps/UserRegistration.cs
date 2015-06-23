using TechTalk.SpecFlow;

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
    }
}