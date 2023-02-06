using System;
using System.Collections.Generic;

#nullable disable

namespace Domain.Models
{
    public partial class CustomFieldValue
    {
        public int Id { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
        public int ProductCustomFieldId { get; set; }

        public virtual ProductCustomField ProductCustomField { get; set; }
    }
}
