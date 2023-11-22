using System.Data;
using DataAccessLayer.Entities;
using DataAccessLayer.Mappers.Core;

namespace DataAccessLayer.Mappers
{
    public class ProductMapper : MapperBase<Product>
    {
        protected override Product Map(IDataRecord record)
        {
            Product product = new()
            {
                ProductId = (int)record["ProductId"],
                ProductName = DBNull.Value == record["ProductName"] ?
                    string.Empty : (string)record["ProductName"]
            };

            return product;
        }
    }
}
