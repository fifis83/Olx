using System;
using System.Collections.Generic;
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
        public DateTime OldestDateAllowed;
        public float MinPrice, MaxPrice;
        public string[] Blacklist;
        
    }
    internal class Helper
    {

        static public UserParameters InputValues()
        {
            UserParameters userParameters = new UserParameters();
            Console.WriteLine("Wyszukiwarka Thinkpad");
            Console.WriteLine("Jaka minimalna cena?:");
            float minPrice = float.Parse(Console.ReadLine());
            userParameters.MinPrice = minPrice;
            Console.WriteLine("Jaka maksymalna cena?:");
            float maxPrice = float.Parse(Console.ReadLine());
            userParameters.MaxPrice = maxPrice;
            Console.WriteLine("Jakie słowa chcesz omijać?: (prosze wstawić ',' po każdym słowie");
            string[] blacklist = Console.ReadLine().Split(',');
            userParameters.Blacklist = blacklist;

            Console.WriteLine("Jaka najstarsza data? ");
            Console.WriteLine("Podaj rok:");
            int year = int.Parse(Console.ReadLine());
            Console.WriteLine("Podaj miesiąc:");
            int month = int.Parse(Console.ReadLine());
            Console.WriteLine("Podaj dzień:");
            int day = int.Parse(Console.ReadLine());
            DateTime oldestDateAllowed = new DateTime(year, month, day);
            userParameters.OldestDateAllowed = oldestDateAllowed;

            Console.WriteLine("Podaj Login:");
            string login = Console.ReadLine();
            userParameters.Login = login;
            Console.WriteLine("Podaj Hasło:");
            string password = Console.ReadLine();
            userParameters.Password = password;

            return userParameters;

        }
        
        static public string CreateURL(UserParameters usrParams)
        {
            string url = "https://www.olx.pl/oferty/q-thinkpad-t61/?search[order]=created_at:desc&search[filter_foloat_price:from]="+usrParams.MinPrice+"&search[filter_float_price:to]="+usrParams.MaxPrice;
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

    }
}
