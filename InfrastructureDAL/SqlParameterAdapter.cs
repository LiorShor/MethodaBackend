using DALContracts;
using System.Data.SqlClient;

namespace InfrastructureDAL
{
    class SqlParameterAdapter : IParameter
    {
        public SqlParameter Parameter  { get; set; }
    }
}
