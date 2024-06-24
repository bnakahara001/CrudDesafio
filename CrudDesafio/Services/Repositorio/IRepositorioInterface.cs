using CrudDesafio.Models;

namespace CrudDesafio.Services.Repositorio
{
    public interface IRepositorioInterface
    {
        Task<ResponseModel<List<RepositorioModel>>> ListarRepositorio();
        Task<ResponseModel<List<RepositorioModel>>> ListarRepositorioFavoritos();
        Task<ResponseModel<List<RepositorioModel>>> BuscarNome(string nome);
        Task<ResponseModel<List<RepositorioModel>>> CriarRepositorio(RepositorioModel repositorioModel);
        Task<ResponseModel<List<RepositorioModel>>> FavoritarRepositorio(RepositorioModel repositorioModel);
        Task<ResponseModel<List<RepositorioModel>>> ExcluirRepositorio(int id);
    }
}
