using System;
using System.Linq;

namespace Appium_Practice;

public static class Constants
{
    public const int TimeOutInSec = 120;
    private static Random random = new Random();
    public const string FirstName = "Hazim";
    public const string LastName = "Okanovic";
    public const string Password = "Somepassword123";
    public const string SignUpButton = "Verify email to sign up";
    public const string VerifyEmailTitle = "Verify your email securely";
    public const string SignUpTitle = "Sign up";
    public const string SignInTitle = "Sign in";
    public const string Email = "someguy234@inboxkitten.com";
    public const string ValidPassword = "Something";
    public const string AccountName = "Hazim OKanoi";
    public const string SettingsTitle = "Settings";
    public const string AccSettingsTitle = "Account Settings";
    public const string LogOutMessage = "Do you want to log out?";
    public const string WelcomeBackMessage = "Welcome back, Hazim!";
    public const string IncorrectEmail = "wrong.email@gmail.com";
    public const string SignInError = "Email or password is incorrect. Please try again.";
    public const string Shopper = "Wish shopper";
    
    public static string GenerateEmail()
    {
        return "hazimokanovic" + RandomString(7) + "@gmail.com";
    }

    public static string RandomString(int length)
    {
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        return new string(Enumerable.Repeat(chars, length)
            .Select(s => s[random.Next(s.Length)]).ToArray());
    }
}