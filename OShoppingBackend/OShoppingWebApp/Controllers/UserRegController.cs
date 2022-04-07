using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using OShoppingWebApp.Models;



namespace OShoppingWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserRegController : ControllerBase
    {

        private readonly IConfiguration _configuration;

        public UserRegController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public JsonResult Get()
        {
            string query = @"
                    select CustomerId,CusName,CusEmail,CusMobile,CusAddress,CusPassword from dbo.Customer";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("OShoppingWebApp");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader); ;

                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult(table);
        }

        [HttpPost]
        public JsonResult Post(UserReg cus)
        {
            string query = @"
                    insert into dbo.Customer 
                    (CusName,CusEmail,CusMobile,CusAddress,CusPassword)
                    values 
                    (
                    '" + cus.CusName + @"'
                    ,'" + cus.CusEmail + @"'
                    ,'" + cus.CusMobile + @"'
                    ,'" + cus.CusAddress + @"'
                    ,'" + cus.CusPassword + @"'
                    )
                    ";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("OShoppingWebApp");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader); ;

                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult("Added Successfully");
        }

        [HttpPut]
        public JsonResult Put(UserReg cus)
        {
            string query = @"
                    update dbo.Customer set 
                    CusName = '" + cus.CusName + @"'
                    ,CusEmail = '" + cus.CusEmail + @"'
                    ,CusMobile = '" + cus.CusMobile + @"'
                    ,CusAddress = '" + cus.CusAddress + @"'
                    ,CusPassword = '" + cus.CusPassword + @"'
                    where CustomerId = " + cus.CustomerId + @" 
                    ";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("OShoppingWebApp");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader); ;

                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult("Updated Successfully");
        }

        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            string query = @"
                    delete from dbo.Customer
                    where CustomerId = " + id + @" 
                    ";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("OShoppingWebApp");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader); ;

                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult("Deleted Successfully");
        }


    }
}
