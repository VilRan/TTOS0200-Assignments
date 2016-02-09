using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recap
{
    class InvoiceItem
    {
        public string Name;
        public double Price;
        public int Quantity;

        public double Total { get { return Price * Quantity; } }

        public override string ToString()
        {
            return String.Format("{0,-6} {1:N}e {2} pieces {3:N}e total", Name, Price, Quantity, Total);
        }
    }
}
