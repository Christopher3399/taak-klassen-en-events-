using System;

namespace Taak_Klassen___Events
{
    class Program
    {
        static void Main()
        {
            var boek1 = new Boek("123456789", "C# Programming", "Uitgever A", 20.0);
            var boek2 = new Boek("987654321", "Python Programming", "Uitgever B", 25.0);
            var tijdschrift1 = new Tijdschrift("555555555", "Tech News", "Uitgever C", 5.0, Verschijningsperiode.Wekelijks);
            var tijdschrift2 = new Tijdschrift("666666666", "Science Weekly", "Uitgever D", 8.0, Verschijningsperiode.Maandelijks);

            var bestelling1 = new Bestelling<Boek>(boek1, DateTime.Now, 3);
            var bestelling2 = new Bestelling<Tijdschrift>(tijdschrift1, DateTime.Now, 5);

            // Utilisez la méthode Bestel pour passer une commande et obtenir les informations
            var infoBestelling1 = bestelling1.Bestel();
            var infoBestelling2 = bestelling2.Bestel();

            // Déclencher un événement pour confirmer la commande
            bestelling1.BestellingGeplaatst += (sender, e) =>
            {
                Console.WriteLine($"Bestelling {e.Id} is bevestigd!");
            };

            // Exemple d'appel d'événement
            bestelling1.ConfirmeBestelling();
            { };
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