using System;
using System.Collections.Generic;
using System.Text;

namespace VendingMachineKata
{
    public class Products
    {
        //Klas tworzy listę produktów i wydaje je
        public List<Product> ProductsList { get; set; }
        public Product Chosen { get; set; }
        public Products()
        {
            ProductsList = new List<Product>();
            ProductsList.Add(new Product(101, "Cola",   1.00));
            ProductsList.Add(new Product(102, "Chips",  0.50));
            ProductsList.Add(new Product(103, "Candys", 0.65));
        }
        public void Pick(int number)
        {
            foreach (var product in ProductsList)
            {
                if(product.Id == number)
                {
                    Chosen = product;
                }
                else
                {
                    Console.WriteLine("There is no such product!!!");
                }
            }
        }

    }
}
