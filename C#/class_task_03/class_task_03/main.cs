using System;

namespace class_task_03
{
    public delegate void CurrencyRateChangedEventHandler(decimal currentRate, decimal newRate);

    public class Exchange
    {
        private decimal currentRate;

        public event CurrencyRateChangedEventHandler RateDecreased;
        public event CurrencyRateChangedEventHandler RateIncreased;

        public Exchange(decimal initialRate)
        {
            currentRate = initialRate;
        }

        public void SimulateRateChange(decimal newRate)
        {
            if (newRate < currentRate)
            {
                RateDecreased?.Invoke(currentRate, newRate);
            }
            else if (newRate > currentRate)
            {
                RateIncreased?.Invoke(currentRate, newRate);
            }

            currentRate = newRate;
        }
    }

    public class Trader
    {
        public string Name { get; private set; }
        public decimal Amount { get; private set; }

        public Trader(string name, decimal initialAmount)
        {
            Name = name;
            Amount = initialAmount;
        }

        public void DisplayBalance()
        {
            Console.WriteLine($"[{Name}] Current balance: {Amount}");
        }

        public void HandleRateDecreased(decimal currentRate, decimal newRate)
        {
            Console.WriteLine($"[{Name}] Selling currency at rate: {newRate}");
      
            Amount -= Amount * (currentRate - newRate); 
            DisplayBalance();
        }

        public void HandleRateIncreased(decimal currentRate, decimal newRate)
        {
            Console.WriteLine($"[{Name}] Buying currency at rate: {newRate}");
     
            Amount += Amount * (newRate - currentRate); 
            DisplayBalance();
        }

        public void SimulateTrading(Exchange exchange, decimal rate)
        {
            exchange.RateDecreased += HandleRateDecreased;
            exchange.RateIncreased += HandleRateIncreased;

            exchange.SimulateRateChange(rate);

            exchange.RateDecreased -= HandleRateDecreased;
            exchange.RateIncreased -= HandleRateIncreased;
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            Exchange exchange = new Exchange(1.5m);

            Trader trader1 = new Trader("John", 1000m);
            Trader trader2 = new Trader("Alice", 2000m);

            trader1.SimulateTrading(exchange, 1.4m);
            trader2.SimulateTrading(exchange, 1.4m);

            trader1.SimulateTrading(exchange, 1.2m);
            trader2.SimulateTrading(exchange, 1.6m);

            trader1.SimulateTrading(exchange, 1.8m);
            trader2.SimulateTrading(exchange, 1.8m);
        }
    }
}
