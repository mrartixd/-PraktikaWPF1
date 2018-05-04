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

        public Room (String nameroom, int idroom, Klient klient, int rooms,  String classroom, bool status)
        {
            this.nr = nameroom;
            this.n = idroom;
            this.k = klient;
            this.r = rooms;
            this.c = classroom;
            this.s = status;
        }

        public Room()
        {

        }

        public String NameRoom { get => nr; set => nr = value; }
        public int IDroom { get => n; set => n = value; }
        public Klient Klient { get => k; set => k = value; }
        public int Rooms { get => r; set => r = value; }
        public String ClassRoom { get => c; set => c = value; }
        public bool Status { get => s; set => s = value; }

    }
}
