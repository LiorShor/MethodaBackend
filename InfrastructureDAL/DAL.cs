using DALContracts;
using System;
using System.Data.SqlClient;
using System.Data;
using Microsoft.Extensions.Options;
using Config;

namespace InfrastructureDAL
{
    public class DAL : IDAL
    {
        string m_ConnetionString;
        public DAL(IOptions<ConfigOptions> i_Settings)
        {
            m_ConnetionString = i_Settings.Value.ConnectionString;
        }
        private SqlCommand getCommand(string i_SpName, params IParameter[] i_Parameters)
        {
            var con = new SqlConnection(m_ConnetionString);
            con.Open();
            SqlCommand commandSP = new SqlCommand();
            commandSP.CommandText = i_SpName;
            commandSP.CommandType = CommandType.StoredProcedure;
            foreach (var parameter in i_Parameters)
            {
                var paramAdapter = parameter as SqlParameterAdapter;
                commandSP.Parameters.Add(paramAdapter.Parameter);
            }

            commandSP.Connection = con;
            return commandSP;
        }

        public IParameter CreateParameter(string i_ParamName, object i_Value)
        {
            var retval = new SqlParameterAdapter();
            retval.Parameter = new SqlParameter(i_ParamName, i_Value);
            return retval as IParameter;
        }

        public DataSet ExecuteQuery(string i_SpName, params IParameter[] i_Parameters)
        {
            DataSet dataSet = new DataSet();
            var commandSP = getCommand(i_SpName, i_Parameters);
            SqlDataAdapter dataAdapter = new SqlDataAdapter(commandSP);
            dataAdapter.Fill(dataSet);
            commandSP.Connection.Close();
            return dataSet;
        }
        public void ExecuteNonQuery(string i_SpName, params IParameter[] i_Parameters)
        {
            var commandSP = getCommand(i_SpName, i_Parameters);
            commandSP.ExecuteNonQuery();

            commandSP.Connection.Close();
        }
    }
}
