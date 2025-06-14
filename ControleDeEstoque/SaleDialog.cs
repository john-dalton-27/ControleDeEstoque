using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;

namespace ControleDeEstoque
{
    public partial class SaleDialog : Form
    {
        public event EventHandler SaleRegisteredOrCancelled;

        public SaleDialog()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            rbEntry.CheckedChanged += (s, e) => UpdateRadioButtonTabStops();
            rbSale.CheckedChanged += (s, e) => UpdateRadioButtonTabStops();
            UpdateRadioButtonTabStops();
        }
        private void UpdateRadioButtonTabStops()
        {
            rbEntry.TabStop = !rbEntry.Checked;
            rbSale.TabStop = !rbSale.Checked;
        }

        private void SaleDialog_Load(object sender, EventArgs e)
        {
            cbSale.Items.Clear();
            var names = DatabaseHelper.GetAllProductNames();
            foreach (var name in names)
            {
                cbSale.Items.Add(CultureInfo.CurrentCulture.TextInfo.ToTitleCase(name.ToLower()));
            }
            if (cbSale.Items.Count > 0)
                cbSale.SelectedIndex = 0;
        }

        private void txtQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void saleTitle_Click(object sender, EventArgs e)
        {

        }
        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (cbSale.SelectedItem == null || string.IsNullOrWhiteSpace(txtQty.Text))
            {
                MessageBox.Show("Selecione um produto e informe a quantidade.");
                return;
            }

            int qty = int.Parse(txtQty.Text);
            string name = cbSale.SelectedItem.ToString().ToLower();

            int qtyChange = rbEntry.Checked ? qty : -qty;

            bool success = DatabaseHelper.UpdateProductQuantity(name, qtyChange);
            if (!success)
            {
                MessageBox.Show("Operação inválida: quantidade insuficiente ou produto não encontrado.");
                return;
            }

            if (rbEntry.Checked)
                MessageBox.Show("Quantidade adicionada com sucesso!");
            else
                MessageBox.Show("Quantidade removida com sucesso!");

            SaleRegisteredOrCancelled?.Invoke(this, EventArgs.Empty);
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show(
                "Deseja realmente fechar a janela? As informações não salvas serão perdidas.",
                "Confirmação",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                SaleRegisteredOrCancelled?.Invoke(this, EventArgs.Empty);
                this.Close();
            }
        }
    }
}
