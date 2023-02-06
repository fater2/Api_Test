using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ViewModels
{
    public class ProductCreateVw
    {
        public string EnName { get; set; }
        public string ArName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal Price { get; set; }
        public string CategoryCode { get; set; }
        public ICollection<CreateProductCustomFieldVw> CustomFieldList{get;set;}

    }
}
