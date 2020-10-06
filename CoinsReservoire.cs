using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace VendingMachineKata
{
    public class CoinsReservoire
    {
        //Klasa tworzy rezerwuar monet i wydaje resztę
        public AcceptedCoins PossibleCoins;
        public Dictionary<Coin, int> CoinsInReservoire { get; set; }
        public List<Coin> ChangeCoinList { get; set; }
        public CoinsReservoire()
        {
            ChangeCoinList = new List<Coin>();
            PossibleCoins = new AcceptedCoins();
            CoinsInReservoire = new Dictionary<Coin, int>();
            CoinsInReservoire.Add(PossibleCoins.CoinList[0], 0);
            CoinsInReservoire.Add(PossibleCoins.CoinList[1], 0);
            CoinsInReservoire.Add(PossibleCoins.CoinList[2], 0);
            CoinsInReservoire.Add(PossibleCoins.CoinList[3], 0);
            CoinsInReservoire.Add(PossibleCoins.CoinList[4], 0);
            CoinsInReservoire.Add(PossibleCoins.CoinList[5], 0);
            CoinsInReservoire.Add(PossibleCoins.CoinList[6], 0);
        }
        public void updateCoinsReservoir(Coin coin)
        {
            if (!IsEmpty())
            {
                CoinsInReservoire[coin]--;
            }
        }
        
        public void PrintChange()
        {
            foreach(var coin in ChangeCoinList)
            {
                Console.WriteLine($"{coin.Name}");
            }
        }
        public bool IsEmpty()
        {
            int cos = 0;
            foreach (var coin in CoinsInReservoire)
            {
                cos = cos + coin.Value;
            };
            if (cos <= 0)
            {
                Console.WriteLine("Vending machine change coin supply is empty");
                return true;
            }
            return false;
        }
    }
}
