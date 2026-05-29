using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using WebApplication1.DATA;
using WebApplication1.Dto.Autor;
using WebApplication1.MODELS;

namespace WebApplication1.Services.Autor
{
    public class IAutorService : AutorInterface
    {
        private readonly AppDbcontext _context;
        public IAutorService(AppDbcontext context)
        {
            _context = context;
        }
        public async Task<ResponseModel<AutorModel>> BuscarAutorPorId(int idAutor)
        {
            ResponseModel<AutorModel> resposta = new ResponseModel<AutorModel>();
            try
            {
                var autor = await _context.Autores.FirstOrDefaultAsync(autorBanco => autorBanco.Id == idAutor);

                if (autor == null) 
                {
                    resposta.Mensagem = "Nenhum registro Localizado!";
                    resposta.Status = false;
                    return resposta; 
                }

                resposta.Dados = autor;
                resposta.Mensagem = "autor localizado";
                resposta.Status = true;
                return resposta;
               
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
            
        }

        public async Task<ResponseModel<AutorModel>> BuscarAutorPorIdLivro(int idLivro)
        {
            ResponseModel<AutorModel> resposta = new ResponseModel<AutorModel>();
            try
            {

                var livro = await _context.Livros.
                    Include(a => a.Autor)
                    .FirstOrDefaultAsync(livroBanco => livroBanco.Id == idLivro);

                if (livro == null)
                {
                    resposta.Mensagem = "Nenhum registro Localizado!";
                    return resposta;

                }

                resposta.Dados = livro.Autor;
                resposta.Mensagem = "autor localizado";
                return resposta;
            }
            catch (Exception ex)
            {
                {
                    resposta.Mensagem = ex.Message;
                    resposta.Status = false;
                    return resposta;
                }
            }
        }

        public async Task<ResponseModel<List<AutorModel>>> CriarAutor(AutorCriacaoDto autorCriacaoDto)
        {
            ResponseModel<List<AutorModel>> resposta = new ResponseModel<List<AutorModel>>();
            try
            {
                var autor = new AutorModel
                {
                    Nome = autorCriacaoDto.Nome,
                    Sobrenome = autorCriacaoDto.Sobrenome
                };

                _context.Add(autor);
                await _context.SaveChangesAsync();

                resposta.Dados = await _context.Autores.ToListAsync();
                resposta.Mensagem = "Autor criado com sucesso!";
                resposta.Status = true;
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<AutorModel>>> ListarAutores()
        {
            ResponseModel<List<AutorModel>> resposta = new ResponseModel<List<AutorModel>>();
            try
            {

                var autores = _context.Autores.ToListAsync();

                resposta.Dados = await autores;
                resposta.Mensagem = "Autores listados com sucesso!";
                return resposta;

            }
            catch (Exception ex)
            {
                {
                    resposta.Mensagem = ex.Message;
                    resposta.Status = false;
                    return resposta;
                }
            }
        }
    }
}



