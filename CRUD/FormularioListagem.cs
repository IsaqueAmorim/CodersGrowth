using CRUD.Repositorios;
using CRUD.Servicos;

namespace CRUD
{
    public partial class FormularioListagem : Form
    {

        private Validacao validacao;
        private RepositorioJogadoresBD _repositorio = new();

        public FormularioListagem()
        {
            InitializeComponent();
            validacao = new Validacao(_repositorio.ObterTodosJogadores());
            CarregarPagina();


        }

        private void AoClicarNovo(object sender, EventArgs e)
        {
            var formularioCadastro = new FormularioCadastro();

            if (formularioCadastro.ShowDialog() == DialogResult.OK)
            {
                var jogadorParaAdicionarNaLista = FormularioCadastro.ObterJogadorCriado();

                _repositorio.CriarJogador(jogadorParaAdicionarNaLista);

                CarregarPagina();
            }
        }

        private void CarregarPagina()
        {
            GRD_GridList.DataSource = _repositorio.ObterTodosJogadores().ToList();
            GRD_GridList.ClearSelection();
        }

        private void AoClicarAtualizar(object sender, EventArgs e)
        {
            var rows = GRD_GridList.SelectedRows.Count;
            try
            {
                Validacao.ValidaQuantidadeDeLinhasSelecionadas(rows);
                var id = Int32.Parse(GRD_GridList.SelectedRows[0].Cells[0].Value.ToString()
                    ?? throw new Exception("Linha não Encontrada"));

                var jogadorAtual = _repositorio.ObterJogadorPorId(id);
                var formularioCadastro = new FormularioCadastro(jogadorAtual);


                if (formularioCadastro.ShowDialog() == DialogResult.OK)
                {
                    var jogadorParaAdicinarNaLista = FormularioCadastro.ObterJogadorCriado();
                    _repositorio.AtualizarJogador(jogadorParaAdicinarNaLista);
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
                Validacao.ValidaQuantidadeDeLinhasSelecionadas(rows);
                var id = Int32.Parse(GRD_GridList.SelectedRows[0].Cells[0].Value.ToString() ?? throw new Exception("Linha não Encontrada"));


                var dialogResult = MessageBox.Show("Tem certeza que deseja excluir permanentemente este item ?", "", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    _repositorio.DeletarJogador(id);
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
