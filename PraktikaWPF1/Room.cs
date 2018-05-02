using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PraktikaWPF1
{
    class Room
    {
        private String nr;
        private int n;
        private Klient k;
        private int r;
        private String c;
        private bool s;

        public Room (String nameroom, int numberroom, Klient klient, int rooms,  String classroom, bool status)
        {
            this.nr = nameroom;
            this.n = numberroom;
            this.k = klient;
            this.r = rooms;
            this.c = classroom;
            this.s = status;
        }

        public Room()
        {

        }

        public String NameRoom { get => nr; set => nr = value; }
        public int NumberRoom { get => n; set => n = value; }
        public Klient Klient { get => k; set => k = value; }
        public String ClassRoom { get => c; set => c = value; }
        public bool Status { get => s; set => s = value; }

    }
}
