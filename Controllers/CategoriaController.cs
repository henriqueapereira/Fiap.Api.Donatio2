using Fiap.Api.Donation2.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Fiap.Api.Donation2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {

        [HttpGet]
        public List<CategoriaModel> Get() 
        { 
            return new List<CategoriaModel>() 
            { 
                new CategoriaModel()
                {
                    CategoriaId = 1,
                    Nome = "Celular"
                },
                new CategoriaModel()
                {
                    CategoriaId = 2,
                    Nome = "Televisor"
                }
            };
        }

        [HttpGet("{id:int}")]
        public CategoriaModel Get([FromRoute]int id)
        {
            return new CategoriaModel()
            {
                CategoriaId = 1,
                Nome = "Celular"
            };
        }

        [HttpDelete("{id:int}")]
        public string Delete([FromRoute] int id)
        {
            return "Categoria removida com sucesso";
        }

        [HttpPost]
        public int Post([FromBody]CategoriaModel categoriaModel)
        {
            return 123123;
        }

        [HttpPut("{id:int}")]
                        //chave que está alterando, objeto que está alterando
        public bool Put([FromRoute] int id, [FromBody] CategoriaModel categoriaModel)
        {
            if ( id == categoriaModel.CategoriaId)
            {
                return true;
            } else
            {
                return false;
            }
        }
    }
}
