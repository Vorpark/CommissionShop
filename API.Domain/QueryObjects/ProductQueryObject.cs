namespace API.Domain.QueryObjects
{
    public class ProductQueryObject
    {
        public decimal? MinPrice { get; set; } = null;
        public decimal? MaxPrice { get; set; } = null;
        public bool? HasDiscount { get; set; } = null;
        public int? CityId { get; set; } = null;
        public int? BrandId { get; set; } = null;
        public int? CategoryId { get; set; } = null;
        public int? SubCategoryId { get; set; } = null;
        public string? SortBy { get; set; } = null;
        public bool IsDecsending { get; set; } = false;
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 20;
    }
}
