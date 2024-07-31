using API.DAL.Repositories.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/customer")]
    [ApiController]
    public class CustomerController(ICustomerRepository repository) : ControllerBase
    {
        private readonly ICustomerRepository _repository = repository;
    }
}
