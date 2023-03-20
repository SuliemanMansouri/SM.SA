using SM.SA.Domain.Entities;
using SM.SA.Infrastructure.Context;
using SM.SA.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace SM.SA.Services
{
    public class StudentService : IStudentService
    {
        private readonly SAContext _db;
        public StudentService()
        {
            _db = new SAContext();
        }

        public StudentService(SAContext db)
        {
            _db = db;
        }

        public void DeleteStudent(Student student)
        {
            var tmp = _db.Students.FirstOrDefault(x => x.Id == student.Id);
            if (tmp != null)
            {
                _db.Students.Remove(tmp);
                _db.SaveChanges();
            }
        }

        public Student FindStudent(string name)
        {
            var tmp = _db.Students.FirstOrDefault(x => x.Name.Contains(name));
            if (tmp != null)
            {
                return tmp;
            }
            else
            {
                return null;
            }
        }

        public List<Student> GetAllStudents()
        {
            return _db.Students.ToList();
        }

        public void SaveStudent(Student student)
        {
            var tmp = _db.Students.FirstOrDefault(x => x.Id == student.Id);
            if (tmp != null)
            {
                tmp.Name = student.Name;
                tmp.DOB = student.DOB;
            }
            else
            {
                _db.Students.Add(student);
            }

            _db.SaveChanges();

        }
    }
}
