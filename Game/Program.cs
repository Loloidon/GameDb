using BigGame;

Affichage affichage = new Affichage();


bool exit = false;

do
{
    
    Console.WriteLine("--------------------------");
    Console.WriteLine("Que voulez vous faire ? ");
    Console.WriteLine("0 - Quitter");
    Console.WriteLine("1 - Ajouter un jeu");
    Console.WriteLine("2 - Ajouter une catégorie");
    Console.WriteLine("3 - Afficher les catégories");
    Console.WriteLine("4 - Afficher les jeux");
    Console.WriteLine("5 - Modifier une catégorie");
    Console.WriteLine("--------------------------");


    int choix = int.Parse(Console.ReadLine());
    Console.Clear();

    switch (choix)
    {
        case 0:
            exit = true;
            break;

        case 1:affichage.AjoutJeu();
            break;
        case 2:
            affichage.AjoutCategorie();
            break;
        case 3:
            affichage.AfficherCat();
            break;
        case 4:
            affichage.AfficherJeu();
            break;
        case 5:
            affichage.ModifierCat();
            break;


        default:
            Console.WriteLine("C'est un ou deux ou trois gros noob !!!");
            break;
    }
}
while (exit == false);
