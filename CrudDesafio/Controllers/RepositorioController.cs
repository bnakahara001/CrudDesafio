using CrudDesafio.Models;
using CrudDesafio.Services.Repositorio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CrudDesafio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RepositorioController : ControllerBase
    {
        private readonly IRepositorioInterface _repositorioInterface;
        public RepositorioController(IRepositorioInterface repositorioInterface)
        {
            _repositorioInterface = repositorioInterface;
        }

        [HttpGet("ListarRepositorio")]
        public async Task<ActionResult<ResponseModel<List<RepositorioModel>>>> ListarRepositorio()
        {
            var repositorios = await _repositorioInterface.ListarRepositorio();
            return Ok(repositorios);
        }

        [HttpGet("ListarRepositorioFavoritos")]
        public async Task<ActionResult<ResponseModel<List<RepositorioModel>>>> ListarRepositorioFavoritos()
        {
            var repositorios = await _repositorioInterface.ListarRepositorioFavoritos();
            return Ok(repositorios);
        }

        [HttpGet("BuscarNome/{nome}")]
        public async Task<ActionResult<ResponseModel<List<RepositorioModel>>>> BuscarNome(string nome)
        {
            var repositorios = await _repositorioInterface.BuscarNome(nome);
            return Ok(repositorios);
        }

        [HttpPost("CriarRepositorio")]
        public async Task<ActionResult<ResponseModel<List<RepositorioModel>>>> CriarRepositorio(RepositorioModel repositorio)
        {
            var repositorios = await _repositorioInterface.CriarRepositorio(repositorio);
            return Ok(repositorios);
        }

        [HttpPut("FavoritarRepositorio")]
        public async Task<ActionResult<ResponseModel<List<RepositorioModel>>>> FavoritarRepositorio(RepositorioModel repositorio)
        {
            var repositorios = await _repositorioInterface.FavoritarRepositorio(repositorio);
            return Ok(repositorios);
        }

        [HttpDelete("ExcluirRepositorio")]
        public async Task<ActionResult<ResponseModel<List<RepositorioModel>>>> ExcluirRepositorio(int id)
        {
            var repositorios = await _repositorioInterface.ExcluirRepositorio(id);
            return Ok(repositorios);
        }
    }
}
