using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adventure
{
    public sealed class DbContextSingleton
    {
        private static DbContextSingleton instance;
        public static readonly object lockObj = new object();

        private DbContextSingleton()
        {

        }

        public static DbContextSingleton GetInstance()
        {
            if (instance == null)
            {
                lock (lockObj)
                {
                    if (instance == null)
                    {
                        instance = new DbContextSingleton();
                    }
                }
            }
            return instance;
        }
    }
}
