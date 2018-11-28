using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Data;

namespace StudyService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public string Get()
        {
            //return new string[] { "value1", "value2" };

          SqlConnection opencon =  connectDB();

            getStudydata(opencon);
                                 
            return "gaurav kumar";

        }

        private void getStudydata(SqlConnection opencon)
        {
           
            SqlCommand cmd = new SqlCommand("select * from Study", opencon);

            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;

            DataSet ds = new DataSet();
            da.Fill(ds);






            //using (SqlDataReader oReader = cmd.ExecuteReader())
            //{
            //    while (oReader.Read())
            //    {
            //        //study = oReader["FirstName"].ToString();
            //        //matchingPerson.lastName = oReader["LastName"].ToString();
            //    }

            //    opencon.Close();
            //}

            opencon.Close();
        }

        private SqlConnection connectDB()
        {
            string conString = @"Data Source=(localdb)\ProjectsV13;Initial Catalog = DBSource; Integrated Security = True; Connect Timeout = 30; Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = conString;

            try
            {
                conn.Open();
            }

            catch

            {
                Exception ex;
            }

            return conn;
        }





    }

    
    
}

