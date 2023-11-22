using System.Data;

namespace DataAccessLayer
{
    class PersonMapper : MapperBase<Product>
    {
        protected override Product Map(IDataRecord record)
        {
            try
            {
                Product product = new Product();
                product.ProductId = (DBNull.Value == record["ProductId"]) ?
                    0 : (int)record["ProductId"];
                product.ProductName = (DBNull.Value == record["ProductName"]) ?
                    string.Empty : (string)record["ProductName"];

                return product;
            }
            catch
            {
                throw;
                // NOTE:  
                // consider handling exeption here instead of re-throwing  
                // if graceful recovery can be accomplished  
            }
        }
    }
}
