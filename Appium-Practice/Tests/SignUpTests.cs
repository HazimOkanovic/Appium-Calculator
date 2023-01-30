using Appium_Practice.Pages;
using NUnit.Framework;

namespace Appium_Practice.Tests;

public class SignUpTests : BaseTest
{
    private readonly SignUpPage signUpPage;
    private readonly SignInPage signInPage;

    public SignUpTests()
    {
        signUpPage = new SignUpPage(driver);
        signInPage = new SignInPage(driver);
    }

    [Test, Order(1)]
    public void ClickCreateAccount()
    {
        signInPage
            .ClickSignUpButton();
        
        Assert.That(signUpPage.GetTitle(), Is.EqualTo(Constants.SignUpTitle));
    }
    [Test, Order(2)]
    public void EnterAllDataTest()
    {
        signUpPage
            .EnterFirstName(Constants.FirstName)
            .EnterLastName(Constants.LastName)
            .EnterEmail(Constants.GenerateEmail())
            .EnterPassword(Constants.Password);
        
        Assert.That(signUpPage.GetButtonTitle(), Is.EqualTo(Constants.SignUpButton));
    }

    [Test, Order(3)]
    public void VerifyEmailScreen()
    {
        signUpPage
            .ClickCreateAccount();
        
        Assert.That(signUpPage.GetVerifyEmailTitle(), Is.EqualTo(Constants.VerifyEmailTitle));
    }

    [Test, Order(4)]
    public void GetBackTest()
    {
        signUpPage
            .ClickGetBack();
        
        Assert.That(signUpPage.GetTitle(), Is.EqualTo(Constants.SignUpTitle));
    }

    [Test, Order(5)]
    public void ClickSignInTest()
    {
        signUpPage
            .ClickSignInButton();
        
        Assert.That(signInPage.GetTitle(), Is.EqualTo(Constants.SignInTitle));
    }
}