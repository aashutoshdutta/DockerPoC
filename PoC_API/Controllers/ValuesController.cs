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
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;

namespace StudyService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values in API
        [HttpGet]
        public string Get()
        {
            //return new string[] { "value1", "value2" };

            // SqlConnection opencon =  connectDB();

            OracleConnection opencon = connectDBOnprem();

            string res = getFDRdata(opencon);

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




            opencon.Close();

            //using (SqlDataReader oReader = cmd.ExecuteReader())
            //{
            //    while (oReader.Read())
            //    {
            //        //study = oReader["FirstName"].ToString();
            //        //matchingPerson.lastName = oReader["LastName"].ToString();
            //    }

            //    opencon.Close();
            //}


        }

        private string getFDRdata(OracleConnection opencon)
        {

            OracleCommand cmd = new OracleCommand("select GL_ACCOUNT,COSTCENTER from GL_LINE_ITEM_CERPS_L where COMP_CODE = 'GB09' and COSTCENTER is not null and ROWNUM <50", opencon);

            OracleDataAdapter da = new OracleDataAdapter();
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


        }

        private SqlConnection connectDB()
        {
            //  string conString = @"Data Source=(localdb)\ProjectsV13;Initial Catalog = DBSource; Integrated Security = True; Connect Timeout = 30; Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            string conString = @"Server=tcp:azureprojectdbserver.database.windows.net,1433;Initial Catalog=azureprojectdb;Persist Security Info=False;User ID=azureadmin;Password=WindowsAdmin1234;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            //string conStringOr= "Pooling=false;User Id=Maher;Password=oracle;Data Source=localhost:1521/mydatabase;"
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

        private OracleConnection connectDBOnprem()
        {
            string conStringOr = @"Data Source=us1sdoel004.corpnet2.com:1521/USTST008.world;User Id=CERPS_FDR_STAGE;Password=C3rpsFdrT$t;Connection Timeout=30";

            OracleConnection conn = new OracleConnection();
            conn.ConnectionString = conStringOr;

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

        //Check for APP Service



    }



}

