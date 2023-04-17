using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRUD
{
    public partial class FML_Listagem : Form
    {
        public List<JogadorModelo> Jogadores = new();



        public FML_Listagem()
        {
            InitializeComponent();
            PopulandoLista();
            FML_Listagem_CarregarPagina();
        }
        private void PopulandoLista()
        {
            Jogadores.Add(new JogadorModelo("Isaque", "Amorim", "Kayfen", "isaque.amorim@invetsoftware", Elo.Desafiante, new DateTime(2003, 08, 13)));
            JogadorModelo.Count++;
            Jogadores.Add(new JogadorModelo("Isaque", "Amorim", "Kayfen", "isaque.amorim@invetsoftware", Elo.Desafiante, new DateTime(2003, 08, 13)));
            JogadorModelo.Count++;
            Jogadores.Add(new JogadorModelo("Isaque", "Amorim", "Kayfen", "isaque.amorim@invetsoftware", Elo.Desafiante, new DateTime(2003, 08, 13)));
            JogadorModelo.Count++;
        }




        private void AoClicarNovo(object sender, EventArgs e)
        {
            var F_Cadastro = new FML_Cadastro(Jogadores);


            if (F_Cadastro.ShowDialog() == DialogResult.OK)
            {
                FML_Listagem_CarregarPagina();
            }



        }



        private void FML_Listagem_CarregarPagina()
        {

            GRD_GridList.DataSource = Jogadores.ToList();

        }

        private void BTN_Atualizar_Click(object sender, EventArgs e)
        {
            var rows = GRD_GridList.SelectedRows.Count;
            try
            {
                Servicos.ValidaQuantidadeDeLinhasSelecionadas(rows);
                var id = Int32.Parse(GRD_GridList.SelectedRows[0].Cells[0].Value.ToString() ?? throw new Exception("Linha não Encontrada"));
                
                var jogador = Jogadores.Find(x => x.Id == id);

                FML_Cadastro formulario = new FML_Cadastro(jogador);
                formulario.ShowDialog();
                
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
        }
    }
}
