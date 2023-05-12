using CRUD.Modelos;
using CRUD.Repositorios;
using CRUD.Servicos;
using Microsoft.AspNetCore.Mvc;

namespace CRUD.API.Controllers
{
    [ApiController]
    [Route("/")]
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
        public IActionResult ParaHome()
        {
            var arquivo = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "webapp", "index.html");
            return PhysicalFile(arquivo, "text/html");
        }
        [HttpGet("v1/jogadores")]
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

        [HttpGet("v1/jogadores/{id}")]
        public IActionResult ObterJogadorPorId(long id)
        {
            JogadorModelo jogador;
            try
            {
                jogador =  _repositorio.ObterJogadorPorId(id);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return NotFound();
            }

            return Ok(jogador);
        }
        [HttpPost("v1/jogadores")]

        public IActionResult CriarJogador([FromBody] JogadorModelo jogador)
        {
            
            long id;
            try
            {
                
                _validacao.ValidaCriacaoJogadorModelo(jogador);
                id = _repositorio.CriarJogador(jogador);
                jogador.Id = id;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest();
            }
            return Created($"/v1/jogadores/{id}", jogador);
        }

        [HttpPut("v1/jogadores/{id}")]
        public IActionResult AtualizarJogador([FromBody] JogadorModelo jogador, long id)
        {
            try
            {
               
                _validacao.ValidaCriacaoJogadorModelo(jogador);
                jogador.Id = id;
                 _repositorio.AtualizarJogador(jogador);

            }
            catch (Exception ex)
            {
                
                Console.WriteLine(ex);
                return BadRequest();
            }

            return Ok();
        }

        [HttpDelete("v1/jogadores/{id}")]
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
