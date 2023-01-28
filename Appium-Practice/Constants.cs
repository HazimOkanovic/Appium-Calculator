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