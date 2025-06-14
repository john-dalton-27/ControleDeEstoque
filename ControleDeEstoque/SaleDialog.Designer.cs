namespace ControleDeEstoque
{
    partial class SaleDialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            fileSystemWatcher1 = new FileSystemWatcher();
            cbSale = new ComboBox();
            btnConfirm = new Button();
            saleTitle = new Label();
            txtSaleName = new Label();
            txtQty = new TextBox();
            btnCancel = new Button();
            txtSaleQty = new Label();
            rbSale = new RadioButton();
            rbEntry = new RadioButton();
            ((System.ComponentModel.ISupportInitialize)fileSystemWatcher1).BeginInit();
            SuspendLayout();
            // 
            // fileSystemWatcher1
            // 
            fileSystemWatcher1.EnableRaisingEvents = true;
            fileSystemWatcher1.SynchronizingObject = this;
            // 
            // cbSale
            // 
            cbSale.DropDownStyle = ComboBoxStyle.DropDownList;
            cbSale.Font = new Font("Arial Narrow", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cbSale.FormattingEnabled = true;
            cbSale.Location = new Point(89, 127);
            cbSale.MaxDropDownItems = 20;
            cbSale.Name = "cbSale";
            cbSale.Size = new Size(251, 28);
            cbSale.TabIndex = 0;
            // 
            // btnConfirm
            // 
            btnConfirm.Font = new Font("Arial", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnConfirm.ForeColor = Color.Lime;
            btnConfirm.Location = new Point(101, 253);
            btnConfirm.Name = "btnConfirm";
            btnConfirm.Size = new Size(161, 58);
            btnConfirm.TabIndex = 5;
            btnConfirm.Text = "Confirmar";
            btnConfirm.UseVisualStyleBackColor = true;
            btnConfirm.Click += btnConfirm_Click;
            // 
            // saleTitle
            // 
            saleTitle.AutoSize = true;
            saleTitle.Font = new Font("Arial", 26.25F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            saleTitle.Location = new Point(66, 22);
            saleTitle.Name = "saleTitle";
            saleTitle.Size = new Size(468, 40);
            saleTitle.TabIndex = 3;
            saleTitle.Text = "Movimentação de Produtos";
            saleTitle.Click += saleTitle_Click;
            // 
            // txtSaleName
            // 
            txtSaleName.AutoSize = true;
            txtSaleName.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtSaleName.Location = new Point(23, 136);
            txtSaleName.Name = "txtSaleName";
            txtSaleName.Size = new Size(60, 19);
            txtSaleName.TabIndex = 4;
            txtSaleName.Text = "Nome:";
            // 
            // txtQty
            // 
            txtQty.Font = new Font("Arial Narrow", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtQty.Location = new Point(495, 127);
            txtQty.Name = "txtQty";
            txtQty.Size = new Size(55, 26);
            txtQty.TabIndex = 2;
            // 
            // btnCancel
            // 
            btnCancel.Font = new Font("Arial", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCancel.ForeColor = Color.Red;
            btnCancel.Location = new Point(340, 253);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(161, 58);
            btnCancel.TabIndex = 6;
            btnCancel.Text = "Cancelar";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // txtSaleQty
            // 
            txtSaleQty.AutoSize = true;
            txtSaleQty.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtSaleQty.Location = new Point(386, 136);
            txtSaleQty.Name = "txtSaleQty";
            txtSaleQty.Size = new Size(103, 19);
            txtSaleQty.TabIndex = 8;
            txtSaleQty.Text = "Quantidade:";
            // 
            // rbSale
            // 
            rbSale.AutoSize = true;
            rbSale.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            rbSale.Location = new Point(340, 190);
            rbSale.Name = "rbSale";
            rbSale.Size = new Size(70, 23);
            rbSale.TabIndex = 4;
            rbSale.TabStop = true;
            rbSale.Text = "Saída";
            rbSale.UseVisualStyleBackColor = true;
            // 
            // rbEntry
            // 
            rbEntry.AutoSize = true;
            rbEntry.Checked = true;
            rbEntry.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            rbEntry.Location = new Point(175, 190);
            rbEntry.Name = "rbEntry";
            rbEntry.Size = new Size(87, 23);
            rbEntry.TabIndex = 3;
            rbEntry.TabStop = true;
            rbEntry.Text = "Entrada";
            rbEntry.UseVisualStyleBackColor = true;
            // 
            // SaleDialog
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(584, 361);
            Controls.Add(rbEntry);
            Controls.Add(rbSale);
            Controls.Add(txtSaleQty);
            Controls.Add(btnCancel);
            Controls.Add(txtQty);
            Controls.Add(txtSaleName);
            Controls.Add(saleTitle);
            Controls.Add(btnConfirm);
            Controls.Add(cbSale);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "SaleDialog";
            Text = "SaleDialog";
            Load += SaleDialog_Load;
            ((System.ComponentModel.ISupportInitialize)fileSystemWatcher1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private FileSystemWatcher fileSystemWatcher1;
        private TextBox txtQty;
        private Label txtSaleName;
        private Label saleTitle;
        private Button btnConfirm;
        private ComboBox cbSale;
        private Button btnCancel;
        private Label txtSaleQty;
        private RadioButton rbEntry;
        private RadioButton rbSale;
    }
}