using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Olx
{
    internal class Dicts
    {
        public static Dictionary<string, string> Elements = new Dictionary<string, string>()
        {
            { "CookiesAccept","//button[@id=\"onetrust-accept-btn-handler\"]"},
            { "Login","//a[@class=\"css-12l1k7f\"]"},
            { "UsernameInput","//input[@name=\"username\""},
            { "PasswordInput","//input[@name=\"password\""},
            { "LoginButton","//button[@type=\"submit\""},
            { "ResultURL","//a[@class=\"css-1tqlkj0\"]"},
            { "ResultPrices","//p[@data-testid=\"ad-price\"]"},
            { "ResultConditions","//span[@class=\"css-iudov9\"]"},
            { "ResultDescription","//div[@class=\"19duwlz\"]"},
            { "NextPageButton","//a[@data-testid=\"pagination-forward\"]"}
        };
        static public Dictionary<string, string> Pages = new Dictionary<string, string>()
        {
            { "MainPage","www.olx.pl"},
        };
    }
}
