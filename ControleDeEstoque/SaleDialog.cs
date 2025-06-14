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
            string name = cbSale.SelectedItem.ToString();

            bool success = DatabaseHelper.SubtractProductQuantity(name, qty);
            if (!success)
            {
                MessageBox.Show("Quantidade insuficiente em estoque ou produto não encontrado.");
                return;
            }

            SaleRegisteredOrCancelled?.Invoke(this, EventArgs.Empty);
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            SaleRegisteredOrCancelled?.Invoke(this, EventArgs.Empty);
            this.Close();
        }
    }
}
