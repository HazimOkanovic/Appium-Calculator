using Appium_Practice.Pages;
using NUnit.Framework;

namespace Appium_Practice.Tests;

public class SignInTests : BaseTest
{
    private readonly HomePage homePage;
    private readonly SettingsPage settingsPage;
    private readonly SignInPage signInPage;
    private readonly SignUpPage signUpPage;

    public SignInTests()
    {
        homePage = new HomePage(driver);
        settingsPage = new SettingsPage(driver);
        signInPage = new SignInPage(driver);
        signUpPage = new SignUpPage(driver);
    }

    [Test, Order(1)]
    public void SuccessfulLoginTest()
    {
        signInPage
            .EnterEmail("someguy234@inboxkitten.com")
            .EnterPassword("Something")
            .ClickSignIn()
            .ClickMenuButton();
        
        Assert.That(homePage.GetNameTitle(), Is.EqualTo("Hazim OKanoi"));
    }

    [Test, Order(2)]
    public void GoToSettingsTest()
    {
        homePage
            .ClickSettingsButton();
        
        Assert.That(settingsPage.GetSettingsTitle(), Is.EqualTo("Settings"));
    }

    [Test, Order(3)]
    public void GoToAccountSettingsTest()
    {
        settingsPage
            .ClickAccountSettings();
            
        Assert.That(settingsPage.GetSettingsTitle(), Is.EqualTo("Account Settings"));
    }

    [Test, Order(4)]
    public void LogOutTest()
    {
        settingsPage
            .ClickLogOutButton();
        
        Assert.That(settingsPage.SignOutModal.GetModalText(), Is.EqualTo("Do you want to log out?"));
    }

    [Test, Order(5)]
    public void ClickLogOutTest()
    {
        settingsPage.SignOutModal
            .ClickLogOutButton();
        
        Assert.That(signInPage.GetWelcomeBackTitle(), Is.EqualTo("Welcome back, Hazim!"));
    }

    [Test, Order(6)]
    public void GoToSignInPageTest()
    {
        signInPage
            .ClickSignInOtherAccount();
        
        Assert.That(signInPage.GetTitle(), Is.EqualTo(Constants.SignInTitle));
    }

    [Test, Order(7)]
    public void WrongEmailTest()
    {
        signInPage
            .EnterEmail("wrong.email@gmail.com")
            .EnterPassword("Something")
            .ClickSignIn();
        
        Assert.That(signInPage.SignInModal.GetErrorMessage(), Is.EqualTo("Email or password is incorrect. Please try again."));
    }

    [Test, Order(8)]
    public void WrongPassword()
    {
        signInPage.SignInModal
            .ClickOk()
            .ClearEmail()
            .ClearPassword()
            .EnterEmail("someguy234@inboxkitten.com")
            .EnterPassword("SomeOtherPassword")
            .ClickSignIn();
        
        Assert.That(signInPage.SignInModal.GetErrorMessage(), Is.EqualTo("Email or password is incorrect. Please try again."));
    }

    [Test, Order(9)]
    public void GoToHomePageWithoutLoginTest()
    {
        signInPage.SignInModal
            .ClickOk()
            .ClickClose()
            .ClickMenuButton();
        
        Assert.That(homePage.GetNameTitle(), Is.EqualTo("Wish shopper"));
    }

    [Test, Order(10)]
    public void GoToAccountTest()
    {
        homePage
            .ClickSettingsButton();
        
        Assert.That(settingsPage.GetSettingsTitle(), Is.EqualTo("Settings"));
    }

    [Test, Order(11)]
    public void ClickSignInTest()
    {
        settingsPage
            .ClickSignIn();
        
        Assert.That(signInPage.GetTitle(), Is.EqualTo(Constants.SignInTitle));
    }
}