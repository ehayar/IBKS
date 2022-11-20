using IBKSCompany.DATA.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;


namespace IBKSCompany.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        //dependency injection to read connectionstring from app settings file
        private readonly IConfiguration _configuration;
        public EmployeeController(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        [HttpGet]
        public JsonResult Get()
        {
            string query = @"
                            select EmployeeID as id, EmployeeName, EmployeeDOB, EmployeeSex, SuperId,BranchId from
                            dbo.Employee
                            ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("DefaultConnectionString");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult(table);

        }


        [HttpGet("{id}")]
        public JsonResult GetById(int id)
        {
            string query = @"
                            select EmployeeID, EmployeeName, EmployeeDOB, EmployeeSex, SuperId,BranchId from
                            dbo.Employee where EmployeeID=@EmployeeID
                            ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("DefaultConnectionString");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@EmployeeID", id);

                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult(table);
        }

        [HttpPost]
        public JsonResult Post(Employee employee)
        {
            string query = @"
                           insert into dbo.Employee
                           values (@EmployeeName, @EmployeeDOB, @EmployeeSex, @SuperId, @BranchId)
                            ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("DefaultConnectionString");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@EmployeeName", employee.EmployeeName);
                    myCommand.Parameters.AddWithValue("@EmployeeDOB", employee.EmployeeDOB);
                    myCommand.Parameters.AddWithValue("@EmployeeSex", employee.EmployeeSex);
                    myCommand.Parameters.AddWithValue("@SuperId", employee.SuperId);
                    myCommand.Parameters.AddWithValue("@BranchId", employee.BranchId);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult("New Employee Added");
        }

        [HttpPost("{id}")]
        public JsonResult Update(Employee employee, int id)
        {
            string query = @"
                           update dbo.Employee
                           set EmployeeName= @EmployeeName,
                               EmployeeDOB= @EmployeeDOB,
                               EmployeeSex= @EmployeeSex,
                               SuperId=@SuperId,
                               BranchId=@BranchId
                            where EmployeeID=@EmployeeID
                            ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("DefaultConnectionString");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@EmployeeID", id);
                    myCommand.Parameters.AddWithValue("@EmployeeName", employee.EmployeeName);
                    myCommand.Parameters.AddWithValue("@EmployeeDOB", employee.EmployeeDOB);
                    myCommand.Parameters.AddWithValue("@EmployeeSex", employee.EmployeeSex);
                    myCommand.Parameters.AddWithValue("@SuperId", employee.SuperId);
                    myCommand.Parameters.AddWithValue("@BranchId", employee.BranchId);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult("Employee Information Updated");
        }

        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            string query = @"
                           delete from dbo.Employee
                            where EmployeeID=@EmployeeID
                            ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("DefaultConnectionString");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@EmployeeID", id);

                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult("Employee Deleted");
        }


    }
}