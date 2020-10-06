using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VendingMachineKata
{
    public class AcceptedCoins
    {
        //Klasa ustanawia akceptowalne monety i identyfikuje je, dodaje do listy zapłaty
        public List<Coin> CoinList { get;} 
        public List<Coin> InsertedCoinList { get; }
        public Coin InsertedCoin { get; set; }
        public AcceptedCoins()
        {
            InsertedCoinList = new List<Coin>();
            CoinList = new List<Coin>();
            CoinList.Add(new Coin { Id = 0, Name = "Unknown", Weight = 0.00, Diameter = 0.00, Value = 0.0 });
            CoinList.Add(new Coin { Id = 1, Name = "0.10", Weight = 0.01, Diameter = 0.01, Value = 0.1 });
            CoinList.Add(new Coin { Id = 2, Name = "0.20", Weight = 0.02, Diameter = 0.02, Value = 0.2 });
            CoinList.Add(new Coin { Id = 3, Name = "0.50", Weight = 0.05, Diameter = 0.05, Value = 0.5 });
            CoinList.Add(new Coin { Id = 4, Name = "1.00", Weight = 0.10, Diameter = 0.10, Value = 1.0 });
            CoinList.Add(new Coin { Id = 5, Name = "2.00", Weight = 0.20, Diameter = 0.20, Value = 2.0 });
            CoinList.Add(new Coin { Id = 6, Name = "5.00", Weight = 0.50, Diameter = 0.50, Value = 5.0 });
        }
        private int MeasureWeight(Coin insertedCoin)
        {
            foreach (var coin in CoinList)
            {
                if (insertedCoin.Weight < coin.MaximumWeight && insertedCoin.Weight > coin.MinimumWeight)
                {
                    return coin.Id;
                }
            }
            return -1;
        }
        private int MeasureDiameter(Coin insertedCoin)
        {
            foreach (var coin in CoinList)
            {
                if (insertedCoin.Diameter < coin.MaximumDiameter && insertedCoin.Weight > coin.MinimumDiameter)
                {
                    return coin.Id;
                }
            }
            return -1;
        }
        private Coin CoinIdentification(Coin insertedCoin)
        {
            int tempId = MeasureWeight(insertedCoin);
            if (MeasureWeight(insertedCoin) == MeasureDiameter(insertedCoin) && MeasureDiameter(insertedCoin) != -1)
            {
                InsertedCoin = CoinList.Where(a => a.Id == tempId).FirstOrDefault();
            }
            else
            {
                InsertedCoin = new Coin(0, "Unknown", 0, 0, 0);
            }
            return InsertedCoin;
        }
        public void Inserting(Coin insertedCoin)
        {
            Coin coin = CoinIdentification(insertedCoin);
            InsertedCoinList.Add(coin);
        }
        public double Sum()
        {
            double result = 0;
            foreach (var coin in InsertedCoinList)
            {
                result = result + coin.Value;
            }
            return result;
        }
    }
}
