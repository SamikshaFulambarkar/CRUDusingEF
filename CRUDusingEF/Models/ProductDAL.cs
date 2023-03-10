using CRUDusingEF.Data;

namespace CRUDusingEF.Models
{
    public class ProductDAL
    {
        private readonly ApplicationDbContext db;
        public ProductDAL(ApplicationDbContext db) 
        {
            this.db = db;
        }
        public IEnumerable<Product> GetAllProducts() 
        {
            return db.Products.ToList();
        }
        public Product GetProductById(int id) 
        {
            var prod = db.Products.Find(id);
            return prod;
        }
        public int AddProduct(Product prod) 
        {
            db.Products.Add(prod);
            int result=db.SaveChanges();
            return result;
        }
        public int UpdateProduct(Product prod) // prod contains new data
        {   // p contains old data
            int result = 0;
            var p=db.Products.Where(x=>x.Id==prod.Id).FirstOrDefault();
            if (p != null) 
            {
                p.Name= prod.Name;
                p.Price= prod.Price;
                p.Company= prod.Company;
                result=db.SaveChanges();
            }
            return result;
        }
        public int DeleteProduct(int id) 
        {
            int result = 0;
            var p = db.Products.Where(x => x.Id == id).FirstOrDefault();
            if (p != null) 
            {
                db.Products.Remove(p);
                result=db.SaveChanges();
            }
            return result;
        }
    }
}
