using System;
using System.Collections.Generic;

namespace aspITIFinal.Models
{
    public partial class Product
    {
        public Product()
        {
            ProductImages = new HashSet<ProductImage>();
        }

        public int Id { get; set; }
        public string? Image { get; set; }
        public decimal? Price { get; set; }
        public string? Brand { get; set; }
        public string? Type { get; set; }
        public string? ModelName { get; set; }
        public string? ProcessorType { get; set; }
        public string? ProcessorCore { get; set; }
        public string? ScreenSize { get; set; }
        public string? HardDiskCapacity { get; set; }
        public string? RamCapacity { get; set; }
        public string? GraphicsCardBrand { get; set; }
        public string? GraphicsCardCapacity { get; set; }
        public string? OperatingSystem { get; set; }
        public string? Color { get; set; }
        public int? IdCat { get; set; }

        public virtual Category? IdCatNavigation { get; set; }
        public virtual ICollection<ProductImage> ProductImages { get; set; }
    }
}
