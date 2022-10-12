using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kemia
{
    class Felfedezesek
    {

        public Felfedezesek(string felfed)
        {

            string[] elemek = felfed.Split(';');
            this.Ev = elemek[0];
            this.Elem = elemek[1];
            this.Vegyjel = elemek[2];
            this.Rendszam = Convert.ToInt32(elemek[3]);
            this.Felfedezo = elemek[4];

        }
        public string Ev { get; set; }
        public string Elem { get; set; }
        public string Vegyjel { get; set; }
        public int  Rendszam { get; set; }
        public string  Felfedezo { get; set; }

    }
}
