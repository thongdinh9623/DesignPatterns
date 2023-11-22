using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayer.Readers.Core
{
    public abstract class ObjectReaderWithSqlServerConnection<T> : ObjectReaderBase<T>
    {
        private const string ConnectionString = @"
            Data Source=.;
            Initial Catalog=DALDemo;
            Integrated Security=True";
        private static readonly string _connectionString =
             ObjectReaderWithSqlServerConnection<T>.ConnectionString;

        protected override IDbConnection GetConnection()
        {
            IDbConnection connection = new SqlConnection(_connectionString);
            return connection;
        }
    }
}
