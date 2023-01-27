using System;
using System.Linq;

namespace Appium_Practice;

public static class Constants
{
    public const int TimeOutInSec = 30;
    private static Random random = new Random();
    
    public static string GenerateEmail()
    {
        return "hazimokanovic" + RandomString(8) + "@inboxkitten.com";
    }

    public static string RandomString(int length)
    {
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        return new string(Enumerable.Repeat(chars, length)
            .Select(s => s[random.Next(s.Length)]).ToArray());
    }
}