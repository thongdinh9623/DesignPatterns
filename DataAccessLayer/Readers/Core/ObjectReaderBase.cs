using DataAccessLayer.Mappers.Core;
using System.Collections.ObjectModel;
using System.Data;

namespace DataAccessLayer.Readers.Core
{
    public abstract class ObjectReaderBase<T>
    {
        protected virtual string? CommandText { get; }

        protected virtual CommandType CommandType { get; }

        protected abstract IDbConnection GetConnection();

        protected abstract Collection<IDataParameter> GetParameters(IDbCommand command);

        protected abstract MapperBase<T> GetMapper();

        public virtual Collection<T> Execute()
        {
            _ = new Collection<T>();
            using IDbConnection connection = GetConnection();
            IDbCommand command = connection.CreateCommand();
            command.Connection = connection;
            command.CommandText = CommandText;
            command.CommandType = CommandType;
            foreach (IDataParameter param in GetParameters(command))
            {
                _ = command.Parameters.Add(param);
            }
            try
            {
                connection.Open();
                using IDataReader reader = command.ExecuteReader();
                try
                {
                    MapperBase<T> mapper = GetMapper();
                    Collection<T> collection = mapper.MapAll(reader);

                    return collection;
                }
                finally
                {
                    reader.Close();
                }
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
