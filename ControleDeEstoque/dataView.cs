using Microsoft.VisualBasic;
using System;
using System.Data.SQLite;
using System.Globalization;
using System.IO;


namespace ControleDeEstoque
{
    public partial class DataView : Form
    {
        public DataView()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Resize += Form1_Resize;
            lblDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
            Form1_Resize(this, EventArgs.Empty);
            dbView.CellFormatting += dbView_CellFormatting;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DatabaseHelper.CreateDatabase();
            cbSearch.Items.Clear();
            cbSearch.Items.Add("ID");
            cbSearch.Items.Add("Nome");
            cbSearch.Items.Add("Quantidade");
            cbSearch.Items.Add("Preço");
            cbSearch.SelectedIndex = 1;
            DataShow();
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
                    CultureInfo.CurrentCulture.TextInfo.ToTitleCase(row["name"].ToString().ToLower()),
                    row["quantity"],
                    string.Format(System.Globalization.CultureInfo.GetCultureInfo("pt-BR"), "{0:C}", row["price"])
                    );
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string selectedColumn = cbSearch.SelectedItem.ToString();
            string dbColumn = selectedColumn switch
            {
                "ID" => "id",
                "Nome" => "name",
                "Quantidade" => "quantity",
                "Preço" => "price",
                _ => "name"
            };

            var table = DatabaseHelper.GetFilteredInventory(dbColumn, txtSearch.Text);
            dbView.Rows.Clear();
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

        // buttons to open dialogs
        private void btnEntry_Click(object sender, EventArgs e)
        {
            var registerDialog = new ProductRegistration();
            registerDialog.RegisteredProductOrCancelled += (s, args) => DataShow();
            registerDialog.ShowDialog();
        }

        private void btnSale_Click(object sender, EventArgs e)
        {
            var saleDialog = new SaleDialog();
            saleDialog.SaleRegisteredOrCancelled += (s, args) => DataShow();
            saleDialog.ShowDialog();
        }

        private void dbView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Supondo que a coluna "Quantidade" seja a coluna de índice 2
            if (dbView.Columns[e.ColumnIndex].Name == "quantity" || dbView.Columns[e.ColumnIndex].HeaderText == "Quantidade")
            {
                if (e.Value != null && int.TryParse(e.Value.ToString(), out int qty))
                {
                    DataGridViewRow row = dbView.Rows[e.RowIndex];
                    if (qty == 0)
                    {
                        row.DefaultCellStyle.BackColor = Color.Red;
                        row.DefaultCellStyle.ForeColor = Color.White;
                    }
                    else
                    {
                        row.DefaultCellStyle.BackColor = Color.White;
                        row.DefaultCellStyle.ForeColor = Color.Black;
                    }
                }
            }
        }
    }
}
