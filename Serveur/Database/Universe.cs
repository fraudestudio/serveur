﻿using System;
using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;
using Server.Database;

namespace Serveur.Database
{
    public static class Universe
    {
        /// <summary>
        /// creer un univers 
        /// </summary>
        /// <param name="mdp">mot de passe de l'univers</param>
        /// <param name="nom_univers">nom de l'univers</param>
        static public async Task<bool> InsertUnivers(string nom_univers, string? mdp, int owner)
        {
            bool result = false;
            using (MySqlConnection conn = DatabaseConnection.NewConnection())
            {
                await conn.OpenAsync();

                string query = "INSERT INTO UNIVERS (NOM_UNIVERS,MDP_SERVEUR,OWNER) VALUES (@nom,@mdp,@owner);";

                try
                {
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@nom", nom_univers);
                    cmd.Parameters.AddWithValue("@mdp", mdp);
                    cmd.Parameters.AddWithValue("@owner", owner);
                    await cmd.ExecuteNonQueryAsync();
                    result = true;
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            return result;
        }
    }
}
