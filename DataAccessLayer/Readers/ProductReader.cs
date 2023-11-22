using DataAccessLayer.Entities;
using DataAccessLayer.Mappers;
using DataAccessLayer.Mappers.Core;
using DataAccessLayer.Readers.Core;
using System.Collections.ObjectModel;
using System.Data;

namespace DataAccessLayer.Readers
{
    internal class ProductReader : ObjectReaderWithSqlServerConnection<Product>
    {
        protected override string CommandText =>
            "SELECT ProductId, ProductName " +
            "FROM Products";

        protected override CommandType CommandType => CommandType.Text;

        protected override Collection<IDataParameter> GetParameters(IDbCommand command)
        {
            Collection<IDataParameter> collection = new();

            // OPTIONAL: Add parameters

            return collection;

        }

        protected override MapperBase<Product> GetMapper()
        {
            MapperBase<Product> mapper = new ProductMapper();

            return mapper;
        }
    }
}
