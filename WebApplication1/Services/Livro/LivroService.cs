using Microsoft.EntityFrameworkCore;
using WebApplication1.DATA;
using WebApplication1.Dto.Autor;
using WebApplication1.Dto.Livro;
using WebApplication1.MODELS;

namespace WebApplication1.Services.Livro
{
    public class LivroService : ILivroInterface
    {
        private readonly AppDbcontext _context;

        public LivroService (AppDbcontext context)
        {
            _context = context;
        }
        public async Task<ResponseModel<LivrosModel>> BuscarLivroPorId(int idLivro) 
        {
            ResponseModel<LivrosModel> resposta = new ResponseModel<LivrosModel>();
            try
            {
                var livro = await _context.Livros
                    .FirstOrDefaultAsync(livroBanco => livroBanco.Id == idLivro);

                if (livro == null)
                {
                    resposta.Mensagem = "Nenhum registro Localizado!";
                    resposta.Status = false;
                    return resposta;
                }

                resposta.Dados = livro;
                resposta.Mensagem = "livro localizado";
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

        public async Task<ResponseModel<List<LivrosModel>>> BuscarLivroPorIdAutor(int idAutor)
        {
            ResponseModel<List<LivrosModel>> resposta = new ResponseModel<List<LivrosModel>>();
            try
            {

                var livro = await _context.Livros
                    .Include(a => a.Autor)
                    .Where(livroBanco => livroBanco.Autor.Id == idAutor)
                    .ToListAsync();

                if (livro == null)
                {
                    resposta.Mensagem = "Nenhum registro Localizado!";
                    return resposta;

                }

                resposta.Dados = livro;
                resposta.Mensagem = "Livro localizados";
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

        public async Task<ResponseModel<List<LivrosModel>>> CriarLivro(LivroCriacaoDto livroCriacaoDto)
        {
            ResponseModel<List<LivrosModel>> resposta = new ResponseModel<List<LivrosModel>>();
            try
            {
                var autor = await _context.Autores.FirstOrDefaultAsync(autorBanco => autorBanco.Id == livroCriacaoDto.Autor.Id);

                if (autor == null)
                {
                    resposta.Mensagem = "Livros não encontrado!";
                    return resposta;
                }
                var livro = new LivrosModel
                {
                    Titulo = livroCriacaoDto.Titulo,
                    Autor = autor
                };
                _context.Add(livro);
                await _context.SaveChangesAsync();

                resposta.Dados = await _context.Livros.Include(a => a.Autor).ToListAsync();

                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<LivrosModel>>> EditarLivro(LivroEdicaoDto livroEdicaoDto)
        {
            ResponseModel<List<LivrosModel>> resposta = new ResponseModel<List<LivrosModel>>();

            try
            {

                var livro = await _context.Livros.Include(a => a.Autor)
                    .FirstOrDefaultAsync(livroBanco => livroBanco.Id == livroEdicaoDto.Id);

                var autor = await _context.Autores.FirstOrDefaultAsync(autorBanco => autorBanco.Id == livroEdicaoDto.Autor.Id);



                if (autor == null)
                {
                    resposta.Mensagem = "Autor não encontrado!";
                    return resposta;
                }


                if (livro == null)
                {
                    resposta.Mensagem = "Livro não encontrado!";
                    return resposta;
                }

                livro.Titulo = livroEdicaoDto.Titulo;
                livro.Autor = autor;

                _context.Update(livro);
                await _context.SaveChangesAsync();

                resposta.Dados = await _context.Livros.Include(a => a.Autor).ToListAsync();

                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
            }
            return resposta;
        }

        public async Task<ResponseModel<List<LivrosModel>>> ExcluirLivro(int idLivro)
        {
            ResponseModel<List<LivrosModel>> resposta = new ResponseModel<List<LivrosModel>>();

            try
            {
                var livro = _context.Livros.FirstOrDefault(livroBanco => livroBanco.Id == idLivro);

                if (livro == null)
                {
                    resposta.Mensagem = "Nenhum registro Localizado!";
                    return resposta;
                }

                _context.Remove(livro);
                await _context.SaveChangesAsync();

                resposta.Dados = await _context.Livros.ToListAsync();
                resposta.Mensagem = "Livro excluido com sucesso!";
                return resposta;

            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
            }
            return resposta;
        }

        public async Task<ResponseModel<List<LivrosModel>>> ListarLivros()
        {
            ResponseModel<List<LivrosModel>> resposta = new ResponseModel<List<LivrosModel>>();
            try
            {

                var livros = await _context.Livros.ToListAsync();

                resposta.Dados = livros;
                resposta.Mensagem = "Livros listados com sucesso!";
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
