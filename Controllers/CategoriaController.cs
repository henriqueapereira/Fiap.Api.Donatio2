using Fiap.Api.Donation2.Models;
using Fiap.Api.Donation2.Repository.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Fiap.Api.Donation2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {

        private readonly ICategoriaRepository _categoriaRepository;

        public CategoriaController(ICategoriaRepository categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
        }   

        //retorna tds categorias cadastradas
        [HttpGet]
        public List<CategoriaModel> Get() 
        {
            return (List<CategoriaModel>)_categoriaRepository.FindAll();
        }

        //retorna 1 categoria
        [HttpGet("{id:int}")]
        public CategoriaModel Get([FromRoute]int id)
        {
            return _categoriaRepository.FindById(id);
        }

        [HttpDelete("{id:int}")]
        public string Delete([FromRoute] int id)
        {
            _categoriaRepository.Delete(id);

            return "Categoria removida com sucesso";
        }

        //cadastra novas categorias
        [HttpPost]
        public int Post([FromBody]CategoriaModel categoriaModel)
        {
            _categoriaRepository.Insert(categoriaModel);
            return categoriaModel.CategoriaId;
        }

        [HttpPut("{id:int}")]
                        //chave que está alterando, objeto que está alterando
        public bool Put([FromRoute] int id, [FromBody] CategoriaModel categoriaModel)
        {
            if ( id == categoriaModel.CategoriaId)
            {
                _categoriaRepository.Update(categoriaModel);

                return true;
            } else
            {
                return false;
            }
        }
    }
}
