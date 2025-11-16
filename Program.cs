using System;

namespace Дубас_Дмитро_ДЗ_4_звадання_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введіть курс гривні до долара (скільки UAH за 1 USD): ");
            decimal usdCourse = Convert.ToDecimal(Console.ReadLine());

            Console.Write("Введіть курс гривні до євро (скільки UAH за 1 EUR): ");
            decimal eurCourse = Convert.ToDecimal(Console.ReadLine());

            Converter converter = new Converter(usdCourse, eurCourse);

            while (true)
            {
                Console.WriteLine("\n--- Нова Конвертація ---");

                string fromCurrency = GetCurrencyChoice("Виберіть валюту з якої конвертуємо:");
                if (fromCurrency == "EXIT") return;

                string toCurrency = GetCurrencyChoice("Виберіть валюту в яку конвертуємо:");
                if (toCurrency == "EXIT") return;

                Console.Write("Введіть суму: ");
                decimal amount = Convert.ToDecimal(Console.ReadLine());
                decimal result = 0;

                if (fromCurrency == toCurrency)
                {
                    result = amount;
                    Console.WriteLine($"Результат: {result:F2} {toCurrency} (валюти співпали)");
                }
                else if (fromCurrency == "UAH" && toCurrency == "USD")
                {
                    result = converter.UahToUsd(amount);
                    Console.WriteLine($"Результат: {result:F2} {toCurrency}");
                }
                else if (fromCurrency == "UAH" && toCurrency == "EUR")
                {
                    result = converter.UahToEur(amount);
                    Console.WriteLine($"Результат: {result:F2} {toCurrency}");
                }
                else if (fromCurrency == "USD" && toCurrency == "UAH")
                {
                    result = converter.UsdToUah(amount);
                    Console.WriteLine($"Результат: {result:F2} {toCurrency}");
                }
                else if (fromCurrency == "EUR" && toCurrency == "UAH")
                {
                    result = converter.EurToUah(amount);
                    Console.WriteLine($"Результат: {result:F2} {toCurrency}");
                }
                else if (fromCurrency == "USD" && toCurrency == "EUR")
                {
                    decimal uahAmount = converter.UsdToUah(amount);
                    result = converter.UahToEur(uahAmount);
                    Console.WriteLine($"Результат: {result:F2} {toCurrency}");
                }
                else if (fromCurrency == "EUR" && toCurrency == "USD")
                {
                    decimal uahAmount = converter.EurToUah(amount);
                    result = converter.UahToUsd(uahAmount);
                    Console.WriteLine($"Результат: {result:F2} {toCurrency}");
                }
            }
        }

        private static string GetCurrencyChoice(string message)
        {
            Console.WriteLine(message);
            Console.WriteLine("1. UAH");
            Console.WriteLine("2. USD");
            Console.WriteLine("3. EUR");
            Console.WriteLine("4. Вийти");
            Console.Write("Ваш вибір: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    return "UAH";
                case "2":
                    return "USD";
                case "3":
                    return "EUR";
                case "4":
                    return "EXIT";
                default:
                    Console.WriteLine("Невірний вибір, спробуйте ще раз.");
                    return GetCurrencyChoice(message);
            }
        }
    }
}