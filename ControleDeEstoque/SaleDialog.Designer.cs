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
            comboBox1 = new ComboBox();
            btnConfirm = new Button();
            saleTitle = new Label();
            txtSaleName = new Label();
            textBox1 = new TextBox();
            btnCancel = new Button();
            txtSaleQty = new Label();
            ((System.ComponentModel.ISupportInitialize)fileSystemWatcher1).BeginInit();
            SuspendLayout();
            // 
            // fileSystemWatcher1
            // 
            fileSystemWatcher1.EnableRaisingEvents = true;
            fileSystemWatcher1.SynchronizingObject = this;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(98, 141);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(368, 23);
            comboBox1.TabIndex = 0;
            // 
            // btnConfirm
            // 
            btnConfirm.Font = new Font("Arial", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnConfirm.Location = new Point(158, 253);
            btnConfirm.Name = "btnConfirm";
            btnConfirm.Size = new Size(161, 58);
            btnConfirm.TabIndex = 1;
            btnConfirm.Text = "Confirmar";
            btnConfirm.UseVisualStyleBackColor = true;
            // 
            // saleTitle
            // 
            saleTitle.AutoSize = true;
            saleTitle.Font = new Font("Arial", 26.25F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            saleTitle.Location = new Point(216, 36);
            saleTitle.Name = "saleTitle";
            saleTitle.Size = new Size(320, 40);
            saleTitle.TabIndex = 3;
            saleTitle.Text = "Saída de Produtos";
            // 
            // txtSaleName
            // 
            txtSaleName.AutoSize = true;
            txtSaleName.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtSaleName.Location = new Point(12, 149);
            txtSaleName.Name = "txtSaleName";
            txtSaleName.Size = new Size(60, 19);
            txtSaleName.TabIndex = 4;
            txtSaleName.Text = "Nome:";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(656, 141);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(55, 23);
            textBox1.TabIndex = 6;
            // 
            // btnCancel
            // 
            btnCancel.Font = new Font("Arial", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCancel.Location = new Point(497, 253);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(161, 58);
            btnCancel.TabIndex = 7;
            btnCancel.Text = "Cancelar";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // txtSaleQty
            // 
            txtSaleQty.AutoSize = true;
            txtSaleQty.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtSaleQty.Location = new Point(527, 145);
            txtSaleQty.Name = "txtSaleQty";
            txtSaleQty.Size = new Size(103, 19);
            txtSaleQty.TabIndex = 8;
            txtSaleQty.Text = "Quantidade:";
            // 
            // SaleDialog
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(txtSaleQty);
            Controls.Add(btnCancel);
            Controls.Add(textBox1);
            Controls.Add(txtSaleName);
            Controls.Add(saleTitle);
            Controls.Add(btnConfirm);
            Controls.Add(comboBox1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "SaleDialog";
            Text = "SaleDialog";
            ((System.ComponentModel.ISupportInitialize)fileSystemWatcher1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private FileSystemWatcher fileSystemWatcher1;
        private TextBox textBox1;
        private Label txtSaleName;
        private Label saleTitle;
        private Button btnConfirm;
        private ComboBox comboBox1;
        private Button btnCancel;
        private Label txtSaleQty;
    }
}