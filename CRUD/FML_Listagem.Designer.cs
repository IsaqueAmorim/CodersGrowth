﻿namespace CRUD
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
            idDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            nomeDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            sobrenomeDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            apelidoDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            emailDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            eloDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            dataNascimentoDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            listaJogadorBindingSource = new BindingSource(components);
            listPlayersBindingSource = new BindingSource(components);
            BTN_Novo = new Button();
            BTN_Atualizar = new Button();
            BTN_Deletar = new Button();
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
            GRD_GridList.Location = new Point(14, 16);
            GRD_GridList.Margin = new Padding(3, 4, 3, 4);
            GRD_GridList.Name = "GRD_GridList";
            GRD_GridList.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            GRD_GridList.RowHeadersWidth = 51;
            GRD_GridList.RowTemplate.Height = 25;
            GRD_GridList.Size = new Size(983, 465);
            GRD_GridList.TabIndex = 0;
          
            // 
            // idDataGridViewTextBoxColumn
            // 
            idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            idDataGridViewTextBoxColumn.HeaderText = "Id";
            idDataGridViewTextBoxColumn.MinimumWidth = 6;
            idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            idDataGridViewTextBoxColumn.ReadOnly = true;
            idDataGridViewTextBoxColumn.Width = 125;
            // 
            // nomeDataGridViewTextBoxColumn
            // 
            nomeDataGridViewTextBoxColumn.DataPropertyName = "Nome";
            nomeDataGridViewTextBoxColumn.HeaderText = "Nome";
            nomeDataGridViewTextBoxColumn.MinimumWidth = 6;
            nomeDataGridViewTextBoxColumn.Name = "nomeDataGridViewTextBoxColumn";
            nomeDataGridViewTextBoxColumn.Width = 125;
            // 
            // sobrenomeDataGridViewTextBoxColumn
            // 
            sobrenomeDataGridViewTextBoxColumn.DataPropertyName = "Sobrenome";
            sobrenomeDataGridViewTextBoxColumn.HeaderText = "Sobrenome";
            sobrenomeDataGridViewTextBoxColumn.MinimumWidth = 6;
            sobrenomeDataGridViewTextBoxColumn.Name = "sobrenomeDataGridViewTextBoxColumn";
            sobrenomeDataGridViewTextBoxColumn.Width = 125;
            // 
            // apelidoDataGridViewTextBoxColumn
            // 
            apelidoDataGridViewTextBoxColumn.DataPropertyName = "Apelido";
            apelidoDataGridViewTextBoxColumn.HeaderText = "Apelido";
            apelidoDataGridViewTextBoxColumn.MinimumWidth = 6;
            apelidoDataGridViewTextBoxColumn.Name = "apelidoDataGridViewTextBoxColumn";
            apelidoDataGridViewTextBoxColumn.Width = 125;
            // 
            // emailDataGridViewTextBoxColumn
            // 
            emailDataGridViewTextBoxColumn.DataPropertyName = "Email";
            emailDataGridViewTextBoxColumn.HeaderText = "E-mail";
            emailDataGridViewTextBoxColumn.MinimumWidth = 6;
            emailDataGridViewTextBoxColumn.Name = "emailDataGridViewTextBoxColumn";
            emailDataGridViewTextBoxColumn.Width = 125;
            // 
            // eloDataGridViewTextBoxColumn
            // 
            eloDataGridViewTextBoxColumn.DataPropertyName = "Elo";
            eloDataGridViewTextBoxColumn.HeaderText = "Elo";
            eloDataGridViewTextBoxColumn.MinimumWidth = 6;
            eloDataGridViewTextBoxColumn.Name = "eloDataGridViewTextBoxColumn";
            eloDataGridViewTextBoxColumn.Width = 125;
            // 
            // dataNascimentoDataGridViewTextBoxColumn
            // 
            dataNascimentoDataGridViewTextBoxColumn.DataPropertyName = "DataNascimento";
            dataNascimentoDataGridViewTextBoxColumn.HeaderText = "Data de Nascimento";
            dataNascimentoDataGridViewTextBoxColumn.MinimumWidth = 6;
            dataNascimentoDataGridViewTextBoxColumn.Name = "dataNascimentoDataGridViewTextBoxColumn";
            dataNascimentoDataGridViewTextBoxColumn.ReadOnly = true;
            dataNascimentoDataGridViewTextBoxColumn.Width = 180;
            // 
            // listaJogadorBindingSource
            // 
            listaJogadorBindingSource.DataSource = typeof(JogadorModelo);
            // 
            // BTN_Novo
            // 
            BTN_Novo.Location = new Point(727, 494);
            BTN_Novo.Margin = new Padding(3, 4, 3, 4);
            BTN_Novo.Name = "BTN_Novo";
            BTN_Novo.Size = new Size(86, 31);
            BTN_Novo.TabIndex = 1;
            BTN_Novo.Text = "Novo";
            BTN_Novo.UseVisualStyleBackColor = true;
            BTN_Novo.Click += button1_Click;
            // 
            // BTN_Atualizar
            // 
            BTN_Atualizar.Location = new Point(819, 494);
            BTN_Atualizar.Margin = new Padding(3, 4, 3, 4);
            BTN_Atualizar.Name = "BTN_Atualizar";
            BTN_Atualizar.Size = new Size(86, 31);
            BTN_Atualizar.TabIndex = 2;
            BTN_Atualizar.Text = "Atualizar";
            BTN_Atualizar.UseVisualStyleBackColor = true;
            BTN_Atualizar.Click += BTN_Update_Click;
            // 
            // BTN_Deletar
            // 
            BTN_Deletar.Location = new Point(911, 494);
            BTN_Deletar.Margin = new Padding(3, 4, 3, 4);
            BTN_Deletar.Name = "BTN_Deletar";
            BTN_Deletar.Size = new Size(86, 31);
            BTN_Deletar.TabIndex = 3;
            BTN_Deletar.Text = "Deletar";
            BTN_Deletar.UseVisualStyleBackColor = true;
            // 
            // FML_Listagem
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1013, 536);
            Controls.Add(BTN_Deletar);
            Controls.Add(BTN_Atualizar);
            Controls.Add(BTN_Novo);
            Controls.Add(GRD_GridList);
            Margin = new Padding(3, 4, 3, 4);
            Name = "FML_Listagem";
            Text = "Jogador";
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