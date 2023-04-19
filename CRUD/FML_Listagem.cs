namespace CRUD
{
    public partial class FML_Listagem : Form
    {
        public List<JogadorModelo> Jogadores = new();
        private Servicos servicos;

        public FML_Listagem()
        {
            InitializeComponent();
            servicos = new Servicos(Jogadores);
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

        private void BTN_Atualizar_AoClicar(object sender, EventArgs e)
        {
            var rows = GRD_GridList.SelectedRows.Count;
            try
            {
                Servicos.ValidaQuantidadeDeLinhasSelecionadas(rows);
                var id = Int32.Parse(GRD_GridList.SelectedRows[0].Cells[0].Value.ToString() ?? throw new Exception("Linha não Encontrada"));
                var jogador = Jogadores.Find(x => x.Id == id);


                var atualiza = new FML_Cadastro(Jogadores, jogador);
                if (atualiza.ShowDialog() == DialogResult.OK)
                {
                    FML_Listagem_CarregarPagina();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }
        private void BTN_Deletar_AoClicar(object sender, EventArgs e)
        {
            var rows = GRD_GridList.SelectedRows.Count;
            try
            {
                Servicos.ValidaQuantidadeDeLinhasSelecionadas(rows);
                var id = Int32.Parse(GRD_GridList.SelectedRows[0].Cells[0].Value.ToString() ?? throw new Exception("Linha não Encontrada"));
                var jogador = Jogadores.Find(x => x.Id == id);

                var dialogResult = MessageBox.Show("Tem certeza que deseja excluir permanentemente este item ?", "", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {

                    Jogadores.Remove(jogador);
                    FML_Listagem_CarregarPagina();
                }
                else if (dialogResult == DialogResult.No)


                {
                    FML_Listagem_CarregarPagina();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
}
