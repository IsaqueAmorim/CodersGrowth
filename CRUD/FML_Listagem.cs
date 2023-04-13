﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRUD
{
    public partial class FML_Listagem : Form
    {
        public static List<JogadorModelo> Jogadores = new();

        private void PopularLista()
        {
            Jogadores.Add(new JogadorModelo("Isaque", "Amorim", "Kayfen", "teste@teste", Elo.GM, DateTime.Today));
            Jogadores.Add(new JogadorModelo("Isaque", "Amorim", "Kayfen", "teste@teste", Elo.Desafiante, DateTime.Today));
            Jogadores.Add(new JogadorModelo("Isaque", "Amorim", "Kayfen", "teste@teste", Elo.Desafiante, DateTime.Today));
            Jogadores.Add(new JogadorModelo("Isaque", "Amorim", "Kayfen", "teste@teste", Elo.Desafiante, DateTime.Today));
        }

        public FML_Listagem()
        {
            InitializeComponent();
            PopularLista();
            FML_Listagem_Load();
        }
      

        private void button1_Click(object sender, EventArgs e)
        {
            var F_Cadastro = new FML_Cadastro();
            F_Cadastro.Show();
            Close();
            

        }


        private void BTN_Update_Click(object sender, EventArgs e)
        {

        }

        private void FML_Listagem_Load()
        {

            GRD_GridList.DataSource = Jogadores;

        }

        private void FML_Listagem_Load(object sender, EventArgs e)
        {

        }

 
    }
}