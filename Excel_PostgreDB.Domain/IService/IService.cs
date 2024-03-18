using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excel_PostgreDB.Domain.IService
{
    public  interface IService
    {
        public Task<object> ImportExcelData();
    }
}
