using Microsoft.AspNetCore.Mvc;
using Bernardino3ITE.Models;
using Bernardino3ITE.Data;
using Bernardino3ITE.Services;

namespace Bernardino3ITE.Controllers
{
    public class StudentController : Controller
    {
        private readonly AppDBContext _dbContext;

        public StudentController(AppDBContext dBContext)
        {
            _dbContext = dBContext;
        }

        public IActionResult Index()
        {

            return View(_dbContext.Students);
        }

        public IActionResult ShowDetails(int id)
        {
            //Search for the student whose id matches the given id
            Student? student = _dbContext.Students.FirstOrDefault(st => st.Id == id);

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
            _dbContext.Students.Add(newStudent);
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Student? student = _dbContext.Students.FirstOrDefault(st => st.Id == id);

            if (student != null)//was an student found?
                return View(student);

            return NotFound();
        }
        [HttpPost]
        public IActionResult Edit(Student studentChange)
        {
            Student? student = _dbContext.Students.FirstOrDefault(st => st.Id == studentChange.Id);

            if (student != null)
            {
                student.LastName = studentChange.LastName;
                student.FirstName = studentChange.FirstName;
                student.Course = studentChange.Course;
                student.AdmissionDate = studentChange.AdmissionDate;
                student.Email = studentChange.Email;
                _dbContext.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult DeleteStudent(int id)
        {
            Student? student = _dbContext.Students.FirstOrDefault(st => st.Id == id);
            if (student != null)
                return View(student);

            return NotFound();
        }

        [HttpPost]
        public IActionResult deleteStudent(int id)
        {
            Student? student = _dbContext.Students.FirstOrDefault(st => st.Id == id);

            if (student != null)
            {
                _dbContext.Students.Remove(student);
                _dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return NotFound();
        }
    }
}