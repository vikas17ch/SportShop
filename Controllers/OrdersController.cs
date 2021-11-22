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
    public class OrdersController : ApiController
    {
        public HttpResponseMessage Get()
        {
            DataTable table = new DataTable();

            string query = @"
                         select order_date,order_number,Item_Number,Customer_Number from Orders;

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
        public string Post(Orders or)
        {
            try
            {
                DataTable table = new DataTable();

                string query = @"
                         insert into Orders values ('" + or.order_date + @"',
                                                     '" + or.Item_Number + @"',
                                                     '" + or.Customer_Number + @"')
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
            catch (Exception ex)
            {

                return "Failed to Add"+ex;
            }
        }
        public string Put(Orders or)
        {
            try
            {
                DataTable table = new DataTable();

                string query = @"
                  update dbo.Orders set order_date = '" + or.order_date + @"'
                        where order_number = " + or.order_number + @"
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
                  delete from dbo.Orders where order_number = " + id;

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