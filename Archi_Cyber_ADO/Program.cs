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
    Console.WriteLine("8. Mettre à jour un étudiant");
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
            Console.WriteLine("------- AFFICHER UN ETUDIANT ------");
            Console.Write("Veuillez entrer l'id de l'étudiant à récupérer : ");
            int id = int.Parse(Console.ReadLine());
            ADO.GetStudentById(id);
            break;
        case "5":
            Console.WriteLine("------- AFFICHER UN ETUDIANT VIA LOGIN ------");
            Console.Write("Veuillez entrer votre Login : ");
            string login = Console.ReadLine();
            ADO.GetStudentByLogin(login);
            break;
        case "6":
            Console.WriteLine("------- SUPPRIMER UN ETUDIANT ------");
            Console.Write("Veuillez entrer l'id de l'étudiant à supprimer : ");
            id = int.Parse(Console.ReadLine());
            ADO.DeleteStudent(id);
            break;
        case "7":
            Console.WriteLine("------- AJOUTER UN ETUDIANT ------");
            Console.Write("Veuillez entrer le nom : ");
            string nom = Console.ReadLine();
            Console.Write("Veuillez entrer le Prénom : ");
            string prenom = Console.ReadLine();
            login = prenom.Substring(0, 1) + nom;
            string course = "EG2210";
            ADO.AddStudent(nom, prenom, login, course);
            break;
        case "8":
            Console.WriteLine("------- METTRE A JOUR UN ETUDIANT ------");
            Console.Write("Veuillez entrer l'id de l'étudiant à modifier : ");
            id = int.Parse(Console.ReadLine());
            ADO.GetStudentById(id);
            Console.Write("Veuillez entrer le nouveau nom : ");
            nom = Console.ReadLine();
            Console.Write("Veuillez entrer le le nouveau Prénom : ");
            prenom = Console.ReadLine();
            ADO.UpdateStudent(id, nom, prenom);
            break;
        case "0":
            continuer = false;
            break;
        default:
            Console.WriteLine("Choix invalide");
            break;
    }

}
