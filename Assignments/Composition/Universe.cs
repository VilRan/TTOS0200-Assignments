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

        public IEnumerable<CelestialSystem> Systems
        {
            get
            {
                foreach (Galaxy galaxy in Galaxies)
                    foreach (CelestialSystem system in galaxy.Systems)
                        yield return system;
            }
        }
        public IEnumerable<CelestialBody> Planets
        {
            get
            {
                foreach (CelestialSystem system in Systems)
                    foreach (CelestialBody planet in system.Planets)
                        yield return planet;
            }
        }
        public IEnumerable<CelestialBody> Moons
        {
            get
            {
                foreach (CelestialBody planet in Planets)
                    foreach (CelestialBody moon in planet.Satellites)
                        yield return moon;
            }
        }
        public IEnumerable<CelestialBody> CelestialBodies
        {
            get
            {
                foreach (CelestialSystem system in Systems)
                {
                    yield return system.Primary;
                    foreach (CelestialBody body in system.Primary.EntireSystem)
                        yield return body;
                }
            }
        }

        public Universe(Random random)
        {
            int number = 1 + (int)Math.Abs(random.NextGaussian(0, 10));
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
            int number = 1 + (int)Math.Abs(random.NextGaussian(0, 1000));
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
        public CelestialBody Primary;

        public IEnumerable<CelestialBody> Planets { get { return Primary.Satellites; } }

        public CelestialSystem(Random random)
        {
            Primary = CelestialBody.CreateFromMass(random.NextDouble(1e26, 1e30), random);
        }
    }

    class CelestialBody
    {
        public CelestialBody Primary = null;
        public List<CelestialBody> Satellites;
        public double Periapsis;
        public double Apoapsis;
        public double Mass;
        
        public double SemimajorAxis { get { return (Periapsis + Apoapsis) / 2; } }
        public double Eccentricity { get { return (Apoapsis - Periapsis) / (Apoapsis + Periapsis); } }
        public double SphereOfInfluence
        {
            get
            {
                if (Primary == null)
                    return Universe.Lightyear / 1000;
                return SemimajorAxis * Math.Pow(Mass / Primary.Mass, 2.0/5.0);
            }
        }

        public IEnumerable<CelestialBody> EntireSystem
        {
            get
            {
                foreach (CelestialBody satellite in Satellites)
                {
                    yield return satellite;
                    foreach (CelestialBody satelliteOfSatellite in satellite.EntireSystem)
                        yield return satelliteOfSatellite;
                }
            }
        }

        public CelestialBody(Random random, double mass)
        {
            Mass = mass;

            int numSatellites = 0;
            if ( !(this is Asteroid))
                do
                    numSatellites = (int)Math.Abs(random.NextGaussian(0, 10));
                while (numSatellites > 10);

            Satellites = new List<CelestialBody>(numSatellites);
            for (int i = 0; i < numSatellites; i++)
            {
                double massFraction, semimajorAxis, eccentricity;
                do
                    massFraction = Math.Abs(random.NextGaussian(0, 0.001));
                while (massFraction > 0.01);
                do
                    semimajorAxis = Math.Abs(random.NextGaussian(0, SphereOfInfluence / 10));
                while (semimajorAxis > SphereOfInfluence);
                do
                    eccentricity = Math.Abs(random.NextGaussian(0, 0.1));
                while (eccentricity > 1);

                CelestialBody satellite = CreateFromMass(Mass * massFraction, random);
                satellite.Primary = this;
                satellite.SetOrbit(semimajorAxis, eccentricity);
                Satellites.Add(satellite);
            }
        }

        public CelestialBody(Random random, double mass, double semimajorAxis, double eccentricity)
            : this(random, mass)
        {
            Mass = mass;
            SetOrbit(semimajorAxis, eccentricity);
        }

        public void SetOrbit(double semimajorAxis, double eccentricity)
        {
            Periapsis = semimajorAxis * (1 - eccentricity);
            Apoapsis = semimajorAxis * (1 + eccentricity);
        }

        public static CelestialBody CreateFromMass(double mass, Random random)
        {
            if (mass > 1e29)
                return new Star(random, mass);
            if (mass > 1e26)
                return new GasGiant(random, mass);
            if (mass > 1e25)
                return new IceGiant(random, mass);
            if (mass > 1e23)
                return new RockyPlanet(random, mass);
            if (mass > 1e21)
                return new DwarfPlanet(random, mass);

            return new Asteroid(random, mass);
        }
    }

    class Star : CelestialBody
    {
        public Star(Random random, double mass)
            : base (random, mass)
        {

        }
    }
    
    abstract class Planet : CelestialBody
    {
        public Planet(Random random, double mass)
            : base(random, mass)
        {

        }
    }

    class GasGiant : Planet
    {
        public GasGiant(Random random, double mass)
            : base(random, mass)
        {

        }
    }

    class IceGiant : Planet
    {
        public IceGiant(Random random, double mass)
            : base(random, mass)
        {

        }
    }

    class RockyPlanet : Planet
    {
        public RockyPlanet(Random random, double mass)
            : base(random, mass)
        {

        }
    }

    class DwarfPlanet : Planet
    {
        public DwarfPlanet(Random random, double mass)
            : base(random, mass)
        {

        }
    }

    class Asteroid : Planet
    {
        public Asteroid(Random random, double mass)
            : base(random, mass)
        {

        }
    }
}
