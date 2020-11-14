using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cis237_assignment5
{
    class BeverageCollection
    {
        // Private Variables
        private Beverage[] beverages;
        private int beverageLength;

        // Constructor. Must pass the size of the collection.
        public BeverageCollection(int size)
        {
            this.beverages = new Beverage[size];
            this.beverageLength = 0;
        }

        // ToString override method to convert the collection to a string
        public override string ToString()
        {
            // Declare a return string
            string returnString = "";

            // Loop through all of the beverages
            foreach (Beverage beverage in beverages)
            {
                // If the current beverage is not null, concat it to the return string
                if (beverage != null)
                {
                    returnString += beverage.ToString() + Environment.NewLine;
                }
            }
            // Return the return string
            return returnString;
        }
    }
}
