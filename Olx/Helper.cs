using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V134.Input;
using OpenQA.Selenium.Support.UI;

namespace Olx
{
    struct UserParameters
    {
        
        public string Login, Password;
        
        
    }
    struct SearchParameters
    {
        public DateTime OldestDateAllowed;
        public int MinPrice, MaxPrice;
        public string[] Blacklist;
    }
    internal class Helper
    {

        static public UserParameters InputValues()
        {
            UserParameters userParameters = new UserParameters();
            SearchParameters searchParameters = new SearchParameters();
            Console.WriteLine("Wyszukiwarka Thinkpad");
            Console.WriteLine("Jaka minimalna cena?:");

            int minPrice = int.Parse(Console.ReadLine());
            while (minPrice < 0 && minPrice % 1 != 0)
            {
                Console.WriteLine("Podaj poprawną minimalną cenę:");
                minPrice = int.Parse(Console.ReadLine());
            }
          
         
            searchParameters.MinPrice = minPrice;
            Console.WriteLine("Jaka maksymalna cena?:");

            int maxPrice = int.Parse(Console.ReadLine());

            while (maxPrice < 0 && maxPrice % 1 != 0 && maxPrice<minPrice )
            {
                Console.WriteLine("Podaj poprawną maksymalną cenę:");
                maxPrice = int.Parse(Console.ReadLine());
            }
            searchParameters.MaxPrice = maxPrice;

            Console.WriteLine("Jakie słowa chcesz omijać?: (prosze wstawić ',' po każdym słowie");
            string[] blacklist = Console.ReadLine().Split(',');
            searchParameters.Blacklist = blacklist;


            Console.WriteLine("Jaka najstarsza data? ");
            Console.WriteLine("Podaj rok:");
            int year = int.Parse(Console.ReadLine());
            if (int.TryParse(Console.ReadLine(), out  year) == false)
            {
                Console.WriteLine("Podano błędny rok jeszcze raz");
                year = int.Parse(Console.ReadLine());
            }
           
            Console.WriteLine("Podaj miesiąc:");
            int month = int.Parse(Console.ReadLine());
            if (int.TryParse(Console.ReadLine(), out  month) == false)
            {
                Console.WriteLine("Podano błędny miesiąc jeszcze raz");
                month = int.Parse(Console.ReadLine());
            }
           
            Console.WriteLine("Podaj dzień:");
            int day = int.Parse(Console.ReadLine());
            if (int.TryParse(Console.ReadLine(), out  day) == false)
            {
                Console.WriteLine("Podano błędny dzień jeszcze raz");
                day = int.Parse(Console.ReadLine());
            }

       
            DateTime oldestDateAllowed = new DateTime(year, month, day);
            searchParameters.OldestDateAllowed = oldestDateAllowed;

            Console.WriteLine("Podaj Login:");
            string login = Console.ReadLine();
            userParameters.Login = login;
            Console.WriteLine("Podaj Hasło:");
            string password = Console.ReadLine();
            userParameters.Password = password;

            return userParameters;

        }
        
        static public string CreateURL(SearchParameters searchParams)
        {
            string url = "https://www.olx.pl/oferty/q-thinkpad-t61/?search[order]=created_at:desc&search[filter_foloat_price:from]="+searchParams.MinPrice+"&search[filter_float_price:to]="+searchParams.MaxPrice;
            return url;
        }

        static public void Login(IWebDriver driver,UserParameters userParameters)
        {
            driver.Navigate().GoToUrl(Dicts.Pages["MainPage"]);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(2));
            
            wait.Until((d) => { return d.FindElement(By.XPath(Dicts.Elements["Login"])); }).Click();
            
            var input = wait.Until((d) => { return d.FindElement(By.XPath(Dicts.Elements["UsernameInput"])); });
            input.SendKeys(userParameters.Login);
            
            input = driver.FindElement(By.XPath(Dicts.Elements["PasswordInput"]));
            input.SendKeys(userParameters.Password);

            driver.FindElement(By.XPath(Dicts.Elements["LoginButton"])).Click();
        }


        static public void getLinkAndPrice(IWebDriver driver, SearchParameters searchParameters)
        {
            driver.Navigate().GoToUrl(CreateURL(searchParameters));
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(2));

            string[] arrayUrls;
            string[] arrayPrices;

          
            var input = wait.Until((d) => { return d.FindElement(By.XPath(Dicts.Elements["ResultURL"])); });
            
            var price = wait.Until((d) => { return d.FindElement(By.XPath(Dicts.Elements["ResultPrices"])); });
        }
       /* static public bool checkIfDateIsGood(SearchParameters searchParameters)
        {

        }*/
        
    }
}
