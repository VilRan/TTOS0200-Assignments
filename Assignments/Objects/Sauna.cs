using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Objects
{
    public class Sauna
    {
        public double Temperature;
        public double Humidity;
        public bool IsOn { private set; get; }

        public double TemperatureCelsius
        {
            get
            {
                return Temperature - 273.15;
            }
            set
            {
                Temperature = value + 273.15;
            }
        }
        public bool IsOff { get { return !IsOn; } }

        public Sauna()
        {
            TemperatureCelsius = 22.0;
            Humidity = 0;
        }

        public void Update()
        {
            if (IsOn && TemperatureCelsius < 100)
            {
                Temperature += 0.01;
            }
            else if (IsOff && TemperatureCelsius > 20)
            {
                Temperature -= 0.01;
            }
        }

        public void TurnOn()
        {
            IsOn = true;
        }

        public void TurnOff()
        {
            IsOn = false;
        }
    }
}
