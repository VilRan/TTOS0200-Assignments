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
        public const double EarthMass = 5.97237e24;
        public const double JupiterMass = 1.8986e27;
        public const double SunMass = 1.98855e30;

        public List<Galaxy> Galaxies = new List<Galaxy>();

        public Universe(Random random)
        {
            int number = (int)Math.Abs(random.NextGaussian(0, 1000));
            Galaxies = new List<Galaxy>(number);
            for (int i = 0; i < number; i++)
            {
                Galaxy galaxy = new Galaxy(random);
                Galaxies.Add(galaxy);
            }
        }
    }

    class Galaxy
    {
        public List<CelestialSystem> Systems;

        public Galaxy(Random random)
        {
            int number = (int)Math.Abs(random.NextGaussian(0, 1000));
            Systems = new List<CelestialSystem>(number);
            for (int i = 0; i < number; i++)
            {
                CelestialSystem system = new CelestialSystem(random);
                Systems.Add(system);
            }
        }
    }

    class CelestialSystem
    {
        public List<CelestialBody> Bodies;

        public CelestialSystem(Random random)
        {
            int stars = (int)Math.Abs(random.NextGaussian(0, 1));
            Bodies = new List<CelestialBody>(stars);
            for (int i = 0; i < stars; i++)
            {
                Star star = new Star(random);
                Bodies.Add(star);
            }
        }
    }

    class CelestialBody
    {
        public List<CelestialBody> Satellites;
        public double Periapsis;
        public double Apoapsis;
        public double Mass;

        public double PeriapsisInAUs { get { return Periapsis / Universe.AstronomicalUnit; } }
        public double ApoapsisInAUs { get { return Apoapsis / Universe.AstronomicalUnit; } }
        public double PeriapsisInLightyears { get { return Periapsis / Universe.Lightyear; } }
        public double ApoapsisInLightyears { get { return Apoapsis / Universe.Lightyear; } }
        public double MassInEarths { get { return Mass / Universe.EarthMass; } }
        public double MassInJupiters { get { return Mass / Universe.JupiterMass; } }
        public double MassInSuns { get { return Mass / Universe.SunMass; } }

        public CelestialBody(Random random)
        {
            int numSatellites = (int)Math.Abs(random.NextGaussian(0, 10));
            Satellites = new List<CelestialBody>(numSatellites);
            for (int i = 0; i < numSatellites; i++)
            {
                CelestialBody moon = CreateFromMass(Mass * random.NextDouble(0, 0.1), random);
                Satellites.Add(moon);
            }
        }

        public static CelestialBody CreateFromMass(double mass, Random random)
        {
            if (mass > 1e29)
                return new Star(random);
            if (mass > 1e26)
                return new GasGiant(random);
            if (mass > 1e25)
                return new IceGiant(random);
            if (mass > 1e23)
                return new RockyPlanet(random);
            if (mass > 1e21)
                return new DwarfPlanet(random);

            return new Asteroid(random);
        }
    }

    class Star : CelestialBody
    {
        public Star(Random random)
            : base (random)
        {
            Mass = Math.Abs(random.NextGaussian(0, Universe.SunMass));
            int planets = (int)Math.Abs(random.NextGaussian(0, 10));
            Satellites = new List<CelestialBody>(planets);
            for (int i = 0; i < planets; i++)
            {

            }
        }
    }
    
    abstract class Planet : CelestialBody
    {
        public Planet(Random random)
            : base(random)
        {

        }
    }

    class GasGiant : Planet
    {
        public GasGiant(Random random)
            : base(random)
        {

        }
    }

    class IceGiant : Planet
    {
        public IceGiant(Random random)
            : base(random)
        {

        }
    }

    class RockyPlanet : Planet
    {
        public RockyPlanet(Random random)
            : base(random)
        {
            int moons = (int)Math.Abs(random.NextGaussian(0, 2));
            Satellites = new List<CelestialBody>(moons);
            for (int i = 0; i < moons; i++)
            {
                CelestialBody moon = CreateFromMass(Mass * random.NextDouble(0.001, 0.1), random);
                Satellites.Add(moon);
            }
        }
    }

    class DwarfPlanet : Planet
    {
        public DwarfPlanet(Random random)
            : base(random)
        {

        }
    }

    class Asteroid : Planet
    {
        public Asteroid(Random random)
            : base(random)
        {

        }
    }
}
