using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class DBProvider:SqlParam
    {
       

        //-- code to get a connection object
        public static SqlConnection GetConnection()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            return con;
        }

        public static void DisposeConnection(SqlConnection con)
        {
            if (con.State == System.Data.ConnectionState.Open)
            {
                con.Close();
            }
            con.Dispose();
        }
        public DataSet ExecuteDataset(string spName)
        {
            SqlConnection con = GetConnection();
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter dataAdapter;
            DataSet ds = new DataSet();
            List<SqlParam> parameters = new List<SqlParam>();
            parameters = base.sqlParameters;
            try
            { 
                cmd.Connection = con;
                cmd.CommandText = spName;
                cmd.CommandType = CommandType.StoredProcedure;
                if (parameters != null)
                {

                    foreach (SqlParam parameter in parameters)
                    {

                        SqlParameter spParameter = new SqlParameter();
                        spParameter.ParameterName = parameter.ParamererName;
                        switch (parameter.ParamererType)
                        {
                            case "String":
                                spParameter.Value = parameter.ParameterValueString;
                                spParameter.SqlDbType = SqlDbType.VarChar;
                                break;
                            case "Int":
                                spParameter.Value = parameter.ParameterValueInt;
                                spParameter.SqlDbType = SqlDbType.Int;
                                break;
                        }
                        cmd.Parameters.Add(spParameter);
                    }
                }
                dataAdapter = new SqlDataAdapter(cmd);
                dataAdapter.Fill(ds);
            }
            catch(Exception ex)
            {

            }
            finally
            {
                DisposeConnection(con);
            }

            return ds;
        }

        public int ExcuteStoredProcedure(string spName)
        {
            SqlConnection con = GetConnection();
            SqlCommand cmd = new SqlCommand();
            int rowCount = 0;
            List<SqlParam> parameters = new List<SqlParam>();
            parameters = base.sqlParameters;

            try
            {
                cmd.Connection = con;
                cmd.CommandText = spName;
                cmd.CommandType = CommandType.StoredProcedure;
                if (parameters != null)
                {
                    foreach (SqlParam parameter in parameters)
                    {
                        if(parameter.ParamererType == "Int")
                        {
                            cmd.Parameters.Add(new SqlParameter(parameter.ParamererName, parameter.ParameterValueInt));
                        }
                        else if(parameter.ParamererType == "String")
                        { 
                            cmd.Parameters.Add(new SqlParameter(parameter.ParamererName, parameter.ParameterValueString));
                        }
                    }
                }
                rowCount = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                DisposeConnection(con);
            }

            return rowCount;
        }

        public DataSet ExecuteQuery(string query)
        {
            SqlConnection con = GetConnection();
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter dataAdapter;
            DataSet ds = new DataSet();
            List<SqlParam> parameters = new List<SqlParam>();
            parameters = base.sqlParameters;
            try
            {
                cmd.Connection = con;
                cmd.CommandText = query;
                cmd.CommandType = CommandType.Text;
                if (parameters != null)
                {

                    foreach (SqlParam parameter in parameters)
                    {

                        SqlParameter spParameter = new SqlParameter();
                        spParameter.ParameterName = parameter.ParamererName;
                        switch (parameter.ParamererType)
                        {
                            case "String":
                                spParameter.Value = parameter.ParameterValueString;
                                spParameter.SqlDbType = SqlDbType.Int;
                                break;
                            case "Int":
                                spParameter.Value = parameter.ParameterValueInt;
                                spParameter.SqlDbType = SqlDbType.VarChar;
                                break;
                        }
                        cmd.Parameters.Add(spParameter);
                    }
                }
                dataAdapter = new SqlDataAdapter(cmd);
                dataAdapter.Fill(ds);
            }
            catch (Exception ex)
            {

            }
            finally
            {
                DisposeConnection(con);
            }

            return ds;
        }

    }
    

}
