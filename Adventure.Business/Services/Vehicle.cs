using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adventure.Business.Services
{
    public enum VehicleType
    {
        Car,
        Motorcycle
    }

    public class Vehicle
    {
        public VehicleType Type { get; set; }

        public double CalculateInsurancePremium()
        {
            double basePremium = 1000;

            if (Type == VehicleType.Car)
            {
                return basePremium * 1.5;
            }
            else if (Type == VehicleType.Motorcycle)
            {
                return basePremium * 2;
            }

            return basePremium;
        }
    }

    public abstract class VehicleOCP
    {
        public virtual double CalculateInsurancePremium()
        {
            throw new NotImplementedException();
        }
    }

    public class CarOCP : VehicleOCP
    {
        public override double CalculateInsurancePremium()
        {
            double basePremium = 1000;
            return basePremium * 1.5;
        }
    }

    public class MotorcycleOCP : VehicleOCP
    {
        public override double CalculateInsurancePremium()
        {
            double basePremium = 1000;
            return basePremium * 2;
        }
    }

    public class BikeOCP : VehicleOCP
    {
        public override double CalculateInsurancePremium()
        {
            double basePremium = 1000;
            return basePremium * 2;
        }
    }

}
