using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Objects
{
    public class House
    {
        List<Person> occupants = new List<Person>();
        double width, depth, height;
        int floors;

        public IEnumerable<Person> Occupants { get { return occupants; } }
        public double FloorArea { get { return width * depth * floors; } }

        public House(double width, double depth, double height, int floors)
        {
            this.width = width;
            this.depth = depth;
            this.height = height;
            this.floors = floors;
        }

        public void MoveIn(params Person[] people)
        {
            foreach (Person person in people)
                occupants.Add(person);
        }

        public void MoveOut(params Person[] people)
        {
            foreach (Person person in people)
                occupants.Add(person);
        }
    }
}
