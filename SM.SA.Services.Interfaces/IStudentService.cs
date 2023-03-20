using SM.SA.Domain.Entities;
using System.Collections.Generic;

namespace SM.SA.Services.Interfaces
{
    public interface IStudentService
    {
        Student FindStudent(string name);
        void SaveStudent(Student student);
        void DeleteStudent(Student student);
        List<Student> GetAllStudents();
        

    }
}
