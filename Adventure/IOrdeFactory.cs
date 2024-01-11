using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adventure
{
    public interface IOrderFactory
    {
        IMenuItem AddMenuItem();
        IDeliveryItem AddDeliveryItem();
    }

    public class ServiceOrderFactory : IOrderFactory
    {
        public IMenuItem AddMenuItem()
        {
            return new CustomMenuItem();
        }

        public IDeliveryItem AddDeliveryItem()
        {
            return new FluentDeliveryItem();
        }

    }

    public class FoodOrderFactory : IOrderFactory
    {
        public IMenuItem AddMenuItem()
        {
            return new FoodMenuItem();
        }

        public IDeliveryItem AddDeliveryItem()
        {
            return new FixedDeliveryItem();
        }

    }

    public interface IMenuItem
    {
        public string GetFullPrice();
    }

    public class CustomMenuItem : IMenuItem
    {
        public string GetFullPrice()
        {
            return "custom full price menum item ";
        }
    }

    public class FoodMenuItem : IMenuItem
    {
        public string GetFullPrice()
        {
            return "food full price menum item ";
        }
    }

    public interface IDeliveryItem
    {
        public string GetPrice();
    }

    public class FluentDeliveryItem : IDeliveryItem
    {
        public string GetPrice()
        {
            return "fluent delivery price";
        }
    }

    public class FixedDeliveryItem : IDeliveryItem
    {
        public string GetPrice()
        {
            return "fixed delivery price";
        }
    }
}
