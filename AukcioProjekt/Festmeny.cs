using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AukcioProjekt
{
    class Festmeny
    {
        private String cim;
        private String festo;
        private String stilus;
        private int licitekSzama;
        private int legmagasabbLicit;
        private DateTime legutolsoLicitIdeje;
        private bool elkelt;

        public Festmeny(string cim, string festo, string stilus)
        {
            this.cim = cim;
            this.festo = festo;
            this.stilus = stilus;
            this.licitekSzama = 0;
            this.legmagasabbLicit = 0;
            this.elkelt = false;
        }

        public string Festo { get => festo; }
        public string Stilus { get => stilus; } 
        public int LicitekSzama { get => licitekSzama; }
        public int LegmagasabbLicit { get => legmagasabbLicit; }
        public DateTime LegutolsoLicitIdeje { get => legutolsoLicitIdeje; }
        public bool Elkelt { get => elkelt; set => elkelt = value; }

        public void Licit()
        {
            if (elkelt)
            {
                Console.WriteLine("Hiba. A termék már elkelt.");
            }
            else if (licitekSzama == 0)
            {
                this.legmagasabbLicit = 100;
                this.licitekSzama++;
                this.legutolsoLicitIdeje = DateTime.Now;
            }
            else
            {
                licitekSzama++;
                legmagasabbLicit += legmagasabbLicit / 10;
                this.legutolsoLicitIdeje = DateTime.Now;
            }
        }

        public void Licit(int mertek)
        {
            if (mertek > 9 && mertek < 101)
            {
                if (licitekSzama == 0)
                {
                    legmagasabbLicit = 100;
                }
                licitekSzama++;
                legmagasabbLicit += (legmagasabbLicit / 100) * mertek;
                this.legutolsoLicitIdeje = DateTime.Now;
            }
            else
            {
                Console.WriteLine("Hiba, rossz szám.");
            }
        }

        

        
        public override string ToString()
        {
            String s = "";
            String elkeltE = "";
            if (elkelt)
            {
                elkeltE = "Elkelt";
            }
            else
            {
                elkeltE = "Nem kelt el";
            }
            s += "Festo: " + Festo + " (" + stilus + ")\n"
                + elkeltE + "\n"
                + "legmagasabbLicit " + legmagasabbLicit + "$ - "
                + "LegutolsoLicitIdeje " + legutolsoLicitIdeje
                + " (összesen: " + licitekSzama + " db)";

            return s;
        }
    }
}
