using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composition
{
    class Universe
    {
        public const double AstronomicalUnit = 149597870700.0;
        public const double Lightyear = 9460730472580800.0;
        public const double Parsec = 648000 / (Math.PI * AstronomicalUnit);

        public List<Galaxy> Galaxies = new List<Galaxy>();
    }

    class Galaxy
    {
        public List<CelestialBody> Bodies = new List<CelestialBody>();
    }

    class CelestialBody
    {
        public List<CelestialBody> Satellites = new List<CelestialBody>();
        public double Periapsis;
        public double Apoapsis;
        public double Mass;

        public double PeriapsisInAUs { get { return Periapsis / Universe.AstronomicalUnit; } }
        public double ApoapsisInAUs { get { return Apoapsis / Universe.AstronomicalUnit; } }
        public double PeriapsisInLightyears { get { return Periapsis / Universe.Lightyear; } }
        public double ApoapsisInLightyears { get { return Apoapsis / Universe.Lightyear; } }
        public double MassInEarths { get { return Mass / (5.97237 * Math.Pow(10, 24)); } }
        public double MassInJupiters { get { return Mass / (1.8986 * Math.Pow(10, 27)); } }
        public double MassInSuns { get { return Mass / (1.98855 * Math.Pow(10, 30)); } }
    }

    class Star : CelestialBody
    {

    }

    class Planet : CelestialBody
    {

    }

    class GasGiant : Planet
    {

    }

    class IceGiant : Planet
    {

    }

    class RockyPlanet : Planet
    {

    }
}
