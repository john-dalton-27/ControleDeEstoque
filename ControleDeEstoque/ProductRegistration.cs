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
using System.Security.Cryptography.X509Certificates;

namespace ControleDeEstoque
{
    public partial class ProductRegistration : Form
    {
        public event EventHandler RegisteredProductOrCancelled;

        public ProductRegistration()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;

            txtQuantity.KeyPress += TxtQuantity_KeyPress;
            txtPrice.KeyPress += TxtPrice_KeyPress;
        }

        private void TxtQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void TxtPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                e.KeyChar != ',' && e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            // Validação dos campos obrigatórios
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("O nome do produto é obrigatório.");
                txtName.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtQuantity.Text))
            {
                MessageBox.Show("A quantidade é obrigatória.");
                txtQuantity.Focus();
                return;
            }

            if (!int.TryParse(txtQuantity.Text, out int q))
            {
                MessageBox.Show("Digite uma quantidade válida (apenas números inteiros).");
                txtQuantity.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtPrice.Text))
            {
                MessageBox.Show("O preço é obrigatório.");
                txtPrice.Focus();
                return;
            }

            if (!double.TryParse(txtPrice.Text.Replace(',', '.'), System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out double p))
            {
                MessageBox.Show("Digite um preço válido (apenas números).");
                txtPrice.Focus();
                return;
            }

            try
            {
                DatabaseHelper.InsertProduct(
                    txtName.Text,
                    q,
                    p
                );
                MessageBox.Show("Produto cadastrado com sucesso!");
                RegisteredProductOrCancelled?.Invoke(this, EventArgs.Empty);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao cadastrar produto: " + ex.Message + "\n" + ex.StackTrace);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            RegisteredProductOrCancelled?.Invoke(this, EventArgs.Empty);
            this.Close();
        }
    }
}
