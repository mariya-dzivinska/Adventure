using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adventure
{

    public interface IVehicleFactory
    {
        public IBike CreateBike();
        public ICar CreateCar();
    }

    public class SportVehicleFactory : IVehicleFactory
    {
        public IBike CreateBike()
        {
            return new SportBike();
        }

        public ICar CreateCar()
        {
            return new SportCar();
        }
    }

    public class RegularVehicleFactory : IVehicleFactory
    {
        public IBike CreateBike()
        {
            return new RegularBike();
        }

        public ICar CreateCar()
        {
            return new RegularCar();
        }
    }

    public interface IBike
    {
        public VehicleType VehicleType { get; set; }

        public string GetFullInfo();
    }

    public interface ICar
    {
        public VehicleType VehicleType { get; set; }
        public string GetFullInfo();
    }

    public class SportCar : ICar
    {
        public VehicleType VehicleType { get; set; } = VehicleType.Sport;

        public string GetFullInfo()
        {
            return VehicleType.ToString();
        }
    }

    public class RegularCar : ICar
    {
        public VehicleType VehicleType { get; set; } = VehicleType.Regular;

        public string GetFullInfo()
        {
            return VehicleType.ToString();
        }
    }

    public class SportBike : IBike
    {
        public VehicleType VehicleType { get; set; } = VehicleType.Sport;

        public string GetFullInfo()
        {
            return VehicleType.ToString();
        }
    }

    public class RegularBike : IBike
    {
        public VehicleType VehicleType { get; set; } = VehicleType.Regular;

        public string GetFullInfo()
        {
            return VehicleType.ToString();
        }
    }

    public enum VehicleType
    {
        Sport,
        Regular
    }
}
