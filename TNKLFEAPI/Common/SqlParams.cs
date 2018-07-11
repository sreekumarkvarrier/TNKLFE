using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class SqlParam
    {
        public List<SqlParam> sqlParameters = new List<SqlParam>();
        
        public SqlParam(string paramererName,string parameterValue)
        {
            if(paramererName!=String.Empty)
            { 
                ParamererName =  '@'+paramererName;
                if(parameterValue == String.Empty)
                {
                    ParameterValueString = null;
                }
                ParameterValueString = parameterValue;
                ParamererType = "String";
            }
        }
        public SqlParam(string paramererName, int parameterValue)
        {
            if (paramererName != String.Empty)
            {
                ParamererName = '@' + paramererName;
                ParameterValueInt = parameterValue;
                ParamererType = "Int";
            }
        }
        public SqlParam()
        {
           
        }
        public string ParamererName { get; set; }
        public string ParamererType { get; set; }
        public string ParameterValueString { get; set; }
        public int ParameterValueInt { get; set; }
        public string ProcedureName { get; set; }
        public void AddParam(string parameter,string value)
        {
            SqlParam sqlParam = new SqlParam(parameter, value);
            sqlParameters.Add(sqlParam);
        }
        public void AddParam(string parameter, int value)
        {
            SqlParam sqlParam = new SqlParam(parameter, value);
            sqlParameters.Add(sqlParam);
        }

    }

}
