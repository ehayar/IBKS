using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IBKSCompany.DATA.Models
{
    public class Branch
    {
        public int BranchID { get; set; }
        public String BranchName { get; set; }

        //Was trying to add relation as foreign key
        //  public List<Client> Clients { get; set;}

        //   public List<Employee> employees { get; set; }
    }

}
