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
            { "ResultDescription","//div[@class=\"css-19duwlz\"]"},
            { "ResultDate","//span[@class='css-pz2ytp']"},
            { "NextPageButton","//a[@data-testid=\"pagination-forward\"]"}
        };
        static public Dictionary<string, string> Pages = new Dictionary<string, string>()
        {
            { "MainPage","https://www.olx.pl/"},
        };
        static public Dictionary<string, int> Months = new Dictionary<string, int>()
        {
            {"stycznia",1 },
            {"lutego", 2 },
            {"marzeca", 3 },
            {"kwiecienia", 4 },
            {"maja", 5 },
            {"czerwca", 6 },
            {"lipca", 7 },
            {"sierpnia", 8 },
            {"września", 9 },
            {"października", 10 },
            {"listopada", 11 },
            {"grudnia", 12 }
        };
    }
}
