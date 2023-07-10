using Modulplaneditor.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modulplaneditor
{
    class ModulDatabase
    {
        private SqlConnection _connection;

        public ModulDatabase()
        {
            string conString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database\ModuleDB.mdf;Integrated Security=True";
            _connection = new SqlConnection(conString);
        }

        public int GetLastID()
        {
            try
            {
                _connection.Open();

                SqlCommand cmd = _connection.CreateCommand();
                cmd.CommandText = $"SELECT MAX(id) FROM inhalte";
                int id = (int)cmd.ExecuteScalar();

                return id;
            }
            catch (SqlException e)
            {
                throw e;
            }
            finally
            {
                _connection.Close();
            }
        }

        public List<Modul> LadeModule()
        {
            _connection.Open();

            List<Modul> module = new List<Modul>();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = $"SELECT id, fach, semester FROM module";
            cmd.Connection = _connection;

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                int id = reader.GetInt32(0);
                string fach = reader.GetString(1);
                int semester = reader.GetInt32(2);

                module.Add(new Modul(id, fach, semester));
            }

            reader.Close();

            _connection.Close();
            return module;
        }

        /// <summary>
        /// Liest alle Inhalte inkl. untergeordnete Inhalte eines Moduls aus der Datenbank
        /// </summary>
        /// <param name="modulID">ID des Moduls</param>
        /// <returns>List<Inhalte></Inhalte></returns>
        public List<Inhalt> LadeOberinhalte(int modulID)
        {
            _connection.Open();

            List<Inhalt> inhalte = new List<Inhalt>();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = $"SELECT id, titel FROM inhalte " +
                $"WHERE modul_id = {modulID} AND oberinhalt_id IS NULL";
            cmd.Connection = _connection;

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                int id = reader.GetInt32(0);
                string titel = reader.GetString(1);
                
                inhalte.Add(new Inhalt(id, titel));
            }

            reader.Close();

            foreach (var item in inhalte)
            {
                LadeUnterinhalte(item);
            }

            _connection.Close();
            return inhalte;
        }

        public void InsertInhalt(Inhalt inhalt, Modul modul, Inhalt super = null)
        {
            try
            {
                _connection.Open();
                
                SqlCommand cmd = _connection.CreateCommand();

                string oberinhaltID = super != null ? super.ID.ToString() : "NULL";
                cmd.CommandText = $"INSERT INTO inhalte (titel, modul_id, oberinhalt_id)" +
                    $" VALUES ('{inhalt.Titel}', {modul.ID}, {oberinhaltID})";

                cmd.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                throw e;
            }
            finally
            {
                _connection.Close();
            }
        }

        public void DeleteInhalt(Inhalt inhalt)
        {
            try
            {
                _connection.Open();
                DeleteUnterinhalte(inhalt);
                
                SqlCommand cmd = _connection.CreateCommand();
                cmd.CommandText = $"DELETE FROM inhalte WHERE id={inhalt.ID}";
                cmd.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                throw e;
            }
            finally
            {
                _connection.Close();
            }
        }

        private void DeleteUnterinhalte(Inhalt inhalt)
        {
            if (inhalt.Unterinhalte.Count <= 0) return;

            foreach (Inhalt unterinhalt in inhalt.Unterinhalte)
            {
                DeleteUnterinhalte(unterinhalt);

                SqlCommand cmd = _connection.CreateCommand();
                cmd.CommandText = $"DELETE FROM inhalte WHERE id={unterinhalt.ID}";
                cmd.ExecuteNonQuery();
            }
        }

        private void LadeUnterinhalte(Inhalt inhalt)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = $"SELECT id, titel FROM inhalte " +
                $"WHERE oberinhalt_id = {inhalt.ID}";
            cmd.Connection = _connection;

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                int id = reader.GetInt32(0);
                string titel = reader.GetString(1);

                inhalt.Unterinhalte.Add(new Inhalt(id, titel));
            }

            reader.Close();

            foreach (var item in inhalt.Unterinhalte)
            {
                LadeUnterinhalte(item);
            }
        }
    }
}
