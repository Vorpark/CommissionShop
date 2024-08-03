namespace API.Domain.Models
{
    public abstract class BaseGuidModel
    {
        public Guid Id { get; set; } = Guid.NewGuid();
    }
}
