﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data;

namespace SportShop.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        public HttpResponseMessage Get()
        {

            DataTable dt = new DataTable();
            dt.Columns.Add("Item_Name");
            dt.Columns.Add("Item_Number");
            dt.Columns.Add("Item_Value");
            dt.Columns.Add("color");
            dt.Columns.Add("Size");

            dt.Rows.Add("Bat", 1, 25000, "Grey", 44);

            return Request.CreateResponse(HttpStatusCode.OK, dt);
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
