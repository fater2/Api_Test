using DataAccess;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.TypeRepository
{
    public class CustoFieldRepository : GenericRepository<CustomField>, Domain.Interfaces.ICustomFieldRepository
    {
        public CustoFieldRepository(ApiTestContext context) : base(context)
        {
        }
    }
}
