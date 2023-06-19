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
                    Console.WriteLine($"You can rent: \n{rent}");
                }
            }
            else if (rentalDecision.ToLower() == "purchase")
            {
                foreach (var purchase in purchasables)
                {
                    Console.WriteLine($"You can buy: \n{purchase}");
                }
            }
            else
            {
                Console.WriteLine("Something wrong. Please enter the correct phrase to countinue");
            }

            Console.ReadLine();
        }
    }

    public interface IRentable
    {
        void Rent();
        void ReturnRental();
    }
    public interface IPurchasable
    {
        void Purchase();
    }

    public class InventoryItemModel
    {
        public string ProductName { get; set; }
        public int QuantityInStock { get; set; }
    }

    public class VehicleModel: InventoryItemModel, IPurchasable, IRentable
    {
        public decimal DealerFee { get; set; }

        public void Purchase()
        {
            QuantityInStock -= 1;
            Console.WriteLine("This vehicle has been purchased");
        }

        public void Rent()
        {
            QuantityInStock -= 1;
            Console.WriteLine("This vehicle has been rented");
        }

        public void ReturnRental()
        {
            QuantityInStock += 1;
            Console.WriteLine("This vehicle has been returned");
        }
    }

    public class BookModel: InventoryItemModel, IPurchasable
    {
        public int NumberOfPages { get; set; }

        public void Purchase()
        {
            QuantityInStock -= 1;
            Console.WriteLine("This book has been purchased");
        }
    }

    public class ExcavatorModel: InventoryItemModel, IRentable
    {
        public void Dig()
        {
            Console.WriteLine("I DIG!");
        }

        public void Rent()
        {
            QuantityInStock -= 1;
            Console.WriteLine("This Excavator has been rented");
        }

        public void ReturnRental()
        {
            QuantityInStock += 1;
            Console.WriteLine("This Excavator has been returned");
        }
    }
}

