using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Olx
{
    struct UserParameters
    {
        
        public string Login, Password;
        public DateTime OldestDateAllowed;
        public int MinPrice, MaxPrice;
        public string[] Blacklist;
        
    }
    internal class Helper
    {

        static UserParameters InputValues()
        {
            UserParameters userParameters = new UserParameters();
            Console.WriteLine("Wyszukiwarka Thinkpad");
            Console.WriteLine("Jaka minimalna cena?:");

            int minPrice = int.Parse(Console.ReadLine());
            while (minPrice < 0 && minPrice % 1 != 0)
            {
                Console.WriteLine("Podaj poprawną minimalną cenę:");
                minPrice = int.Parse(Console.ReadLine());
            }
          
         
            userParameters.MinPrice = minPrice;
            Console.WriteLine("Jaka maksymalna cena?:");

            int maxPrice = int.Parse(Console.ReadLine());

            while (maxPrice < 0 && maxPrice % 1 != 0 && maxPrice<minPrice )
            {
                Console.WriteLine("Podaj poprawną maksymalną cenę:");
                maxPrice = int.Parse(Console.ReadLine());
            }
            userParameters.MaxPrice = maxPrice;

            Console.WriteLine("Jakie słowa chcesz omijać?: (prosze wstawić ',' po każdym słowie");
            string[] blacklist = Console.ReadLine().Split(',');
            userParameters.Blacklist = blacklist;


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
            userParameters.OldestDateAllowed = oldestDateAllowed;

            Console.WriteLine("Podaj Login:");
            string login = Console.ReadLine();
            userParameters.Login = login;
            Console.WriteLine("Podaj Hasło:");
            string password = Console.ReadLine();
            userParameters.Password = password;

            return userParameters;

        }
       
    }
}
