using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taak_Klassen___Events
{
    public enum Verschijningsperiode
    {
        Dagelijks,
        Wekelijks,
        Maandelijks
    }

    public class Tijdschrift : Boek
    {
        public Verschijningsperiode Verschijningsperiode { get; set; }

        public Tijdschrift(string isbn, string naam, string uitgever, double prijs, Verschijningsperiode periode)
            : base(isbn, naam, uitgever, prijs)
        {
            Verschijningsperiode = periode;
        }

        public override string ToString()
        {
            return $"{base.ToString()}, Verschijningsperiode: {Verschijningsperiode}";
        }

        public void Lees()
        {
            Console.WriteLine("Dit is een tijdschrift. Begin met lezen!");
        }
    }
}