using Calculator;
using Models;
using Models.Interfaces;

internal class Program
{
    private static void Main(string[] args)
    {
        IVehicle vehicle = new Car();
        var dates = new DateTime[]
        {
            new DateTime(2013,1,14,21,0,0),
            new DateTime(2013,1,15,21,0,0),
            new DateTime(2013,2,07,06,23,27),
            new DateTime(2013,2,07,15,27,00),
            new DateTime(2013,2,08,06,27,00),
            new DateTime(2013,2,08,06,20,27),
            new DateTime(2013,2,08,14,35,00),
            new DateTime(2013,2,08,15,29,00),
            new DateTime(2013,2,08,15,47,00),
            new DateTime(2013,2,08,16,01,00),
            new DateTime(2013,2,08,16,48,00),
            new DateTime(2013,2,08,17,49,00),
            new DateTime(2013,2,08,18,29,00),
            new DateTime(2013,2,08,18,35,00),
            new DateTime(2013,3,26,14,25,00),
            new DateTime(2013,3,28,14,07,00),
        };
        var ctc = new GothenburgTaxCalculator();
        var tax = ctc.GetTax(vehicle, dates);
        Console.WriteLine($"{vehicle.GetVehicleType()} tax : {tax}");
        Console.ReadKey();
    }
}