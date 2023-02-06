using DataAccess;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.TypeRepository
{
    public class ProductCustomFieldRepository : GenericRepository<ProductCustomField>, Domain.Interfaces.IProductCustomFieldRepository
    {
        public ProductCustomFieldRepository(ApiTestContext context) : base(context)
        {
        }
    }
}
