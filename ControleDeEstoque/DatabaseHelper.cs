using System;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Windows.Forms;

namespace ControleDeEstoque
{
    public static class DatabaseHelper
    {
        private static readonly string ConnectionString = @"URI=file:" + Application.StartupPath + "\\inventory.db";
        private static readonly string path = "inventory.db";

        public static DataTable GetAllInventory()
        {
            using var con = new SQLiteConnection(ConnectionString);
            con.Open();
            using var cmd = new SQLiteCommand("SELECT * FROM inventory", con);
            using var adapter = new SQLiteDataAdapter(cmd);
            var table = new DataTable();
            adapter.Fill(table);
            return table;
        }

        public static void CreateDatabase()
        {
            if (!File.Exists(path))
            {
                SQLiteConnection.CreateFile(path);
                using (var sqlite = new SQLiteConnection(@"Data Source=" + path + ";Version=3;"))
                {
                    sqlite.Open();
                    string sql = "CREATE TABLE inventory (id INTEGER PRIMARY KEY AUTOINCREMENT, name TEXT NOT NULL, quantity INTEGER NOT NULL, price REAL NOT NULL)";
                    SQLiteCommand command = new SQLiteCommand(sql, sqlite);
                    command.ExecuteNonQuery();
                }
            }
            else
            {
                Console.WriteLine("Database already exists.");
                return;
            }
        }

        public static DataTable GetFilteredInventory(string column, string value)
        {
            using var con = new SQLiteConnection(ConnectionString);
            con.Open();
            string query = $"SELECT * FROM inventory WHERE {column} LIKE @value";
            using var cmd = new SQLiteCommand(query, con);
            cmd.Parameters.AddWithValue("@value", "%" + value + "%");
            using var adapter = new SQLiteDataAdapter(cmd);
            var table = new DataTable();
            adapter.Fill(table);
            return table;
        }

        public static void InsertProduct(string name, int quantity, double price)
        {
            using var con = new SQLiteConnection(ConnectionString);
            con.Open();
            using var cmd = new SQLiteCommand("INSERT INTO inventory (name, quantity, price) VALUES (@name, @quantity, @price)", con);
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@quantity", quantity);
            cmd.Parameters.AddWithValue("@price", price);
            cmd.ExecuteNonQuery();
        }

        public static void DeleteAllInventory()
        {
            using var con = new SQLiteConnection(ConnectionString);
            con.Open();
            using var cmd = new SQLiteCommand("DELETE FROM inventory", con);
            cmd.ExecuteNonQuery();
        }

        // Adicione outros métodos conforme necessário (Update, Delete por ID, etc.)
    }
}