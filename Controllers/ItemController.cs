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
    public class ItemController : ApiController
    {
        
            public HttpResponseMessage Get()
            {
                DataTable table = new DataTable();

                string query = @"
                          select Item_Name,Item_Number , Item_value , Color , Size from Item;
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
        public string Post(Item it)
        {
            try
            {
                DataTable table = new DataTable();

                string query = @"
                         insert into Item values ('" + it.Item_Name + @"',
                                                      '" + it.Item_value + @"',
                                                      '" + it.Color + @"',
                                                      '" + it.Size + @"')
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
        public string Put(Item it)
        {
            try
            {
                DataTable table = new DataTable();

                string query = @"
                  update dbo.Item set Item_Name = '" + it.Item_Name + @"'
                        where Item_Number = " + it.Item_Number + @"
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
                  delete from dbo.Item where Item_Number = " + id;

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