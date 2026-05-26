using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
    }
}
