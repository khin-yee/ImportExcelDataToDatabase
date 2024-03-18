using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excel_PostgreDB.Domain.Models
{
    public class SR
    {
        public int Id { get; set; }
        public string SRPcode { get; set; }
        public string SRNameEng { get; set; }
        public string SRNameMMR { get; set; }
    }
}
