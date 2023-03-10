using CRUDusingEF.Data;
using CRUDusingEF.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRUDusingEF.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext db;
        CategoryDAL categoryDAL;

        public CategoryController(ApplicationDbContext db)
        {
            this.db = db;
            categoryDAL = new CategoryDAL(this.db);
        }
        // GET: CategorytController
        public ActionResult Index()
        {
            var list = categoryDAL.GetAllcategories();
            return View(list);
        }

        // GET: CategoryController/Details/5
        public ActionResult Details(int id)
        {
            var cate = categoryDAL.GetCategoryById(id);
            return View(cate);
        }

        // GET: CategoryController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CategoryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Category cate)
        {
            try
            {
                int result = categoryDAL.AddCategory(cate);
                if (result == 1)
                    return RedirectToAction(nameof(Index));
                else
                    return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: CategoryController/Edit/5
        [HttpGet]
        public ActionResult Edit(int id)
        {
            try
            {
                var cate = categoryDAL.GetCategoryById(id);
                return View(cate);
            }
            catch
            {
                return View();
            }
        }

        // POST: CategoryController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Category cate)
        {
            try
            {
                int result = categoryDAL.UpdateCategory(cate);
                if (result == 1)
                    return RedirectToAction(nameof(Index));
                else
                    return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: CategoryController/Delete/5
        public ActionResult Delete(int id)
        {
            var cate = categoryDAL.GetCategoryById(id);
            return View(cate);
        }

        // POST: CategoryController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public ActionResult DeletePost(int id)
        {
            try
            {
                int result = categoryDAL.DeleteCategory(id);
                if (result == 1)
                    return RedirectToAction(nameof(Index));
                else
                    return View();
            }
            catch
            {
                return View();
            }
        }
    }
}
