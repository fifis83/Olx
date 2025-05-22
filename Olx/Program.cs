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
            UserParameters userParameters = Costam.InputValuesDebug(out searchParameters);
            var options = new ChromeOptions();
            options.AddArgument("--headless=new");
            options.AddArgument("--no-sandbox");
            WebDriver driver = new ChromeDriver(options);

            Helper.Login(driver, userParameters);
            Helper.CreateTempResultsFile(Helper.GetResults(driver, searchParameters));
            var AIResponse = Helper.GenerateAIResponse();
            Console.WriteLine(AIResponse);

            driver.Quit();
        }
    }
}
