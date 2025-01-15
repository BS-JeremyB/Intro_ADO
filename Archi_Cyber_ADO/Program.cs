using Archi_Cyber_ADO;

bool continuer = true;
string choix;
while (continuer)
{
    Console.WriteLine("Veuillez faire une selection : ");
    Console.WriteLine("1. Vérifier la connexion");
    Console.WriteLine("2. Voir le nombre d'étudiants");
    Console.WriteLine("3. Afficher les étudiants");
    Console.WriteLine("4. Afficher un étudiant");
    Console.WriteLine("5. Afficher un étudiant par login");
    Console.WriteLine("6. Supprimer un étudiant");
    Console.WriteLine("7. Ajouter un étudiant");
    Console.WriteLine("0. Quitter");
    Console.Write("Votre choix : ");
    choix = Console.ReadLine();
    Console.Clear();

    switch (choix)
    {
        case "1":
            ADO.State();
            break;
        case "2":
            ADO.CountStudent();
            break;
        case "3":
            ADO.GetAllStudent();
            break;
        case "4":
            ADO.GetStudentById();
            break;
        case "5":
            ADO.GetStudentByLogin();
            break;
        case "6":
            ADO.DeleteStudent();
            break;
        case "7":
            ADO.AddStudent();
            break;
        case "0":
            continuer = false;
            break;
        default:
            Console.WriteLine("Choix invalide");
            break;
    }

}
