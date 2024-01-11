using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adventure.Business.Services
{
    public interface IDino
    {
        void Roar();
    }

    public class Dino : IDino
    {
        public void Roar()
        {
            Console.WriteLine("Roar");
        }
    }

    public class LoudDinoDecorator : IDino
    {
        protected readonly IDino _dino;

        public LoudDinoDecorator(IDino dino)
        {
            _dino = dino;
        }


        public void Roar()
        {
            _dino.Roar();
            Console.WriteLine("Loud");
        }
    }
}
