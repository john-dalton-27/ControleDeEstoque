using System;
using System.Data.SQLite;
using System.IO;


namespace ControleDeEstoque
{
    public partial class DataView : Form
    {

        // Database connection and operations
        string path = "inventory.db";
        string cs = @"URI=file:" + Application.StartupPath + "\\" + "inventory.db";

        SQLiteConnection con;
        SQLiteCommand cmd;
        SQLiteDataReader dr;

        // DataGridView to display the data
        public void DataShow()
        {
            con = new SQLiteConnection(cs);
            con.Open();
            cmd = new SQLiteCommand("SELECT * FROM inventory", con);
            dr = cmd.ExecuteReader();
            dbView.Rows.Clear();
            while (dr.Read())
            {
                dbView.Rows.Add(
                    dr["id"], 
                    dr["name"], 
                    dr["quantity"], 
                    string.Format(System.Globalization.CultureInfo.GetCultureInfo("pt-BR"), "{0:C}", dr["price"]), 
                    dr["aquisition_date"]
                );
            }
            con.Close();
        }

        // Create the database if it does not exist
        private void createDatabase()
        {
            if (!File.Exists(path))
            {
                SQLiteConnection.CreateFile(path);
                using (var sqlite = new SQLiteConnection(@"Data Source=" + path + ";Version=3;"))
                {
                    sqlite.Open();
                    string sql = "CREATE TABLE inventory (id INTEGER PRIMARY KEY AUTOINCREMENT, name TEXT NOT NULL, quantity INTEGER NOT NULL, price REAL NOT NULL, aquisition_date TEXT NOT NULL)";
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

        // Database connection
        public SQLiteConnection GetConnection()
        {
            if (con == null)
            {
                con = new SQLiteConnection(cs);
            }
            return con;
        }


        public DataView()
        {
            InitializeComponent();
            this.Resize += Form1_Resize;
            lblDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
            Form1_Resize(this, EventArgs.Empty);
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
            createDatabase();
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

        }

    }
}
