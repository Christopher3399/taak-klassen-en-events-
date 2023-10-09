using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Taak_Klassen___Events
{
    public class Bestelling<T>
    {
        private static int _nextId = 1;

        public int Id { get; }
        public T Item { get; }
        public DateTime Datum { get; set; }
        public int Aantal { get; set; }
        public Verschijningsperiode? BestelPeriode { get; set; }

        public event EventHandler<BestellingEventArgs> BestellingGeplaatst;

        public Bestelling(T item, DateTime datum, int aantal, Verschijningsperiode? periode = null)
        {
            Id = _nextId++;
            Item = item;
            Datum = datum;
            Aantal = aantal;
            BestelPeriode = periode;
        }

        public Tuple<string, int, double> Bestel()
        {
            double totalePrijs = Aantal * ((Item is Boek boek) ? boek.Prijs : ((Tijdschrift)Item).Prijs);

            string isbn = (Item is Boek boek) ? boek.Isbn : ((Tijdschrift)Item).Isbn;

            Console.WriteLine($"Bestelling {Id} is geplaatst. ISBN: {isbn}, Aantal: {Aantal}, Totale Prijs: {totalePrijs}€");

            return new Tuple<string, int, double>(isbn, Aantal, totalePrijs);
        }

        public void ConfirmeBestelling()
        {
            BestellingGeplaatst?.Invoke(this, new BestellingEventArgs(Id));
        }
    }

    public class BestellingEventArgs : EventArgs
    {
        public int Id { get; }

        public BestellingEventArgs(int id)
        {
            Id = id;
        }
    }




}