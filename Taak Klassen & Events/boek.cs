using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Taak_Klassen___Events
{
    public class Boek
    {
        public string Isbn { get; set; }
        public string Naam { get; set; }
        public string Uitgever { get; set; }
        private double _prijs;

        public double Prijs
        {
            get { return _prijs; }
            set
            {
                if (value >= 5 && value <= 50)
                {
                    _prijs = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Prijs moet tussen 5€ en 50€ liggen.");
                }
            }
        }

        public Boek(string isbn, string naam, string uitgever, double prijs)
        {
            Isbn = isbn;
            Naam = naam;
            Uitgever = uitgever;
            Prijs = prijs;
        }

        public override string ToString()
        {
            return $"ISBN: {Isbn}, Naam: {Naam}, Uitgever: {Uitgever}, Prijs: {Prijs}€";
        }

        public void Lees()
        {
            Console.WriteLine("Dit is een boek. Begin met lezen!");
        }
    }

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
            return $"{base.ToString()}, Verschijningsperiode: {Verschijningsperiode periode}";
        }

        public void Lees()
        {
            Console.WriteLine("Dit is een tijdschrift. Begin met lezen!");
        }
    }

}