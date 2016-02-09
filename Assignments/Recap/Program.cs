using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Recap
{
    class Program
    {
        const int MinAssignments = 1;
        const int MaxAssignments = 6;

        static void Main(string[] args)
        {
            while (true)
            {
                Console.Write("Enter assignment number (" + MinAssignments + "-" + MaxAssignments + ") or enter something else to exit > ");
                int assignment;
                if (!int.TryParse(Console.ReadLine(), out assignment)
                    || assignment < MinAssignments || assignment > MaxAssignments)
                    break;

                Type type = typeof(Program);
                MethodInfo info = type.GetMethod("Assignment" + assignment, BindingFlags.Static | BindingFlags.Public);
                info.Invoke(null, null);
                Console.WriteLine();
            }
        }

        public static void Assignment1()
        {
            Die die = new Die();

            Console.WriteLine("How many times do you want to throw a die : ");
            int times = int.Parse(Console.ReadLine());
            die.Throw(times);

            Console.WriteLine("Die has now been thrown {0} times", die.TotalTimes);
            Console.WriteLine("- average is " + Math.Round(die.Average, 4));
            for (int i = 1; i <= 6; i++)
                Console.WriteLine("- " + i + " count is " + die.GetTimes(i));
            Console.WriteLine();
        }

        public static void Assignment2()
        {
            List<Product> products = new List<Product>();

            products.Add(new Product() { Type = "Milk", Price = 1.4 });
            products.Add(new Product() { Type = "Beer", Price = 2.2 });
            products.Add(new Product() { Type = "Butter", Price = 3.2 });
            products.Add(new Product() { Type = "Cheese", Price = 4.2 });

            Console.WriteLine("All products in collection: ");
            foreach (Product product in products)
                Console.WriteLine("- product : " + product);
        }

        public static void Assignment3()
        {

        }

        public static void Assignment4()
        {

        }

        public static void Assignment5()
        {
            double[] array = { 1.0, 2.0, 3.3, 5.5, 6.3, -4.5, 12.0 };

            Console.WriteLine("Sum = {0:N}", ArrayCalcs.Sum(array));
            Console.WriteLine("Avg = {0:N}", ArrayCalcs.Average(array));
            Console.WriteLine("Min = {0:N}", ArrayCalcs.Min(array));
            Console.WriteLine("Max = {0:N}", ArrayCalcs.Max(array));
        }

        public static void Assignment6()
        {
            Invoice invoice = new Invoice() { Customer = "Kirsi Kernel" };
            invoice.Items.Add(new InvoiceItem() { Name = "Milk", Price = 1.75, Quantity = 1 });
            invoice.Items.Add(new InvoiceItem() { Name = "Beer", Price = 5.25, Quantity = 1 });
            invoice.Items.Add(new InvoiceItem() { Name = "Butter", Price = 2.50, Quantity = 2 });

            invoice.PrintInvoice();
        }
    }
}
