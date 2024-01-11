using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adventure
{
    public class CarFactory
    {
        public ICarBuilder CarBuilder { get; set; }

        public CarFactory(ICarBuilder builder)
        {
            CarBuilder = builder;
        }

        public void BuildBasicCar()
        {
            CarBuilder.AddMainParts();
        }

        public void BuildFullCar()
        {

            CarBuilder.AddElectronics();
            CarBuilder.AddAddMaterials();
        }

    }

    public interface ICarBuilder
    {
        public void AddMainParts();
        public void AddElectronics();
        public void AddAddMaterials();
    }

    public class TruckBuilder : ICarBuilder
    {
        public Truck Truck { get; set; } = new Truck();

        public void AddMainParts()
        {
            Truck.MainParts = "Main Parts Truck";
        }

        public void AddElectronics()
        {
            Truck.Electronics = "Electornics Truck";
        }

        public void AddAddMaterials()
        {
            Truck.Material = "Premium materials Truck";
        }

        public Truck Build()
        {
            return Truck;
        }
    }

    public class BusBuilder : ICarBuilder
    {
        public Bus Bus { get; set; } = new Bus();

        public void AddMainParts()
        {
            Bus.MainParts = "Main Parts Bus";
        }

        public void AddElectronics()
        {
            Bus.Electronics = "Electornics Bus";
        }

        public void AddAddMaterials()
        {
            Bus.Material = "Premium materials Bus";
        }

        public Bus Build()
        {
            return Bus;
        }
    }

    public class Truck
    {
        public string MainParts { get; set; }
        public string Electronics { get; set; }
        public string Material { get; set; }
    }

    public class Bus
    {
        public string MainParts { get; set; }
        public string Electronics { get; set; }
        public string Material { get; set; }
    }
}
