using CRUDusingEF.Data;
namespace CRUDusingEF.Models
{
    public class CategoryDAL
    {
        private readonly ApplicationDbContext db;
        public CategoryDAL(ApplicationDbContext db)
        {
            this.db = db;
        }
        public IEnumerable<Category> GetAllcategories()
        {
            return db.Categories.ToList();
        }
        public Category GetCategoryById(int id)
        {
            var cate = db.Categories.Find(id);
            return cate;
        }
        public int AddCategory(Category cate)
        {
            db.Categories.Add(cate);
            int result = db.SaveChanges();
            return result;
        }
        public int UpdateCategory(Category cate) // cate contains new data
        {   // c contains old data
            int result = 0;
            var c = db.Categories.Where(x => x.Id == cate.Id).FirstOrDefault();
            if (c != null)
            {
                c.Name = cate.Name;
                result = db.SaveChanges();
            }
            return result;
        }
        public int DeleteCategory(int id)
        {
            int result = 0;
            var c = db.Categories.Where(x => x.Id == id).FirstOrDefault();
            if (c != null)
            {
                db.Categories.Remove(c);
                result = db.SaveChanges();
            }
            return result;
        }
    }
}
