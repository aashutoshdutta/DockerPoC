using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Data;
using System.Web;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

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

           string res= getStudydata(opencon);
                                 
            return res;

        }

        private string getStudydata(SqlConnection opencon)
        {
           
            SqlCommand cmd = new SqlCommand("select * from Project", opencon);

            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable dt = new DataTable();
            DataSet ds = new DataSet();
            da.Fill(dt);
                        
            List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
            Dictionary<string, object> row;
            foreach (DataRow dr in dt.Rows)
            {
                row = new Dictionary<string, object>();
                foreach (DataColumn col in dt.Columns)
                {
                    row.Add(col.ColumnName, dr[col]);
                }
                rows.Add(row);
            }
            return JsonConvert.SerializeObject(rows);






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
            //  string conString = @"Data Source=(localdb)\ProjectsV13;Initial Catalog = DBSource; Integrated Security = True; Connect Timeout = 30; Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            string conString = @"Server=tcp:azureprojectdbserver.database.windows.net,1433;Initial Catalog=azureprojectdb;Persist Security Info=False;User ID=azureadmin;Password=WindowsAdmin1234;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
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

