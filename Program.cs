using System;
using VendingMachineKata;

namespace VendingMachineKata2
{
    class Program
    {
        static void Main(string[] args)
        {
            VendingMachine machine = new VendingMachine();
            machine.ChoseProduct();
            machine.InsertingCoins();
            machine.ReturningChange();
            machine.PrintChange();
        }
    }
}
