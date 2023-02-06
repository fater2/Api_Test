using System;
using System.Collections.Generic;

#nullable disable

namespace Domain.Models
{
    public partial class CustomField
    {
        public CustomField()
        {
           
            ProductCustomFields = new HashSet<ProductCustomField>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
       
        public virtual ICollection<ProductCustomField> ProductCustomFields { get; set; }
    }
}
