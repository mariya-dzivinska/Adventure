using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adventure
{
    public class CarBuilder : IVehicleBuilder
    {
        private Car car  = new Car();


        public IVehicleBuilder BuildElectronics()
        {
            car.Electronics = "new electronics";
            return this;
        }

        public IVehicleBuilder BuildMainParts()
        {
            car.MainParts = "Main parts";
            return this;
        }

        public IVehicleBuilder BuildMaterials()
        {
            car.Materials = "Materials";
            return this;
        }

        public Car Build()
        {
            return car;
        }
    }

    public class Car
    {
        public string MainParts { get; set; }
        public string Electronics { get; set; }

        public string Materials { get; set; }
    }

    public class Shop
    {
        public IVehicleBuilder VehicleBuilder { get; set; }

        public Shop(IVehicleBuilder builder)
        {
            VehicleBuilder = builder;
        }

        public void BasicConfiguration()
        {
            VehicleBuilder.BuildMainParts();
            
        }

        public void FullConfiguration()
        {
            VehicleBuilder.BuildMainParts()
                .BuildElectronics()
                .BuildMaterials();

        }
    }
}
