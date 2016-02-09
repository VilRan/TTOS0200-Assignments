using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recap
{
    class Product
    {
        public string Type;
        public double Price;

        public override string ToString()
        {
            return Type + " " + Price + " e";
        }
    }
}
