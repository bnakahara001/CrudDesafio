using CrudDesafio.Data;
using CrudDesafio.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace CrudDesafio.Services.Repositorio
{
    public class RepositorioService : IRepositorioInterface
    {
        private readonly AppDbContext _context;
        public RepositorioService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel<List<RepositorioModel>>> BuscarNome(string nome)
        {
            ResponseModel<List<RepositorioModel>> resposta = new ResponseModel<List<RepositorioModel>>();
            try
            {
                var repo = await _context.Repositorio.Where(c=>c.Nome.Contains(nome)).ToListAsync();

                if (repo == null)
                {
                    resposta.Mensagem = "Nenhum Registro localizado";
                    return resposta;
                }
                else
                {
                    resposta.Dados = repo;
                    resposta.Mensagem = "Sucesso";
                }

                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<RepositorioModel>>> ListarRepositorio()
        {
            ResponseModel<List<RepositorioModel>> resposta = new ResponseModel<List<RepositorioModel>>();
            try
            {
                var repo = await _context.Repositorio.ToListAsync();
                
                resposta.Dados = repo;
                resposta.Mensagem = "Sucesso";

                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<RepositorioModel>>> ListarRepositorioFavoritos()
        {
            ResponseModel<List<RepositorioModel>> resposta = new ResponseModel<List<RepositorioModel>>();
            try
            {
                var repo = await _context.Repositorio.Where(c => c.Favorito).ToListAsync();

                resposta.Dados = repo;
                resposta.Mensagem = "Sucesso";

                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<RepositorioModel>>> CriarRepositorio(RepositorioModel repositorio)
        {
            ResponseModel<List<RepositorioModel>> resposta = new ResponseModel<List<RepositorioModel>>();

            try
            {
                _context.Add(repositorio);
                await _context.SaveChangesAsync();

                resposta.Dados = await _context.Repositorio.ToListAsync();
                resposta.Mensagem = "Criado com Sucesso";
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<RepositorioModel>>> FavoritarRepositorio(RepositorioModel repositorioModel)
        {
            ResponseModel<List<RepositorioModel>> resposta = new ResponseModel<List<RepositorioModel>>();
            try
            {
                var repositorio = await _context.Repositorio.FirstOrDefaultAsync(c => c.Id == repositorioModel.Id);

                if (repositorio == null)
                {
                    resposta.Mensagem = "Nenhum nome localizado";
                    return resposta;
                }

                repositorio.Nome = repositorioModel.Nome;
                repositorio.Descricao = repositorioModel.Descricao;
                repositorio.Linguagem = repositorioModel.Linguagem;
                repositorio.UltimaAtualizacao = repositorioModel.UltimaAtualizacao;
                repositorio.DonoRepositorio = repositorioModel.DonoRepositorio;
                repositorio.Favorito = true;

                _context.Update(repositorio);
                await _context.SaveChangesAsync();

                resposta.Dados = await _context.Repositorio.ToListAsync();
                return resposta;

            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<RepositorioModel>>> ExcluirRepositorio(int id)
        {
            ResponseModel<List<RepositorioModel>> resposta = new ResponseModel<List<RepositorioModel>>();

            try
            {
                var repositorio = await _context.Repositorio.FirstOrDefaultAsync(c => c.Id == id);

                if (repositorio == null)
                {
                    resposta.Mensagem = "Nenhum id localizado";
                    return resposta;
                }

                _context.Remove(repositorio);
                await _context.SaveChangesAsync();

                resposta.Dados = await _context.Repositorio.ToListAsync();
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }
    }
}
