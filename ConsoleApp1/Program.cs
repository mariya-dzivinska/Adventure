using Adventure;
using Adventure.FactoryMethod;

public class Program
{


    public static void Main(string[] args)
    {
        var service = new OrderService();
        IOrderService orderService = service;
        var result = orderService.GetLogger(new ConsoleLoggerProvider());
    }   
}
