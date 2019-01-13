using System;


namespace ATM
{
    public class Program
    {
        static decimal accountBalance = 0.00m;

        static void Main(string[] args)
        {
            UserInterface();

            Console.WriteLine("Please press any key to exit...");
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
            CenterText("4.                 Quit.");
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
            else if (menuSelector.Contains("4"))
            {
                Environment.Exit(1);
            }
        }

        // Show the accountbalance on the screen
        static void GetViewBalance()
        {
            ShowHeading();

            CenterText($"Current Balance:              ${ accountBalance }");
        }

        // Show the balance to the user, ask how much they want to withdraw, then show the updated balance to the user
        static void GetWithdrawCash()
        {
            try
            {
                GetViewBalance();

                Console.WriteLine("\n\n");
                CenterText("How much cash would like to withdraw?  ", 1);

                string userInput = Console.ReadLine();
                decimal withdrawal = decimal.Parse(userInput);

                decimal tempBalance = WithdrawCash(accountBalance, withdrawal);
                accountBalance = tempBalance;

                Console.WriteLine();
                CenterText($"You new balance is: ${accountBalance}");
            }
            catch (FormatException)
            {
                CenterText("Please provide a monetary amount.");

                GetWithdrawCash();
            }
        }

        // Show the balance to the user, ask how much they want to deposit, then show the updated balance to the user
        static void GetDepositCash()
        {
            try
            {
                GetViewBalance();

                Console.WriteLine("\n\n");
                CenterText("How much cash would like to deposit?  ", 1);

                string userInput = Console.ReadLine();
                decimal deposit = decimal.Parse(userInput);

                decimal tempBalance = DepositCash(accountBalance, deposit);
                accountBalance = tempBalance;

                Console.WriteLine();
                CenterText($"You new balance is: ${accountBalance}");
            }
            catch (FormatException)
            {
                CenterText("Please provide a monetary amount.");

                GetDepositCash();
            }
        }



        /**
         * CALCULATION METHODS
         **/
        // This method takes a balance and a withdrawal amount then returns a new balance equal to the balance minus the withdrawal
        public static decimal WithdrawCash(decimal balance, decimal withdrawal)
        {
            decimal newBalance = balance - withdrawal;

            if ( newBalance < 0.00m )
            {
                newBalance = 0.00m;
            }

            return newBalance;
        }

        // This method takes a balance and a deposit amount then returns a new balance equal to the balance plus the deposit
        public static decimal DepositCash(decimal balance, decimal deposit)
        {
            decimal newBalance = balance + deposit;

            return newBalance;
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
