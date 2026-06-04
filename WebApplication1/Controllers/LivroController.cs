using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Dto.Autor;
using WebApplication1.Dto.Livro;
using WebApplication1.MODELS;
using WebApplication1.Services.Autor;
using WebApplication1.Services.Livro;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LivroController : ControllerBase
    {
        private readonly ILivroInterface _livroInterface;
        public LivroController(ILivroInterface livroInterface)
        {
            _livroInterface = livroInterface;
        }

        [HttpGet("ListarLivros")]
        public async Task<ActionResult<ResponseModel<List<LivrosModel>>>> ListarLivros()
        {
            var livros = await _livroInterface.ListarLivros();
            return Ok(livros);
        }

        [HttpGet("BuscarLivroPorId/{idLivro}")]

        public async Task<ActionResult<ResponseModel<LivrosModel>>> BuscarLivroPorId(int idLivro)
        {
            var livro = await _livroInterface.BuscarLivroPorId(idLivro);
            return Ok(livro);

        }

        [HttpGet("BuscarLivroPorIdAutor/{idAutor}")]

        public async Task<ActionResult<ResponseModel<List<LivrosModel>>>> BuscarLivroPorIdAutor(int idAutor)
        {
            var livros = await _livroInterface.BuscarLivroPorIdAutor(idAutor);
            return Ok(livros);

        }

        [HttpPost("CriarLivro")]
        public async Task<ActionResult<ResponseModel<List<LivrosModel>>>> CriarLivro(LivroCriacaoDto livroCriacaoDto)
        {
            var livros = await _livroInterface.CriarLivro(livroCriacaoDto);
            return Ok(livros);

        }
        [HttpPut("EditarLivro")]
        public async Task<ActionResult<ResponseModel<List<LivrosModel>>>> EditarLivro(LivroEdicaoDto livroEdicaoDto)
        {
            var livros = await _livroInterface.EditarLivro(livroEdicaoDto);
            return Ok(livros);
        }


        [HttpDelete("ExcluirLivro")]
        public async Task<ActionResult<ResponseModel<List<LivrosModel>>>> ExcluirLivro(int idLivro)
        {
            var livros = await _livroInterface.ExcluirLivro(idLivro);
            return Ok(livros);
        }
    }
}
