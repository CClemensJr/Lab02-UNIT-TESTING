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

        // The userinterface will interact with the user
        static void UserInterface()
        {
            ShowHeading();
        }

        // Show heading is responsible for showing the credit union slogan
        static void ShowHeading()
        {
            CenterText("Welcome to Code Fellows Credit Union.\n");
            CenterText("Thank you for your membership!\n\n\n");
        }

        // CenterText will center text in the console window. Inspiration came from MSDN docs on String.Format and this stackoverflow article: stackoverflow.com/questions/21917203/how-do-i-center-text-in-a-console-application
        static void CenterText(string text)
        {
            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (text.Length / 2)) + "}", text));
        }
    }
}
