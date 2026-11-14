using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Devart.Data.MySql;

namespace SQL
{
    public class MySQLHelper
    {
    
            private string connectionString = "Server=localhost;Database=feladat;User Id=root;Password=yourpassword;";

            public void InsertTemperature(decimal temperature)
            {
                try
                {
                    using (MySqlConnection conn = new MySqlConnection(connectionString))
                    {
                        conn.Open();
                        string query = "INSERT INTO adatok (Homerseklet) VALUES (@temperature)";
                        using (MySqlCommand cmd = new MySqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@temperature", temperature);
                            cmd.ExecuteNonQuery();
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Hiba: " + ex.Message);
                }
            }

            public DataTable GetLastHourData()
            {
                DataTable dt = new DataTable();
                try
                {
                    using (MySqlConnection conn = new MySqlConnection(connectionString))
                    {
                        conn.Open();
                        string query = "SELECT Date, Homerseklet FROM adatok WHERE Date >= NOW() - INTERVAL 1 HOUR";
                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn))
                        {
                            adapter.Fill(dt);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Hiba: " + ex.Message);
                }
                return dt;
            }
        }
    }

