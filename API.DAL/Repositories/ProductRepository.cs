using API.DAL.Data;
using API.DAL.Repositories.IRepository;
using API.Domain.Models;

namespace API.DAL.Repositories
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        private readonly ApplicationDbContext _db;
        public ProductRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        //TODO: Update
    }
}
