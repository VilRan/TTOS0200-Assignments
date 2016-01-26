using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewOverride
{
    class A
    {
        public virtual void C() { Console.WriteLine("A!"); }
        public virtual void D() { Console.WriteLine("A!"); }
    }
    class B : A
    {
        public override void C() { Console.WriteLine("B!"); }
        new public void D() { Console.WriteLine("B!"); }
    }
    class Program
    {
        static void Main(string[] args)
        {
            A a = new A();
            B b1 = new B();
            A b2 = new B();

            a.C();
            a.D();
            b1.C();
            b1.D();
            b2.C();
            b2.D();
            ((B)b2).C();
            ((B)b2).D();

            Console.ReadLine();
        }
    }
}
