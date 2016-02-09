using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recap
{
    class Invoice
    {
        public string Customer = "";
        public List<InvoiceItem> Items = new List<InvoiceItem>();
        public double Total { get { return Items.Sum(i => i.Total); } }

        public void PrintInvoice()
        {
            Console.WriteLine("Customer {0}'s invoice:");
            Console.WriteLine("=================================");
            foreach (InvoiceItem item in Items)
                Console.WriteLine(item);
            Console.WriteLine("=================================");
            Console.WriteLine("Total : {0} euros", Total);
        }
    }
}
