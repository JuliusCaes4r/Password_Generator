using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.IO;

namespace Password_generator
{
    internal class Program
    {
        
        static void Main(string[] args)
        {

            string[] letters = { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m",
            "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z", "A", "B", "C", "D",
            "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T","U",
            "V", "W", "X", "Y", "Z" };
            string[] numbers = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };
            string[] symbols = { "!", "@", "#", "$", "%", "^", "&", "*", "(", ")", "[", "{", "}", "]", ";", ":", ",", ".", "/", "<", ">", "?", "_", "-", "=", "+" };
            string[] password_array = { };
            ///

            Console.WriteLine("PASSWORD GENERATOR");
            Console.WriteLine("What is this password for?:");
            string accountFor = Console.ReadLine();
            Console.WriteLine("Enter Username: ");
            string username = Console.ReadLine();
            Console.WriteLine("Enter email: ");
            string email = Console.ReadLine();
            Console.Write("How many letters would you like in your password?\nLetters:");
            int letter_length = Convert.ToInt32(Console.ReadLine());
            password_array = password_array.Concat(choose_random(letter_length, letters)).ToArray();
            Console.Write("How many numbers do you want in you password?\nNumbers:");
            int numbers_lenght = Convert.ToInt32(Console.ReadLine());
            password_array = password_array.Concat(choose_random(numbers_lenght, numbers)).ToArray();
            Console.Write("How many symbols would you like?\nSymbols:");
            int symbols_length = Convert.ToInt32(Console.ReadLine());
            password_array = password_array.Concat(choose_random(symbols_length, symbols)).ToArray();

            Random random = new Random();
            password_array = password_array.OrderBy(x => random.Next()).ToArray();
            string realpassword = "";
            foreach (var item in password_array)
            {
                realpassword = realpassword + item;
            }
            Console.Clear();
            Console.WriteLine($"New Password: {realpassword}");
            Console.Read();
            Console.Clear();
            Console.WriteLine($"{accountFor}\n---------------\n{username}\n{email}\n{realpassword}");
            string myfile = @"D:\Users\tokok\OneDrive\Desktop\accounts.txt";
            string savethis = $"{accountFor}\n---------------\n{username}\n{email}\n{realpassword}";
            //File.AppendText("D:\\Users\\tokok\\OneDrive\\Desktop\\accounts.txt", savethis);
            using(StreamWriter sw = File.AppendText(myfile))
            {
                sw.WriteLine(savethis);
                sw.WriteLine("\n_______________________________\n");
            }
        }
        
        static string[] choose_random(int length, string[] array)
        {
            string[] password_arr = {};
            for (int i = 0; i < length; i++)
            {
                Random random = new Random();
                int random_charracter = random.Next(0, array.Length); 
                password_arr = password_arr.Append(array[random_charracter]).ToArray();
            }
            return password_arr;
        }
    }
}


/*
 letters = ["a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z"]
numbers = ["0", "1", "2", "3", "4", "5", "6", "7", "8", "9"]
symbols = ["!", "@", "#", "$", "%", "^", "&", "*", "(", ")", "[", "{", "}", "]", ";", ":", ",", ".", "/", "<", ">", "?", "_", "-", "=", "+"]
 */