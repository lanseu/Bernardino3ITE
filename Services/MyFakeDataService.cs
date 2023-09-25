using System;
using Bernardino3ITE.Services;
using Bernardino3ITE.Models;
using System.Collections.Generic;

namespace Bernardino3ITE.Services
{
    public class MyFakeDataService : IMyFakeDataService
    {
        public MyFakeDataService() 
        {
            StudentList = new List<Student>
            {
                new Student()
                {
                    Id= 1,FirstName = "Gabriel",LastName = "Montano", Course = Course.BSIT, AdmissionDate = DateTime.Parse("2022-08-26"), GPA = 1.5, Email = "ghaby021@gmail.com"
                },
                new Student()
                {
                    Id= 2,FirstName = "Zyx",LastName = "Montano", Course = Course.BSIS, AdmissionDate = DateTime.Parse("2022-08-07"), GPA = 1, Email = "zyx@gmail.com"
                },
                new Student()
                {
                    Id= 3,FirstName = "Aerdriel",LastName = "Montano", Course = Course.BSCS, AdmissionDate = DateTime.Parse("2020-01-25"), GPA = 1.5, Email = "aerdriel@gmail.com"
                }
            };
            InstructorList = new List<Instructor>
            {
                new Instructor()
                {
                    Id=1, FirstName ="Aria", LastName ="Stormrider", HiringDate = new DateTime(2020, 03, 20), IsTenured = true, Rank = Rank.Instructor
                },
                new Instructor()
                {
                    Id=2, FirstName ="John", LastName ="Smith", HiringDate = new DateTime(2021, 04, 30), IsTenured = false, Rank = Rank.AssociateProfessor
                }
            };
        }
        public List<Student> StudentList { get; }
        public List<Instructor> InstructorList { get; }
    }
}
