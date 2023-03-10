using CRUDusingEF.Data;

namespace CRUDusingEF.Models
{
    public class StudentDAL
    {
        private readonly ApplicationDbContext db;
        public StudentDAL(ApplicationDbContext db)
        {
            this.db = db;
        }
        public IEnumerable<Student> GetAllstudents()
        {
            return db.Students.ToList();
        }
        public Student GetStudentById(int id)
        {
            var st = db.Students.Find(id);
            return st;
        }
        public int AddStudent(Student st)
        {
            db.Students.Add(st);
            int result = db.SaveChanges();
            return result;
        }
        public int UpdateStudent(Student st) // st contains new data
        {   // s contains old data
            int result = 0;
            var s = db.Students.Where(x => x.Id == st.Id).FirstOrDefault();
            if (s != null)
            {
                s.Name = st.Name;
                s.Course = st.Course;
                result = db.SaveChanges();
            }
            return result;
        }
        public int DeleteStudent(int id)
        {
            int result = 0;
            var s = db.Students.Where(x => x.Id == id).FirstOrDefault();
            if (s != null)
            {
                db.Students.Remove(s);
                result = db.SaveChanges();
            }
            return result;
        }
    }
}
