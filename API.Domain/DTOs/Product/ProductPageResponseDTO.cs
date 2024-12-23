﻿namespace API.Domain.DTOs.Product
{
    public class ProductPageResponseDTO : BaseModelResponseDTO
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public bool HasDiscount { get; set; }
        public decimal DiscountPrice { get; set; }
        public int DiscountPercent { get; set; }
        public int CityId { get; set; }
        public string ImageUrl { get; set; }
    }
}
