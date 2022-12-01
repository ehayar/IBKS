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
    public class BranchController : Controller
    {
        private readonly ILogger<BranchController> _logger;
        private readonly IConfiguration _configuration;

        public BranchController(ILogger<BranchController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;

        }

        //    public IActionResult Index()
        //    {
        //        string query = @"
        //                        select BranchID as id, BranchName from
        //                        dbo.Branch
        //                        ";

        //        DataTable table = new DataTable();
        //        string sqlDataSource = _configuration.GetConnectionString("DefaultConnectionString");
        //        SqlDataReader myReader;
        //        using (SqlConnection myCon = new SqlConnection(sqlDataSource))
        //        {
        //            myCon.Open();
        //            using (SqlCommand myCommand = new SqlCommand(query, myCon))
        //            {
        //                myReader = myCommand.ExecuteReader();
        //                table.Load(myReader);
        //                myReader.Close();
        //                myCon.Close();
        //            }
        //        }

        //        return View();
        //    }
        //}

        [Route("Branch")]

        public IActionResult Index()
        {
            DataSet ds = new DataSet();
            string constr = @"Data Source=LAPTOP-BND4D3PS;Initial Catalog=IBKSCompanyDB;Integrated Security=True;Pooling=False; Encrypt=False";
            using (SqlConnection con = new SqlConnection(constr))
            {
                string query = @"
                            select BranchID as id, BranchName from
                            dbo.Branch
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

        [Route("Branch/Create")]

        public ActionResult Create(Branch branch)
        {
            String branch1 = branch.BranchName;

            return View("Create");
        }

        //[HttpPost]
        //public ActionResult Add(Branch branch)
        //{
        //    string constr = @"Data Source=LAPTOP-BND4D3PS;Initial Catalog=IBKSCompanyDB;Integrated Security=True;Pooling=False; Encrypt=False";
        //    using (SqlConnection con = new SqlConnection(constr))
        //    {
        //        string query = @"
        //                   insert into dbo.Branch
        //                   values (@BranchName)
        //                    ";
        //        using (SqlCommand cmd = new SqlCommand(query))
        //        {
        //            cmd.Connection = con;
        //            con.Open();
        //            cmd.Parameters.AddWithValue("@BranchName", branch.BranchName);
        //            cmd.Parameters.AddWithValue("@BranchID", branch.BranchID);
        //            branch.BranchID= Convert.ToInt32(cmd.ExecuteScalar());
        //            con.Close();
        //        }
        //    }

        //    return View(branch);
        //}
    }
}