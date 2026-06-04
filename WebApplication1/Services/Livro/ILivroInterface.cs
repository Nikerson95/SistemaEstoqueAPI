using WebApplication1.Dto.Livro;
using WebApplication1.MODELS;

namespace WebApplication1.Services.Livro
{
    public interface ILivroInterface 
    {
        Task<ResponseModel<List<LivrosModel>>> ListarLivros();
        Task<ResponseModel<LivrosModel>> BuscarLivroPorId(int idLivro);
        Task<ResponseModel<List<LivrosModel>>> BuscarLivroPorIdAutor(int idAutor);
        Task<ResponseModel<List<LivrosModel>>> EditarLivro(LivroEdicaoDto livroEdicaoDto);
        Task<ResponseModel<List<LivrosModel>>> ExcluirLivro(int idLivro);
        Task<ResponseModel<List<LivrosModel>>> CriarLivro(LivroCriacaoDto livroCriacaoDto);
    }
}
