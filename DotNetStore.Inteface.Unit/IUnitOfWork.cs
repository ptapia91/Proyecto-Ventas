using DotNetStore.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetStore.Inteface.Unit
{
    public interface IUnitOfWork
    {
        //ICustomerRepository Customers { get; }
        //IProductRepository Products { get; }
        //IOrderRepository Orders { get; }
        IUserRepository Users { get; }
    }
}
