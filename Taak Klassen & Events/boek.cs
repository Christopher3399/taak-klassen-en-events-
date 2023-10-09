using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Taak_Klassen___Events
{
    using System;

    public class Boek
    {
        public string Isbn { get; set; }
        public string Naam { get; set; }
        public string Uitgever { get; set; }
        public double Prijs { get; set; }

        public Boek(string isbn, string naam, string uitgever, double prijs)
        {
            Isbn = isbn;
            Naam = naam;
            Uitgever = uitgever;
            Prijs = prijs;
        }

        public override string ToString()
        {
            return $"ISBN: {Isbn}\nNaam: {Naam}\nUitgever: {Uitgever}\nPrijs: {Prijs:C}";
        }

        public void Lees()
        {
            Console.WriteLine($"Je leest het boek '{Naam}' door {Uitgever}.");
        }
    }

    // Enum pour la périodicité du tijdschrift
    public enum Verschijningsperiode
    {
        Dagelijks,
        Wekelijks,
        Maandelijks
    }

    public class Tijdschrift : Boek
    {
        public Verschijningsperiode Periode { get; set; }

        public Tijdschrift(string isbn, string naam, string uitgever, double prijs, Verschijningsperiode periode)
            : base(isbn, naam, uitgever, prijs)
        {
            Periode = periode;
        }

        public override string ToString()
        {
            return $"{base.ToString()}\nVerschijningsperiode: {Periode}";
        }

        public new void Lees()
        {
            Console.WriteLine($"Je leest het tijdschrift '{Naam}' ({Periode}) door {Uitgever}.");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Création d'instances de Boek
            Boek boek1 = new Boek("978-3-16-148410-0", "C# Programming", "Tech Publications", 29.99);
            Boek boek2 = new Boek("978-1-23-456789-0", "Python Basics", "Code Experts", 19.99);

            // Création d'instances de Tijdschrift
            Tijdschrift tijdschrift1 = new Tijdschrift("978-9-87-654321-0", "Tech News", "Tech World", 5.99, Verschijningsperiode.Wekelijks);
            Tijdschrift tijdschrift2 = new Tijdschrift("978-0-12-345678-9", "Science Digest", "Science Publications", 6.99, Verschijningsperiode.Maandelijks);

            // Affichage des détails
            Console.WriteLine("Détails du Boek 1 :");
            Console.WriteLine(boek1);

            Console.WriteLine("\nDétails du Tijdschrift 1 :");
            Console.WriteLine(tijdschrift1);

            // Simulation de la lecture
            Console.WriteLine("\nSimulation de la lecture :");
            boek1.Lees();
            tijdschrift1.Lees();
        }
    }


}