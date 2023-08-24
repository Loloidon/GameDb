using GameDataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace BigGame
{
    public class Affichage
    {

        public void AjoutJeu()
        {

            Game nouveau = new Game();
            Console.WriteLine("---------------------------");
            Console.Write("Titre du jeu : ");
            nouveau.Titre = Console.ReadLine();

            Console.Write("Date de sortie : ");
            nouveau.AnneeSortie = DateTime.Parse(Console.ReadLine());

            Console.Write("Ecrivez le synopsis du jeu : ");
            nouveau.Synopsis = Console.ReadLine();
            Console.WriteLine("---------------------------");

            GameServices services = new GameServices();
            services.Create(nouveau);
        }

        public void AjoutCategorie()
        {

            Categorie nouvelle = new Categorie();
            Console.WriteLine("---------------------------");
            Console.Write("Nom de la catégorie : ");
            nouvelle.Nom = Console.ReadLine();


            Console.WriteLine("---------------------------");

            GameServices services = new GameServices();
            services.CreateCat(nouvelle);
        }

        public void AfficherCat()
        {
            GameServices services = new GameServices();
            foreach (Categorie c in services.GetCategories())
            {
                Console.WriteLine($"({c.Id} - {c.Nom}");
            }
        }
        public void AfficherJeu()
        {
            GameServices services = new GameServices();
            foreach (Game g in services.GetGame())
            {
                Console.WriteLine($"({g.Id} - {g.Titre} - {g.AnneeSortie} - {g.Synopsis}");
            }
        }
        public void ModifierCat()
        {
            GameServices services = new GameServices();
            AfficherCat();
            Console.WriteLine("Entrez le numéro de la catégorie a modifier");
            int Id = int.Parse(Console.ReadLine());
            Console.WriteLine("Entrez le nouveau nom de la catégorie");
            string Nom = Console.ReadLine();
            services.UpdateCat(Id, Nom);
        }




    }
}
