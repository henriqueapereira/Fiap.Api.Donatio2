using Fiap.Api.Donation2.Data;
using Fiap.Api.Donation2.Models;
using Fiap.Api.Donation2.Repository.Interface;

namespace Fiap.Api.Donation2.Repository
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly DataContext _dataContext;
        public CategoriaRepository(DataContext ctx)
        {
            _dataContext = ctx;
        }

        public IList<CategoriaModel> FindAll()
        {
            return _dataContext.Categorias.ToList();
        }

        public CategoriaModel FindById(int id)
        {
            var categoria = _dataContext.Categorias.FirstOrDefault(u => u.CategoriaId == id);

            return categoria;
        }

        public int Insert(CategoriaModel categoriaModel)
        {
            _dataContext.Categorias.Add(categoriaModel);
            _dataContext.SaveChanges();

            return categoriaModel.CategoriaId;
        }

        public void Update(CategoriaModel categoriaModel)
        {
            _dataContext.Categorias.Update(categoriaModel);
            _dataContext.SaveChanges();

        }

        public void Delete(int id)
        {
            var categoriaModel = new CategoriaModel()
            {
                CategoriaId = id
            };

            _dataContext.Categorias.Remove(categoriaModel);
            _dataContext.SaveChanges();
        }
    }
}
