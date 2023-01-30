using Appium_Practice.Pages;
using NUnit.Framework;

namespace Appium_Practice.Tests;

public class SignInTests : BaseTest
{
    private readonly HomePage homePage;
    private readonly SettingsPage settingsPage;
    private readonly SignInPage signInPage;

    public SignInTests()
    {
        homePage = new HomePage(driver);
        settingsPage = new SettingsPage(driver);
        signInPage = new SignInPage(driver);
    }

    [Test, Order(1)]
    public void SuccessfulLoginTest()
    {
        signInPage
            .EnterEmail(Constants.Email)
            .EnterPassword(Constants.ValidPassword)
            .ClickSignIn()
            .ClickMenuButton();
        
        Assert.That(homePage.GetNameTitle(), Is.EqualTo(Constants.AccountName));
    }

    [Test, Order(2)]
    public void GoToSettingsTest()
    {
        homePage
            .ClickSettingsButton();
        
        Assert.That(settingsPage.GetSettingsTitle(), Is.EqualTo(Constants.SettingsTitle));
    }

    [Test, Order(3)]
    public void GoToAccountSettingsTest()
    {
        settingsPage
            .ClickAccountSettings();
            
        Assert.That(settingsPage.GetSettingsTitle(), Is.EqualTo(Constants.AccSettingsTitle));
    }
    
    [Test, Order(4)]
    public void BackButtonTest()
    {
        settingsPage
            .ClickBackButton();

        Assert.That(settingsPage.GetSettingsTitle(), Is.EqualTo(Constants.SettingsTitle));
    }

    [Test, Order(5)]
    public void LogOutTest()
    {
        settingsPage
            .ClickLogOutButton();
        
        Assert.That(settingsPage.SignOutModal.GetModalText(), Is.EqualTo(Constants.LogOutMessage));
    }

    [Test, Order(6)]
    public void ClickLogOutTest()
    {
        settingsPage.SignOutModal
            .ClickLogOutButton();
        
        Assert.That(signInPage.GetWelcomeBackTitle(), Is.EqualTo(Constants.WelcomeBackMessage));
    }

    [Test, Order(7)]
    public void GoToSignInPageTest()
    {
        signInPage
            .ClickSignInOtherAccount();
        
        Assert.That(signInPage.GetTitle(), Is.EqualTo(Constants.SignInTitle));
    }

    [Test, Order(8)]
    public void WrongEmailTest()
    {
        signInPage
            .EnterEmail(Constants.IncorrectEmail)
            .EnterPassword(Constants.ValidPassword)
            .ClickSignIn();
        
        Assert.That(signInPage.SignInModal.GetErrorMessage(), Is.EqualTo(Constants.SignInError));
    }

    [Test, Order(9)]
    public void WrongPassword()
    {
        signInPage.SignInModal
            .ClickOk()
            .ClearEmail()
            .ClearPassword()
            .EnterEmail(Constants.Email)
            .EnterPassword(Constants.Password)
            .ClickSignIn();
        
        Assert.That(signInPage.SignInModal.GetErrorMessage(), Is.EqualTo(Constants.SignInError));
    }

    [Test, Order(10)]
    public void GoToHomePageWithoutLoginTest()
    {
        signInPage.SignInModal
            .ClickOk()
            .ClickClose()
            .ClickMenuButton();
        
        Assert.That(homePage.GetNameTitle(), Is.EqualTo(Constants.Shopper));
    }

    [Test, Order(11)]
    public void GoToAccountTest()
    {
        homePage
            .ClickSettingsButton();
        
        Assert.That(settingsPage.GetSettingsTitle(), Is.EqualTo(Constants.SettingsTitle));
    }

    [Test, Order(12)]
    public void ClickSignInTest()
    {
        settingsPage
            .ClickSignIn();
        
        Assert.That(signInPage.GetTitle(), Is.EqualTo(Constants.SignInTitle));
    }
}