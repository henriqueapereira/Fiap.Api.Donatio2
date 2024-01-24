using Fiap.Api.Donation2.Models;
using Fiap.Api.Donation2.Repository.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
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
        public ActionResult <IList<UsuarioModel>> Get()
        {
            var usuarios = _usuarioRepository.FindAll();

            if(usuarios != null && usuarios.Count > 0)
            {
                return Ok(usuarios);
            } else
            {
                return NoContent();
            }
        }

        //retorna 1 usuario
        [HttpGet("{id:int}")]
        public ActionResult <UsuarioModel> Get(int id)
        {
            var usuario = _usuarioRepository.FindById(id);

            if(usuario != null)
            {
                return Ok(usuario);
            } else
            {
                return NotFound();
            }

            
        }

        //cadastra novos usuarios
        [HttpPost]
        public ActionResult<UsuarioModel> Post([FromBody] UsuarioModel usuarioModel)
        {
            if ( ! ModelState.IsValid )
            {
                return BadRequest();
            }

            _usuarioRepository.Insert(usuarioModel);

            var url = Request.GetEncodedUrl().EndsWith("/") ?
                Request.GetEncodedUrl() : 
                Request.GetEncodedUrl() + "/";

            url = url + usuarioModel.UsuarioId;

            return Created(url + usuarioModel.UsuarioId, usuarioModel);
        }

        [HttpPut("{id:int}")]
        //chave que está alterando, objeto que está alterando
        public ActionResult Put([FromRoute] int id, [FromBody] UsuarioModel usuarioModel)
        {
            if (!ModelState.IsValid )
            {
                return BadRequest();
            }

            if ( id != usuarioModel.UsuarioId)
            {
                return BadRequest();
            } else
            {
                _usuarioRepository.Update(usuarioModel);
                return NoContent();
            }
                

        }

        [HttpPost]
        [Route("Login")]
        public ActionResult<UsuarioModel> Login([FromBody] UsuarioModel usuarioModel)
        {
            var usuario =  _usuarioRepository.FindByEmailAndSenha
                (usuarioModel.EmailUsuario, usuarioModel.Senha);

            if ( usuario != null )
            {
                usuario.Senha = string.Empty;
                return Ok(usuario);
            } else
            {
                return NotFound();
            }
        }

        [HttpDelete("{id:int}")]
        public ActionResult Delete([FromRoute] int id)
        {
            if ( id == 0)
            {
                return BadRequest();
            }
            var usuario = _usuarioRepository.FindById(id);

            if (usuario == null)
            {
                return NotFound();
            }
        
                _usuarioRepository.Delete(id);
                return NoContent();
        
        }
    }
}
