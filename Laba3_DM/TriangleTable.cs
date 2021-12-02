using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba3_DM
{
    class TriangleTable
    {
        public string e1 { get; set; }
        public string e2 { get; set; }
        public string e3 { get; set; }
        public string e4 { get; set; }
        public string e5 { get; set; }
        public string e6 { get; set; }
        public string e7 { get; set; }
        public string e8 { get; set; }

        public TriangleTable()
        {

        }

        public TriangleTable(string e1, string e2, string e3, string e4, string e5, string e6, string e7, string e8)
        {
            this.e1 = e1;
            this.e2 = e2;
            this.e3 = e3;
            this.e4 = e4;
            this.e5 = e5;
            this.e6 = e6;
            this.e7 = e7;
            this.e8 = e8;
        }
    }
}
