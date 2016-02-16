using Microsoft.VisualStudio.TestTools.UnitTesting;
using Recap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recap.Tests
{
    [TestClass()]
    public class InvoiceTests
    {
        [TestMethod()]
        public void TotalTest()
        {
            Invoice invoice = new Invoice() { Customer = "Kirsi Kernel" };
            invoice.Items.Add(new InvoiceItem() { Name = "Milk", Price = 1.75, Quantity = 1 });
            invoice.Items.Add(new InvoiceItem() { Name = "Beer", Price = 5.25, Quantity = 1 });
            invoice.Items.Add(new InvoiceItem() { Name = "Butter", Price = 2.50, Quantity = 2 });

            double expected = 1.75 + 5.25 + 2.50 * 2;
            double actual = invoice.Total;
            Assert.AreEqual(expected, actual);
        }
    }
}