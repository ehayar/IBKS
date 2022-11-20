using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IBKSCompany.DATA.Models
{
    public class Employee
    {
        public int EmployeeID { get; set; }
        public string EmployeeName { get; set; }
        public DateTime EmployeeDOB { get; set; }
        public char EmployeeSex { get; set; }
        public int? SuperId { get; set; }
        public int BranchId { get; set; }
        //Was trying to add relation as foreign key
        //   public Branch branch { get; set; }

        //  public List<Employee> employees { get; set; }
        //  public Employee employee { get; set; }
    }
}
