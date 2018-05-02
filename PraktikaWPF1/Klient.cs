using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PraktikaWPF1
{
    class Klient
    {
        private String n;
        private String l;
        private String t;
        private String d;
        private int b;
        private DateTime s;
        private DateTime e;

        public Klient (String name, String lastname, String telefone, String docnum, int booknumber, DateTime start, DateTime end)
        {
            this.n = name;
            this.l = lastname;
            this.t = telefone;
            this.d = docnum;
            this.b = booknumber;
            this.s = start;
            this.e = end;
        }

        public Klient()
        {

        }

        public String name { get => n; set => n = value; }
        public String lastname { get => l; set => l = value; }
        public String telefone { get => t; set => t = value; }
        public String docnum { get => d; set => d = value; }
        public int booknumber { get => b; set => b = value; }
        public DateTime start { get => s; set => s = value; }
        public DateTime end { get => e; set => e = value; }

            

    }
}
