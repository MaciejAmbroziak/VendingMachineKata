using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace VendingMachineKata
{
    class VendingMachine
    {
        AcceptedCoins coins = new AcceptedCoins();
        CoinsReservoire reservoire = new CoinsReservoire();
        Products products = new Products();
        double SumThrown => coins.Sum();
        Product Product { get; set; }
        public void ChoseProduct()
        {
            if (reservoire.IsEmpty())
            {
                Console.WriteLine("Vending Machine Change Coin Reservoire is Empty");
            }
            Console.WriteLine("Chose product:");
            foreach (var product in products.ProductsList)
            {
                Console.WriteLine($"{product.Item} for {product.Value} chose: {product.Id}");
            }
            int chosen = Int32.Parse(Console.ReadLine());
            Product = products.ProductsList.Where(a => a.Id == chosen).FirstOrDefault();
        }
        public void InsertingCoins()
        {
            while (SumThrown < Product.Value)
            {
                Console.WriteLine("Throw in required sum");
                Console.WriteLine("Chose coin (0-6):");
                int thrown = Int32.Parse(Console.ReadLine());
                Coin coin = coins.CoinList.Where(a => a.Id == thrown).FirstOrDefault();
                coins.Inserting(coin);
                Console.WriteLine($"You inserted: {SumThrown}");
            }
        }
        public void ReturningChange()
        {

            double ChangeToBeGiven = SumThrown - Product.Value;
            while (ChangeToBeGiven > 0)
            {
                double previousCoinValue = 0;
                foreach (var coinSuply in reservoire.CoinsInReservoire)
                {
                    if (coinSuply.Value > 0)
                    {
                        if (coinSuply.Key.Value <= ChangeToBeGiven)
                        {
                            if (previousCoinValue < coinSuply.Key.Value)
                            {
                                previousCoinValue = coinSuply.Key.Value;

                            }
                        }
                    }
                }
                if (reservoire.IsEmpty())
                {
                    break;
                }

                ChangeToBeGiven = ChangeToBeGiven-previousCoinValue;
                reservoire.ChangeCoinList.Add(coins.CoinList.Where(a => a.Value == previousCoinValue).FirstOrDefault());
                reservoire.updateCoinsReservoir(reservoire.CoinsInReservoire.Where(a => a.Key.Value == previousCoinValue).FirstOrDefault().Key);
                
            }
        }
        public void PrintChange()
        {
            foreach(var coin in reservoire.ChangeCoinList)
            {
                Console.WriteLine(coin.Name);
            }
        }

    }
}
