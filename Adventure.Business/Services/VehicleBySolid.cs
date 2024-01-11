using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adventure.Business.Services
{
    public abstract class VehicleBySolid
    {
        public abstract double CalculateInsurancePremium();
    }

    public class Car : VehicleBySolid
    {
        public override double CalculateInsurancePremium()
        {
            double basePremium = 1000;
            return basePremium * 1.5;
        }
    }

    public class Motorcycle : VehicleBySolid
    {
        public override double CalculateInsurancePremium()
        {
            double basePremium = 1000;
            return basePremium * 2;
        }
    }
}
