using Fiap.Api.Donation2.Models;
using Fiap.Api.Donation2.Repository.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Fiap.Api.Donation2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {

        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioController(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        //retorna tds usuarios cadastradas
        [HttpGet]
        public List<UsuarioModel> Get()
        {
            return (List<UsuarioModel>)_usuarioRepository.FindAll();
        }

        //retorna 1 usuario
        [HttpGet("{id:int}")]
        public UsuarioModel Get([FromRoute] int id)
        {
            return _usuarioRepository.FindById(id);
        }

        [HttpDelete("{id:int}")]
        public string Delete([FromRoute] int id)
        {
            _usuarioRepository.Delete(id);

            return "Usuario removido com sucesso";
        }

        //cadastra novos usuarios
        [HttpPost]
        public int Post([FromBody] UsuarioModel usuarioModel)
        {
            _usuarioRepository.Insert(usuarioModel);
            return usuarioModel.UsuarioId;
        }

        [HttpPut("{id:int}")]
        //chave que está alterando, objeto que está alterando
        public bool Put([FromRoute] int id, [FromBody] UsuarioModel usuarioModel)
        {
            if (id == usuarioModel.UsuarioId)
            {
                _usuarioRepository.Update(usuarioModel);

                return true;
            }
            else
            {
                return false;
            }
        }

        [HttpPost]
        [Route("Login")]
        public UsuarioModel Login([FromBody] UsuarioModel usuarioModel)
        {
            return _usuarioRepository.FindByEmailAndSenha
                (usuarioModel.EmailUsuario, usuarioModel.Senha);
        }
    }
}
