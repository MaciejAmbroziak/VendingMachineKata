using System;
using System.Collections.Generic;
using System.Text;

namespace VendingMachineKata
{
    public class Product
    {
        //Klasa tworzy produkt
        public Product(int id, string item, double value)
        {
            Id = id;
            Item = item;
            Value = value;
        }

        public int Id { get; set; }
        public string Item { get; set; }
        public double Value { get; set; }
    }
    
}
