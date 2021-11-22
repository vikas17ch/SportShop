using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using SportShop.Models;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


namespace SportShop.Controllers
{
    public class CustomerController : ApiController
    {
        public HttpResponseMessage Get()
        {
            DataTable table = new DataTable();

            string query = @"
                          select Customer_Name,Customer_Number,Contact_Number,Address,Email_Id from Customer;
                          ";

            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["Management"].ConnectionString))
            using (var cmd = new SqlCommand(query, con))
            using (var da = new SqlDataAdapter(cmd))
            {
                cmd.CommandType = CommandType.Text;
                da.Fill(table);
            }

            return Request.CreateResponse(HttpStatusCode.OK, table);
        }
        public string Post(Customer ct)
        {
            try
            {
                DataTable table = new DataTable();

                string query = @"
                         insert into Customer values ('" + ct.Customer_Name + @"',
                                                      '" + ct.Contact_Number + @"',
                                                      '" + ct.Address + @"',
                                                      '" + ct.Email_Id + @"')
                          ";

                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["Management"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    da.Fill(table);
                }

                return "Added Successfully";
            }
            catch (Exception)
            {

                return "Failed to Add";
            }
        }
        public string Put(Customer ct)
        {
            try
            {
                DataTable table = new DataTable();

                string query = @"
                  update dbo.Customer set Customer_Name = '" + ct.Customer_Name + @"'
                        where Customer_Number = " + ct.Customer_Number + @"
                          ";

                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["Management"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    da.Fill(table);
                }

                return "Updated Successfully";
            }
            catch (Exception)
            {

                return "Failed to Update";
            }
        }

        public string Delete(int id)
        {
            try
            {
                DataTable table = new DataTable();

                string query = @"
                  delete from dbo.Customer where Customer_Number = " + id;

                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["Management"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    da.Fill(table);
                }

                return "Deleted Successfully";
            }
            catch (Exception)
            {

                return "Failed to delete";
            }
        }

    }
}