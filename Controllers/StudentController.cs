using Microsoft.AspNetCore.Mvc;
using Bernardino3ITE.Models;
using Bernardino3ITE.Services;

namespace Bernardino3ITE.Controllers
{
    public class StudentController : Controller
    {
        private readonly IMyFakeDataService _fakeData;

        public StudentController(IMyFakeDataService fakeData)
        {
            _fakeData = fakeData;
        }

        public IActionResult Index()
        {

            return View(_fakeData.StudentList);
        }

        public IActionResult ShowDetails(int id)
        {
            //Search for the student whose id matches the given id
            Student? student = _fakeData.StudentList.FirstOrDefault(st => st.Id == id);

            if (student != null)//was an student found?
                return View(student);

            return NotFound();
        }

        [HttpGet]
        public IActionResult AddStudent()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddStudent(Student newStudent)
        {
            _fakeData.StudentList.Add(newStudent);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Student? student = _fakeData.StudentList.FirstOrDefault(st => st.Id == id);

            if (student != null)//was an student found?
                return View(student);

            return NotFound();
        }
        [HttpPost]
        public IActionResult Edit(Student studentChange)
        {
            Student? student = _fakeData.StudentList.FirstOrDefault(st => st.Id == studentChange.Id);

            if (student != null)
            {
                student.LastName = studentChange.LastName;
                student.FirstName = studentChange.FirstName;
                student.Course = studentChange.Course;
                student.AdmissionDate = studentChange.AdmissionDate;
                student.Email = studentChange.Email;
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult DeleteStudent(int id)
        {
            Student? student = _fakeData.StudentList.FirstOrDefault(st => st.Id == id);
            if (student != null)
                return View(student);

            return NotFound();
        }
        
        [HttpPost]
        public IActionResult deleteStudent (int id)
        {
            Student? student = _fakeData.StudentList.FirstOrDefault(st => st.Id == id);

            if (student != null)
            {
                _fakeData.StudentList.Remove(student);
                return RedirectToAction("Index");
            }
            return NotFound();
        }
    }      
}