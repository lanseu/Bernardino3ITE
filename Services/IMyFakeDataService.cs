using System;
using Bernardino3ITE.Models;
namespace Bernardino3ITE.Services
{
    public interface IMyFakeDataService
    {
        List<Student> StudentList { get; }
        List<Instructor> InstructorList { get; }
    }
}
