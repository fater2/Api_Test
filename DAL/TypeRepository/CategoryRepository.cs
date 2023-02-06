using DataAccess;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.TypeRepository
{
    public class CategoryRepository : GenericRepository<Category>, Domain.Interfaces.ICategoryRepository
    {
        public CategoryRepository(ApiTestContext context) : base(context)
        {
    
    }
        public override void Remove(Category entity)
        {
            entity.IsActive = false;
            base.Edit(entity);
        }
    }
}
