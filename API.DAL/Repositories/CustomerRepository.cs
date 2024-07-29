using API.DAL.Data;
using API.DAL.Repositories.IRepository;
using API.Domain.Models;

namespace API.DAL.Repositories
{
    public class CustomerRepository : BaseRepository<Customer>, ICustomerRepository
    {
        private readonly ApplicationDbContext _db;
        public CustomerRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
    }
}
