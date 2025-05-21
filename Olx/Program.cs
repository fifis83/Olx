using System.Diagnostics;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Olx
{
    public class Program
    {
        public static void Main(string[] args)
        {
            SearchParameters searchParameters;
            UserParameters userParameters = Helper.InputValues(out searchParameters);
            var options = new ChromeOptions();
            options.AddArgument("--headless=new");
            WebDriver driver = new OpenQA.Selenium.Chrome.ChromeDriver(options);

            Helper.Login(driver, userParameters);
            Helper.CreateTempResultsFile(Helper.GetResults(driver, searchParameters));
            var AIResponse = Helper.GenerateAIResponse();
            Console.WriteLine(AIResponse);



            driver.Quit();
        }
    }
}
