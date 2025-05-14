using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Olx
{
    struct UserParameters
    {
        
        public string Phrase, Login, Password;
        public DateTime OldestDateAllowed;
        public float MinPrice, MaxPrice;
        public string[] Blacklist;
        
    }
    internal class Helper
    {

        static UserParameters InputValues()
        {
            UserParameters userParameters = new UserParameters();
            Console.WriteLine("Czego szukasz?:");
            string phrase = Console.ReadLine();
            userParameters.Phrase = phrase;
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
       
    }
}
