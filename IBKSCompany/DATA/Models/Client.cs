using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IBKSCompany.DATA.Models
{
    public class Client
    {
        public int ClientID { get; set; }
        public string ClientName { get; set; }
        public int BranchId { get; set; }
    //Was trying to add relation as foreign key
     //   public Branch branch { get; set; }
    }
}
