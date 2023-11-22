using DataAccessLayer.Entities;
using DataAccessLayer.Readers;
using System.Collections.ObjectModel;

namespace DataAccessLayer
{
    internal static class Program
    {
        private static void Main()
        {
            ProductReader reader = new();
            Collection<Product> products = reader.Execute();
            foreach (Product p in products)
            {
                Console.WriteLine(string.Format("{0}: {1}",
                    p.ProductId,
                    p.ProductName));
            }
        }
    }
}
