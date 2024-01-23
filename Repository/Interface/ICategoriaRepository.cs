using Fiap.Api.Donation2.Models;

namespace Fiap.Api.Donation2.Repository.Interface
{
    public interface ICategoriaRepository
    {
        public IList<CategoriaModel> FindAll();

        public CategoriaModel FindById(int id);

        public int Insert(CategoriaModel categoriaModel);

        public void Update(CategoriaModel categoriaModel);

        public void Delete(int id);
    }
}
