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

        public static void DeleteAllInventoryAndResetId()
        {
            using var con = new SQLiteConnection(ConnectionString);
            con.Open();
            using (var cmd = new SQLiteCommand("DELETE FROM inventory;", con))
            {
                cmd.ExecuteNonQuery();
            }
            using (var cmd = new SQLiteCommand("DELETE FROM sqlite_sequence WHERE name='inventory';", con))
            {
                cmd.ExecuteNonQuery();
            }
        }

        public static List<string> GetAllProductNames()
        {
            var names = new List<string>();
            using var con = new SQLiteConnection(ConnectionString);
            con.Open();
            using var cmd = new SQLiteCommand("SELECT name FROM inventory", con);
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                names.Add(reader.GetString(0));
            }
            return names;
        }

        public static bool SubtractProductQuantity(string name, int quantityToSubtract)
        {
            using var con = new SQLiteConnection(ConnectionString);
            con.Open();
            using (var cmd = new SQLiteCommand("SELECT quantity FROM inventory WHERE name = @name", con))
            {
                cmd.Parameters.AddWithValue("@name", name);
                var result = cmd.ExecuteScalar();
                if (result == null) return false;
                int currentQty = Convert.ToInt32(result);
                if (quantityToSubtract > currentQty) return false; // Não permite estoque negativo

                using (var updateCmd = new SQLiteCommand("UPDATE inventory SET quantity = quantity - @qty WHERE name = @name", con))
                {
                    updateCmd.Parameters.AddWithValue("@qty", quantityToSubtract);
                    updateCmd.Parameters.AddWithValue("@name", name);
                    updateCmd.ExecuteNonQuery();
                }
                return true;
            }
        }

        public static bool DeleteProductByName(string name)
        {
            using var con = new SQLiteConnection(ConnectionString);
            con.Open();
            using var cmd = new SQLiteCommand("DELETE FROM inventory WHERE name = @name", con);
            cmd.Parameters.AddWithValue("@name", name);
            int rowsAffected = cmd.ExecuteNonQuery();
            return rowsAffected > 0;
        }

        public static bool UpdateProductQuantity(string name, int qtyChange)
        {
            using var con = new SQLiteConnection(ConnectionString);
            con.Open();
            using (var cmd = new SQLiteCommand("SELECT quantity FROM inventory WHERE name = @name", con))
            {
                cmd.Parameters.AddWithValue("@name", name.ToLower());
                var result = cmd.ExecuteScalar();
                if (result == null) return false;
                int currentQty = Convert.ToInt32(result);
                int newQty = currentQty + qtyChange;
                if (newQty < 0) return false; // Não permite negativo

                using (var updateCmd = new SQLiteCommand("UPDATE inventory SET quantity = @newQty WHERE name = @name", con))
                {
                    updateCmd.Parameters.AddWithValue("@newQty", newQty);
                    updateCmd.Parameters.AddWithValue("@name", name.ToLower());
                    updateCmd.ExecuteNonQuery();
                }
                return true;
            }
        }

        public static bool ProductExists(string name)
        {
            using var con = new SQLiteConnection(ConnectionString);
            con.Open();
            using var cmd = new SQLiteCommand("SELECT COUNT(*) FROM inventory WHERE name = @name", con);
            cmd.Parameters.AddWithValue("@name", name.ToLower());
            long count = (long)cmd.ExecuteScalar();
            return count > 0;
        }
    }
}