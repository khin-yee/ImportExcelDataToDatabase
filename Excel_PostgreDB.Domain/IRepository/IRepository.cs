
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excel_PostgreDB.Domain.IRepository
{
    public  interface IRepository
    {
        public  Task<object> ImportExcelData();
        public  Task<object> ImportCSVData();

    }
}
