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
            ColorizeScreen();
            ShowHeading();
            ShowMenu();
        }

        // Show heading is responsible for showing the credit union slogan
        static void ShowHeading()
        {
            CenterText("Welcome to Code Fellows Credit Union.\n");
            CenterText("Thank you for your membership!\n\n\n");
        }

        static void ShowMenu()
        {
            CenterText("Please select an option:");
            CenterText("------------------------");
            ColumnizeText("1.",  "View your balance.");
            ColumnizeText("2.", "Withdraw cash.");
            ColumnizeText("3.", "Deposit cash.");
        }



        /**
         * INTERFACE HELPER METHODS
         **/
         // Colorize will make the console look more like an old ATM
        static void ColorizeScreen()
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.Clear();
            
        }

        // CenterText will center text in the console window. Inspiration came from MSDN docs on String.Format and this stackoverflow article: stackoverflow.com/questions/21917203/how-do-i-center-text-in-a-console-application
        static void CenterText(string text)
        {
            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (text.Length / 2)) + "}", text));
        }

        // ColumnizeText is similar to center text except it will center the text across two columns
        static void ColumnizeText(string menuSelector, string selectorText)
        {
            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 3) + (menuSelector.Length)) + "} {1," + ((Console.WindowWidth / 4) + (selectorText.Length)) + "}", menuSelector, selectorText));
        }


    }
}
