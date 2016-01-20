using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Objects
{
    public class Vehicle
    {
        public string Name;
        public int Speed;
        public int Tyres;

        public void PrintData()
        {
            Console.WriteLine(ToString());
        }

        public override string ToString()
        {
            return "Name: " + Name + ", Speed: " + Speed + ", Tyres: " + Tyres;
        }
    }
}
