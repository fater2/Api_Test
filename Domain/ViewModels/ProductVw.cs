using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ViewModels
{
    public class ProductVw
    {
        public int id;
        public string EnName { get; set; }
        public string ArName { get; set; }
        public DateTime RegisterDate { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal Price { get; set; }
        public string CategoryCode { get; set; }
        public string CategoryName { get; set; }

    }
}
