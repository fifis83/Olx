using OpenQA.Selenium;

namespace Olx
{
    public class Program
    {
        public static void Main(string[] args)
        {
            UserParameters userParameters = Helper.InputValues();

            WebDriver driver = new OpenQA.Selenium.Chrome.ChromeDriver();
        }
    }
}