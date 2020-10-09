using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace RandomGift
{
    class Program
    {

        static void Main(string[] args)
        {
            Menu();
            Console.WriteLine("Veuillez choisir entre 1 à 5:");
            int choix = int.Parse(Console.ReadLine());
            Console.Clear();
            switch (choix)
            {
                case 1:
                    AjouterClient();
                    break;
                case 2:
                    AfficherClient();
                    break;
            }
            Console.ReadLine();
        }

        static void AjouterClient()
        {
            SqlConnection con;
            string str;
            string Fullname;
            int Telephone;
            string email;
            string listedeSouhait;

            try
            {
                //connexion a la base de donné
                str = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\RandomGift\RandomGift\Data.mdf;Integrated Security=True";
                con = new SqlConnection(str);
                con.Open();
                Console.WriteLine("Database connected");

                Console.WriteLine("Veuiller creé un client");

                Console.WriteLine("\n Enter your Fullname: ");
                Fullname = Console.ReadLine();
                Console.WriteLine("\n Enter your Telephone: ");
                Telephone = int.Parse(Console.ReadLine());
                Console.WriteLine("\n Enter your email: ");
                email = Console.ReadLine();
                Console.WriteLine("\n Enter your listedeSouhait: ");
                listedeSouhait = Console.ReadLine();

                //inserer dans la base de donnee
                string query = "INSERT INTO db (Fullname,Telephone,email,listedeSouhait) VALUES('" + Fullname + "','" + Telephone + "','" + email + "','" + listedeSouhait + "')";
                SqlCommand ins = new SqlCommand(query, con);
                ins.ExecuteNonQuery();
                Console.WriteLine("\n Client ajouté avec succès");
                con.Close();
            }
            catch (SqlException x)
            {
                Console.WriteLine(x.Message);
            }
            Console.ReadLine();
        }

        static void Menu()
        {
            Console.WriteLine("********************Menu***********************");
            Console.WriteLine("********************1- Ajout Client***********************");
            Console.WriteLine("********************2- Afficher tout les clients***********************");
            Console.WriteLine("********************3- Rechercher un Client***********************");
            Console.WriteLine("********************4- Mise a jour des Clients***********************");
            Console.WriteLine("********************5- Supprimer des Clients***********************");

        }

        static void AfficherClient()
        {
            string str;
            str = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\RandomGift\RandomGift\Data.mdf;Integrated Security=True"; 
            SqlConnection con;
            con = new SqlConnection(str);
            con.Open();
            Console.WriteLine("\n Data Stored Into Database ");
            string q = "SELECT * FROM db";
            SqlCommand view = new SqlCommand(q, con);
            SqlDataReader dr = view.ExecuteReader();
            while (dr.Read())
            {
                Console.WriteLine("\nFullname:" + dr.GetValue(1).ToString());
                Console.WriteLine("\nTelephone:" + dr.GetValue(2).ToString());
                Console.WriteLine("\nemail:" + dr.GetValue(3).ToString());
                Console.WriteLine("\nlistedeSouhait:" + dr.GetValue(4).ToString());
            }
        }

    }
}
