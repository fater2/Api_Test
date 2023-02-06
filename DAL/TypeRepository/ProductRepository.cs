using DataAccess;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.TypeRepository
{
    public  class ProductRepository : GenericRepository<Product>, Domain.Interfaces.IProductRepository
    {
        public ProductRepository(ApiTestContext context) : base(context)
        {
        }
        public override IEnumerable<Product> GetAll()
        {
            
            return base.GetAll().Where(m=>(m.IsActive==true && m.Category.IsActive));
        }
        public override Product GetById(int id)
        {
            var product = base.GetById(id);
            if(product==null)
                return null;
            if (!product.IsActive  ||!product.Category.IsActive)
                return null;
            return product;
        }
        public override void Remove(Product entity)
        {   
            entity.IsActive = false;
            base.Edit(entity);
        }
        public IEnumerable<Product> GetByCategoryId(int categoryId)
        {
            
            return base.GetAll().Where(m=>(m.IsActive==true && m.CategoryId == categoryId&& m.Category.IsActive));
        }


    }
}
