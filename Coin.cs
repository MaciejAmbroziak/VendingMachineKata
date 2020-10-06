using System;
using System.Collections.Generic;
using System.Text;

namespace VendingMachineKata
{
    public class Coin
    {
        //Klasa tworzy obiekt moneta
        public Coin()
        {

        }
        public Coin(int id, string name, double value, double weight, double diameter)
        {
            Id = id;
            Name = name;
            Value = value;
            Weight = weight;
            Diameter = diameter;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public double Value { get; set; }
        public double Weight { get; set; }
        public double Diameter { get; set; }
        public double MaximumWeight => Weight * 1.005;
        public double MinimumWeight => Weight * 0.995;
        public double MaximumDiameter => Diameter * 1.005;
        public double MinimumDiameter => Diameter * 0.995;
    }
}
