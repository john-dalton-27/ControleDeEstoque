using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
using System.IO;

namespace ControleDeEstoque
{
    public partial class ProductRegistration : Form
    {
        public ProductRegistration()
        {
            InitializeComponent();
        }

        private void ProductRegistration_Load(object sender, EventArgs e)
        {
            int posX = (this.ClientSize.Width - lblRegisterTitle.Width) / 2;
            lblRegisterTitle.Location = new Point(posX, lblRegisterTitle.Location.Y);
        }

        public static class DatabaseHelper
        {
            public static string ConnectionString = @"URI=file:" + Application.StartupPath + "\\" + "inventory.db";
            public static SQLiteConnection GetConnection()
            {
                var con = new SQLiteConnection(ConnectionString);
                con.Open();
                return con;
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            try
            {
                using (var con = DatabaseHelper.GetConnection())
                using (var cmd = new SQLiteCommand(con))
                {
                    cmd.CommandText = "INSERT INTO inventory (name, quantity, price) VALUES (@name, @quantity, @price)";
                    cmd.Parameters.AddWithValue("@name", txtName.Text);
                    cmd.Parameters.AddWithValue("@quantity", int.TryParse(txtQuantity.Text, out int q) ? q : 0);
                    cmd.Parameters.AddWithValue("@price", double.TryParse(txtPrice.Text, out double p) ? p : 0.0);
                    cmd.ExecuteNonQuery();
                }
                MessageBox.Show("Produto cadastrado com sucesso!");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao cadastrar produto: " + ex.Message + "\n" + ex.StackTrace);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

        }
    }
}
