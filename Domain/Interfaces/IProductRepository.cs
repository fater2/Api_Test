using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        public IEnumerable<Product> GetByCategoryId(int categoryId);
    }
}
