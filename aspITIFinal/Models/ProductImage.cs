using System;
using System.Collections.Generic;

namespace aspITIFinal.Models
{
    public partial class ProductImage
    {
        public int Id { get; set; }
        public string? Image { get; set; }
        public int? IdProduct { get; set; }

        public virtual Product? IdProductNavigation { get; set; }
    }
}
