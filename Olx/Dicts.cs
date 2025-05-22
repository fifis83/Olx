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
            { "Login","https://login.olx.pl/?cc=eyJjYyI6MSwiZ3JvdXBzIjoiQzAwMDE6MSxDMDAwMjoxLEMwMDAzOjEsQzAwMDQ6MSxnYWQ6MSJ9&client_id=6j7elk01p32o648o1io8lvhhab&code_challenge=kchix2JsbwlYXfl0z3kphmUHfpmKwFtkIj3sc2LBoOA&code_challenge_method=S256&lang=pl&redirect_uri=https%3A%2F%2Fwww.olx.pl%2Fd%2Fcallback%2F&st=eyJzbCI6IjE5NmQwMDYxZmU3eDY0M2MwMDYzIiwicyI6IjE5NmQwMDYxZmU3eDY0M2MwMDYzIn0%3D&state=SVp0YkRBaVZrMnVjUXVJOXNYeVUyNmJmYzFhbFRUc1ppREdFV0tYLVFadg%3D%3D"},
            { "SearchStart","https://www.olx.pl/oferty/q-thinkpad-t61/?search[order]=created_at:desc&search[filter_float_price:from]="},
        };
        static public Dictionary<string, int> Months = new Dictionary<string, int>()
        {
            {"stycznia",1 },
            {"lutego", 2 },
            {"marca", 3 },
            {"kwietnia", 4 },
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
