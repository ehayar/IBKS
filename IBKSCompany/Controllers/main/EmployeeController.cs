using IBKSCompany.DATA.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Data;
using System.Diagnostics;

namespace IBKSHead.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly ILogger<EmployeeController> _logger;
        private readonly IConfiguration _configuration;

        public EmployeeController(ILogger<EmployeeController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;

        }


        [Route("Employee")]

        public IActionResult Index()
        {
            DataSet ds = new DataSet();
            string constr = @"Data Source=LAPTOP-BND4D3PS;Initial Catalog=IBKSCompanyDB;Integrated Security=True;Pooling=False; Encrypt=False";
            using (SqlConnection con = new SqlConnection(constr))
            {
                string query = @"
                            select EmployeeID as id, EmployeeName,EmployeeDOB,EmployeeSex,SuperId, BranchId from
                            dbo.Employee
                            ";
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.Connection = con;
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        sda.Fill(ds);
                    }
                }
            }

            return View(ds);
        }

      

    }
}