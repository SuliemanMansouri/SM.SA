using SM.SA.Domain.Entities;
using SM.SA.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.SA.Services
{
    public class StudentServiceDesign : IStudentService
    {
        public void DeleteStudent(Student student)
        {

        }

        public Student FindStudent(string name)
        {
            return new Student
            {
                Id = -1000,
                Name = "Demo Name1",
                DOB = DateTime.Now
            };
        }

        public List<Student> GetAllStudents()
        {
            return new List<Student>
           {
                new Student
                {
                    Id = -1000,
                    Name = "Demo Name1",
                    DOB = DateTime.Now
                },
                new Student
                {
                    Id = -2000,
                    Name = "Demo Name2",
                    DOB = DateTime.Now
                },
                new Student
                {
                    Id = -3000,
                    Name = "Demo Name3",
                    DOB = DateTime.Now
                },
                new Student
                {
                    Id = -4000,
                    Name = "Demo Name4",
                    DOB = DateTime.Now
                }
            };
        }

        public void SaveStudent(Student student)
        {
            
        }
    }
}
