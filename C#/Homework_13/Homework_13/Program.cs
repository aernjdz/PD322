using System;
using System.Net;
using Newtonsoft.Json;
using System.Linq;
using System.Collections.Generic;

namespace Homework_13
{
    class Program
    {
        static void Main()
        {
            try
            {
             
                WebClient wc = new WebClient();
                string json = wc.DownloadString("https://api.privatbank.ua/p24api/pubinfo?json&exchange&coursid=5");

              
                List<Currency> currencies = JsonConvert.DeserializeObject<List<Currency>>(json);
               
           
                Console.WriteLine("Available currencies:");
                foreach (var currency in currencies)
                {      

                    Console.WriteLine($"{currency.ccy} - {currency.base_ccy}");
                }

                Console.Write("Enter the currency code (e.g., USD): ");
                string selectedCurrencyCode = Console.ReadLine().ToUpper();

             
                Currency selectedCurrency = currencies.Find(c => c.ccy == selectedCurrencyCode);

           
                if (selectedCurrency != null)
                {
                    Console.WriteLine($"Buy rate for {selectedCurrency.ccy}: {selectedCurrency.buy}");
                    Console.WriteLine($"Sale rate for {selectedCurrency.ccy}: {selectedCurrency.sale}");
                }
                else
                {
                    Console.WriteLine("Currency not found.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
