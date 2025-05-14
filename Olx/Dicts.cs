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
            { "ResultDate","//p[@data-testid=\"location-date\"]"},
            { "NextPageButton","//a[@data-testid=\"pagination-forward\"]"}
        };
        static public Dictionary<string, string> Pages = new Dictionary<string, string>()
        {
            { "MainPage","www.olx.pl"},
        };
        static public Dictionary<string, int> Months = new Dictionary<string, int>()
        {
            {"styczeń",1 },
            {"luty", 2 },
            {"marzec", 3 },
            {"kwiecień", 4 },
            {"maj", 5 },
            {"czerwiec", 6 },
            {"lipiec", 7 },
            {"sierpień", 8 },
            {"wrzesień", 9 },
            {"październik", 10 },
            {"listopad", 11 },
            {"grudzień", 12 }
        };
    }
}
