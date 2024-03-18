using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excel_PostgreDB.Domain.Models
{
    public class Ward
    {
        public int Id { get; set; }
        public string SRPcode { get; set; }

        public string SRNameEng { get; set; }
        public string DistrictPcode { get; set; }
        public string DistrictNameEng { get; set; }
        public string TspPcode { get; set; }
        public string TownshipNameEng { get; set; }
        public string TownPcode { get; set; }
        public string Town { get; set; }
        public string WardPcode { get; set; }
        public string WardNameEng { get; set; }
        public string WardNameMMR { get; set; }
    }
}
