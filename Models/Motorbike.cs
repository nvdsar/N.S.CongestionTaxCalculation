using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Interfaces;

namespace Models
{
    public class Motorbike : IVehicle
    {
        public string GetVehicleType()
        {
            return "Motorcycle";
        }
    }
}