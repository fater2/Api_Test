using System;
using System.Collections.Generic;

#nullable disable

namespace Domain.Models
{
    public partial class ProductCustomField
    {
        public ProductCustomField()
        {
            CustomFieldValues = new HashSet<CustomFieldValue>();
        }
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int CustomFieldId { get; set; }
        public virtual ICollection<CustomFieldValue> CustomFieldValues { get; set; }

        public virtual CustomField CustomField { get; set; }
        public virtual Product Product { get; set; }
    }
}
