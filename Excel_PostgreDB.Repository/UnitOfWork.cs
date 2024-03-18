using Excel_PostgreDB.Domain.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excel_PostgreDB.Repository
{
    public  class UnitOfWork:IUnitOfWork
    {
        private readonly DatabaseConnect _context;
        public IRepository Repository { get; }

        public UnitOfWork(DatabaseConnect context,IRepository repository)
        {
            _context = context;
        }
        public int Complete()
        {
            return _context.SaveChanges();
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
        }
    }
}
