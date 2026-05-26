 using WebApplication1.MODELS;

namespace WebApplication1.Services.Autor
{
    public interface AutorInterface
    {
        Task<ResponseModel<List<AutorModel>>> ListarAutores();
        Task<ResponseModel<AutorModel>> BuscarAutorPorId(int idAutor);
        Task<ResponseModel<AutorModel>> BuscarAutorPorIdLivro(int idAutor);
    
    }
}
