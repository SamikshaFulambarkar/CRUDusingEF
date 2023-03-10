using CRUDusingEF.Data;
using CRUDusingEF.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRUDusingEF.Controllers
{
    public class StudentController : Controller
    {
        private readonly ApplicationDbContext db;
        StudentDAL studentDAL;

        public StudentController(ApplicationDbContext db)
        {
            this.db = db;
            studentDAL = new StudentDAL(this.db);
        }
        // GET: StudentController
        public ActionResult Index()
        {
            var list = studentDAL.GetAllstudents();
            return View(list);
        }

        // GET: StudentController/Details/5
        public ActionResult Details(int id)
        {
            var st = studentDAL.GetStudentById(id);
            return View(st);
        }

        // GET: StudentController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StudentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Student st)
        {
            try
            {
                int result = studentDAL.AddStudent(st);
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

        // GET: StudentController/Edit/5
        [HttpGet]
        public ActionResult Edit(int id)
        {
            try
            {
                var st = studentDAL.GetStudentById(id);
                return View(st);
            }
            catch
            {
                return View();
            }
        }

        // POST: StudentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Student st)
        {
            try
            {
                int result = studentDAL.UpdateStudent(st);
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

        // GET: StudentController/Delete/5
        public ActionResult Delete(int id)
        {
            var st = studentDAL.GetStudentById(id);
            return View(st);
        }

        // POST: ProductController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public ActionResult DeletePost(int id)
        {
            try
            {
                int result = studentDAL.DeleteStudent(id);
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
