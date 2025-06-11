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
        public ProductRegistration()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void ProductRegistration_Load(object sender, EventArgs e)
        {
            int posX = (this.ClientSize.Width - lblRegisterTitle.Width) / 2;
            lblRegisterTitle.Location = new Point(posX, lblRegisterTitle.Location.Y);
        }
        private void btnRegister_Click(object sender, EventArgs e)
        {
            try
            {
                DatabaseHelper.InsertProduct(
                    txtName.Text,
                    int.TryParse(txtQuantity.Text, out int q) ? q : 0,
                    double.TryParse(txtPrice.Text, out double p) ? p : 0.0
                );
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
