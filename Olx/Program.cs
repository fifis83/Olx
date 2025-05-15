using OpenQA.Selenium;

namespace Olx
{
    public class Program
    {
        public static void Main(string[] args)
        {
            SearchParameters searchParameters;
            UserParameters userParameters = Helper.InputValues(out searchParameters);

            WebDriver driver = new OpenQA.Selenium.Chrome.ChromeDriver();
        
            Helper.Login(driver, userParameters);
            var results = Helper.GetResults(driver, searchParameters);

            foreach (var result in results)
            {
                Console.WriteLine("URL: " + result[0]);
                Console.WriteLine("Price: " + result[1]);
                Console.WriteLine("Description: " + result[2]);
                Console.WriteLine();
            }

            driver.Quit();
        }
    }
}
