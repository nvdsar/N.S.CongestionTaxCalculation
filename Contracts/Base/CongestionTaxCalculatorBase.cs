using Models.Interfaces;

namespace Calculator.Base
{
    public abstract class CongestionTaxCalculatorBase
    {
        /// <summary>
        /// Calculates tax fees according to Gothenburg laws
        /// </summary>
        /// <param name="vehicle">Type of vehicle</param>
        /// <param name="dates">An array of dates which are entry/exiting dates of the vehicle</param>
        /// <returns>Calculated toll</returns>
        public abstract int GetTax(IVehicle vehicle, params DateTime[] dates);
        /// <summary>
        /// Calculate toll fee for each <paramref name="date"/> and <paramref name="vehicle"/>
        /// </summary>
        /// <param name="date">A date of entry/exiting for the vehicle</param>
        /// <param name="vehicle">Type of vehicle</param>
        /// <returns>Calculated toll</returns>
        protected abstract int GetTollFee(DateTime date, IVehicle vehicle);
        /// <summary>
        /// Checks if this <paramref name="date"/> is toll free by the laws of the certain city
        /// </summary>
        /// <param name="date">A date of entry/exiting for the vehicle</param>
        /// <returns>Whether this date is toll free or not</returns>
        protected abstract bool IsTollFreeDate(DateTime date);
        /// <summary>
        /// Checks if this <paramref name="vehicle"/> is toll free by the laws of the certain city
        /// </summary>
        /// <param name="vehicle">Type of vehicle</param>
        /// <returns>Whether this vehicle is toll free or not</returns>
        /// <returns>Whether this vehicle is toll free or not</returns>
        protected abstract bool IsTollFreeVehicle(IVehicle vehicle);
    }
}