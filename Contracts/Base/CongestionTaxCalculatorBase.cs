using Models.Interfaces;
using Nager.Date;
using System;

namespace Calculator.Base
{
    public abstract class CongestionTaxCalculatorBase
    {
        public CongestionTaxCalculatorBase()
        {
            DateSystem.LicenseKey = "LostTimeIsNeverFoundAgain";
        }
        public abstract int GetTax(IVehicle vehicle, DateTime[] dates);
        protected abstract int GetTollFee(DateTime date, IVehicle vehicle);
        protected abstract bool IsTollFreeDate(DateTime date);
        protected abstract bool IsTollFreeVehicle(IVehicle vehicle);
    }
}