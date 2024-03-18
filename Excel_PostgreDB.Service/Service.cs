using Excel_PostgreDB.Domain.IRepository;
using Excel_PostgreDB.Domain.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excel_PostgreDB.Service
{
    public  class Service:IService
    {
        private readonly IUnitOfWork _unitOfWork;
        //private readonly IRepository _respo;
        public Service(IUnitOfWork unitOfWork)
        {
           _unitOfWork = unitOfWork ;
        }
        public async Task<object> ImportExcelData()
        {
            var result = await _unitOfWork.Repository.ImportExcelData();

            return result;
        }
      

    }
}
