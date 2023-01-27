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
    public void SuccessfulAccountCreation()
    {
        signUpPage
            .EnterFirstName("Hazim")
            .EnterLastName("Okanovic")
            .EnterEmail(Constants.GenerateEmail())
            .EnterPassword("Somepassword");
        
        Assert.That(signUpPage.GetButtonTitle(), Is.EqualTo("Verify email to sign up"));
    }

    [Test, Order(2)]
    public void VerifyEmailScreen()
    {
        signUpPage
            .ClickCreateAccount();
        
        Assert.That(signUpPage.GetVerifyEmailTitle(), Is.EqualTo("Verify your email securely"));
    }

    [Test, Order(3)]
    public void GetBackTest()
    {
        signUpPage
            .ClickGetBack();
        
        Assert.That(signUpPage.GetTitle(), Is.EqualTo("Sign up"));
    }

    [Test, Order(4)]
    public void ClickSignInTest()
    {
        signUpPage
            .ClickSignInButton();
        
        Assert.That(signInPage.GetTitle(), Is.EqualTo("Sign in"));
    }
}