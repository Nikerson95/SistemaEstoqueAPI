using WebApplication1.Dto.Autor;
using WebApplication1.MODELS;

namespace WebApplication1.Services.Autor
{
    public interface AutorInterface
    {
        Task<ResponseModel<List<AutorModel>>> ListarAutores();
        Task<ResponseModel<AutorModel>> BuscarAutorPorId(int idAutor);
        Task<ResponseModel<AutorModel>> BuscarAutorPorIdLivro(int idLivro);
        Task<ResponseModel<List<AutorModel>>> EditarAutor(AutoredicaoDto autorEdicaoDto);
        Task<ResponseModel<List<AutorModel>>> ExcluirAutor(int idAutor);
        Task<ResponseModel<List<AutorModel>>> CriarAutor(AutorCriacaoDto autorCriacaoDto);
    }
}
