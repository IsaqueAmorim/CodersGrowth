using CRUD.Modelos;
using CRUD.Repositorios;
using CRUD.Servicos;
using LinqToDB.Tools;
using Microsoft.AspNetCore.Mvc;

namespace CRUD.API.Controllers
{
    [ApiController]
    [Route("v1/jogadores")]
    public class JogadorController : ControllerBase
    {
        private IRepositorioJogadores _repositorio;
        private Validacao _validacao;

        public JogadorController(IRepositorioJogadores repositorio, Validacao validacao)
        {
            _repositorio = repositorio;
            _validacao = validacao;
        }   

        [HttpGet]
        public IActionResult ObterTodosJogadores()
        {
            List<JogadorModelo> listaJogadores;
            try
            {
                listaJogadores = _repositorio.ObterTodosJogadores();

            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok(listaJogadores);
        }
        [HttpGet("{id}")]
        public IActionResult ObterJogadorPorId(long id)
        {
           var jogador =  _repositorio.ObterJogadorPorId(id);

            return Ok(jogador);
        }
        [HttpPost]
        public IActionResult CriarJogador([FromBody] JogadorModelo jogador)
        {
            var jogadorCriado = new JogadorModelo(jogador);
            _validacao.ValidaCriacaoJogadorModelo(jogador);
            
            var id = _repositorio.CriarJogador(jogadorCriado);
            jogadorCriado.Id = id;

            
            

            return Created($"https://localhost/v1/jogadores/{id}", jogadorCriado);
        }
        [HttpPut]
        public IActionResult AtualizarJogador([FromBody] JogadorModelo jogador)
        {
            _repositorio.AtualizarJogador(jogador);

            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult DeletarJogador(long id)
        {
            try
            {
                _repositorio.DeletarJogador(id);

            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok();
        }
    }
}
