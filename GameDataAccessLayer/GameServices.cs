using Microsoft.Data.SqlClient;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDataAccessLayer
{
    public class GameServices
    {
        private string _connectionString = "Data Source=DESKTOP-L6EA6H1;Initial Catalog=GameDb;Integrated Security=True;Connect Timeout=60;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";

        public void Create(Game game)
        {
            using (SqlConnection cnx = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = cnx.CreateCommand())
                {
                    string sql = "INSERT INTO Jeu (Titre,AnneeSortie,Synopsis) " +
                        "VALUES (@titre,@anneesortie,@synopsis)";
                    cmd.CommandText = sql;
                    cmd.Parameters.AddWithValue("titre", game.Titre);
                    cmd.Parameters.AddWithValue("anneesortie", game.AnneeSortie);
                    cmd.Parameters.AddWithValue("synopsis", game.Synopsis);

                    cnx.Open();
                    cmd.ExecuteNonQuery();
                    cnx.Close();

                }
            }

        }
        public void CreateCat(Categorie categorie)
        {

            using (SqlConnection cnx = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = cnx.CreateCommand())
                {
                    string sql = "INSERT INTO Categorie (Nom) " +
                        "VALUES ( @Nom )";
                    cmd.CommandText = sql;
                    cmd.Parameters.AddWithValue("nom", categorie.Nom);
                    cnx.Open();
                    cmd.ExecuteNonQuery();
                    cnx.Close();

                }
            }

        }
        public void LinkInt(Link l)
        {
            using (SqlConnection cnx = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = cnx.CreateCommand())
                {
                    string sql = "INSERT INTO Jeu-Categorie ( Categorie_ID , Jeu_ID ) " +
                        "VALUES (@Categorie_ID,@Jeu_ID)";
                    cmd.CommandText = sql;
                    cmd.Parameters.AddWithValue("categorie_id", l.Categorie_ID);
                    cmd.Parameters.AddWithValue("jeu_id", l.Jeu_ID);
                    cnx.Open();
                    cmd.ExecuteNonQuery();
                    cnx.Close();

                }

            }
        }
        public int LastId()
        {
            int id;
            using (SqlConnection cnx = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = cnx.CreateCommand())
                {
                    string sql = " SELECT MAX ( id ) FROM Jeu  " 
                        ;
                    cmd.CommandText = sql;
                    
                    cnx.Open();
                    id=(int)cmd.ExecuteScalar();
                    cnx.Close();
                    return id;

                }

            }

        }
        public void LinkID(Link l)
        {
            using (SqlConnection cnx = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = cnx.CreateCommand())
                {
                    int id=0;
                    int Jeu_ID = LastId();
                    string sql = " INSERT INTO [Jeu-Categorie] (JeuID)" +
                        "VALUES (@Jeu_ID)  "
                        ;
                    
                    cmd.Parameters.AddWithValue("jeu_id", l.Jeu_ID);
                    cmd.CommandText = sql;
                    cnx.Open();
                    cmd.ExecuteNonQuery();
                    cnx.Close();
                }

            }

        }
        public void UpdateCat(int Id, string Nom)
        {
            Categorie c = new Categorie();
            using (SqlConnection cnx = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = cnx.CreateCommand())
                {
                    string sql = "update Categorie set Nom=@nom where Id=@id";
                    cmd.CommandText = sql;
                    cmd.Parameters.AddWithValue("nom", Nom);
                    cmd.Parameters.AddWithValue("id", Id);
                    cnx.Open();
                    cmd.ExecuteNonQuery();
                    cnx.Close();


                }
            }
        }

        public List<Categorie> GetCategories()
        {
            List<Categorie> list = new List<Categorie>();
            using (SqlConnection cnx = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = cnx.CreateCommand())
                {
                    string sql = " SELECT * FROM Categorie ";
                    cmd.CommandText = sql;
                    cnx.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new Categorie()
                            {
                                Id = (int)reader["ID"],
                                Nom = (string)reader["Nom"]

                            });
                        }
                    }
                    cnx.Close();
                }
            }
            return list;
        }

        public List<Game> GetGame()
        {
            List<Game> list = new List<Game>();
            using (SqlConnection cnx = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = cnx.CreateCommand())
                {
                    string sql = " SELECT * FROM Jeu ";
                    cmd.CommandText = sql;
                    cnx.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new Game()
                            {
                                Id = (int)reader["ID"],
                                Titre = (string)reader["Titre"],
                                AnneeSortie = (DateTime)reader["AnneeSortie"],
                                Synopsis = (string)reader["Synopsis"]

                            });
                        }
                    }
                    cnx.Close();
                }
            }
            return list;
        }

    }
}