using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adventure
{
    public sealed class SingltonClass
    {
        private static SingltonClass instance;
        private static readonly object lockObj = new object();

        private SingltonClass()
        {
        }

        public static SingltonClass GetInstance()
        {
            if (instance == null)
            {
                lock (lockObj)
                {
                    if (instance == null)
                    {
                        instance = new SingltonClass();
                    }
                }
            }
            return instance;
        }

        //
    }
}
