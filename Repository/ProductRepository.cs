namespace Repository
{
    public class ProductRepository :
        Repository<Product>,
        IProductRepository
    {
        private readonly ApplicationDbContext _db;

        public ProductRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public async Task<Product> UpdateAsync(Product entity)
        {
            _ = _db.Products.Update(entity);
            _ = await _db.SaveChangesAsync();

            return entity;
        }
    }
}
