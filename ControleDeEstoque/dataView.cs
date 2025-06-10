using System;
using System.Data.SQLite;
using System.IO;


namespace ControleDeEstoque
{
    public partial class DataView : Form
    {
        public DataView()
        {
            InitializeComponent();
            this.Resize += Form1_Resize;
            lblDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
            Form1_Resize(this, EventArgs.Empty);
        }

        // DataGridView to display the data
        public void DataShow()
        {
            dbView.Rows.Clear();
            var table = DatabaseHelper.GetAllInventory();
            foreach (System.Data.DataRow row in table.Rows)
            {
                dbView.Rows.Add(
                    row["id"],
                    row["name"],
                    row["quantity"],
                    string.Format(System.Globalization.CultureInfo.GetCultureInfo("pt-BR"), "{0:C}", row["price"])
                    );
            }
        }


        // Position and dimension of components
        private void Form1_Resize(object sender, EventArgs e)
        {
            int alturaSuperior = (int)(this.ClientSize.Height * 0.3);
            int alturaDataGrid = this.ClientSize.Height - alturaSuperior;

            panelSuperior.Location = new Point(0, 0);
            panelSuperior.Size = new Size(this.ClientSize.Width, alturaSuperior);

            dbView.Location = new Point(0, alturaSuperior);
            dbView.Size = new Size(this.ClientSize.Width, alturaDataGrid);

            int spacing = 20;
            int larguraTotalBotoes = btnEntry.Width + spacing + btnSale.Width;
            int posX = (panelSuperior.Width - larguraTotalBotoes) / 2;
            int posY = (panelSuperior.Height - btnEntry.Height) / 2;

            btnEntry.Location = new Point(posX, posY);
            btnSale.Location = new Point(posX + btnEntry.Width + spacing, posY);

            int distanciaEntreLabelEBotoes = 20;
            int lblTituloX = (panelSuperior.Width - lblTitle.Width) / 2;
            int lblTituloY = posY - lblTitle.Height - distanciaEntreLabelEBotoes;
            if (lblTituloY < 0) lblTituloY = 0;

            lblTitle.Location = new Point(lblTituloX, lblTituloY);
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            DatabaseHelper.CreateDatabase();
            DataShow();
        }

        // Insert data into the database
        private void btnEntry_Click(object sender, EventArgs e)
        {
            var formRegister = new ProductRegistration();
            formRegister.FormClosed += (s, args) =>
            {
                this.Show();
                this.DataShow();
            };
            formRegister.Show();
            this.Hide();
        }

        private void btnSale_Click(object sender, EventArgs e)
        {
            var saleDialog = new SaleDialog();
            saleDialog.ShowDialog();
        }

    }
}
