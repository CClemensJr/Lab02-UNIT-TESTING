using System;


namespace ATM
{
    public class Program
    {
        static void Main(string[] args)
        {
            UserInterface();

            Console.ReadLine();
        }

        static void UserInterface()
        {
            CenterText("Welcome to Code Fellows Credit Union.");
            CenterText("Thank you for your membership!");
        }

        static void CenterText(string text)
        {
            Console.WriteLine(text);
        }
    }
}
