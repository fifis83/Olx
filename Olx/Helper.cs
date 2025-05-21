using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
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
        static public UserParameters InputValues(out SearchParameters searchParameters)
        {
            UserParameters userParameters = new UserParameters();
            searchParameters = new SearchParameters();
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

            while (maxPrice < 0 && maxPrice % 1 != 0 && maxPrice < minPrice)
            {
                Console.WriteLine("Podaj poprawną maksymalną cenę:");
                maxPrice = int.Parse(Console.ReadLine());
            }
            searchParameters.MaxPrice = maxPrice;

            Console.WriteLine("Jakie słowa chcesz omijać?: (prosze wstawić ',' po każdym słowie");
            string[] blacklist = Console.ReadLine().Split(',');
            searchParameters.Blacklist = blacklist;

            GetBlacklistXpath(blacklist, out string urlXpath, out string priceXpath);
            Console.WriteLine("Jaka najstarsza data? ");
            Console.WriteLine("Podaj rok:");
            int year;
            while (int.TryParse(Console.ReadLine(), out year) == false)
            {
                Console.WriteLine("Podano błędny rok jeszcze raz");
            }

            Console.WriteLine("Podaj miesiąc:");
            int month;
            while (int.TryParse(Console.ReadLine(), out month) == false)
            {
                Console.WriteLine("Podano błędny miesiąc jeszcze raz");
            }

            Console.WriteLine("Podaj dzień:");
            int day;
            while (int.TryParse(Console.ReadLine(), out day) == false)
            {
                Console.WriteLine("Podano błędny dzień jeszcze raz");
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
            string url = "https://www.olx.pl/oferty/q-thinkpad-t61/?search[order]=created_at:desc&search[filter_float_price:from]=" + searchParams.MinPrice + "&search[filter_float_price:to]=" + searchParams.MaxPrice;
            return url;
        }

        static public bool Login(IWebDriver driver, UserParameters userParameters)
        {
            driver.Navigate().GoToUrl("https://login.olx.pl/?cc=eyJjYyI6MSwiZ3JvdXBzIjoiQzAwMDE6MSxDMDAwMjoxLEMwMDAzOjEsQzAwMDQ6MSxnYWQ6MSJ9&client_id=6j7elk01p32o648o1io8lvhhab&code_challenge=kchix2JsbwlYXfl0z3kphmUHfpmKwFtkIj3sc2LBoOA&code_challenge_method=S256&lang=pl&redirect_uri=https%3A%2F%2Fwww.olx.pl%2Fd%2Fcallback%2F&st=eyJzbCI6IjE5NmQwMDYxZmU3eDY0M2MwMDYzIiwicyI6IjE5NmQwMDYxZmU3eDY0M2MwMDYzIn0%3D&state=SVp0YkRBaVZrMnVjUXVJOXNYeVUyNmJmYzFhbFRUc1ppREdFV0tYLVFadg%3D%3D");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            //wait.Until((d) => { return d.FindElement(By.XPath(Dicts.Elements["CookiesAccept"])); }).Click();

            //wait.Until((d) => { return d.FindElement(By.XPath(Dicts.Elements["Login"])); }).Click();

            var input = wait.Until((d) => { return d.FindElement(By.XPath(Dicts.Elements["UsernameInput"])); });
            input.SendKeys(userParameters.Login);

            input = driver.FindElement(By.XPath(Dicts.Elements["PasswordInput"]));
            input.SendKeys(userParameters.Password);

            driver.FindElement(By.XPath(Dicts.Elements["LoginButton"])).Click();
        
            driver.Navigate().GoToUrl(Dicts.Pages["MainPage"]);
            return true;
        }


        static public List<string[]> GetResults(IWebDriver driver, SearchParameters searchParameters)
        {
            //Console.WriteLine(CreateURL(searchParameters));
            driver.Navigate().GoToUrl(CreateURL(searchParameters));
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));

            //wait.Until((d) => { return d.FindElement(By.XPath(Dicts.Elements["CookiesAccept"])); }).Click();
            
            string urlXpath, priceXpath;
            GetBlacklistXpath(searchParameters.Blacklist, out urlXpath, out priceXpath);

            List<string[]> results = new List<string[]>();
            string dateOfListing = "";
            while (true)
            {
                
                var urls = wait.Until((d) => { return d.FindElements(By.XPath(urlXpath)); });

                var prices = driver.FindElements(By.XPath(priceXpath));

                for (int i = 0; i < urls.Count; i++)
                {
                    string url = urls[i].GetAttribute("href");
                   /* if (checkIfDateIsGood(searchParameters, GetDate(url)))
                    {
                        return results;
                    }*/


                   
                    string price = prices[i].Text;
                    string desc = GetDescription(url);
                    results.Add(new string[] { url, price, desc });
                }

                //if(driver.FindElements(By.XPath(Dicts.Elements["NextPageButton"])).Count == 0)
                //{
                //}
                //driver.FindElement(By.XPath(Dicts.Elements["NextPageButton"])).Click();
                    return results;
                }
               
                driver.FindElement(By.XPath(Dicts.Elements["NextPageButton"])).Click();
            }

        }

        static void GetBlacklistXpath(string[] blacklist, out string urlXpath, out string priceXpath)
        {
            urlXpath = "//h4[@class=\"css-1g61gc2\"";
            
            foreach (var word in blacklist)
            {
                if (word == "") continue;
                urlXpath = urlXpath + " and not(contains(text(),\"" + word + "\"))";
            }

            priceXpath = urlXpath + "]//following::p";
            urlXpath = urlXpath + "]//parent::a";
            Console.WriteLine(urlXpath+" "+ priceXpath);
        }

        static string GetDescription(string url)
        {
            var options = new ChromeOptions();
            options.AddArgument("--headless=new");
            IWebDriver driver = new OpenQA.Selenium.Chrome.ChromeDriver(options);
            driver.Navigate().GoToUrl(url);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until((d) => { return d.FindElement(By.XPath(Dicts.Elements["CookiesAccept"])); }).Click();
            string description = wait.Until((d) => { return d.FindElement(By.XPath(Dicts.Elements["ResultDescription"])); }).Text;
            driver.Quit();
            return description;
        }

        static public string GenerateAIResponse()
        {
            var proc = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = "C:/Users/fifis/AppData/Local/Programs/Python/Python313/python.exe",
                    Arguments = "C:/Users/fifis/dev/python/costam.py",
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    CreateNoWindow = false,
                }
        static string GetDate(string url)
        {
            IWebDriver driver = new OpenQA.Selenium.Chrome.ChromeDriver();
            driver.Navigate().GoToUrl(url);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until((d) => { return d.FindElement(By.XPath(Dicts.Elements["CookiesAccept"])); }).Click();
            string date = wait.Until((d) => { return d.FindElement(By.XPath(Dicts.Elements["ResultDate"])); }).Text;
            driver.Quit();
            return date;
        }

            };
            string output = "";

            proc.Exited += new EventHandler((object sender, System.EventArgs e) => {
                output = File.ReadAllText("C:/Users/fifis/dev/python/response.txt");    
            });
            proc.Start();
            proc.WaitForExit();
            if(proc.HasExited)
            {
                return output;
            }
            return "Error";
        }

    

        static string GetTitleFromURL(string url)
        {
            string title = url.Replace("https://www.olx.pl/d/oferta/", "");
            int index = title.IndexOf("-CID");
            if (index >= 0)
                title = title.Substring(0, index);
            title = title.Replace("-", " ");
            return title;
        }

        static public void CreateTempResultsFile(List<string[]> results)
        {
            string argument = "";
            int i = 1;

            foreach (var result in results)
            {
                argument += i++ + ". " + GetTitleFromURL(result[0]) + "; " + result[1] + "; " + result[2] + "\n";
            }


            File.WriteAllText("C:/Users/fifis/dev/python/temp.txt", argument);
            
        }
        static public bool checkIfDateIsGood(SearchParameters searchParameters, string dateOfListing)
        {
            if (dateOfListing.Contains("Dzisiaj"))
            {
                return false;
            }
            else
            {

                int Day = Int32.Parse(dateOfListing.Split(' ')[0]);

                string MonthStr = dateOfListing.Split(' ')[1];
                int Year = Int32.Parse(dateOfListing.Split(' ')[2]);

                int Month = Dicts.Months[MonthStr];
                if (Year > searchParameters.OldestDateAllowed.Year)
                {
                    return false;
                }

                else if (Year == searchParameters.OldestDateAllowed.Year)
                {

                    if (Month > searchParameters.OldestDateAllowed.Month)
                    {
                        return false;
                    }
                    else if (Month == searchParameters.OldestDateAllowed.Month)
                    {
                        if (Day > searchParameters.OldestDateAllowed.Day)
                        {
                            return false;
                        }
                    }

                }

            }

            return true;

        }

        static public int getAIChoice(List<string[]> results)
        {
            string argument="";
            int i = 1;

            foreach (var result in results)
            {
                argument += i++ +". "+ result[0] + "; " + result[1] + "; " + result[2] + "\n";
            }

            var proc = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = "C:/Users/fifis/AppData/Local/Programs/Python/Python313/python.exe",
                    Arguments = "C:/Users/fifis/dev/python/costam.py "+argument,
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    CreateNoWindow = true
                }
            };

            string aiChoice= "0";

            proc.Start();
            while (!proc.StandardOutput.EndOfStream)
            {
                aiChoice = proc.StandardOutput.ReadLine();
            }

            return int.Parse(aiChoice.Trim());

        }

    }
}
