using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Dto.Autor;
using WebApplication1.MODELS;
using WebApplication1.Services.Autor;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutorController : ControllerBase
    {

        private readonly AutorInterface _autorService;
        public AutorController(AutorInterface autorService)
        {
            _autorService = autorService;
        }

        [HttpGet("ListarAutores")]
        public async Task<ActionResult<ResponseModel<List<AutorModel>>>> ListarAutores()
        {
            var autores = await _autorService.ListarAutores();
            return Ok(autores);
        }

        [HttpGet("BuscarAutorPorId/{idAutor}")]

        public async Task<ActionResult<ResponseModel<AutorModel>>> BuscarAutorPorId(int idAutor)
        {
            var autor = await _autorService.BuscarAutorPorId(idAutor);
            return Ok(autor);

        }

        [HttpGet("BuscarAutorPorIdLivro/{idlivro}")]

        public async Task<ActionResult<ResponseModel<AutorModel>>> BuscarAutorPorIdLivro(int idlivro)
        {
            var autor = await _autorService.BuscarAutorPorIdLivro(idlivro);
            return Ok(autor);

        }

        [HttpPost("CriarAutor")]
        public async Task<ActionResult<ResponseModel<List<AutorModel>>>> CriarAutor(AutorCriacaoDto autorCriacaoDto)
        {
            var autores = await _autorService.CriarAutor(autorCriacaoDto);
            return Ok(autores);

        }
        [HttpPut("EditarAutor")]
        public async Task<ActionResult<ResponseModel<AutorModel>>> EditarAutor(AutoredicaoDto autorEdicaoDto)
        {
            var autores = await _autorService.EditarAutor(autorEdicaoDto);
            return Ok(autores);
        }


        [HttpDelete("ExcluirAutor")]
        public async Task<ActionResult<ResponseModel<List<AutorModel>>>> ExcluirAutor(int idAutor)
        {
            var autores = await _autorService.ExcluirAutor(idAutor);
            return Ok(autores);
        }
    }

}
