using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Core.GlobalRepository.SQL.Process;
using Crosscutting.Common.Tools.ExcelGenerator;

namespace DataAccess.ProcessModule.Repository
{
    public class ReportRepository : IReportRepository
    {
        public ReportDto GetReportTransactional(DateTime startdate, DateTime enddate)
        {
            var returned = new ReportDto();

            var cnx =
                new SqlConnection(ConfigurationManager.ConnectionStrings["ProcessModelEntities"].ConnectionString);
            var cmd = new SqlCommand();

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "GetBill";
            cmd.Connection = cnx;

            var p1 = new SqlParameter
            {
                ParameterName = "StartDate",
                Value = startdate,
                DbType = DbType.DateTime
            };


            var p2 = new SqlParameter
            {
                ParameterName = "EndDate",
                Value = enddate,
                DbType = DbType.DateTime
            };

            cmd.Parameters.Add(p1);
            cmd.Parameters.Add(p2);


            var dt = new SqlDataAdapter(cmd);


            var dataSet = new DataSet();
            cnx.Open();
            dt.Fill(dataSet);
            var ddata = new List<Dictionary<string, string>>();
            if (dataSet.Tables.Count > 0)
            {
                var converter = dataSet.Tables[0];
                var dataColumnCollection = converter.Columns;
                foreach (DataRow row in converter.Rows)
                {
                    var x = new Dictionary<string, string>();
                    foreach (DataColumn column in dataColumnCollection)
                        x.Add(column.ColumnName, row[column.ColumnName].ToString());
                    ddata.Add(x);
                }
            }

            cnx.Close();
            cnx.Dispose();
            returned.ReportData = ddata;

            return returned;
        }
    }
}