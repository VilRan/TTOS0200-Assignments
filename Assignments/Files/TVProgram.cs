using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Files
{
    [Serializable]
    class TVProgram
    {
        public string Title;
        public string Channel;
        public string Information;
        public DateTime Start;
        public DateTime End;

        public TVProgram(string title, string channel, string information, DateTime start, DateTime end)
        {
            Title = title;
            Channel = channel;
            Information = information;
            Start = start;
            End = end;
        }

        public override string ToString()
        {
            return String.Format("Title: {0}, Channel: {1}, Info: {2}, {3}-{4}", Title, Channel, Information, Start, End.TimeOfDay);
        }
    }
}
