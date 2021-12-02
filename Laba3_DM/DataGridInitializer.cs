using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba3_DM
{
    class DataGridInitializer
    { 
        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }
        
        public int F { get; set; }

        public int Fbin { get; set; }

        public DataGridInitializer(int x, int y, int z, int f, int fbin)
        {
            X = x;
            Y = y;
            Z = z;
            F = f;
            Fbin = fbin;
        }
    }
}
