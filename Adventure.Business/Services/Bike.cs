using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adventure.Business.Services
{
    public abstract class AbstractBike
    {
        public abstract string BikeType { get; }
        public abstract void Drive();
    }

    public class Bike : AbstractBike
    {
        public override string BikeType { get; }
        public override void Drive()
        {
            Console.WriteLine($"{BikeType} bike is driving");
        }
    }

    public class ElectricBike : AbstractBike
    {
        public override string BikeType { get; }
        public override void Drive()
        {
            Console.WriteLine($"{BikeType} electric bike is driving");
        }
    }

    public abstract class BikeDecorator : AbstractBike
    {
        public AbstractBike _bike;

        public BikeDecorator(AbstractBike bike)
        {
            _bike = bike;
        }

        public override void Drive()
        {
            _bike.Drive();
        }
    }

    public class ElectricBikeDecorator : BikeDecorator
    {
        public ElectricBikeDecorator(AbstractBike bike) : base(bike)
        {
        }

        public override string BikeType { get; }

        public override void Drive()
        {
            base.Drive();
            Console.WriteLine("Check and check you battery!");
        }
    }
}
