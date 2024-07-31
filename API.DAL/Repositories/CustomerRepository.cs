using API.DAL.Data;
using API.DAL.Repositories.IRepository;
using API.Domain.Models;

namespace API.DAL.Repositories
{
    public class CustomerRepository(ApplicationDbContext db) : BaseRepository<Customer>(db), ICustomerRepository
    {
        private readonly ApplicationDbContext _db = db;

        //TODO: Update
    }
}
