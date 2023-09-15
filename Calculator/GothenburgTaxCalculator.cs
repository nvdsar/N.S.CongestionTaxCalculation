using Calculator.Base;
using Models.Interfaces;
using Nager.Date;
using Nager.Date.Model;

namespace Calculator
{
    public class GothenburgTaxCalculator : CongestionTaxCalculatorBase
    {
        public override int GetTax(IVehicle vehicle, DateTime[] dates)
        {
            if (vehicle == null) throw new ArgumentNullException(nameof(vehicle));
            if (IsTollFreeVehicle(vehicle))
                return 0;

            dates = dates.OrderBy(d => d.Date).ThenBy(d => d.TimeOfDay).ToArray();
            var totalFee = 0;
            var calculatedTimes = new List<DateTime>();
            for (var i = 0; i <= dates.Length - 1; i++)
            {
                var currentTime = dates[i];
                var currentFee = GetTollFee(currentTime, vehicle);
                if (i != 0)
                {
                    DateTime previousTime = dates[i - 1];
                    var diffInMinute = new TimeSpan(currentTime.Ticks - previousTime.Ticks).TotalMilliseconds / 1000 / 60;
                    if (Math.Abs(diffInMinute) <= 60)
                    {
                        if (totalFee > 0)
                        {
                            var previousFee = GetTollFee(previousTime, vehicle);
                            totalFee -= previousFee;
                            if (previousFee >= currentFee)
                                currentFee = previousFee;
                        }
                    }
                }
                totalFee += currentFee;


            }
            //foreach (DateTime date in dates)
            //{
            //    int nextFee = GetTollFee(date, vehicle);
            //    int tempFee = GetTollFee(intervalStart, vehicle);

            //    long diffInMillies = date.Millisecond - intervalStart.Millisecond;
            //    long minutes = diffInMillies / 1000 / 60;

            //    if (minutes <= 60)
            //    {
            //        if (totalFee > 0) totalFee -= tempFee;
            //        if (nextFee >= tempFee) tempFee = nextFee;
            //        totalFee += tempFee;
            //    }
            //    else
            //    {
            //        totalFee += nextFee;
            //    }
            //}
            if (totalFee > 60) totalFee = 60;
            return totalFee;
        }
        private bool IsWithin60Minutes(DateTime initialDateTime, DateTime secondaryDateTime)
        {
            var diffInMinute = new TimeSpan(initialDateTime.Ticks - secondaryDateTime.Ticks).TotalMilliseconds / 1000 / 60;
            if (Math.Abs(diffInMinute) <= 60)
                return true;
            return false;
        }
        protected override bool IsTollFreeVehicle(IVehicle vehicle)
        {
            if (vehicle == null) return false;
            return Enum.TryParse<TollFreeVehicles>(vehicle.GetVehicleType(), true, out _);
        }
        protected override int GetTollFee(DateTime date, IVehicle vehicle)
        {
            if (IsTollFreeDate(date))
                return 0;

            var hour = date.Hour;
            var minute = date.Minute;

            if (hour == 6 && minute >= 0 && minute <= 29) return 8;
            else if (hour == 6 && minute >= 30 && minute <= 59) return 13;
            else if (hour == 7 && minute >= 0 && minute <= 59) return 18;
            else if (hour == 8 && minute >= 0 && minute <= 29) return 13;
            else if (hour == 8 && minute >= 30 && minute <= 59) return 8;
            else if (hour >= 9 && hour <= 14) return 8;
            else if (hour == 15 && minute >= 0 && minute <= 29) return 13;
            else if (hour == 15 && minute >= 30 && minute <= 59) return 18;
            else if (hour == 16) return 18;
            else if (hour == 17) return 13;
            else if (hour == 18 && minute >= 0 && minute <= 29) return 8;
            else return 0;
        }
        protected override bool IsTollFreeDate(DateTime date)
        {
            if (date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday) return true;
            if (DateSystem.IsPublicHoliday(date, CountryCode.GB) || DateSystem.IsPublicHoliday(date.AddDays(1), CountryCode.GB)) return true;
            if (date.Month == (int)Month.July) return true;
            return false;
        }
    }
}