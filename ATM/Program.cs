﻿using System;


namespace ATM
{
    public class Program
    {
        static decimal accountBalance = 0.00m;

        static void Main(string[] args)
        {
            UserInterface();

            Console.ReadLine();
        }

        /**
         * INTERFACE METHODS
         **/

        // The userinterface will interact with the user
        static void UserInterface()
        {
            ColorizeScreen();
            ShowHeading();
            ShowMenu();
            GetMenuSelection();
        }

        // Show heading is responsible for showing the credit union slogan
        static void ShowHeading()
        {
            Console.Clear();
            CenterText("Welcome to Code Fellows Credit Union.\n");
            CenterText("Thank you for your membership!\n\n\n");
        }

        // Show the menu items
        static void ShowMenu()
        {
            CenterText("Please select an option:");
            CenterText("------------------------");
            CenterText("1.    View your balance.");
            CenterText("2.        Withdraw cash.");
            CenterText("3.         Deposit cash.");
        }

        // Collect the user input
        static void GetMenuSelection()
        {
            CenterText("Your Selection: ", 1);

            string menuSelector = Console.ReadLine();

            if (menuSelector.Contains("1"))
            {
                GetViewBalance();
            }
            else if (menuSelector.Contains("2"))
            {
                GetWithdrawCash();
            }
            else if (menuSelector.Contains("3"))
            {
                GetDepositCash();

            }
        }

        static void GetViewBalance()
        {
            ShowHeading();

            CenterText($"Current Balance:              ${ accountBalance }");
        }

        static void GetWithdrawCash()
        {
            GetViewBalance();

            Console.WriteLine("\n\n");
            CenterText("How much cash would like to withdraw?  ", 1);

        }

        static void GetDepositCash()
        {
            Console.WriteLine("In DepositCash");
        }


        /**
         * CALCULATION METHODS
         **/


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
        static void CenterText(string text, int writeLine = 0)
        {
            if (writeLine == 0)
            {
                Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (text.Length / 2)) + "}", text));
            }
            else
            {
                Console.Write(String.Format("{0," + ((Console.WindowWidth / 2) + (text.Length / 2)) + "}", text));
            }
        }
    }
}
