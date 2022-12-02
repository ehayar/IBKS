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
    public class ClientController : Controller
    {
        private readonly ILogger<ClientController> _logger;
        private readonly IConfiguration _configuration;

        public ClientController(ILogger<ClientController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;

        }


        [Route("Client")]

        public IActionResult Index()
        {
            DataSet ds = new DataSet();
            string constr = @"Data Source=LAPTOP-BND4D3PS;Initial Catalog=IBKSCompanyDB;Integrated Security=True;Pooling=False; Encrypt=False";
            using (SqlConnection con = new SqlConnection(constr))
            {
                string query = @"
                            select ClientID as id, ClientName, BranchId from
                            dbo.Client
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

        [Route("Client/Create")]

        public ActionResult Create(Client client)
        {
            String client1 = client.ClientName;
            int branchid = client.BranchId;

            return View("Create");
        }

    }
}