using Fiap.Api.Donation2.Models;

namespace Fiap.Api.Donation2.Repository.Interface
{
    public interface IUsuarioRepository
    {
        public IList<UsuarioModel> FindAll() //devolve a lista pois pode ter 1 ou varios retornos
        {

        }
        public IList<UsuarioModel> FindByName(string nomeParcial) //devolve a lista pois pode ter 1 ou varios retornos
        {
            

        }

        public UsuarioModel FindById(int id) //pesquisa pelo Id, vai devolver somente 1
        {

        }
        public int Insert(UsuarioModel usuarioModel);

        public void Update(UsuarioModel usuarioModel);

        public void Delete(int id);
    }
}
