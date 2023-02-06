using DataAccess;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.TypeRepository
{
    public  class CustomFieldValueRepository : GenericRepository<CustomFieldValue>, Domain.Interfaces.ICustomFieldValueRepository
    {
        public CustomFieldValueRepository(ApiTestContext context) : base(context)
        {
        }
    }
}
