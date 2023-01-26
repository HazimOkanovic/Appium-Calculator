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

    [Test]
    public void FirstTest()
    {
        signUpPage
            .EnterFirstName("Hazim")
            .EnterLastName("Okanovic")
            .EnterEmail("someemail")
            .EnterPassword("somepassword")
            .ClickSignInButton();
    }
}