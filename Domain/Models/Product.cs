using System;
using System.Collections.Generic;

#nullable disable

namespace Domain.Models

{
    public partial class Product
    {
        public Product()
        {
            ProductCustomFields = new HashSet<ProductCustomField>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime StartDate { get; set; }
        public double? Duration { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        public string NameAr { get; set; }
        public string Code { get; set; }
        public bool IsActive { get; set; }
        public virtual Category Category { get; set; }
        public virtual ICollection<ProductCustomField> ProductCustomFields { get; set; }
    }
}
