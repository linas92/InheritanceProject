﻿using System;
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
            List<InventoryItemModel> inventory = new List<InventoryItemModel>();
            inventory.Add(new VehicleModel { DealerFee = 25, ProductName = "Nissan"});
            inventory.Add(new BookModel { ProductName = "Harry Potter", NumberOfPages = 500});

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

    public class VehicleModel: InventoryItemModel
    {
        public decimal DealerFee { get; set; }
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

    public class Excavator: InventoryItemModel, IRentable
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

