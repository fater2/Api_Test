using DAL.TypeRepository;
using Domain.Interfaces;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApiTestContext _context;
        public UnitOfWork(ApiTestContext context)
        {
            _context = context;

            Product = new ProductRepository(context);
            Category = new CategoryRepository(context);
            CustomField = new CustoFieldRepository(context);
            CustomFieldValue= new CustomFieldValueRepository(context);
            ProductCustomField = new ProductCustomFieldRepository(context);

        }
        public ICategoryRepository Category{ get; private set; }
        public ICustomFieldRepository CustomField{ get; private set; }
        public ICustomFieldValueRepository CustomFieldValue{ get; private set; }
        public IProductRepository Product{ get; private set; }
        public IProductCustomFieldRepository ProductCustomField{ get; private set; }
  
        public void Dispose()
        {
            _context.Dispose();
        }
        public int Save()
        {
            return _context.SaveChanges();
        }


    }
}
