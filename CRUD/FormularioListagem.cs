using CRUD.Repositorios;

namespace CRUD
{
    public partial class FormularioListagem : Form
    {
        private RepositorioJogadoresEmMemoria repository = new RepositorioJogadoresEmMemoria();
        

        public FormularioListagem()
        {
            InitializeComponent();
            servicos = new Servicos(repository.ObterTodosJogadores());
            CarregarPagina();
        }
     
        private void AoClicarNovo(object sender, EventArgs e)
        {
            var formularioCadastro = new FormularioCadastro();

            if (formularioCadastro.ShowDialog() == DialogResult.OK)
            {
                var jogadorParaAdicionarNaLista = FormularioCadastro.ObterJogadorCriado();
                jogadorParaAdicionarNaLista.Id = ListaSingleton.ObterProximoId();
                repository.CriarJogador(jogadorParaAdicionarNaLista);

                CarregarPagina();
            }
        }

        private void CarregarPagina()
        {
            GRD_GridList.DataSource = repository.ObterTodosJogadores().ToList();
        }

        private void AoClicarAtualizar(object sender, EventArgs e)
        {
            var rows = GRD_GridList.SelectedRows.Count;
            try
            {
                Servicos.ValidaQuantidadeDeLinhasSelecionadas(rows); 
                var id = Int32.Parse(GRD_GridList.SelectedRows[0].Cells[0].Value.ToString() 
                    ?? throw new Exception("Linha não Encontrada"));

                var jogadorAtual = repository.ObterJogadorPorId(id);
                var jogadorParaAdicinarNaLista = FormularioCadastro.ObterJogadorCriado();
                var formularioCadastro = new FormularioCadastro(jogadorAtual);
                

                if (formularioCadastro.ShowDialog() == DialogResult.OK)
                {
                    repository.AtualizarJogador(jogadorParaAdicinarNaLista, jogadorAtual);
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
                var jogador = repository.ObterJogadorPorId(id);

                var dialogResult = MessageBox.Show("Tem certeza que deseja excluir permanentemente este item ?", "", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    repository.DeletarJogador(jogador);
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
