using NUnit.Framework;
using SpecFlowProjectPlaywright.Drivers;
using SpecFlowProjectPlaywright.Pages;
using TechTalk.SpecFlow.Assist;

namespace SpecFlowProjectPlaywright.StepDefinitions
{
    [Binding]
    public class LoginStepDefinitions
    {
        private readonly Driver _driver;
        private readonly LoginPage _loginPage;
        public LoginStepDefinitions(Driver driver)
        {
            _driver = driver;
            _loginPage = new LoginPage(_driver.Page);
        }

        [Given(@"Navigate to URL")]
        public async Task GivenNavigateToURL()
        {
            await _driver.Page.GotoAsync("http://www.eaapp.somee.com");
        }

        [When(@"Enter valid login credentials")]
        public async Task GivenEnterValidLoginCredentials(Table table)
        {
            dynamic data = table.CreateDynamicInstance();
            await _loginPage.Login((string)data.Username, (string)data.Password);
        }

        [Given(@"Click on login button")]
        public async Task WhenClockOnLoginButton()
        {
            await _loginPage.ClickLogin();
        }

        [Then(@"user should be able to login")]
        public async Task ThenUserShouldBeAbleToLogin()
        {
            var isExist = await _loginPage.IsEmployeeDetailsExists();
            Assert.IsTrue(isExist);
        }
    }
}
