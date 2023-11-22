using System.Collections.ObjectModel;
using System.Data;

namespace DataAccessLayer.Mappers.Core
{
    public abstract class MapperBase<T>
    {
        protected abstract T Map(IDataRecord record);

        public Collection<T> MapAll(IDataReader reader)
        {
            Collection<T> collection = new();
            while (reader.Read())
            {
                collection.Add(Map(reader));
            }

            return collection;
        }
    }
}
