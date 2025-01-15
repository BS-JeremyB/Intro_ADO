﻿using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archi_Cyber_ADO
{
    public static class ADO
    {
        private static readonly string connectionString = "Data Source=(localdb)\\BStormLocalDB;Initial Catalog=dbslide;Integrated Security=True;Connect Timeout=60;Encrypt=True;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";

        public static void State() 
        {
            Console.WriteLine("------- ETAT DE CONNEXION ------");
            using (SqlConnection connection = new SqlConnection(connectionString)) 
            {
                connection.Open();
                Console.WriteLine($"La connexion est : {connection.State}");
                connection.Close();
            }

            Console.ReadLine();
            Console.Clear();
        }


        public static void CountStudent() 
        {
            Console.WriteLine("------- NOMBRE D'ETUDIANTS ------");
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT COUNT(Student_Id) FROM Student";
                    command.CommandType = CommandType.Text;

                    connection.Open();
                    int nbrStudent = (int)command.ExecuteScalar();
                    connection.Close();
                    Console.WriteLine($"Le nombre d'étudiant est de  : {nbrStudent}");
                    Console.ReadLine();
                    Console.Clear();

                }
            }
        }


        public static void GetAllStudent()
        {
            Console.WriteLine("------- AFFICHER LES ETUDIANTS ------");
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT * FROM Student";
                    command.CommandType = CommandType.Text;

                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine("-----------------------------\n");
                            Console.WriteLine($"Id : {reader["student_id"]}");
                            Console.WriteLine($"Nom Complet : {reader["first_name"]}  {reader["last_name"]}");
                            Console.WriteLine($"Date de naissance : {reader["birth_date"]}");
                            Console.WriteLine($"Login : {reader["login"]}");
                            Console.WriteLine($"Section Id : {reader["section_id"]}");
                            Console.WriteLine($"Résultats annuel : {reader["year_result"]}");
                            Console.WriteLine($"Course Id : {reader["course_id"]}");
                        }
                    }
                    connection.Close();
                    Console.ReadLine();
                    Console.Clear();
                }
            }
        }

        public static void GetStudentById()
        {
            Console.WriteLine("------- AFFICHER UN ETUDIANT ------");
            Console.Write("Veuillez entrer l'id de l'étudiant à récupérer : ");
            int id = int.Parse(Console.ReadLine());


            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = $"SELECT * FROM Student WHERE student_id = @id";
                    command.CommandType = CommandType.Text;

                    command.Parameters.AddWithValue("@id", id);

                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine("-----------------------------\n");
                            Console.WriteLine($"Id : {reader["student_id"]}");
                            Console.WriteLine($"Nom Complet : {reader["first_name"]} {reader["last_name"]}");
                            Console.WriteLine($"Date de naissance : {reader["birth_date"]}");
                            Console.WriteLine($"Login : {reader["login"]}");
                            Console.WriteLine($"Section Id : {reader["section_id"]}");
                            Console.WriteLine($"Résultats annuel : {reader["year_result"]}");
                            Console.WriteLine($"Course Id : {reader["course_id"]}");
                        }
                    }
                    connection.Close();
                    Console.ReadLine();
                    Console.Clear();
                }
            }
        }


        public static void GetStudentByLogin()
        {
            Console.WriteLine("------- AFFICHER UN ETUDIANT VIA LOGIN ------");
            Console.Write("Veuillez entrer votre Login : ");
            string login = Console.ReadLine();


            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = $"SELECT * FROM Student WHERE login = @login";
                    command.CommandType = CommandType.Text;

                    command.Parameters.AddWithValue("@login", login);

                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Console.WriteLine("-----------------------------\n");
                            Console.WriteLine($"Id : {reader["student_id"]}");
                            Console.WriteLine($"Nom Complet : {reader["first_name"]} {reader["last_name"]}");
                            Console.WriteLine($"Date de naissance : {reader["birth_date"]}");
                            Console.WriteLine($"Login : {reader["login"]}");
                            Console.WriteLine($"Section Id : {reader["section_id"]}");
                            Console.WriteLine($"Résultats annuel : {reader["year_result"]}");
                            Console.WriteLine($"Course Id : {reader["course_id"]}");
                        }
                    }
                    connection.Close();
                    Console.ReadLine();
                    Console.Clear();
                }
            }
        }


        public static void DeleteStudent()
        {
            Console.WriteLine("------- SUPPRIMER UN ETUDIANT ------");
            Console.Write("Veuillez entrer l'id de l'étudiant à supprimer : ");
            int id = int.Parse(Console.ReadLine());

            using(SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "DELETE FROM student WHERE student_id = @id";
                    command.CommandType = CommandType.Text;

                    command.Parameters.AddWithValue("@id", id);

                    connection.Open();
                    int nbrRow = command.ExecuteNonQuery();
                    connection.Close();

                    if (nbrRow > 0) 
                    {
                        Console.WriteLine("l'élément à été supprimé !");
                    }
                    else
                    {
                        Console.WriteLine("l'élément n'a pas pu être trouvé ou supprimé !");
                    }

                    Console.ReadLine();
                    Console.Clear();
                
                }
            }
        }


        public static void AddStudent()
        { 
            Console.WriteLine("------- AJOUTER UN ETUDIANT ------");
            Console.Write("Veuillez entrer le nom : ");
            string nom = Console.ReadLine();        
            Console.Write("Veuillez entrer le Prénom : ");
            string prenom = Console.ReadLine();
            string login = prenom.Substring(0, 1) + nom;
            string course = "EG2210";

            using (SqlConnection connection = new SqlConnection(connectionString)) 
            {
                using (SqlCommand command = connection.CreateCommand()) 
                {
                    command.CommandText = "INSERT INTO student (last_name, first_name, login, course_id) " +
                                          $"OUTPUT inserted.student_id " +
                                          "VALUES (@nom, @prenom, @login, @course)";
                    command.CommandType = CommandType.Text;

                    command.Parameters.AddWithValue("@nom", nom);
                    command.Parameters.AddWithValue("@prenom", prenom);
                    command.Parameters.AddWithValue("@login", login);
                    command.Parameters.AddWithValue("@course", course);

                    connection.Open();
                    int id = (int)command.ExecuteScalar();
                    connection.Close();
                    Console.WriteLine($"L'étudiant a été ajouté à l'id : {id}");

                    Console.ReadLine();
                    Console.Clear();
                }

            }
        }


    }
}
