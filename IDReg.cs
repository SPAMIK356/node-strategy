using System;
using System.Collections.Generic;
using System.Text;

namespace NodeStrategy
{
    public static class IDReg
    {
        private static int currentId = 0;

        public static int NextID
        {
            get
            {
                return currentId++;
            }
        }

    }
}
