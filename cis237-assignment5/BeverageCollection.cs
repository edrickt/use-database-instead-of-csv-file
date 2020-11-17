using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Infrastructure;

namespace cis237_assignment5
{
    class BeverageCollection
    {
        // Private Variables
        private Beverage[] beverages;
        private int beverageLength;

        UserInterface ui = new UserInterface();

        BeverageContext bc = new BeverageContext();

        // Constructor. Must pass the size of the collection.
        public BeverageCollection(int size)
        {
            this.beverages = new Beverage[size];
            this.beverageLength = 0;
        }

        // ToString override method to convert the collection to a string
        public void PrintList()
        {
            Console.WriteLine("\nPRINTING LIST OF BEVERAGE\n");
            Console.WriteLine(ui.GetItemHeader());
            foreach (Beverage bev in bc.Beverages)
            {
                Console.WriteLine(GetPrintString(bev));
            }
        }

        public void FindById()
        {
            Beverage bevToFind = bc.Beverages.Find(ui.GetSearchQuery());
            Console.WriteLine("\n" + ui.GetItemHeader() + "\n" +
                              GetPrintString(bevToFind));
        }

        public void AddNewItem()
        {
            Beverage bevToAdd = new Beverage();
            string[] bevInfo = ui.GetNewItemInformation();
            bevToAdd.id = bevInfo[0];
            bevToAdd.name = bevInfo[1];
            bevToAdd.pack = bevInfo[2];
            bevToAdd.price = Int32.Parse(bevInfo[3]);
            bevToAdd.active = Boolean.Parse(bevInfo[4]);

            try
            {
                bc.Beverages.Add(bevToAdd);
                bc.SaveChanges();
                ui.DisplayAddWineItemSuccess();
            }
            catch (DbUpdateException e)
            {
                bc.Beverages.Remove(bevToAdd);
                ui.DisplayItemAlreadyExistsError();
            }
        }

        public void RemoveItem()
        {
            Beverage bevToDelete = bc.Beverages.Find(ui.GetSearchQuery());
            if (bevToDelete != null)
            {
                bc.Beverages.Remove(bevToDelete);
                bc.SaveChanges();
            }
            else
            {
                ui.DisplayItemFoundError();
            }
        }

        public string GetPrintString(Beverage b)
        {
            return $"{b.id} {b.name} {b.pack} {b.price} {b.active}";
        }
    }
}
