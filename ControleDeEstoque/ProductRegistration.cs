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

        private void UpdateRadioButtonTabStops()
        {
            rbAdd.TabStop = !rbAdd.Checked;
            rbRemove.TabStop = !rbRemove.Checked;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (rbAdd.Checked)
            {
                txtQuantity.Enabled = true;
                txtPrice.Enabled = true;
            }
            UpdateRadioButtonTabStops();
        }

        private void rbRemove_CheckedChanged(object sender, EventArgs e)
        {
            if (rbRemove.Checked)
            {
                txtQuantity.Enabled = false;
                txtPrice.Enabled = false;
                txtQuantity.Text = "";
                txtPrice.Text = "";
            }
            UpdateRadioButtonTabStops();
        }

        public ProductRegistration()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            txtQuantity.KeyPress += TxtQuantity_KeyPress;
            txtPrice.KeyPress += TxtPrice_KeyPress;
            rbAdd.CheckedChanged += (s, e) => UpdateRadioButtonTabStops();
            rbRemove.CheckedChanged += (s, e) => UpdateRadioButtonTabStops();
            UpdateRadioButtonTabStops();
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
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("O nome do produto é obrigatório.");
                txtName.Focus();
                return;
            }

            if (rbAdd.Checked)
            {
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

                string nameLower = txtName.Text.ToLower();

                try
                {
                    if (DatabaseHelper.ProductExists(nameLower))
                    {
                        var result = MessageBox.Show(
                            $"O produto \"{txtName.Text}\" já existe. Deseja acrescentar a quantidade ao estoque?",
                            "Produto já existe",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question
                        );
                        if (result == DialogResult.Yes)
                        {
                            bool updated = DatabaseHelper.UpdateProductQuantity(nameLower, q);
                            if (updated)
                                MessageBox.Show("Quantidade acrescentada ao estoque com sucesso!");
                            else
                                MessageBox.Show("Erro ao atualizar a quantidade do produto.");
                            RegisteredProductOrCancelled?.Invoke(this, EventArgs.Empty);
                            this.Close();
                        }
                    }
                    else
                    {
                        DatabaseHelper.InsertProduct(
                            nameLower,
                            q,
                            p
                        );
                        MessageBox.Show("Produto cadastrado com sucesso!");
                        RegisteredProductOrCancelled?.Invoke(this, EventArgs.Empty);
                        this.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao cadastrar produto: " + ex.Message + "\n" + ex.StackTrace);
                }
            }
            else if (rbRemove.Checked)
            {
                var result = MessageBox.Show(
                    $"Deseja realmente remover o produto \"{txtName.Text}\"?",
                    "Confirmação de Remoção",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );
                if (result == DialogResult.Yes)
                {
                    string nameLower = txtName.Text.ToLower();
                    bool removed = DatabaseHelper.DeleteProductByName(nameLower);
                    if (removed)
                        MessageBox.Show("Produto removido com sucesso!");
                    else
                        MessageBox.Show("Produto não encontrado!");

                    RegisteredProductOrCancelled?.Invoke(this, EventArgs.Empty);
                    this.Close();
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show(
                "Deseja realmente fechar o cadastro? As informações não salvas serão perdidas.",
                "Confirmação",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                RegisteredProductOrCancelled?.Invoke(this, EventArgs.Empty);
                this.Close();
            }
        }
    }
}
