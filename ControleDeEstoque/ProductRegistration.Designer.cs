namespace ControleDeEstoque
{
    partial class ProductRegistration
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
            lblRegisterTitle = new Label();
            lblName = new Label();
            txtName = new TextBox();
            lblQuantity = new Label();
            lblPrice = new Label();
            txtQuantity = new TextBox();
            txtPrice = new TextBox();
            btnRegister = new Button();
            btnCancel = new Button();
            rbAdd = new RadioButton();
            rbRemove = new RadioButton();
            SuspendLayout();
            // 
            // lblRegisterTitle
            // 
            lblRegisterTitle.Anchor = AnchorStyles.None;
            lblRegisterTitle.AutoSize = true;
            lblRegisterTitle.Font = new Font("Arial Black", 20.25F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lblRegisterTitle.Location = new Point(133, 22);
            lblRegisterTitle.Name = "lblRegisterTitle";
            lblRegisterTitle.Size = new Size(338, 38);
            lblRegisterTitle.TabIndex = 0;
            lblRegisterTitle.Text = "Cadastro de Produtos";
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Font = new Font("Arial", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblName.Location = new Point(43, 120);
            lblName.Name = "lblName";
            lblName.Size = new Size(70, 22);
            lblName.TabIndex = 1;
            lblName.Text = "Nome:";
            // 
            // txtName
            // 
            txtName.AcceptsTab = true;
            txtName.Font = new Font("Arial Narrow", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtName.Location = new Point(225, 110);
            txtName.Name = "txtName";
            txtName.Size = new Size(318, 32);
            txtName.TabIndex = 3;
            // 
            // lblQuantity
            // 
            lblQuantity.AutoSize = true;
            lblQuantity.Font = new Font("Arial", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblQuantity.Location = new Point(43, 175);
            lblQuantity.Name = "lblQuantity";
            lblQuantity.Size = new Size(124, 22);
            lblQuantity.TabIndex = 9;
            lblQuantity.Text = "Quantidade:";
            // 
            // lblPrice
            // 
            lblPrice.AutoSize = true;
            lblPrice.Font = new Font("Arial", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblPrice.Location = new Point(43, 230);
            lblPrice.Name = "lblPrice";
            lblPrice.Size = new Size(72, 22);
            lblPrice.TabIndex = 10;
            lblPrice.Text = "Preço:";
            // 
            // txtQuantity
            // 
            txtQuantity.Font = new Font("Arial Narrow", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtQuantity.Location = new Point(225, 165);
            txtQuantity.Name = "txtQuantity";
            txtQuantity.Size = new Size(318, 32);
            txtQuantity.TabIndex = 4;
            // 
            // txtPrice
            // 
            txtPrice.Font = new Font("Arial Narrow", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtPrice.Location = new Point(225, 220);
            txtPrice.Name = "txtPrice";
            txtPrice.Size = new Size(318, 32);
            txtPrice.TabIndex = 5;
            // 
            // btnRegister
            // 
            btnRegister.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnRegister.ForeColor = Color.Lime;
            btnRegister.Location = new Point(225, 277);
            btnRegister.Name = "btnRegister";
            btnRegister.Size = new Size(152, 49);
            btnRegister.TabIndex = 6;
            btnRegister.Text = "Salvar";
            btnRegister.UseVisualStyleBackColor = true;
            btnRegister.Click += btnRegister_Click;
            // 
            // btnCancel
            // 
            btnCancel.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCancel.ForeColor = Color.Red;
            btnCancel.Location = new Point(391, 277);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(152, 49);
            btnCancel.TabIndex = 7;
            btnCancel.Text = "Cancelar";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // rbAdd
            // 
            rbAdd.AutoSize = true;
            rbAdd.Checked = true;
            rbAdd.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            rbAdd.Location = new Point(225, 74);
            rbAdd.Name = "rbAdd";
            rbAdd.Size = new Size(100, 23);
            rbAdd.TabIndex = 1;
            rbAdd.TabStop = true;
            rbAdd.Text = "Adicionar";
            rbAdd.UseVisualStyleBackColor = true;
            rbAdd.CheckedChanged += radioButton1_CheckedChanged;
            // 
            // rbRemove
            // 
            rbRemove.AutoSize = true;
            rbRemove.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            rbRemove.Location = new Point(447, 74);
            rbRemove.Name = "rbRemove";
            rbRemove.Size = new Size(96, 23);
            rbRemove.TabIndex = 2;
            rbRemove.TabStop = true;
            rbRemove.Text = "Remover";
            rbRemove.UseVisualStyleBackColor = true;
            rbRemove.CheckedChanged += rbRemove_CheckedChanged;
            // 
            // ProductRegistration
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(584, 361);
            Controls.Add(rbRemove);
            Controls.Add(rbAdd);
            Controls.Add(btnCancel);
            Controls.Add(btnRegister);
            Controls.Add(txtPrice);
            Controls.Add(txtQuantity);
            Controls.Add(lblPrice);
            Controls.Add(lblQuantity);
            Controls.Add(txtName);
            Controls.Add(lblName);
            Controls.Add(lblRegisterTitle);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MaximumSize = new Size(600, 400);
            MinimumSize = new Size(600, 400);
            Name = "ProductRegistration";
            Text = "Cadastro de Produtos";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblRegisterTitle;
        private Label lblName;
        private TextBox txtName;
        private Label lblQuantity;
        private Label lblPrice;
        private TextBox txtQuantity;
        private TextBox txtPrice;
        private Button btnRegister;
        private Button btnCancel;
        private RadioButton rbAdd;
        private RadioButton rbRemove;
    }
}