using System;

namespace Дубас_Дмитро_ДЗ_4_звадання_3
{
    public class Converter
    {
        private decimal _usdRate;
        private decimal _eurRate;

        public Converter(decimal usd, decimal eur)
        {
            this._usdRate = usd;
            this._eurRate = eur;
        }

        public decimal UahToUsd(decimal uahAmount)
        {
            return uahAmount / _usdRate;
        }

        public decimal UsdToUah(decimal usdAmount)
        {
            return usdAmount * _usdRate;
        }

        public decimal UahToEur(decimal uahAmount)
        {
            return uahAmount / _eurRate;
        }

        public decimal EurToUah(decimal eurAmount)
        {
            return eurAmount * _eurRate;
        }
    }
}