﻿// Edrick Tamayo
// 3:30 Thursday
// 20 November 2020
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cis237_assignment5
{
    class Program
    {
        static void Main(string[] args)
        {
            // Set Console Window Size
            Console.BufferHeight = Int16.MaxValue - 1;
            Console.WindowHeight = 40;
            Console.WindowWidth = 120;

            // Set a constant for the size of the collection
            const int beverageCollectionSize = 4000;

            // Create an instance of the UserInterface class
            UserInterface userInterface = new UserInterface();

            // Create an instance of the BeverageCollection class
            BeverageCollection beverageCollection = new BeverageCollection();

            // Display the Welcome Message to the user
            userInterface.DisplayWelcomeGreeting();

            // Display the Menu and get the response. Store the response in the choice integer
            // This is the 'primer' run of displaying and getting.
            int choice = userInterface.DisplayMenuAndGetResponse();

            BeverageContext bc = new BeverageContext();

            // While the choice is not exit program
            while (choice != 6)
            {
                switch (choice)
                {
                    // Print list
                    case 1:
                        beverageCollection.PrintList();
                        break;
                    // Find beverage by ID
                    case 2:
                        beverageCollection.FindById();
                        break;
                    // Add new item
                    case 3:
                        beverageCollection.AddNewItem();
                        break;
                    // Update existing item
                    case 4:
                        beverageCollection.UpdateItem();
                        break;
                    // Remove beverage
                    case 5:
                        beverageCollection.RemoveItem();
                        break;
                    case 6:
                        break;
                }

                // Get the new choice of what to do from the user
                choice = userInterface.DisplayMenuAndGetResponse();
            }
        }
    }
}
