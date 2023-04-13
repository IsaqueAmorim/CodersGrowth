namespace CRUD
{
    partial class FML_Listagem
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
            components = new System.ComponentModel.Container();
            GRD_GridList = new DataGridView();
            listaJogadorBindingSource = new BindingSource(components);
            listPlayersBindingSource = new BindingSource(components);
            BTN_Novo = new Button();
            BTN_Atualizar = new Button();
            BTN_Deletar = new Button();
            idDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            nomeDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            sobrenomeDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            apelidoDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            emailDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            eloDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            dataNascimentoDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)GRD_GridList).BeginInit();
            ((System.ComponentModel.ISupportInitialize)listaJogadorBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)listPlayersBindingSource).BeginInit();
            SuspendLayout();
            // 
            // GRD_GridList
            // 
            GRD_GridList.AutoGenerateColumns = false;
            GRD_GridList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            GRD_GridList.Columns.AddRange(new DataGridViewColumn[] { idDataGridViewTextBoxColumn, nomeDataGridViewTextBoxColumn, sobrenomeDataGridViewTextBoxColumn, apelidoDataGridViewTextBoxColumn, emailDataGridViewTextBoxColumn, eloDataGridViewTextBoxColumn, dataNascimentoDataGridViewTextBoxColumn });
            GRD_GridList.DataSource = listaJogadorBindingSource;
            GRD_GridList.Location = new Point(12, 12);
            GRD_GridList.Name = "GRD_GridList";
            GRD_GridList.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            GRD_GridList.RowTemplate.Height = 25;
            GRD_GridList.Size = new Size(775, 349);
            GRD_GridList.TabIndex = 0;
            // 
            // listaJogadorBindingSource
            // 
            listaJogadorBindingSource.DataSource = typeof(JogadorModelo);
            // 
            // BTN_Novo
            // 
            BTN_Novo.Location = new Point(550, 367);
            BTN_Novo.Name = "BTN_Novo";
            BTN_Novo.Size = new Size(75, 23);
            BTN_Novo.TabIndex = 1;
            BTN_Novo.Text = "Novo";
            BTN_Novo.UseVisualStyleBackColor = true;
            BTN_Novo.Click += button1_Click;
            // 
            // BTN_Atualizar
            // 
            BTN_Atualizar.Location = new Point(631, 367);
            BTN_Atualizar.Name = "BTN_Atualizar";
            BTN_Atualizar.Size = new Size(75, 23);
            BTN_Atualizar.TabIndex = 2;
            BTN_Atualizar.Text = "Atualizar";
            BTN_Atualizar.UseVisualStyleBackColor = true;
            BTN_Atualizar.Click += BTN_Update_Click;
            // 
            // BTN_Deletar
            // 
            BTN_Deletar.Location = new Point(712, 367);
            BTN_Deletar.Name = "BTN_Deletar";
            BTN_Deletar.Size = new Size(75, 23);
            BTN_Deletar.TabIndex = 3;
            BTN_Deletar.Text = "Deletar";
            BTN_Deletar.UseVisualStyleBackColor = true;
            // 
            // idDataGridViewTextBoxColumn
            // 
            idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            idDataGridViewTextBoxColumn.HeaderText = "Id";
            idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            idDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // nomeDataGridViewTextBoxColumn
            // 
            nomeDataGridViewTextBoxColumn.DataPropertyName = "Nome";
            nomeDataGridViewTextBoxColumn.HeaderText = "Nome";
            nomeDataGridViewTextBoxColumn.Name = "nomeDataGridViewTextBoxColumn";
            // 
            // sobrenomeDataGridViewTextBoxColumn
            // 
            sobrenomeDataGridViewTextBoxColumn.DataPropertyName = "Sobrenome";
            sobrenomeDataGridViewTextBoxColumn.HeaderText = "Sobrenome";
            sobrenomeDataGridViewTextBoxColumn.Name = "sobrenomeDataGridViewTextBoxColumn";
            // 
            // apelidoDataGridViewTextBoxColumn
            // 
            apelidoDataGridViewTextBoxColumn.DataPropertyName = "Apelido";
            apelidoDataGridViewTextBoxColumn.HeaderText = "Apelido";
            apelidoDataGridViewTextBoxColumn.Name = "apelidoDataGridViewTextBoxColumn";
            // 
            // emailDataGridViewTextBoxColumn
            // 
            emailDataGridViewTextBoxColumn.DataPropertyName = "Email";
            emailDataGridViewTextBoxColumn.HeaderText = "Email";
            emailDataGridViewTextBoxColumn.Name = "emailDataGridViewTextBoxColumn";
            // 
            // eloDataGridViewTextBoxColumn
            // 
            eloDataGridViewTextBoxColumn.DataPropertyName = "Elo";
            eloDataGridViewTextBoxColumn.HeaderText = "Elo";
            eloDataGridViewTextBoxColumn.Name = "eloDataGridViewTextBoxColumn";
            // 
            // dataNascimentoDataGridViewTextBoxColumn
            // 
            dataNascimentoDataGridViewTextBoxColumn.DataPropertyName = "DataNascimento";
            dataNascimentoDataGridViewTextBoxColumn.HeaderText = "DataNascimento";
            dataNascimentoDataGridViewTextBoxColumn.Name = "dataNascimentoDataGridViewTextBoxColumn";
            dataNascimentoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // FML_Listagem
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(799, 402);
            Controls.Add(BTN_Deletar);
            Controls.Add(BTN_Atualizar);
            Controls.Add(BTN_Novo);
            Controls.Add(GRD_GridList);
            Name = "FML_Listagem";
            Text = "FML_Listagem";
            Load += FML_Listagem_Load;
            ((System.ComponentModel.ISupportInitialize)GRD_GridList).EndInit();
            ((System.ComponentModel.ISupportInitialize)listaJogadorBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)listPlayersBindingSource).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView GRD_GridList;
        private Button BTN_Novo;
        private Button BTN_Atualizar;
        private Button BTN_Deletar;
        private BindingSource listPlayersBindingSource;
        private BindingSource listaJogadorBindingSource;
        private DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn nomeDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn sobrenomeDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn apelidoDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn emailDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn eloDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn dataNascimentoDataGridViewTextBoxColumn;
    }
}