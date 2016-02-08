using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collections
{
    class CD
    {
        public string Title, Artist;
        public List<Song> Songs = new List<Song>();

        public string Information
        {
            get
            {
                string s = "";

                s += "CD data:";
                s += "\n- Title: " + Title;
                s += "\n- Artist: " + Artist;
                s += "\n- Songs: ";
                foreach (Song song in Songs)
                    s += "\n    - " + song.Title + ", " + song.Duration;

                return s;
            }
        }
    }

    class Song
    {
        public string Title;
        public TimeSpan Duration;
    }
}
