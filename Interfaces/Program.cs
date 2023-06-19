using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InheritanceProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // List<InventoryItemModel> inventory = new List<InventoryItemModel>();

            List<IRentable> rentables = new List<IRentable>();

            List<IPurchasable> purchasables = new List<IPurchasable>();

            var vehicle = new VehicleModel { DealerFee = 25, ProductName = "Nissan" };

            var book = new BookModel { ProductName = "Harry Potter", NumberOfPages = 500 };

            var excavator = new ExcavatorModel { ProductName = "Subaru Monster Claw", QuantityInStock = 2 };


            rentables.Add(vehicle);
            rentables.Add(excavator);

            purchasables.Add(book);
            purchasables.Add(vehicle);


            Console.Write("Do you want to rent or purchase? (rent, purchase)");
            string rentalDecision = Console.ReadLine();

            if (rentalDecision.ToLower() == "rent")
            {
                foreach (var rent in rentables)
                {
                    Console.WriteLine($"You can rent: \n{rent.ProductName}");
                    Console.Write("Do you want to rent this item (yes/no): ");

                    string wantToRent = Console.ReadLine();

                    if (wantToRent.ToLower() == "yes")
                    {
                        rent.Rent();
                    }

                    Console.WriteLine("Do you want to return this item (yes/no): ");

                    string wantToReturn = Console.ReadLine();

                    if (wantToReturn.ToLower() == "yes")
                    {
                        rent.ReturnRental();
                    }
                }
            }

            else if (rentalDecision.ToLower() == "purchase")
            {
                foreach (var purchase in purchasables)
                {
                    Console.WriteLine($"You can buy: \n{purchase.ProductName}");
                    Console.Write("Do you want to purchase this item (yes/no): ");

                    string wantToPurchase = Console.ReadLine();

                    if (wantToPurchase.ToLower() == "yes")
                    {
                        purchase.Purchase();
                    }
                }
            }

            else
            {
                Console.WriteLine("Something wrong. We have to say goodbye");
            }
            Console.WriteLine("we dooone :))) ");

            Console.ReadLine();
        }
    }
}

