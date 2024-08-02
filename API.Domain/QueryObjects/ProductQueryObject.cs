namespace API.Domain.QueryObjects
{
    public class ProductQueryObject
    {
        public Guid? CategoryId { get; set; } = null;
        public Guid? SubCategoryId { get; set; } = null;
        public decimal? MinPrice { get; set; } = null;
        public decimal? MaxPrice { get; set; } = null;
        public bool HasDiscount { get; set; } = false;
        public string? Brand { get; set; } = null;
        public string? SortBy { get; set; } = null;
        public bool IsDecsending { get; set; } = false;
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 20;
    }
}
