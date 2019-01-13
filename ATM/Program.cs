using System;


namespace ATM
{
    public class Program
    {
        static decimal accountBalance = 36.00m;

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

        // Collect the user input and call the method appropriate to their selection
        static void GetMenuSelection()
        {
            try
            {
                Console.WriteLine("\n\n");
                CenterText("Your Selection: ", 1);

                string menuSelector = Console.ReadLine();
                int menuSelectorNumber = int.Parse(menuSelector);

                if (menuSelectorNumber == 1)
                {
                    GetViewBalance();
                }
                else if (menuSelectorNumber == 2)
                {
                    GetWithdrawCash();
                }
                else if (menuSelectorNumber == 3)
                {
                    GetDepositCash();
                }
                else if (menuSelectorNumber == 4)
                {
                    Environment.Exit(1);
                }
            }
            catch(Exception error)
            {
                Console.WriteLine("Please make a valid selection:");
                Console.WriteLine(error.Message);
            }
            finally
            {
                UserInterface();
            }
        }

        // Show the accountbalance on the screen
        static void GetViewBalance()
        {
            CenterText($"Current Balance:              ${ accountBalance }");

            Console.WriteLine("\n\n");
            CenterText("Press enter to make another selection.", 1);
            Console.ReadLine();
        }

        // Show the balance to the user, ask how much they want to withdraw, then show the updated balance to the user
        static void GetWithdrawCash()
        {
            try
            {
                CenterText("How much cash would like to withdraw?  $", 1);

                string userInput = Console.ReadLine();
                decimal withdrawal = decimal.Parse(userInput);

                if (withdrawal < 0)
                {
                    CenterText("Please enter a number greater than 0");
                    GetWithdrawCash();
                }

                decimal tempBalance = WithdrawCash(accountBalance, withdrawal);
                accountBalance = tempBalance;

                Console.WriteLine();
                CenterText($"You new balance is: ${accountBalance}");

                Console.WriteLine("\n\n");
                CenterText("Press enter to make another selection.", 1);
                Console.ReadLine();
            }
            catch (FormatException)
            {
                CenterText("Please provide a monetary amount.", 1);
                Console.ReadLine();
            }
        }

        // Show the balance to the user, ask how much they want to deposit, then show the updated balance to the user
        static void GetDepositCash()
        {
            try
            {
                CenterText("How much cash would like to deposit?  $", 1);

                string userInput = Console.ReadLine();
                decimal deposit = decimal.Parse(userInput);

                if (deposit < 0)
                {
                    CenterText("Please enter a number greater than 0");
                    GetWithdrawCash();
                }

                decimal tempBalance = DepositCash(accountBalance, deposit);
                accountBalance = tempBalance;

                Console.WriteLine();
                CenterText($"You new balance is: ${accountBalance}");

                Console.WriteLine("\n\n");
                CenterText("Press enter to make another selection.", 1);
                Console.ReadLine();
            }
            catch (FormatException)
            {
                CenterText("Please provide a monetary amount.", 1);
                Console.ReadLine();
            }
        }



        /**
         * CALCULATION METHODS
         **/
        // This method takes a balance and a withdrawal amount then returns a new balance equal to the balance minus the withdrawal
        public static decimal WithdrawCash(decimal balance, decimal withdrawal)
        {
            try
            { 
                if ((balance - withdrawal) < 0.00m || withdrawal < 0)
                {
                    return balance;
                }
                else
                {
                    return balance - withdrawal;
                }
            }
            catch (Exception error)
            {
                Console.WriteLine("Please provide valid input:");
                Console.WriteLine(error.Message);
            }

            return balance;
        }

        // This method takes a balance and a deposit amount then returns a new balance equal to the balance plus the deposit
        public static decimal DepositCash(decimal balance, decimal deposit)
        {
            try
            {
                if (deposit < 0)
                {
                    return balance;
                }
                else
                {
                    return balance + deposit;
                }
            }
            catch (Exception error)
            {
                Console.WriteLine("Please provide valid input:");
                Console.WriteLine(error.Message);
            }

            return balance;
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
