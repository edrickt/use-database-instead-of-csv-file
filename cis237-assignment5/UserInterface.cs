using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cis237_assignment5
{
    class UserInterface
    {
        const int MAX_MENU_CHOICES = 5;
        BeverageContext bc = new BeverageContext();

        /*
        |----------------------------------------------------------------------
        | Public Methods
        |----------------------------------------------------------------------
        */

        // Display Welcome Greeting
        public void DisplayWelcomeGreeting()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Welcome to the wine program!");
            Console.WriteLine("Beverages loaded");
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        // Display Menu And Get Response
        public int DisplayMenuAndGetResponse()
        {
            // Declare variable to hold the selection
            string selection;

            // Display menu, and prompt
            this.DisplayMenu();
            this.DisplayPrompt();

            // Get the selection they enter
            selection = this.GetSelection();

            // While the response is not valid
            while (!this.VerifySelectionIsValid(selection))
            {
                // Display error message
                this.DisplayErrorMessage();

                // Display the prompt again
                this.DisplayPrompt();

                // Get the selection again
                selection = this.GetSelection();
            }
            // Return the selection casted to an integer
            return Int32.Parse(selection);
        }

        // Get the search query from the user
        public string GetSearchQuery()
        {
            Console.WriteLine();
            Console.WriteLine("Please enter primary key");
            Console.Write("> ");
            return Console.ReadLine();
        }

        // Get New Item Information From The User.
        public string[] GetNewItemInformation()
        {
            Console.WriteLine("");
            string id = this.GetStringField("Id");
            Console.WriteLine("");
            string name = this.GetStringField("Name");
            Console.WriteLine("");
            string pack = this.GetStringField("Pack");
            Console.WriteLine("");
            string price = this.GetDecimalField("Price");
            Console.WriteLine("");
            string active = this.GetBoolField("Active");
            Console.WriteLine("");

            return new string[] { id, name, pack, price, active };
        }

        // Display All Items
        public void DisplayAllItems(string allItemsOutput)
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Printing List");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(this.GetItemHeader());
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine(allItemsOutput);
        }

        // Display All Items Error
        public void DisplayAllItemsError()
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("There are no items in the list to print");
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        // Display Item Removed Success
        public void DisplayItemRemoved()
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Item removed!");
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        // Display Item Found Error
        public void DisplayItemFoundError()
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("A Match was not found");
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        // Display Add Wine Item Success
        public void DisplayAddWineItemSuccess()
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("The Item was successfully added");
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        public void DisplayUpdateWineItemSuccess()
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("The Item was successfully updated");
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        // Display Item Already Exists Error
        public void DisplayItemAlreadyExistsError()
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("An Item With That Id Already Exists");
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        /*
        |----------------------------------------------------------------------
        | Private Methods
        |----------------------------------------------------------------------
        */

        // Display the Menu
        private void DisplayMenu()
        {
            Console.WriteLine();
            Console.WriteLine("What would you like to do?");
            Console.WriteLine();
            Console.WriteLine("1. Print list of beverages");
            Console.WriteLine("2. Search beverage by primary ID");
            Console.WriteLine("3. Add new beverage");
            Console.WriteLine("4. Update beverage");
            Console.WriteLine("5. Delete beverage");
        }

        // Display the Prompt
        private void DisplayPrompt()
        {
            Console.WriteLine();
            Console.Write("Enter Your Choice: ");
        }

        // Display the Error Message
        private void DisplayErrorMessage()
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("That is not a valid option. Please make a valid choice");
        }

        // Get the selection from the user
        private string GetSelection()
        {
            return Console.ReadLine();
        }

        // Verify that a selection from the main menu is valid
        private bool VerifySelectionIsValid(string selection)
        {
            // Declare a returnValue and set it to false
            bool returnValue = false;

            try
            {
                // Parse the selection into a choice variable
                int choice = Int32.Parse(selection);

                // If the choice is between 0 and the maxMenuChoice
                if (choice > 0 && choice <= MAX_MENU_CHOICES)
                {
                    // Set the return value to true
                    returnValue = true;
                }
            }
            // If the selection is not a valid number, this exception will be thrown
            catch (Exception e)
            {
                // Set return value to false even though it should already be false
                returnValue = false;
            }

            // Return the reutrnValue
            return returnValue;
        }

        // Get a valid string field from the console
        public string GetStringField(string fieldName)
        {
            Console.WriteLine("New {0}:", fieldName);
            Console.Write("> ");
            string value = null;
            bool valid = false;
            while (!valid)
            {
                value = Console.ReadLine();
                if (!String.IsNullOrWhiteSpace(value))
                {
                    valid = true;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("You must provide a value.");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine();
                    Console.WriteLine("New {0}:", fieldName);
                    Console.Write("> ");
                }
            }
            return value;
        }

        // Get a valid decimal field from the console
        public string GetDecimalField(string fieldName)
        {
            Console.WriteLine("New {0}:", fieldName);
            decimal value = 0;
            bool valid = false;
            while (!valid)
            {
                try
                {
                    value = decimal.Parse(Console.ReadLine());
                    valid = true;
                }
                catch (Exception)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("That is not a valid Decimal. Please enter a valid Decimal.");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine();
                    Console.WriteLine("New {0}:", fieldName);
                    Console.Write("> ");
                }
            }

            return value.ToString();
        }

        // Get a valid bool field from the console
        public string GetBoolField(string fieldName)
        {
            Console.WriteLine("Should the Item be {0} (y/n)", fieldName);
            string input = null;
            bool value = false;
            bool valid = false;
            while (!valid)
            {
                input = Console.ReadLine();
                if (input.ToLower() == "y" || input.ToLower() == "n")
                {
                    valid = true;
                    value = (input.ToLower() == "y");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("That is not a valid Entry.");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine();
                    Console.WriteLine("Should the Item be {0} (y/n)", fieldName);
                    Console.Write("> ");
                }
            }

            return value.ToString();
        }

        // Get a string formatted as a header for items
        public string GetItemHeader()
        {
            return String.Format(
                "{0,-6} {1,-55} {2,-15} {3,6} {4,-6}",
                "Id",
                "Name",
                "Pack",
                "Price",
                "Active"
            ) +
            Environment.NewLine +
            String.Format(
                "{0,-6} {1,-55} {2,-15} {3,6} {4,-6}",
                new String('-', 6),
                new String('-', 40),
                new String('-', 15),
                new String('-', 6),
                new String('-', 5)
            );
        }
        public int WhichToUpdate()
        {
            Console.WriteLine("\nWhich property would you like to update?");
            Console.WriteLine("1. Name");
            Console.WriteLine("2. Pack");
            Console.WriteLine("3. Price");
            Console.WriteLine("4. Active");
            Console.WriteLine("5. EXIT");
            Console.Write("\n> ");
            string choice = Console.ReadLine();
            int choiceInt = 5;
            bool correct = false;
            while (correct == false)
            {
                if (int.TryParse(choice, out choiceInt))
                {
                    correct = true;
                    return choiceInt;
                }
                else
                {
                    Console.WriteLine("PLEASE ENTER VALID OPTION");
                }
            }
            return choiceInt;
        }
    }
}
