using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excel_PostgreDB.Domain.IRepository
{
    public  interface IUnitOfWork:IDisposable
    {
        IRepository Repository { get; }
        int Complete();
    }
}
