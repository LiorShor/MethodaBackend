using System;
using System.Data;

namespace DALContracts
{
    public interface IDAL
    {
        void ExecuteNonQuery(string i_SpName, params IParameter[] i_Parameters);
        DataSet ExecuteQuery(string i_SpName, params IParameter[] i_Parameters);
        IParameter CreateParameter(string i_ParamName, object i_Value);
    }
}
