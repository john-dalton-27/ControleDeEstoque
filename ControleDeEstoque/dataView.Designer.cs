namespace ControleDeEstoque
{
    partial class DataView
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dbView = new DataGridView();
            btnEntry = new Button();
            btnSale = new Button();
            txtSearch = new TextBox();
            cbSearch = new ComboBox();
            panelSuperior = new Panel();
            lblTitle = new Label();
            lblDate = new Label();
            id = new DataGridViewTextBoxColumn();
            name = new DataGridViewTextBoxColumn();
            quantity = new DataGridViewTextBoxColumn();
            price = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dbView).BeginInit();
            panelSuperior.SuspendLayout();
            SuspendLayout();
            // 
            // dbView
            // 
            dbView.BackgroundColor = SystemColors.ButtonHighlight;
            dbView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dbView.Columns.AddRange(new DataGridViewColumn[] { id, name, quantity, price });
            dbView.Location = new Point(0, 113);
            dbView.Name = "dbView";
            dbView.RowHeadersWidth = 100;
            dbView.Size = new Size(1055, 355);
            dbView.TabIndex = 0;
            // 
            // btnEntry
            // 
            btnEntry.Location = new Point(319, 22);
            btnEntry.Name = "btnEntry";
            btnEntry.Size = new Size(154, 35);
            btnEntry.TabIndex = 1;
            btnEntry.Text = "Entrada";
            btnEntry.UseVisualStyleBackColor = true;
            btnEntry.Click += btnEntry_Click;
            // 
            // btnSale
            // 
            btnSale.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnSale.Location = new Point(563, 22);
            btnSale.Name = "btnSale";
            btnSale.Size = new Size(152, 35);
            btnSale.TabIndex = 2;
            btnSale.Text = "Saída";
            btnSale.UseVisualStyleBackColor = true;
            btnSale.Click += btnSale_Click;
            // 
            // txtSearch
            // 
            txtSearch.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtSearch.Location = new Point(125, 79);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(927, 23);
            txtSearch.TabIndex = 3;
            // 
            // cbSearch
            // 
            cbSearch.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            cbSearch.FormattingEnabled = true;
            cbSearch.Location = new Point(3, 79);
            cbSearch.Name = "cbSearch";
            cbSearch.Size = new Size(116, 23);
            cbSearch.TabIndex = 4;
            // 
            // panelSuperior
            // 
            panelSuperior.BackgroundImage = Properties.Resources.capa;
            panelSuperior.Controls.Add(lblTitle);
            panelSuperior.Controls.Add(lblDate);
            panelSuperior.Controls.Add(txtSearch);
            panelSuperior.Controls.Add(btnEntry);
            panelSuperior.Controls.Add(btnSale);
            panelSuperior.Controls.Add(cbSearch);
            panelSuperior.Location = new Point(0, 2);
            panelSuperior.Name = "panelSuperior";
            panelSuperior.Size = new Size(1055, 105);
            panelSuperior.TabIndex = 5;
            // 
            // lblTitle
            // 
            lblTitle.Anchor = AnchorStyles.Top;
            lblTitle.AutoSize = true;
            lblTitle.BackColor = Color.Transparent;
            lblTitle.Font = new Font("Arial Black", 20F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lblTitle.ForeColor = Color.Lime;
            lblTitle.Location = new Point(381, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(318, 38);
            lblTitle.TabIndex = 6;
            lblTitle.Text = "Controle de Estoque";
            // 
            // lblDate
            // 
            lblDate.AutoSize = true;
            lblDate.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblDate.ForeColor = Color.Red;
            lblDate.Location = new Point(12, 7);
            lblDate.Name = "lblDate";
            lblDate.Size = new Size(54, 19);
            lblDate.TabIndex = 5;
            lblDate.Text = "label1";
            // 
            // id
            // 
            id.HeaderText = "ID";
            id.Name = "id";
            // 
            // name
            // 
            name.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            name.HeaderText = "Nome";
            name.Name = "name";
            // 
            // quantity
            // 
            quantity.HeaderText = "Quantidade";
            quantity.Name = "quantity";
            // 
            // price
            // 
            price.HeaderText = "Preço";
            price.Name = "price";
            // 
            // DataView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1054, 461);
            Controls.Add(panelSuperior);
            Controls.Add(dbView);
            MinimumSize = new Size(600, 400);
            Name = "DataView";
            Text = "Controle de Estoque";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dbView).EndInit();
            panelSuperior.ResumeLayout(false);
            panelSuperior.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dbView;
        private Button btnEntry;
        private Button btnSale;
        private TextBox txtSearch;
        private ComboBox cbSearch;
        private Panel panelSuperior;
        private Label lblDate;
        private Label lblTitle;
        private DataGridViewTextBoxColumn id;
        private DataGridViewTextBoxColumn name;
        private DataGridViewTextBoxColumn quantity;
        private DataGridViewTextBoxColumn price;
    }
}
