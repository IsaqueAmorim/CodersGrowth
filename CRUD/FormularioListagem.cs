namespace CRUD
{
    public partial class FormularioListagem : Form
    {
        public List<JogadorModelo> Jogadores = ListaSingleton.PegarInstancia();


        private Servicos servicos;

        public FormularioListagem()
        {
            InitializeComponent();
            servicos = new Servicos(Jogadores);
            PopulandoLista();
            CarregarPagina();
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
            var FormularioCadastro = new FormularioCadastro(Jogadores);

            if (FormularioCadastro.ShowDialog() == DialogResult.OK)
            {
                var JogadorParaAdicionarNaLista = FormularioCadastro.PegarJogadorCriado();
                JogadorParaAdicionarNaLista.Id = ListaSingleton.ObterProximoId();
                Jogadores.Add(JogadorParaAdicionarNaLista);

                CarregarPagina();
            }
        }

        private void CarregarPagina()
        {
            GRD_GridList.DataSource = Jogadores.ToList();
        }

        private void AoClicarAtualizar(object sender, EventArgs e)
        {
            var rows = GRD_GridList.SelectedRows.Count;
            try
            {
                Servicos.ValidaQuantidadeDeLinhasSelecionadas(rows); 

                var id = Int32.Parse(GRD_GridList.SelectedRows[0].Cells[0].Value.ToString() 
                    ?? throw new Exception("Linha não Encontrada"));

                var jogador = Jogadores.Find(x => x.Id == id);


                var atualiza = new FormularioCadastro(Jogadores, jogador);
                if (atualiza.ShowDialog() == DialogResult.OK)
                {
                    CarregarPagina();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }
        private void AoClicarDeletar(object sender, EventArgs e)
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
                    CarregarPagina();
                }
                else if (dialogResult == DialogResult.No)
                {
                    CarregarPagina();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
}
