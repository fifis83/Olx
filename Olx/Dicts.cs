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
            { "Login","//a[@data-cy=\"myolx-link\"]"},
            { "UsernameInput","//input[@name=\"username\"]"},
            { "PasswordInput","//input[@name=\"password\"]"},
            { "LoginButton","//button[@type=\"submit\"]"},
            { "ResultURL","//h4[@class=\"css-1g61gc2\"]/parent::a"},
            { "ResultPrices","//p[@data-testid=\"ad-price\"]"},
            { "ResultConditions","//span[@class=\"css-iudov9\"]"},
            { "ResultDescription","//div[@class=\"19duwlz\"]"},
            { "ResultDate","//p[@data-testid=\"location-date\"]"},
            { "NextPageButton","//a[@data-testid=\"pagination-forward\"]"}
        };
        static public Dictionary<string, string> Pages = new Dictionary<string, string>()
        {
            { "MainPage","https://www.olx.pl/"},
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
