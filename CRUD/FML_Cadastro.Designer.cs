namespace CRUD
{
    partial class FML_Cadastro
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
            LB_Nome = new Label();
            TXB_Nome = new TextBox();
            TXB_Sobrenome = new TextBox();
            LB_Sobrenome = new Label();
            TXB_Email = new TextBox();
            LB_Email = new Label();
            LB_Elo = new Label();
            TXB_Apelido = new TextBox();
            LB_Apelido = new Label();
            CBX_Elo = new ComboBox();
            LB_DataNascimento = new Label();
            DTM_DataNascimento = new DateTimePicker();
            BTN_Cadastrar = new Button();
            BTN_Cancelar = new Button();
            SuspendLayout();
            // 
            // LB_Nome
            // 
            LB_Nome.AutoSize = true;
            LB_Nome.Location = new Point(25, 27);
            LB_Nome.Name = "LB_Nome";
            LB_Nome.Size = new Size(50, 20);
            LB_Nome.TabIndex = 0;
            LB_Nome.Text = "Nome";
            // 
            // TXB_Nome
            // 
            TXB_Nome.Location = new Point(25, 49);
            TXB_Nome.Name = "TXB_Nome";
            TXB_Nome.Size = new Size(161, 27);
            TXB_Nome.TabIndex = 1;
            // 
            // TXB_Sobrenome
            // 
            TXB_Sobrenome.Location = new Point(195, 49);
            TXB_Sobrenome.Name = "TXB_Sobrenome";
            TXB_Sobrenome.Size = new Size(161, 27);
            TXB_Sobrenome.TabIndex = 3;
            // 
            // LB_Sobrenome
            // 
            LB_Sobrenome.AutoSize = true;
            LB_Sobrenome.Location = new Point(195, 27);
            LB_Sobrenome.Name = "LB_Sobrenome";
            LB_Sobrenome.Size = new Size(86, 20);
            LB_Sobrenome.TabIndex = 2;
            LB_Sobrenome.Text = "Sobrenome";
            // 
            // TXB_Email
            // 
            TXB_Email.Location = new Point(25, 109);
            TXB_Email.Name = "TXB_Email";
            TXB_Email.Size = new Size(331, 27);
            TXB_Email.TabIndex = 5;
            // 
            // LB_Email
            // 
            LB_Email.AutoSize = true;
            LB_Email.Location = new Point(25, 85);
            LB_Email.Name = "LB_Email";
            LB_Email.Size = new Size(52, 20);
            LB_Email.TabIndex = 4;
            LB_Email.Text = "E-mail";
            // 
            // LB_Elo
            // 
            LB_Elo.AutoSize = true;
            LB_Elo.Location = new Point(195, 155);
            LB_Elo.Name = "LB_Elo";
            LB_Elo.Size = new Size(30, 20);
            LB_Elo.TabIndex = 8;
            LB_Elo.Text = "Elo";
            // 
            // TXB_Apelido
            // 
            TXB_Apelido.Location = new Point(25, 179);
            TXB_Apelido.Name = "TXB_Apelido";
            TXB_Apelido.Size = new Size(161, 27);
            TXB_Apelido.TabIndex = 7;
            // 
            // LB_Apelido
            // 
            LB_Apelido.AutoSize = true;
            LB_Apelido.Location = new Point(25, 155);
            LB_Apelido.Name = "LB_Apelido";
            LB_Apelido.Size = new Size(62, 20);
            LB_Apelido.TabIndex = 6;
            LB_Apelido.Text = "Apelido";
            // 
            // CBX_Elo
            // 
            CBX_Elo.FormattingEnabled = true;
            CBX_Elo.Location = new Point(195, 179);
            CBX_Elo.Name = "CBX_Elo";
            CBX_Elo.Size = new Size(161, 28);
            CBX_Elo.TabIndex = 9;
            // 
            // LB_DataNascimento
            // 
            LB_DataNascimento.AutoSize = true;
            LB_DataNascimento.Location = new Point(25, 229);
            LB_DataNascimento.Name = "LB_DataNascimento";
            LB_DataNascimento.Size = new Size(145, 20);
            LB_DataNascimento.TabIndex = 10;
            LB_DataNascimento.Text = "Data de Nascimento";
            // 
            // DTM_DataNascimento
            // 
            DTM_DataNascimento.Format = DateTimePickerFormat.Short;
            DTM_DataNascimento.Location = new Point(25, 253);
            DTM_DataNascimento.Name = "DTM_DataNascimento";
            DTM_DataNascimento.Size = new Size(161, 27);
            DTM_DataNascimento.TabIndex = 11;
            // 
            // BTN_Cadastrar
            // 
            BTN_Cadastrar.Location = new Point(40, 399);
            BTN_Cadastrar.Name = "BTN_Cadastrar";
            BTN_Cadastrar.Size = new Size(94, 29);
            BTN_Cadastrar.TabIndex = 12;
            BTN_Cadastrar.Text = "Cadastrar";
            BTN_Cadastrar.UseVisualStyleBackColor = true;
            BTN_Cadastrar.Click += BTN_Cadastrar_Click;
            // 
            // BTN_Cancelar
            // 
            BTN_Cancelar.Location = new Point(238, 399);
            BTN_Cancelar.Name = "BTN_Cancelar";
            BTN_Cancelar.Size = new Size(94, 29);
            BTN_Cancelar.TabIndex = 13;
            BTN_Cancelar.Text = "Cancelar";
            BTN_Cancelar.UseVisualStyleBackColor = true;
            BTN_Cancelar.Click += AoClicarCancelar;
            // 
            // FML_Cadastro
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(385, 451);
            Controls.Add(BTN_Cancelar);
            Controls.Add(BTN_Cadastrar);
            Controls.Add(DTM_DataNascimento);
            Controls.Add(LB_DataNascimento);
            Controls.Add(CBX_Elo);
            Controls.Add(LB_Elo);
            Controls.Add(TXB_Apelido);
            Controls.Add(LB_Apelido);
            Controls.Add(TXB_Email);
            Controls.Add(LB_Email);
            Controls.Add(TXB_Sobrenome);
            Controls.Add(LB_Sobrenome);
            Controls.Add(TXB_Nome);
            Controls.Add(LB_Nome);
            Name = "FML_Cadastro";
            Text = "FML_Cadastro";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label LB_Nome;
        private TextBox TXB_Nome;
        private TextBox TXB_Sobrenome;
        private Label LB_Sobrenome;
        private TextBox TXB_Email;
        private Label LB_Email;
        private TextBox textBox2;
        private Label LB_Elo;
        private TextBox TXB_Apelido;
        private Label LB_Apelido;
        private ComboBox CBX_Elo;
        private Label LB_DataNascimento;
        private DateTimePicker DTM_DataNascimento;
        private Button BTN_Cadastrar;
        private Button BTN_Cancelar;
    }
}