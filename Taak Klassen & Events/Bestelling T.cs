using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Taak_Klassen___Events
{
    

    public class Bestelling<T>
    {
        private static int volgnummerCount = 1; // Compteur de volgnummers pour les IDs uniques
        private int volgnummer; // ID unique de la commande

        public int Id
        {
            get { return volgnummer; }
            private set { volgnummer = value; }
        }

        public T Item { get; set; }
        public DateTime Datum { get; set; }
        public int Aantal { get; set; }
        public Verschijningsperiode? Periode { get; set; } // Période de la commande (tijdschriften-abonnement)

        public Bestelling(T item, DateTime datum, int aantal, Verschijningsperiode? periode = null)
        {
            Id = volgnummerCount++; // Attribuer un ID unique à la commande
            Item = item;
            Datum = datum;
            Aantal = aantal;
            Periode = periode;
        }

        // Getter-Setter pour la propriété Prix pour s'assurer que le prix est entre 5€ et 50€
        private double prijs;
        public double Prijs
        {
            get { return prijs; }
            set
            {
                if (value >= 5 && value <= 50)
                {
                    prijs = value;
                }
                else
                {
                    Console.WriteLine("Le prix doit être entre 5€ et 50€.");
                }
            }
        }
         
        // Méthode pour passer une commande et retourner une Tuple avec les informations
        public Tuple<string, int, double> Bestel()
        {
            string isbn = "";
            int aantalBesteld = 0;

            if (Item is Boek boek)
            {
                isbn = boek.Isbn;
                aantalBesteld = Aantal;
                Prijs = boek.Prijs * Aantal;
                OnBestellingGeplaatst("Boek besteld");
            }
            else if (Item is Tijdschrift tijdschrift)
            {
                isbn = tijdschrift.Isbn;
                aantalBesteld = Aantal;
                Prijs = tijdschrift.Prijs * Aantal;
                OnBestellingGeplaatst("Tijdschrift besteld");
            }

            return Tuple.Create(isbn, aantalBesteld, Prijs);
        }

        // Event pour confirmer la commande
        public event Action<string> BestellingGeplaatst;

        protected virtual void OnBestellingGeplaatst(string message)
        {
            BestellingGeplaatst?.Invoke(message);
        }
    }





}