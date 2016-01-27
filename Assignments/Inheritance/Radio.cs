using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance
{
    class Radio
    {
        public string Status
        {
            get
            {
                string status = "";
                if (isOn)
                    status += "The radio is on. ";
                else
                    status += "The radio is off. ";
                status += "It is tuned to the frequency " + frequency + ". ";
                status += "The volume is set to " + volume + ". ";
                return status;
            }
        }
        public double Frequency
        {
            get { return frequency; }
            set { frequency = Math.Min(26000.0, Math.Max(2000.0, value)); }
        }
        public int Volume
        {
            get { return volume; }
            set { if (value < 0) volume = 0; else if (value > 9) volume = 9; else volume = (byte)value; }
        }
        public bool IsOn { get { return IsOn; } }

        private double frequency = 2000.0;
        private byte volume = 5;
        private bool isOn = false;

        public void TurnOn()
        {
            isOn = true;
        }

        public void TurnOff()
        {
            isOn = false;
        }

        public void Toggle()
        {
            isOn = !isOn;
        }

    }
}
