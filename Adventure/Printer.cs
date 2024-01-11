using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Console = System.Console;

namespace Adventure
{
    public class Printer : IPrinter
    {
        public void Print()
        {
            Console.WriteLine("Print documents");
        }
    }

    public interface IPrinter
    {
        void Print();
    }

    public class AlarmPrinterDecorator : IPrinter
    {
        protected IPrinter printer;

        public AlarmPrinterDecorator(IPrinter printer)
        {
            this.printer = printer;
        }
        public void Print()
        {
            this.printer.Print();
            Console.WriteLine("Done.Print is finished.");
        }
    }
}
