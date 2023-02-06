using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IProductRepository              Product{ get; }
        ICategoryRepository             Category{ get; }
        ICustomFieldRepository          CustomField{ get; }
        ICustomFieldValueRepository     CustomFieldValue{ get; }
        IProductCustomFieldRepository   ProductCustomField{ get; }

        int Save();

    }
}
